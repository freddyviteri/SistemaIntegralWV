using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Update;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Queries.GetAll;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.IndicadorML.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Queries.GetAll;
using WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetAll;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Areas.Planificacion.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Indicadores.Controllers
{
    [Area("Indicadores")]
    [Authorize]
    public class VinculacionIndicadorController : BaseController<VinculacionIndicadorController>
    {
        private readonly CommonMethods _commonMethods;

        public VinculacionIndicadorController()
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
            List<VinculacionIndicadorViewModel> viewModels = new List<VinculacionIndicadorViewModel>();
            var response = await _mediator.Send(new GetAllVinculacionIndicadorQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<VinculacionIndicadorViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new VinculacionIndicadorViewModel();

                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetVinculacionIndicadorByIdQuery() { Id = id, Include = true });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<VinculacionIndicadorViewModel>(response.Data);

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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar VinculacionIndicador.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(VinculacionIndicadorViewModel VinculacionIndicadorViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (VinculacionIndicadorViewModel.Id == 0)
                {
                    var vinculacionCrearMultiple = VinculacionIndicadorViewModel.IdOtrosIndicadores.Select(i => new VinculacionIndicadorViewModel { IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo, IdMarcoLogico = VinculacionIndicadorViewModel.IdMarcoLogico, IdOtroIndicador = i });

                    var createEntidadCommand = _mapper.Map<CreateMultipleVinculacionIndicadoresCommand>(vinculacionCrearMultiple);
                    var result = await _mediator.Send(createEntidadCommand);
                    var resultsSucceeded = result.Where(r=> r.Succeeded).Count();
                    if (resultsSucceeded == result.Count)
                        _notify.Success($"VinculacionIndicador con ID {string.Join(" ,", result.Select(r => r.Data.ToString()))} Creado.");
                    else return _commonMethods.SaveError(string.Join(" ,", result.Where(r => r.Message != null)));
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateVinculacionIndicadorCommand>(VinculacionIndicadorViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"VinculacionIndicador con ID {result.Data} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                var response = await _mediator.Send(new GetAllVinculacionIndicadorQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<VinculacionIndicadorViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar VinculacionIndicador", result);
            }
        }

        private async Task SetDropDownList(VinculacionIndicadorViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            //var fase = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoFaseProyecto });
            var indicadorML = await _mediator.Send(new GetAllIndicadorMLQuery());
            var otroIndicador = await _mediator.Send(new GetAllOtroIndicadorQuery { Include = true});
            var marcoLogico = await _mediator.Send(new GetAllMarcoLogicoQuery { Include = true });
            var tipoIndicador = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoTipoIndicador });

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<OtroIndicadorViewModel> otrosIndicadores = _mapper.Map<List<OtroIndicadorViewModel>>(otroIndicador.Data);
            List<IndicadorMLViewModel> indicadorMLs = _mapper.Map<List<IndicadorMLViewModel>>(indicadorML.Data);
            List<MarcoLogicoViewModel> marcosLogicos = _mapper.Map<List<MarcoLogicoViewModel>>(marcoLogico.Data);
            List<GetListByIdDetalleResponse> tipoIndicadores = tipoIndicador.Data;

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                otrosIndicadores = otrosIndicadores.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
                indicadorMLs = indicadorMLs.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
                marcosLogicos = marcosLogicos.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
                tipoIndicadores = tipoIndicadores.Where(e => e.Estado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.OtrosIndicadores = otrosIndicadores;
            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.OtroIndicadorList = _commonMethods.SetGenericCatalog(otrosIndicadores, CatalogoConstant.FieldOtroIndicador);
            entidadViewModel.IndicadorMLList = _commonMethods.SetGenericCatalog(indicadorMLs, CatalogoConstant.FieldIndicadorML);
            entidadViewModel.MarcoLogicoList = _commonMethods.SetGenericCatalog(marcosLogicos, CatalogoConstant.FieldMarcoLogico);
            entidadViewModel.TipoIndicadorList = _commonMethods.SetGenericCatalogWithoutIdLabel(tipoIndicadores, CatalogoConstant.FieldTipoIndicador);
        }
    }
}
