using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Update;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Queries.GetAll;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Queries.GetAll;
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
                    var createEntidadCommand = _mapper.Map<CreateVinculacionIndicadorCommand>(VinculacionIndicadorViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"VinculacionIndicador con ID {result.Data} Creado.");
                    else return _commonMethods.SaveError(result.Message);
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
            var indicadorPR = await _mediator.Send(new GetAllIndicadorPRQuery());
            var otroIndicador = await _mediator.Send(new GetAllOtroIndicadorQuery { Include = true});

            List<GetListByIdDetalleResponse> estados = estado.Data;
            //entidadViewModel.OtrosIndicadores = _mapper.Map<List<OtroIndicadorViewModel>>(otroIndicador.Data);
            List<OtroIndicadorViewModel> otrosIndicadores  = _mapper.Map<List<OtroIndicadorViewModel>>(otroIndicador.Data);
            List<IndicadorPRViewModel> indicadorPRs = _mapper.Map<List<IndicadorPRViewModel>>(indicadorPR.Data);

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                //otroIndicadores = otroIndicadores.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
                indicadorPRs = indicadorPRs.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
            //entidadViewModel.OtroIndicadorList = _commonMethods.SetGenericCatalog(otroIndicadores, CatalogoConstant.FieldOtroIndicador);
            entidadViewModel.IndicadorPRList = _commonMethods.SetGenericCatalog(indicadorPRs, CatalogoConstant.FieldIndicadorPR);

            List<DetalleVinculacionIndicadorViewModel> list = new List<DetalleVinculacionIndicadorViewModel>();
            foreach (var item in otrosIndicadores)
            {
                bool selected = false;
                //int idDetalle = 0;
                if (entidadViewModel.DetalleVinculacionIndicadores != null)
                //{
                    if (entidadViewModel.DetalleVinculacionIndicadores.Where(l => l.IdOtroIndicador == item.Id).Count() > 0)
                    //{
                        selected = true;
                    //    idDetalle = detalle.Id;
                    //}
                //}
                list.Add(new DetalleVinculacionIndicadorViewModel
                {
                    //Id = idDetalle,
                    IdVinculacionIndicador = entidadViewModel.Id,
                    //IdIndicadorPR = idIndicador,
                    IdOtroIndicador = item.Id,
                    OtroIndicador = item,
                    Selected = selected,
                });
            }
            entidadViewModel.DetalleVinculacionIndicadores = list;
        }
    }
}
