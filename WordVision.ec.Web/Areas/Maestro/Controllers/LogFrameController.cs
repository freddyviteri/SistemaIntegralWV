using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Create;
using WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Delete;
using WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Update;
using WordVision.ec.Application.Features.Maestro.LogFrame.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.LogFrame.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetAll;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class LogFrameController : BaseController<LogFrameController>
    {
        private readonly CommonMethods _commonMethods;

        public LogFrameController()
        {
            _commonMethods = new CommonMethods();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoadAll()
        {
            List<LogFrameViewModel> viewModels = new List<LogFrameViewModel>();
            var response = await _mediator.Send(new GetAllLogFrameQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<LogFrameViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new LogFrameViewModel();
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetLogFrameByIdQuery() { Id = id, Include = true });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<LogFrameViewModel>(response.Data);
                        await SetDropDownList(entidadViewModel);
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                    }
                    return new JsonResult(new
                    {
                        isValid = false
                    });
                }
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar LogFrame.", ex.Message);                
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(LogFrameViewModel logFrameViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (logFrameViewModel.Id == 0)
                {                    
                    var createEntidadCommand = _mapper.Map<CreateLogFrameCommand>(logFrameViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"LogFrame con ID {result.Data} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    if(logFrameViewModel.IdNivel != CatalogoConstant.IdCatalogoNivelActivity)
                    {
                        logFrameViewModel.IdTipoActividad = null;
                        logFrameViewModel.IdSectorProgramatico = null;
                        logFrameViewModel.IdRubro = null;
                    }

                    var updateEntidadCommand = _mapper.Map<UpdateLogFrameCommand>(logFrameViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"LogFrame con ID {result.Data} Actualizado.");
                    else _notify.Error(result.Message);
                }
                var response = await _mediator.Send(new GetAllLogFrameQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<LogFrameViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar LogFrame", result);
            }
        }

        [HttpDelete]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            _commonMethods.SetProperties(_notify, _logger);
            var deleteCommand = await _mediator.Send(new DeleteLogFrameCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"El registro de LogFrame fue eliminado");
                var response = await _mediator.Send(new GetAllLogFrameQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<LogFrameViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);

            }
            else
            {
                return _commonMethods.SaveError(deleteCommand.Message);
            }
        }

        private async Task SetDropDownList(LogFrameViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var nivel = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoNivel });
            var rubro = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoRubro });
            var sector = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoSectorProgrematico });
            var tipoActividad = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoTipoActividad });
            var proyecto = await _mediator.Send(new GetAllProyectoTecnicoQuery());
            //var indicador = await _mediator.Send(new GetAllIndicadorPRQuery());

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<GetListByIdDetalleResponse> niveles = nivel.Data;
            List<GetListByIdDetalleResponse> rubros = rubro.Data;
            List<GetListByIdDetalleResponse> sectores = sector.Data;
            List<GetListByIdDetalleResponse> tipoActividades = tipoActividad.Data;
            List<ProyectoTecnicoViewModel> proyectos = _mapper.Map<List<ProyectoTecnicoViewModel>>(proyecto.Data);
            //List<IndicadorPRViewModel> indicadores = _mapper.Map<List<IndicadorPRViewModel>>(indicador.Data);

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                niveles = niveles.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                rubros = rubros.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                sectores = sectores.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                tipoActividades = tipoActividades.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                proyectos = proyectos.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
                //indicadores = indicadores.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalogWithoutIdLabel(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.NivelList = _commonMethods.SetGenericCatalogWithoutIdLabel(niveles, CatalogoConstant.FieldNivel);
            entidadViewModel.RubroList = _commonMethods.SetGenericCatalog(rubros, CatalogoConstant.FieldRubro);
            entidadViewModel.TipoActividadList = _commonMethods.SetGenericCatalogWithoutIdLabel(tipoActividades, CatalogoConstant.FieldTipoActividad);
            entidadViewModel.SectorProgramaticoList = _commonMethods.SetGenericCatalog(sectores, CatalogoConstant.FieldSectorProgrematico);
            entidadViewModel.ProyectoTecnicoList = _commonMethods.SetGenericCatalog(proyectos, CatalogoConstant.FieldProyectoTecnico);
            //entidadViewModel.IndicadorPRList = _commonMethods.SetGenericCatalog(indicadores, CatalogoConstant.FieldIndicadorPR);
            //List<LogFrameIndicadorPRViewModel> list= new List<LogFrameIndicadorPRViewModel>();
            //foreach(var item in indicadores)
            //{
            //    bool selected = false;
            //    if (entidadViewModel.LogFrameIndicadores != null)
            //        if (entidadViewModel.LogFrameIndicadores.Where(l => l.IdIndicadorPR == item.Id).Count() > 0)
            //            selected = true;
            //    list.Add(new LogFrameIndicadorPRViewModel
            //    {
            //        IdIndicadorPR = item.Id,
            //        IdLogFrame = entidadViewModel.Id,
            //        Selected = selected,
            //        CodigoIndicador = item.Codigo,
            //        DescripcionIndicador = item.Descripcion
            //    });
            //}
            //entidadViewModel.LogFrameIndicadores = list;
        }
    }
}
