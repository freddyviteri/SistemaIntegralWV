using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Commands.Update;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Queries.GetAll;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Queries.GetAll;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Indicadores.Controllers
{
    [Area("Indicadores")]
    [Authorize]
    public class OtroIndicadorPadreHijoController : BaseController<OtroIndicadorPadreHijoController>
    {
        private readonly CommonMethods _commonMethods;

        public OtroIndicadorPadreHijoController()
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
            List<OtroIndicadorPadreHijoViewModel> viewModels = new List<OtroIndicadorPadreHijoViewModel>();
            var response = await _mediator.Send(new GetAllOtroIndicadorPadreHijoQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<OtroIndicadorPadreHijoViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new OtroIndicadorPadreHijoViewModel();

                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetOtroIndicadorPadreHijoByIdQuery() { Id = id, Include = true });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<OtroIndicadorPadreHijoViewModel>(response.Data);

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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar OtroIndicadorPadreHijo.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(OtroIndicadorPadreHijoViewModel OtroIndicadorPadreHijoViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (OtroIndicadorPadreHijoViewModel.Id == 0)
                {
                    var otroIndicadorPadreHijoCrearMultiple = OtroIndicadorPadreHijoViewModel.IdOtrosIndicadoresHijos.Select(i => new OtroIndicadorPadreHijoViewModel { IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo, IdPadre = OtroIndicadorPadreHijoViewModel.IdPadre, IdHijo = i });

                    var createEntidadCommand = _mapper.Map<CreateMultipleOtroIndicadorPadreHijoCommand>(otroIndicadorPadreHijoCrearMultiple);
                    var result = await _mediator.Send(createEntidadCommand);
                    var resultsSucceeded = result.Where(r => r.Succeeded).Count();
                    if (resultsSucceeded == result.Count)
                        _notify.Success($"OtroIndicadorPadreHijo con ID {string.Join(" ,", result.Select(r => r.Data.ToString()))} Creado.");
                    else return _commonMethods.SaveError(string.Join(" ,", result.Where(r => r.Message != null)));
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateOtroIndicadorPadreHijoCommand>(OtroIndicadorPadreHijoViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"OtroIndicadorPadreHijo con ID {result.Data} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                var response = await _mediator.Send(new GetAllOtroIndicadorPadreHijoQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<OtroIndicadorPadreHijoViewModel>>(response.Data);
                    //var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar OtroIndicadorPadreHijo", result);
            }
        }
        [HttpGet]
        public async Task<IActionResult> SearchOtrosIndicadoresPadre(int idTipoIndicadorPadre)
        {
            ViewBag.OtroIndicadorPadreList = await GetOtrosIndicadoresSelect(idTipoIndicadorPadre);
            return PartialView("_ViewIndicadorPadre");
        }

        [HttpGet]
        public async Task<IActionResult> SearchTipoIndicadorHijo(int idTipoIndicadorPadre)
        {
            ViewBag.TipoIndicadorHijoList = await GetTipoIndicadorSelect(idTipoIndicadorPadre, true);
            return PartialView("_ViewTipoIndicadorHijo");
        }

        [HttpGet]
        public async Task<IActionResult> SearchTodosOtrosIndicadores()
        {
            ViewBag.OtroIndicadorCompleteList = await GetOtrosIndicadoresSelect();
            return PartialView("_ViewOtrosIndicadoresDNone");
        }

        [HttpGet]
        public async Task<IActionResult> SearchOtrosIndicadoresHijo(int idTipoIndicadorHijo)
        {
            ViewBag.OtroIndicadorHijoList = await GetOtrosIndicadoresList(idTipoIndicadorHijo);
            return PartialView("_ViewListaOtrosIndicadores");
        }

        [HttpGet]
        public async Task<IActionResult> SearchOtrosIndicadoresHijo2(int idTipoIndicadorHijo)
        {
            ViewBag.OtroIndicadorHijoList = await GetOtrosIndicadoresSelect(idTipoIndicadorHijo);
            return PartialView("_ViewIndicadorHijo");
        }


        private async Task SetDropDownList(OtroIndicadorPadreHijoViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            entidadViewModel.EstadoList = await GetEstadoSelect(isNew);
            entidadViewModel.TipoIndicadorPadreList = await GetTipoIndicadorSelect(0,isNew);
        }
        private async Task<SelectList> GetEstadoSelect(bool isNew = false)
        {
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            List<GetListByIdDetalleResponse> estados = estado.Data;
            estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
            if (isNew) estados = estados.Where(e => e.Estado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            return _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
        }
        private async Task<SelectList> GetTipoIndicadorSelect(int idTipoIndicador = 0, bool isNew = false, string valueField = "IdTipoIndicadorPadre")
        {
            var tipoIndicador = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoTipoIndicador });
            List<GetListByIdDetalleResponse> tipoIndicadores = tipoIndicador.Data;
            if (isNew) tipoIndicadores = tipoIndicadores.Where(e => e.Estado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            if (idTipoIndicador != 0) tipoIndicadores = tipoIndicadores.Where(e => e.Id != idTipoIndicador).ToList();
            return _commonMethods.SetGenericCatalogWithoutIdLabel(tipoIndicadores, valueField);
        }
        private async Task<SelectList> GetOtrosIndicadoresSelect(int idTipoIndicador = 0, bool isNew = false, string valueFiel = "IdPadre")
        {
            List<OtroIndicadorViewModel> otrosIndicadores = await GetOtrosIndicadoresList(idTipoIndicador, isNew);
            return _commonMethods.SetGenericCatalog(otrosIndicadores, valueFiel);
        }
        private async Task<List<OtroIndicadorViewModel>> GetOtrosIndicadoresList(int idTipoIndicador = 0, bool isNew = false)
        {
            var otroIndicador = await _mediator.Send(new GetAllOtroIndicadorQuery { Include = true });
            List<OtroIndicadorViewModel> otrosIndicadores = _mapper.Map<List<OtroIndicadorViewModel>>(otroIndicador.Data);

            if (isNew) otrosIndicadores = otrosIndicadores.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            if (idTipoIndicador != 0) otrosIndicadores = otrosIndicadores.Where(e => e.IdTipoIndicador == idTipoIndicador).ToList();
            return otrosIndicadores;
        }

    }
}
