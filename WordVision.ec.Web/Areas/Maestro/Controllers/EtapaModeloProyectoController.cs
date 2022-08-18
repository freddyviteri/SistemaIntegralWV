using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Delete;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class EtapaModeloProyectoController : BaseController<EtapaModeloProyectoController>
    {
        private readonly CommonMethods _commonMethods;
        public EtapaModeloProyectoController()
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
            List<EtapaModeloProyectoViewModel> viewModels = new List<EtapaModeloProyectoViewModel>();
            var response = await _mediator.Send(new GetAllEtapaModeloProyectoQuery { Include = true});
            if (response.Succeeded)
                viewModels = _mapper.Map<List<EtapaModeloProyectoViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new EtapaModeloProyectoViewModel();
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetEtapaModeloProyectoByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<EtapaModeloProyectoViewModel>(response.Data);
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
              return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar Etapa Modelo Proyecto.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(EtapaModeloProyectoViewModel EtapaModeloProyectoViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (EtapaModeloProyectoViewModel.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateEtapaModeloProyectoCommand>(EtapaModeloProyectoViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"Etapa Modelo Proyecto con ID {result.Data} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateEtapaModeloProyectoCommand>(EtapaModeloProyectoViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Etapa Modelo Proyecto con ID {result.Data} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                var response = await _mediator.Send(new GetAllEtapaModeloProyectoQuery {Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EtapaModeloProyectoViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar la Etapa Model Proyecto", result);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateMultiple(EtapaModeloProyectoMultipleViewModel EtapaModeloProyectoMultipleViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                var contErrores = 0;
                var msgAcum = "";
                foreach (var etapa in EtapaModeloProyectoMultipleViewModel.ListaAcciones)
                {
                    EtapaModeloProyectoViewModel dc = new EtapaModeloProyectoViewModel();
                    dc.Etapa = EtapaModeloProyectoMultipleViewModel.Etapa;
                    dc.IdAccionOperativa = etapa.Id;

                    var createEntidadCommand = _mapper.Map<CreateEtapaModeloProyectoCommand>(dc);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Failed)
                    {
                        contErrores++;
                        msgAcum = $"{result.Message}; ";
                    }
                }

                if (contErrores == 0)
                {
                    _notify.Success($"Etapa Modelo Proyecto fue Creado.");
                    var response = await _mediator.Send(new GetAllEtapaModeloProyectoQuery { Include = true });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<EtapaModeloProyectoViewModel>>(response.Data);
                        var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);

                        await LoadAll();

                        return new JsonResult(new { isValid = true, html = html });
                    }
                    else
                        return _commonMethods.SaveError(response.Message);
                }
                else return _commonMethods.SaveError($"Una o más de las acciones operativas seleccionadas no fuero creadas: {msgAcum}");
                
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar la Etapa Modelo Proyecto", result);
            }
        }

            [HttpDelete]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            _commonMethods.SetProperties(_notify, _logger);
            var deleteCommand = await _mediator.Send(new DeleteEtapaModeloProyectoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"El registro de EtapaModeloProyecto fue eliminado");
                var response = await _mediator.Send(new GetAllEtapaModeloProyectoQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EtapaModeloProyectoViewModel>>(response.Data);
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

        private async Task SetDropDownList(EtapaModeloProyectoViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var acccion = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoAccionOperativa });

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<GetListByIdDetalleResponse> acciones = acccion.Data;

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                acciones = acciones.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalogWithoutIdLabel(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.AccionOperativaList = _commonMethods.SetGenericCatalogWithoutIdLabel(acciones, CatalogoConstant.FieldAccionOperativa);
        }
    }   
}
