using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Indicadores.Planificacion.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetAll;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Queries.GetAll;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Areas.Planificacion.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{

    [Area("Planificacion")]
    public class ProyectoITTController : BaseController<ProyectoITTController>
    {
        private readonly CommonMethods _commonMethods;

        public ProyectoITTController()
        {
            _commonMethods = new CommonMethods();
        }

        public IActionResult Index()
        {
            var entidadViewModel = new ProyectoITTViewModel();
            //await SetDropDownList(entidadViewModel);
            return View(entidadViewModel);
        }

        public async Task<JsonResult> Cargarcombos()
        {
            var response = await _mediator.Send(new GetAllFaseProgramaAreaQuery() { Include = true });
            var listadistinct = ((List<FaseProgramaAreaResponse>)(response.Data))
                .Select(x => new { idpt = x.ProyectoTecnico.Id, nombreproyecto = x.ProyectoTecnico.NombreProyecto, idpa = x.ProgramaArea.Id, nombreprograma = x.ProgramaArea.Descripcion, idfase = x.IdFaseProyecto, fase = x.FaseProyecto.Nombre }).ToList();

            return Json(listadistinct);
        }

        [HttpGet]
        public async Task<IActionResult> LoadAll(int idpt, int idpa)
        {
            List<ProyectoITTViewModel> viewModels = new List<ProyectoITTViewModel>();

            var fpa = new FaseProgramaAreaResponse()
            {
                IdProyectoTecnico = idpt,
                IdProgramaArea = idpa
            };

            var response = await _mediator.Send(new GetAllProyectoITTQuery { Include = true, FaseProgramaArea = fpa });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<ProyectoITTViewModel>>(response.Data);

            foreach (var item in viewModels)
            {
                var modelfp = ((List<ProyectoITTResponse>)response.Data).Where(x => x.Id == item.Id).FirstOrDefault();
                item.FaseProgramaAreaViewModel = _mapper.Map<FaseProgramaAreaViewModel>(modelfp.FaseProgramaArea);
            }

            return PartialView("_ViewAll", viewModels);
        }


        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new ProyectoITTViewModel
                {
                    //FechaInicio = DateTime.Now,
                    //FechaFin = DateTime.Now,
                    //FechaDisenio = DateTime.Now,
                    //FechaRedisenio = DateTime.Now,
                    //FechaTransicion = DateTime.Now,
                };
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetProyectoITTByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<ProyectoITTViewModel>(response.Data);
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar ProyectoITT.", ex.Message);
            }
        }



        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(ProyectoITTViewModel viewmodel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (viewmodel.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateProyectoITTCommand>(viewmodel);
                    //createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"ProyectoITT con ID {result.Data} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateProyectoITTCommand>(viewmodel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"ProyectoITT con ID {result.Data} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                var response = await _mediator.Send(new GetAllProyectoITTQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ProyectoITTViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar ProyectoITT", result);
            }
        }



        public async Task<JsonResult> OnInsumos(int id = 0)
        {
            try
            {
                var entidadViewModel = new ProyectoITTViewModel();
                //{
                //    //FechaInicio = DateTime.Now,
                //    //FechaFin = DateTime.Now,
                //    //FechaDisenio = DateTime.Now,
                //    //FechaRedisenio = DateTime.Now,
                //    //FechaTransicion = DateTime.Now,
                //};
                //if (id == 0)
                //{
                //    await SetDropDownList(entidadViewModel);
                //    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                //}
                //else
                //{
                //    var response = await _mediator.Send(new GetProyectoITTByIdQuery() { Id = id });
                //    if (response.Succeeded)
                //    {
                //        entidadViewModel = _mapper.Map<ProyectoITTViewModel>(response.Data);
                //        await SetDropDownList(entidadViewModel);
                //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                //    }
                //    return new JsonResult(new
                //    {
                //        isValid = false
                //    });
                //}
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_Insumos", entidadViewModel) });
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnInsumos Error al consultar ProyectoITT.", ex.Message);
            }
        }


        [HttpPost]
        public async Task<JsonResult> OnInsumos(ProyectoITTViewModel viewmodel)
        {
            var entidadViewModel = new ProyectoITTViewModel();
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_Insumos", entidadViewModel) });
        }

        private async Task SetDropDownList(ProyectoITTViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;

            /*todo: ver el estado activo*/
            var response = await _mediator.Send(new GetAllFaseProgramaAreaQuery() { Include = true });
            var listadistinct = ((List<FaseProgramaAreaResponse>)(response.Data))
                .Select(x => new { idpt = x.ProyectoTecnico.Id, nombreproyecto = x.ProyectoTecnico.NombreProyecto, idpa = x.ProgramaArea.Id, nombreprograma = x.ProgramaArea.Descripcion, idfase = x.IdFaseProyecto, fase = x.FaseProyecto.Nombre }).ToList();

            // ViewBag.ListTecnicos = (await _agenciarepository.GetListTecnicos(0, 0)).Select(x => new SelectListItem { Text = x.FullName, Value = x.Id });
            var distinpy = listadistinct.Select(x => new { x.idpt, x.nombreproyecto }).Distinct().ToList();


            List<SelectListItem> items = new SelectList(distinpy, "idpt", "nombreproyecto").ToList();

            items.Insert(0, (new SelectListItem
            {
                Text = "Selecionar",
                Value = "0",
                Selected = true
            }));


            entidadViewModel.ProyectoTecnicoList = new SelectList(items, "Value", "Text");

            SelectListItem selListItem = new SelectListItem() { Value = "0", Text = "Seleccionar" };
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(selListItem);

            entidadViewModel.ProgramaAreaList = new SelectList(newList, "Value", "Text"); ;
        }
    }



}
