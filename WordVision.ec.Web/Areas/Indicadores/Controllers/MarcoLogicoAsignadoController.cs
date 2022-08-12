using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Command.Create;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Queries.GetAll;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Queries.GetProgramasTecnicosDsiponiblesQuery;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Queries.GetProyectosTecnicosDisponiblesQuery;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Queries.GetByPt;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Queries.GetAll;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllResponsablesQuery;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllSupervisoresQuery;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Areas.Registro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Indicadores.Controllers
{
    [Area("Indicadores")]
    [Authorize]
    public class MarcoLogicoAsignadoController : BaseController<MarcoLogicoAsignadoController>
    {
        private readonly CommonMethods _commonMethods;

        public MarcoLogicoAsignadoController()
        {
            _commonMethods = new CommonMethods();
        }

        public async Task<IActionResult> IndexAsync()
        {
            await SetDropDownList();
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreate(List<MarcoLogicoAsignadoViewModel> marcoLogicoAsignado)
        {
            var createEntidadCommand = _mapper.Map<CreateMarcoLogicoAsignadoCommand>(marcoLogicoAsignado);
            await _mediator.Send(createEntidadCommand);
            _notify.Success($"Datos registrados correctamente.");
            return new JsonResult(new { isValid = true });
        }

        [HttpGet]
        public async Task<IActionResult> SearchProyectoTecnico(int idProgramaArea, int idProgramaTecnico)
        {
            await SetDropDownListProyectosTecnicos(idProgramaArea, idProgramaTecnico);
            return PartialView("_ViewSelectProyectoTecnico");
        }


        [HttpGet]
        public async Task<IActionResult> SearchMarcoLogico(int idProgramaArea, int idProgramaTecnico,int idProyectoTecnico)
        {
            return PartialView("_ViewAll", await GetMarcoLogicoList(idProgramaArea, idProgramaTecnico, idProyectoTecnico));
        }


        private async Task SetDropDownList()
        {
            var programaAreas = await _mediator.Send(new GetAllProgramaAreaQuery());
            List<ProgramaAreaViewModel> programasAreas = _mapper.Map<List<ProgramaAreaViewModel>>(programaAreas.Data);

            var programaTecnicos = await _mediator.Send(new GetAllProgramaTecnicoQuery());
            List<ProgramaTecnicoViewModel> programasTecnicos = _mapper.Map<List<ProgramaTecnicoViewModel>>(programaTecnicos.Data);

          ViewBag.ProgramasAreasSelect = _commonMethods.SetGenericCatalog(programasAreas, CatalogoConstant.FieldProgramaArea);
            ViewBag.ProgramasTecnicosSelect = _commonMethods.SetGenericCatalog(programasTecnicos, CatalogoConstant.FieldProgramaTecnico);
        }

        private async Task SetDropDownListProgramasTecnicos(int idProgramaArea)
        {
            var programasTecnicos = (await _mediator.Send(new GetProgramasTecnicosDsiponiblesQuery() { IdProgramaArea = idProgramaArea }))?.Data;
            List<ProgramaTecnicoViewModel> programasTecnicosList = _mapper.Map<List<ProgramaTecnicoViewModel>>(programasTecnicos);

            ViewBag.ProgramasTecnicosSelect = _commonMethods.SetGenericCatalog(programasTecnicosList, CatalogoConstant.FieldProgramaTecnico);
        }

        private async Task SetDropDownListProyectosTecnicos(int idProgramaArea, int idProgramaTecnico)
        {
            var proyectosTecnicos = (await _mediator.Send(new GetProyectosTecnicosDisponiblesQuery() { IdProgramaArea = idProgramaArea, IdProgramaTecnico = idProgramaTecnico }))?.Data;
            List<ProyectoTecnicoViewModel> proyectosTecnicosList = _mapper.Map<List<ProyectoTecnicoViewModel>>(proyectosTecnicos);

            int idSupervisor = 0;
            var primerProyectoTecnico =proyectosTecnicosList.FirstOrDefault();
            if (primerProyectoTecnico!=null)
            {
                var marcoLogicoPtxPA = (await _mediator.Send(new GetAllMarcoLogicoAsignadoQuery() { Include = true, IdProyectoTecnico = primerProyectoTecnico.Id }))?.Data ?? new List<MarcoLogicoAsignadoResponse>();
                idSupervisor = marcoLogicoPtxPA?.FirstOrDefault()?.IdSupervisor??0;
                ViewBag.SupervisorHabilitado = idSupervisor > 0;
            }

            var supervisor = await _mediator.Send(new GetAllSupervisoresQuery());
            List<ColaboradorViewModel> supervisores = _mapper.Map<List<ColaboradorViewModel>>(supervisor.Data);
            ViewBag.SupervisoresSelect = _commonMethods.SetGenericCatalog(supervisores, CatalogoConstant.FieldSupervisor, idSupervisor);


            ViewBag.ProyectosTecnicosSelect = _commonMethods.SetGenericCatalog(proyectosTecnicosList, CatalogoConstant.FieldProyectoTecnico);
        }

        private async Task<List<MarcoLogicoAsignadoViewModel>> GetMarcoLogicoList(int idProgramaArea, int idProgramaTecnico, int idProyectoTecnico)
        {
            var marcoLogico = (await _mediator.Send(new GetMarcoLogicoByPtQuery() { Include = true, Id = idProgramaTecnico }))?.Data;
            var marcoLogicoPtxPA = (await _mediator.Send(new GetAllMarcoLogicoAsignadoQuery() { Include = true, IdProyectoTecnico = idProyectoTecnico }))?.Data ?? new List<MarcoLogicoAsignadoResponse>();

            var listaMarcoLogico = _mapper.Map<List<MarcoLogicoViewModel>>
            (marcoLogico).Select(l => new MarcoLogicoAsignadoViewModel()
            {
                Asignado = true,
                Nuevo = true,
                MarcoLogico = l,
                IdMarcoLogico = l.Id
            });


            var listaMarcoLogicoPtxPA = _mapper.Map<List<MarcoLogicoAsignadoViewModel>>(marcoLogicoPtxPA);
            listaMarcoLogicoPtxPA.ForEach(l => l.Nuevo = false);

            var final = listaMarcoLogicoPtxPA.Union(listaMarcoLogico);

            ViewBag.BotonHabilitado = final.Where(f => f.Nuevo).Count() > 0;
            var responsable = await _mediator.Send(new GetAllResponsablesQuery());
            List<ColaboradorViewModel> responsables = _mapper.Map<List<ColaboradorViewModel>>(responsable.Data);
            ViewBag.ResponsablesSelect = _commonMethods.SetGenericCatalog(responsables, CatalogoConstant.FieldResponsable,0);
            return final.ToList();
        }
    }
}
