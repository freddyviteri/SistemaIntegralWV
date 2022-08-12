using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.IndicadorML.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.LogFrame.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Commands.Delete;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Commands.Create;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Commands.Update;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class MarcoLogicoController : BaseController<MarcoLogicoController>
    {
        private readonly CommonMethods _commonMethods;

        public MarcoLogicoController()
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
            List<MarcoLogicoViewModel> viewModels = new List<MarcoLogicoViewModel>();
            var response = await _mediator.Send(new GetAllMarcoLogicoQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<MarcoLogicoViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new MarcoLogicoViewModel();
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetMarcoLogicoByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<MarcoLogicoViewModel>(response.Data);
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar Marco Logico.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(MarcoLogicoViewModel MarcoLogicoViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (MarcoLogicoViewModel.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateMarcoLogicoCommand>(MarcoLogicoViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"Marco Logico con ID {result.Data} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateMarcoLogicoCommand>(MarcoLogicoViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Marco Logico con ID {result.Data} Actualizado.");
                    else _notify.Error(result.Message);
                }

                var response = await _mediator.Send(new GetAllMarcoLogicoQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<MarcoLogicoViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar Marco Logico", result);
            }
        }

        [HttpDelete]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            _commonMethods.SetProperties(_notify, _logger);
            var deleteCommand = await _mediator.Send(new DeleteMarcoLogicoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"El registro de Marco Logico fue eliminado");
                var response = await _mediator.Send(new GetAllMarcoLogicoQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<MarcoLogicoViewModel>>(response.Data);
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

        private async Task SetDropDownList(MarcoLogicoViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var logframe = await _mediator.Send(new GetAllLogFrameQuery());
            var indicador = await _mediator.Send(new GetAllIndicadorMLQuery());

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<LogFrameViewModel> logFrames = _mapper.Map<List<LogFrameViewModel>>(logframe.Data);
            List<IndicadorMLViewModel> indicadores = _mapper.Map<List<IndicadorMLViewModel>>(indicador.Data);

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                logFrames = logFrames.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
                indicadores = indicadores.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.IndicadorMLList = _commonMethods.SetGenericCatalog(indicadores, CatalogoConstant.FieldIndicadorML);
            entidadViewModel.LogFrameList = _commonMethods.SetGenericCatalogWithCode(logFrames, CatalogoConstant.FieldLogFrame);

        }
    }
}
