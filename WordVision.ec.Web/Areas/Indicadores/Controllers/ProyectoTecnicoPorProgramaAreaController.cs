using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Command.Create;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Command.Update;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Queries.GetByProyectoTecnico;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Queries.GetByPt;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Indicadores.Controllers
{
    [Area("Indicadores")]
    [Authorize]
    public class ProyectoTecnicoPorProgramaAreaController : BaseController<ProyectoTecnicoPorProgramaAreaController>
    {
        private readonly CommonMethods _commonMethods;

        public ProyectoTecnicoPorProgramaAreaController()
        {
            _commonMethods = new CommonMethods();
        }

        public async Task<IActionResult> IndexAsync()
        {
            await SetDropDownListProgramasArea();
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreate(List<ProyectoTecnicoPorProgramaAreaViewModel> proyectoTecnicoPorProgramaAreaViewModel)
        {
            var createEntidadCommand = _mapper.Map<CreateProyectoTecnicoPorProgramaAreaCommand>(proyectoTecnicoPorProgramaAreaViewModel);

            await _mediator.Send(createEntidadCommand);


            _notify.Success($"Datos registrados correctamente.");

            return new JsonResult(new { isValid = true });
        }



        [HttpGet]
        public async Task<IActionResult> SearchProyectoTecnico(int idPrograma)
        {
            await SetDropDownListProyectosTecnicos(idPrograma);
            return PartialView("_ViewSelectPT");
        }


        [HttpGet]
        public async Task<IActionResult> SearchLogFrameIndicadoresPR(int idProyecto)
        {
            return PartialView("_ViewAll", await GetLogFrameIndicadoresPRList(idProyecto));
        }


        private async Task SetDropDownListProgramasArea()
        {
            var programaAreas = await _mediator.Send(new GetAllProgramaAreaQuery());
            List<ProgramaAreaViewModel> programas = _mapper.Map<List<ProgramaAreaViewModel>>(programaAreas.Data);

            ViewBag.ProgramasAreasSelect = _commonMethods.SetGenericCatalog(programas, CatalogoConstant.FieldProgramaArea);
            ViewBag.ProyectosTecnicosSelect = _commonMethods.SetGenericCatalog(new List<ProyectoTecnicoViewModel>(), CatalogoConstant.FieldProyectoTecnico);
        }

        private async Task SetDropDownListProyectosTecnicos(int idPrograma)
        {

            var programaArea = (await _mediator.Send(new GetProgramaAreaByIdQuery() { Id = idPrograma }))?.Data;


            var proyectoTecnico = (await _mediator.Send(new GetProyectoTecnicoByIdQuery() { Id = programaArea?.IdProyectoTecnico ?? 0 }))?.Data;




            var proyectoTecnicoViewModel = _mapper.Map<ProyectoTecnicoViewModel>(proyectoTecnico);



            var proyectosTecnicos = proyectoTecnicoViewModel != null ? new List<ProyectoTecnicoViewModel>()
            {
                proyectoTecnicoViewModel
            } : new List<ProyectoTecnicoViewModel>();

            ViewBag.ProyectosTecnicosSelect = _commonMethods.SetGenericCatalog(proyectosTecnicos, CatalogoConstant.FieldProyectoTecnico);
        }

        private async Task<List<ProyectoTecnicoPorProgramaAreaViewModel>> GetLogFrameIndicadoresPRList(int idProyecto)
        {
            var logFrameIndicadoresPR = (await _mediator.Send(new GetLogFrameIndicadorPRByPtQuery() {  Include = true, IdPt= idProyecto }))?.Data ?? new List<LogFrameIndicadorPRResponse>() ;
            var logFrameIndicadoresPtxPA = (await _mediator.Send(new GetAllProyectoTecnicoPorProgramaAreaQuery() { Include = true, IdPt = idProyecto }))?.Data ?? new List<ProyectoTecnicoPorProgramaAreaResponse>();

            var listaLogFrameIndicadoresPR = _mapper.Map<List<LogFrameIndicadorPRViewModel>>
            (logFrameIndicadoresPR).Select(l => new ProyectoTecnicoPorProgramaAreaViewModel()
            {
                Asignado = true,
                Nuevo = true,
                LogFrameIndicadorPR = l,
                IdLogFrameIndicadorPR = l.Id
            });


            var listaLogFrameIndicadoresPtxPA = _mapper.Map<List<ProyectoTecnicoPorProgramaAreaViewModel>>(logFrameIndicadoresPtxPA);
            listaLogFrameIndicadoresPtxPA.ForEach(l => l.Nuevo = false);

            var final = listaLogFrameIndicadoresPtxPA.Union(listaLogFrameIndicadoresPR);

            ViewBag.BotonHabilitado = final.Where(f => f.Nuevo).Count() > 0;

            return  final.ToList();
        }
    }
}
