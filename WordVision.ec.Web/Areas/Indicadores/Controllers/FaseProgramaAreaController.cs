using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Commands.Update;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetAll;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Indicadores.Controllers
{
    [Area("Indicadores")]
    [Authorize]
    public class FaseProgramaAreaController : BaseController<FaseProgramaAreaController>
    {
        private readonly CommonMethods _commonMethods;

        public FaseProgramaAreaController()
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
            List<FaseProgramaAreaViewModel> viewModels = new List<FaseProgramaAreaViewModel>();
            var response = await _mediator.Send(new GetAllFaseProgramaAreaQuery { Include = true });
            List<FaseProgramaAreaResponse> faprresponse = new List<FaseProgramaAreaResponse>();
            if (response.Succeeded)
            {
                faprresponse = response.Data;
                // viewModels = _mapper.Map<List<FaseProgramaAreaViewModel>>(faprresponse);
            }

            var OLista = new ObservableCollection<FaseProgramaAreaViewModel>(
            faprresponse.Select(m => _mapper.Map<FaseProgramaAreaViewModel>(m)).ToList());

            viewModels = OLista.ToList();
            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new FaseProgramaAreaViewModel
                {
                    //FechaInicio = DateTime.Now,
                    //FechaFin = DateTime.Now,
                    //FechaDisenio = DateTime.Now,
                    //FechaRedisenio = DateTime.Now,
                    //FechaTransicion = DateTime.Now,
                };
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetFaseProgramaAreaByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<FaseProgramaAreaViewModel>(response.Data);
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar FaseProgramaArea.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(FaseProgramaAreaViewModel FaseProgramaAreaViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (FaseProgramaAreaViewModel.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateFaseProgramaAreaCommand>(FaseProgramaAreaViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"FaseProgramaArea con ID {result.Data} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateFaseProgramaAreaCommand>(FaseProgramaAreaViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"FaseProgramaArea con ID {result.Data} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                var response = await _mediator.Send(new GetAllFaseProgramaAreaQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<FaseProgramaAreaViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar FaseProgramaArea", result);
            }
        }

        private async Task SetDropDownList(FaseProgramaAreaViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var fase = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoFaseProyecto });
            var programaAreas = await _mediator.Send(new GetAllProgramaAreaQuery());

            var proyectoTecnicos = await _mediator.Send(new GetAllProyectoTecnicoQuery());

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<GetListByIdDetalleResponse> fases = fase.Data;
            List<ProgramaAreaViewModel> programas = _mapper.Map<List<ProgramaAreaViewModel>>(programaAreas.Data);
            List<ProyectoTecnicoViewModel> proyectos = _mapper.Map<List<ProyectoTecnicoViewModel>>(proyectoTecnicos.Data);

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                fases = fases.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                programas = programas.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
                proyectos = proyectos.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.FaseProyectoList = _commonMethods.SetGenericCatalog(fases, CatalogoConstant.FieldFaseProyecto);
            entidadViewModel.ProgramaAreaList = _commonMethods.SetGenericCatalog(programas, CatalogoConstant.FieldProgramaArea);
            entidadViewModel.ProyectoTecnicoList = _commonMethods.SetGenericCatalog(proyectos, CatalogoConstant.FieldProyectoTecnico);
        }
    }
}
