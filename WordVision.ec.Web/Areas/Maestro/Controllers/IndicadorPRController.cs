using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Commands.Create;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Commands.Update;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Commands.Delete;
using WordVision.ec.Application.Features.Maestro.ActorParticipante.Queries.GetAll;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class IndicadorPRController : BaseController<IndicadorPRController>
    {
        private readonly CommonMethods _commonMethods;

        public IndicadorPRController()
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
            List<IndicadorPRViewModel> viewModels = new List<IndicadorPRViewModel>();
            var response = await _mediator.Send(new GetAllIndicadorPRQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<IndicadorPRViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new IndicadorPRViewModel();
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetIndicadorPRByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<IndicadorPRViewModel>(response.Data);
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar IndicadorPR.", ex.Message);                
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(IndicadorPRViewModel IndicadorPRViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (IndicadorPRViewModel.Id == 0)
                {                    
                    var createEntidadCommand = _mapper.Map<CreateIndicadorPRCommand>(IndicadorPRViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"IndicadorPR con Código {createEntidadCommand.Codigo} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateIndicadorPRCommand>(IndicadorPRViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"IndicadorPR con Código {updateEntidadCommand.Codigo} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                var response = await _mediator.Send(new GetAllIndicadorPRQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<IndicadorPRViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar IndicadorPR", result);
            }
        }

        [HttpDelete]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            _commonMethods.SetProperties(_notify, _logger);
            var deleteCommand = await _mediator.Send(new DeleteIndicadorPRCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"El registro de IndicadorPR fue eliminado");
                var response = await _mediator.Send(new GetAllIndicadorPRQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<IndicadorPRViewModel>>(response.Data);
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

        private async Task SetDropDownList(IndicadorPRViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var frecuencia = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoFrecuencia });
            var tipo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoTipoMedida });
            var target = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoTarget });
            var actor = await _mediator.Send(new GetAllActorParticipanteQuery());

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<GetListByIdDetalleResponse> frecuencias = frecuencia.Data;
            List<GetListByIdDetalleResponse> tipos = tipo.Data;
            List<GetListByIdDetalleResponse> targets = target.Data;
            List<ActorParticipanteViewModel> actores = _mapper.Map<List<ActorParticipanteViewModel>>(actor.Data);


            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                frecuencias = frecuencias.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                tipos = tipos.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                targets = targets.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                actores = actores.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalogWithoutIdLabel(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.FrecuenciaList = _commonMethods.SetGenericCatalogWithoutIdLabel(frecuencias, CatalogoConstant.FieldFrecuencia);
            entidadViewModel.TipoMedidaList = _commonMethods.SetGenericCatalogWithoutIdLabel(tipos, CatalogoConstant.FieldTipoMedida);
            entidadViewModel.TargetList = _commonMethods.SetGenericCatalog(targets, CatalogoConstant.FieldTipoMedida);
            entidadViewModel.ActorParticipanteList = _commonMethods.SetGenericCatalog(actores, CatalogoConstant.FieldActorParticipante);
        }
    }
}
