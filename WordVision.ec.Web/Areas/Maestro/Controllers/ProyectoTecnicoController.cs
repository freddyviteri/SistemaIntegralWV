﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Areas.Maestro.Validators;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class ProyectoTecnicoController : BaseController<ProyectoTecnicoController>
    {
        private readonly CommonMethods _commonMethods;

        public ProyectoTecnicoController()
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
            List<ProyectoTecnicoViewModel> viewModels = new List<ProyectoTecnicoViewModel>();
            var response = await _mediator.Send(new GetAllProyectoTecnicoQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<ProyectoTecnicoViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new ProyectoTecnicoViewModel();
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetProyectoTecnicoByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<ProyectoTecnicoViewModel>(response.Data);
                        await SetDropDownList(entidadViewModel);
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                    }
                    return new JsonResult(new { isValid = false });
                }
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar Proyecto Técnicos.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(ProyectoTecnicoViewModel viewmodel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            ProyectoTecnicoViewModelValidator customerValidator = new ProyectoTecnicoViewModelValidator();
            var validatorResult = customerValidator.Validate(viewmodel);

            if (validatorResult.IsValid)
            {
                if (viewmodel.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateProyectoTecnicoCommand>(viewmodel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"Proyecto Técnico con Código {createEntidadCommand.Codigo} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateProyectoTecnicoCommand>(viewmodel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Proyecto Técnico con Código {updateEntidadCommand.Codigo} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                var response = await _mediator.Send(new GetAllProyectoTecnicoQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ProyectoTecnicoViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', validatorResult.Errors.SelectMany(v => validatorResult.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar Proyecto Técnico.", result);
            }
        }

        private async Task SetDropDownList(ProyectoTecnicoViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;


            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var financiamiento = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoFinanciamiento });
            var ubicacion = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoUbicacion });
            var programaAreas = await _mediator.Send(new GetAllProgramaAreaQuery());
            var programaTecnicos = await _mediator.Send(new GetAllProgramaTecnicoQuery());


            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<GetListByIdDetalleResponse> financiamientos = financiamiento.Data;
            List<GetListByIdDetalleResponse> ubicaciones = ubicacion.Data;

            List<ProgramaAreaViewModel> programas = _mapper.Map<List<ProgramaAreaViewModel>>(programaAreas.Data);
            List<ProgramaTecnicoViewModel> proyectos = _mapper.Map<List<ProgramaTecnicoViewModel>>(programaTecnicos.Data);

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                financiamientos = financiamientos.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                ubicaciones = ubicaciones.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                programas = programas.Where(e => e.IdEstado == CatalogoConstant.EstadoActivo).ToList();
                proyectos = proyectos.Where(e => e.IdEstado == CatalogoConstant.EstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.FinanciamientoList = _commonMethods.SetGenericCatalog(financiamientos, CatalogoConstant.FieldFinanciamiento);
            entidadViewModel.UbicacionList = _commonMethods.SetGenericCatalog(ubicaciones, CatalogoConstant.FieldUbicacion);
            entidadViewModel.ProgramaAreaList = _commonMethods.SetGenericCatalog(programas, CatalogoConstant.FieldProgramaArea, true);
            entidadViewModel.ProgramaTecnicoList = _commonMethods.SetGenericCatalog(proyectos, CatalogoConstant.FieldProgramaTecnico, true);
        }
    }
}
