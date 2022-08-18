using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetAll;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class ProgramaAreaController : BaseController<ProgramaAreaController>
    {
        private readonly CommonMethods _commonMethods;

        public ProgramaAreaController()
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
            List<ProgramaAreaViewModel> viewModels = new List<ProgramaAreaViewModel>();
            var response = await _mediator.Send(new GetAllProgramaAreaQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<ProgramaAreaViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new ProgramaAreaViewModel();
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetProgramaAreaByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<ProgramaAreaViewModel>(response.Data);
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar Programa de Área.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(ProgramaAreaViewModel ProgramaAreaViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (ProgramaAreaViewModel.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateProgramaAreaCommand>(ProgramaAreaViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                    {
                        ProgramaAreaViewModel.Id = result.Data;
                        _notify.Success($"Programa de Área con Código {createEntidadCommand.Codigo} Creado.");
                    }
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateProgramaAreaCommand>(ProgramaAreaViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Programa de Área con Código {result.Data} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                var response = await _mediator.Send(new GetAllProgramaAreaQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ProgramaAreaViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar Proyecto Técnico.", result);
            }
        }

        private async Task SetDropDownList(ProgramaAreaViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var proyecto = await _mediator.Send(new GetAllProyectoTecnicoQuery());

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<ProyectoTecnicoViewModel> proyectos = _mapper.Map<List<ProyectoTecnicoViewModel>>(proyecto.Data);
            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                proyectos = proyectos.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.ProyectoTecnicoList = _commonMethods.SetGenericCatalog(proyectos, CatalogoConstant.FieldProyectoTecnico);
        }
    }
}
