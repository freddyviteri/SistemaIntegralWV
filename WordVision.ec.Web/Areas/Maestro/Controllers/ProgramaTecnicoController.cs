using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Queries.GetById;

using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Areas.Maestro.Validators;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class ProgramaTecnicoController : BaseController<ProgramaTecnicoController>
    {
        private readonly CommonMethods _commonMethods;

        public ProgramaTecnicoController()
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
            List<ProgramaTecnicoViewModel> viewModels = new List<ProgramaTecnicoViewModel>();
            var response = await _mediator.Send(new GetAllProgramaTecnicoQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<ProgramaTecnicoViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new ProgramaTecnicoViewModel();

                ModelState.Remove<ProgramaTecnicoViewModel>(x => x.Codigo);
                ModelState.Remove("Codigo");

                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetProgramaTecnicoByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<ProgramaTecnicoViewModel>(response.Data);
                        await SetDropDownList(entidadViewModel);
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                    }
                    return new JsonResult(new { isValid = false });
                }
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar Programa Técnicos.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(ProgramaTecnicoViewModel viewmodel)
        {
            _commonMethods.SetProperties(_notify, _logger);

            if (ModelState.IsValid)
            {
                if (viewmodel.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateProgramaTecnicoCommand>(viewmodel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"Programa Técnico con Código {createEntidadCommand.Codigo} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateProgramaTecnicoCommand>(viewmodel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Programa Técnico con Código {updateEntidadCommand.Codigo} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                var response = await _mediator.Send(new GetAllProgramaTecnicoQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ProgramaTecnicoViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar Programa Técnico.", result);
            }
        }

        private async Task SetDropDownList(ProgramaTecnicoViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var tipo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoTipoProyecto });

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<GetListByIdDetalleResponse> tipos = tipo.Data;
            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                tipos = tipos.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.TipoProyectoList = _commonMethods.SetGenericCatalog(tipos, CatalogoConstant.FieldTipoProyecto);
        }
    }
}
