using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.LogFrame.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Commands.Create;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Commands.Delete;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Commands.Update;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetAll;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class LogFrameIndicadorPRController : BaseController<LogFrameIndicadorPRController>
    {
        private readonly CommonMethods _commonMethods;

        public LogFrameIndicadorPRController()
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
            List<LogFrameIndicadorPRViewModel> viewModels = new List<LogFrameIndicadorPRViewModel>();
            var response = await _mediator.Send(new GetAllLogFrameIndicadorPRQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<LogFrameIndicadorPRViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new LogFrameIndicadorPRViewModel();
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetLogFrameIndicadorPRByIdQuery() { Id = id});
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<LogFrameIndicadorPRViewModel>(response.Data);
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar LogFrameIndicadorPR.", ex.Message);                
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(LogFrameIndicadorPRViewModel LogFrameIndicadorPRViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (LogFrameIndicadorPRViewModel.Id == 0)
                {                    
                    var createEntidadCommand = _mapper.Map<CreateLogFrameIndicadorPRCommand>(LogFrameIndicadorPRViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"LogFrameIndicadorPR con ID {result.Data} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateLogFrameIndicadorPRCommand>(LogFrameIndicadorPRViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"LogFrameIndicadorPR con ID {result.Data} Actualizado.");
                    else _notify.Error(result.Message);
                }

                var response = await _mediator.Send(new GetAllLogFrameIndicadorPRQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<LogFrameIndicadorPRViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar LogFrameIndicadorPR", result);
            }
        }

        [HttpDelete]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            _commonMethods.SetProperties(_notify, _logger);
            var deleteCommand = await _mediator.Send(new DeleteLogFrameIndicadorPRCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"El registro de LogFrameIndicadorPR fue eliminado");
                var response = await _mediator.Send(new GetAllLogFrameIndicadorPRQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<LogFrameIndicadorPRViewModel>>(response.Data);
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

        private async Task SetDropDownList(LogFrameIndicadorPRViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var logframe = await _mediator.Send(new GetAllLogFrameQuery());
            var indicador = await _mediator.Send(new GetAllIndicadorPRQuery());

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<LogFrameViewModel> logFrames = _mapper.Map<List<LogFrameViewModel>>(logframe.Data);
            List<IndicadorPRViewModel> indicadores = _mapper.Map<List<IndicadorPRViewModel>>(indicador.Data);

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                logFrames = logFrames.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
                indicadores = indicadores.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.IndicadorPRList = _commonMethods.SetGenericCatalog(indicadores, CatalogoConstant.FieldIndicadorPR);
            entidadViewModel.LogFrameList = _commonMethods.SetGenericCatalogWithCode(logFrames, CatalogoConstant.FieldLogFrame);
            //entidadViewModel.IndicadorPRList = _commonMethods.SetGenericCatalog(indicadores, CatalogoConstant.FieldIndicadorPR);
            //List<LogFrameIndicadorPRIndicadorPRViewModel> list= new List<LogFrameIndicadorPRIndicadorPRViewModel>();
            //foreach(var item in indicadores)
            //{
            //    bool selected = false;
            //    if (entidadViewModel.LogFrameIndicadorPRIndicadores != null)
            //        if (entidadViewModel.LogFrameIndicadorPRIndicadores.Where(l => l.IdIndicadorPR == item.Id).Count() > 0)
            //            selected = true;
            //    list.Add(new LogFrameIndicadorPRIndicadorPRViewModel
            //    {
            //        IdIndicadorPR = item.Id,
            //        IdLogFrameIndicadorPR = entidadViewModel.Id,
            //        Selected = selected,
            //        CodigoIndicador = item.Codigo,
            //        DescripcionIndicador = item.Descripcion
            //    });
            //}
            //entidadViewModel.LogFrameIndicadorPRIndicadores = list;
        }
    }
}
