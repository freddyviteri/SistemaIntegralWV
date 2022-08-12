using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Commands.Delete;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Delete;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Delete;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Commands.Delete;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class ModeloProyectoEtapaAccionController : BaseController<ModeloProyectoEtapaAccionController>
    {
        private readonly CommonMethods _commonMethods;
        public ModeloProyectoEtapaAccionController()
        {
            _commonMethods = new CommonMethods();
        }

        public async Task<IActionResult> Index()
        {
            ModeloProyectoEtapaAccionViewModel model = new ModeloProyectoEtapaAccionViewModel();
            await SetDropDownModeloProyectoEtapaAccionList(model);
            return await Task.FromResult(View(model));
        }




        [HttpGet]
        public async Task<IActionResult> LoadAccionOperativaAll()
        {
            List<AccionOperativaViewModel> viewModels = new List<AccionOperativaViewModel>();
            var response = await _mediator.Send(new GetAllAccionOperativaQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<AccionOperativaViewModel>>(response.Data);

            return PartialView("_ViewAccionOperativaAll", viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> LoadEtapaAll()
        {
            List<EtapaViewModel> viewModels = new List<EtapaViewModel>();
            var response = await _mediator.Send(new GetAllEtapaQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<EtapaViewModel>>(response.Data);

            return PartialView("_ViewEtapaAll", viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> LoadModeloProyectoAll()
        {
            List<ModeloProyectoViewModel> viewModels = new List<ModeloProyectoViewModel>();
            var response = await _mediator.Send(new GetAllModeloProyectoQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<ModeloProyectoViewModel>>(response.Data);

            return PartialView("_ViewModeloProyectoAll", viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> LoadModeloProyectoEtapaAccionAll(int? idmp, int? idetapa)
        {
            List<ModeloProyectoEtapaAccionViewModel> viewModels = new List<ModeloProyectoEtapaAccionViewModel>();
            var response = await _mediator.Send(new GetAllModeloProyectoEtapaAccionQuery { Include = true, IdModeloProyecto = idmp, IdEtapa = idetapa });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<ModeloProyectoEtapaAccionViewModel>>(response.Data);


            // var movies = viewModels.OrderBy(c => c.IdModeloProyecto).ThenBy(n => n.IdEtapa);
            return PartialView("_ViewModeloProyectoEtapaAccionAll", viewModels);
        }

        public async Task<JsonResult> OnGetAccionOperativaCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new AccionOperativaViewModel();
                if (id == 0)
                {
                    await SetDropDownAccionOperativaList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_AccionOperativaCreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetAccionOperativaByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<AccionOperativaViewModel>(response.Data);
                        await SetDropDownAccionOperativaList(entidadViewModel);
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_AccionOperativaCreateOrEdit", entidadViewModel) });
                    }
                    return new JsonResult(new
                    {
                        isValid = false
                    });
                }
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnGetAccionOperativaCreateOrEdit Error al consultar Accion Operativa.", ex.Message);
            }
        }

        public async Task<JsonResult> OnGetEtapaCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new EtapaViewModel();
                if (id == 0)
                {
                    await SetDropDownEtapaList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_EtapaCreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetEtapaByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<EtapaViewModel>(response.Data);
                        await SetDropDownEtapaList(entidadViewModel);
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_EtapaCreateOrEdit", entidadViewModel) });
                    }
                    return new JsonResult(new
                    {
                        isValid = false
                    });
                }
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnGetEtapaCreateOrEdit Error al consultar Etapas.", ex.Message);
            }
        }

        public async Task<JsonResult> OnGetModeloProyectoCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new ModeloProyectoViewModel();
                if (id == 0)
                {
                    await SetDropDownModeloProyectoList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ModeloProyectoCreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetModeloProyectoByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<ModeloProyectoViewModel>(response.Data);
                        await SetDropDownModeloProyectoList(entidadViewModel);
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ModeloProyectoCreateOrEdit", entidadViewModel) });
                    }
                    return new JsonResult(new
                    {
                        isValid = false
                    });
                }
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnGetModeloProyectoCreateOrEdit Error al consultar Modelo Proyecto.", ex.Message);
            }
        }


        public async Task<JsonResult> OnGetModeloProyectoEtapaAccionCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new ModeloProyectoEtapaAccionViewModel();
                //if (id == 0)
                //{
                await SetDropDownModeloProyectoEtapaAccionList(entidadViewModel);

                //entidadViewModel.codigosao = "";
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ModeloProyectoEtapaAccionCreateOrEdit", entidadViewModel) });
                //}
                //else
                //{
                //    var response = await _mediator.Send(new GetModeloProyectoEtapaAccionByIdQuery() { Id = id });
                //    if (response.Succeeded)
                //    {
                //        entidadViewModel = _mapper.Map<ModeloProyectoEtapaAccionViewModel>(response.Data);
                //        await SetDropDownModeloProyectoEtapaAccionList(entidadViewModel);
                //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ModeloProyectoEtapaAccionCreateOrEdit", entidadViewModel) });
                //    }
                //    return new JsonResult(new
                //    {
                //        isValid = false
                //    });
                //}
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnGetModeloProyectoEtapaAccionCreateOrEdit Error al consultar Modelo Proyecto Etapa Accion.", ex.Message);
            }
        }



        [HttpPost]
        public async Task<JsonResult> OnPostAccionOperativaCreateOrEdit(AccionOperativaViewModel model)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateAccionOperativaCommand>(model);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                    {
                        model.Id = result.Data;
                        _notify.Success($"Accion Operativa con ID {result.Data} Creado.");
                    }
                    else _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateAccionOperativaCommand>(model);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Accion Operativa con ID {result.Data} Actualizado.");
                    else _commonMethods.SaveError(result.Message);
                }

                //var response = await _mediator.Send(new GetAllAccionOperativaQuery { Include = true });
                //if (response.Succeeded)
                //{
                //    // var listviewModel = _mapper.Map<List<AccionOperativaViewModel>>(response.Data);
                //    //  return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAccionOperativaAll", listviewModel) });
                return new JsonResult(new { isValid = true });
                //}
                //else
                //    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar la Accion Operativa", result);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostEtapaCreateOrEdit(EtapaViewModel model)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateEtapaCommand>(model);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                    {
                        model.Id = result.Data;
                        _notify.Success($"Etapa con ID {result.Data} Creado.");
                    }
                    else _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateEtapaCommand>(model);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Etapa con ID {result.Data} Actualizado.");
                    else _commonMethods.SaveError(result.Message);
                }

                return new JsonResult(new { isValid = true });

                //var response = await _mediator.Send(new GetAllEtapaQuery { Include = true });
                //if (response.Succeeded)
                //{
                //    var viewModel = _mapper.Map<List<EtapaViewModel>>(response.Data);
                //    var html = await _viewRenderer.RenderViewToStringAsync("_ViewEtapaAll", viewModel);
                //    return new JsonResult(new { isValid = true, html = html });
                //}
                //else
                //    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar la Etapa", result);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostModeloProyectoCreateOrEdit(ModeloProyectoViewModel model)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateModeloProyectoCommand>(model);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                    {
                        model.Id = result.Data;
                        _notify.Success($"Modelo Proyecto con ID {result.Data} Creado.");
                    }
                    else _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateModeloProyectoCommand>(model);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Modelo Proyecto con ID {result.Data} Actualizado.");
                    else _commonMethods.SaveError(result.Message);
                }

                return new JsonResult(new { isValid = true });

                //var response = await _mediator.Send(new GetAllModeloProyectoQuery { Include = true });
                //if (response.Succeeded)
                //{
                //    var viewModel = _mapper.Map<List<ModeloProyectoViewModel>>(response.Data);
                //    var html = await _viewRenderer.RenderViewToStringAsync("_ViewModeloProyectoAll", viewModel);
                //    return new JsonResult(new { isValid = true, html = html });
                //}
                //else
                //    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar la Modelo Proyecto", result);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostModeloProyectoEtapaAccionCreateOrEdit(ModeloProyectoEtapaAccionViewModel model)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {

                string[] words = model.codigosao.Split(',');
                var createEntidadCommand = _mapper.Map<CreateModeloProyectoEtapaAccionCommand>(model);
                createEntidadCommand.ListModeloProyectoEtapaAccionResponse = new List<ModeloProyectoEtapaAccionResponse>();
                createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                foreach (var word in words)
                {
                    var r = _mapper.Map<ModeloProyectoEtapaAccionResponse>(model);
                    r.IdAccionOperativa = int.Parse(word);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    createEntidadCommand.ListModeloProyectoEtapaAccionResponse.Add(r);
                }



                //if (model.Id == 0)
                //{
                //    //var createEntidadCommand = _mapper.Map<CreateModeloProyectoEtapaAccionCommand>(model);
                //    //createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                var result = await _mediator.Send(createEntidadCommand);
                if (result.Succeeded)
                {
                    model.Id = result.Data;
                    _notify.Success($"Modelo Proyecto Etapa Accion fueron creadas.");
                }
                else _commonMethods.SaveError(result.Message);
                //}
                //else
                //{
                //    //var updateEntidadCommand = _mapper.Map<UpdateModeloProyectoEtapaAccionCommand>(model);
                //    //var result = await _mediator.Send(updateEntidadCommand);
                //    //if (result.Succeeded) _notify.Information($"Modelo Proyecto Etapa Accion con ID {result.Data} Actualizado.");
                //    //else _commonMethods.SaveError(result.Message);
                //}

                //var response = await _mediator.Send(new GetAllModeloProyectoEtapaAccionQuery { Include = true });
                //if (response.Succeeded)
                //{
                //    var viewModel = _mapper.Map<List<ModeloProyectoEtapaAccionViewModel>>(response.Data);
                //    var html = await _viewRenderer.RenderViewToStringAsync("_ViewModeloProyectoEtapaAccionAll", viewModel);
                //    return new JsonResult(new { isValid = true, html = html });
                //}
                //else
                //    return _commonMethods.SaveError(response.Message);
                return new JsonResult(new { isValid = true });
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar la Modelo Proyecto Etapa Accion", result);
            }
        }



        [HttpDelete]
        public async Task<JsonResult> OnPostAccionOperativaDelete(int id)
        {
            _commonMethods.SetProperties(_notify, _logger);
            var deleteCommand = await _mediator.Send(new DeleteAccionOperativaCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"El registro de Accion Operativa fue eliminado");
                var response = await _mediator.Send(new GetAllAccionOperativaQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<AccionOperativaViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAccionOperativaAll", viewModel);
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

        [HttpDelete]
        public async Task<JsonResult> OnPostEtapaDelete(int id)
        {
            _commonMethods.SetProperties(_notify, _logger);
            var deleteCommand = await _mediator.Send(new DeleteEtapaCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"El registro de Etapa fue eliminado");
                var response = await _mediator.Send(new GetAllEtapaQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EtapaViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewEtapaAll", viewModel);
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

        [HttpDelete]
        public async Task<JsonResult> OnPostModeloProyectoDelete(int id)
        {
            _commonMethods.SetProperties(_notify, _logger);
            var deleteCommand = await _mediator.Send(new DeleteModeloProyectoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"El registro de Modelo Proyecto fue eliminado");
                var response = await _mediator.Send(new GetAllModeloProyectoQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ModeloProyectoViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewModeloProyectoAll", viewModel);
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


        [HttpDelete]
        public async Task<JsonResult> OnPostModeloProyectoEtapaAccionDelete(int id)
        {
            _commonMethods.SetProperties(_notify, _logger);
            var deleteCommand = await _mediator.Send(new DeleteModeloProyectoEtapaAccionCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"El registro de Modelo Proyecto Etapa Accion fue eliminado");
                var response = await _mediator.Send(new GetAllModeloProyectoEtapaAccionQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ModeloProyectoEtapaAccionViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewModeloProyectoEtapaAccionAll", viewModel);
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

        private async Task SetDropDownEtapaList(EtapaViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });

            List<GetListByIdDetalleResponse> estados = estado.Data;

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalogWithoutIdLabel(estados, CatalogoConstant.FieldEstado);

        }

        private async Task SetDropDownAccionOperativaList(AccionOperativaViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });

            List<GetListByIdDetalleResponse> estados = estado.Data;

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalogWithoutIdLabel(estados, CatalogoConstant.FieldEstado);

        }


        private async Task SetDropDownModeloProyectoList(ModeloProyectoViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });

            List<GetListByIdDetalleResponse> estados = estado.Data;

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalogWithoutIdLabel(estados, CatalogoConstant.FieldEstado);

        }

        private async Task SetDropDownModeloProyectoEtapaAccionList(ModeloProyectoEtapaAccionViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;

            var modeloproyecto = await _mediator.Send(new GetAllModeloProyectoQuery { Include = false });
            var etapa = await _mediator.Send(new GetAllEtapaQuery { Include = false });
            var accioperativa = await _mediator.Send(new GetAllAccionOperativaQuery { Include = false });
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });

            List<ModeloProyectoViewModel> modelosproyectos = _mapper.Map<List<ModeloProyectoViewModel>>(modeloproyecto.Data);
            List<EtapaViewModel> etapas = _mapper.Map<List<EtapaViewModel>>(etapa.Data);
            List<AccionOperativaViewModel> accionesoperativas = _mapper.Map<List<AccionOperativaViewModel>>(accioperativa.Data);
            List<GetListByIdDetalleResponse> estados = estado.Data;

            if (isNew)
            {
                modelosproyectos = modelosproyectos.Where(e => e.IdEstado == CatalogoConstant.EstadoActivo).ToList();
                etapas = etapas.Where(e => e.IdEstado == CatalogoConstant.EstadoActivo).ToList();
                accionesoperativas = accionesoperativas.Where(e => e.IdEstado == CatalogoConstant.EstadoActivo).ToList();
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
            }

            entidadViewModel.ModeloProyectoList = _commonMethods.SetGenericCatalog(modelosproyectos, CatalogoConstant.FieldIdModeloProyecto, true);
            entidadViewModel.EtapaList = _commonMethods.SetGenericCatalog(etapas, CatalogoConstant.FieldIdEtapa, true);
            entidadViewModel.AccionoperativaList = _commonMethods.SetGenericCatalog(accionesoperativas, CatalogoConstant.FieldIdAccionOperativa);
            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalogWithoutIdLabel(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.codigosao = "";
        }

    }
}
