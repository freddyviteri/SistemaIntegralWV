using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Command.Create;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Queries.GetByProyectoTecnico;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Queries.GetProgramasAreaDisponiblesQuery;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Queries.GetProgramasTecnicosDsiponiblesQuery;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Queries.GetProyectosTecnicosDisponiblesQuery;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Queries.GetByPt;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Indicadores.Controllers
{
    [Area("Indicadores")]
    [Authorize]
    public class ProgramaTecnicoPorProgramaAreaController : BaseController<ProgramaTecnicoPorProgramaAreaController>
    {
        private readonly CommonMethods _commonMethods;

        public ProgramaTecnicoPorProgramaAreaController()
        {
            _commonMethods = new CommonMethods();
        }

        public async Task<IActionResult> IndexAsync()
        {
            await SetDropDownListProgramasArea();
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreate(List<ProgramaTecnicoPorProgramaAreaViewModel> programaTecnicoPorProgramaAreaViewModel)
        {
            var createEntidadCommand = _mapper.Map<CreateProgramaTecnicoPorProgramaAreaCommand>(programaTecnicoPorProgramaAreaViewModel);

            await _mediator.Send(createEntidadCommand);


            _notify.Success($"Datos registrados correctamente.");

            return new JsonResult(new { isValid = true });
        }



        [HttpGet]
        public async Task<IActionResult> SearchProgramaTecnico(int idProgramaArea)
        {
            await SetDropDownListProgramasTecnicos(idProgramaArea);
            return PartialView("_ViewSelectProgramaTecnico");
        }

        [HttpGet]
        public async Task<IActionResult> SearchProyectoTecnico(int idProgramaArea, int idProgramaTecnico)
        {
            await SetDropDownListProyectosTecnicos(idProgramaArea, idProgramaTecnico);
            return PartialView("_ViewSelectProyectoTecnico");
        }


        [HttpGet]
        public async Task<IActionResult> SearchLogFrameIndicadoresPR(int idProgramaArea, int idProgramaTecnico,int idProyectoTecnico)
        {
            return PartialView("_ViewAll", await GetLogFrameIndicadoresPRList(idProgramaArea, idProgramaTecnico, idProyectoTecnico));
        }


        private async Task SetDropDownListProgramasArea()
        {
            var programaAreas = await _mediator.Send(new GetProgramasAreaDisponiblesQuery());
            List<ProgramaAreaViewModel> programas = _mapper.Map<List<ProgramaAreaViewModel>>(programaAreas.Data);

            ViewBag.ProgramasAreasSelect = _commonMethods.SetGenericCatalog(programas, CatalogoConstant.FieldProgramaArea);
            ViewBag.ProgramasTecnicosSelect = _commonMethods.SetGenericCatalog(new List<ProgramaTecnicoViewModel>(), CatalogoConstant.FieldProgramaTecnico);
            ViewBag.ProyectosTecnicosSelect = _commonMethods.SetGenericCatalog(new List<ProyectoTecnicoViewModel>(), CatalogoConstant.FieldProyectoTecnico);

        }

        private async Task SetDropDownListProgramasTecnicos(int idProgramaArea)
        {
            var programasTecnicos = (await _mediator.Send(new GetProgramasTecnicosDsiponiblesQuery() { IdProgramaArea = idProgramaArea }))?.Data;
            List<ProgramaTecnicoViewModel> programasTecnicosList = _mapper.Map<List<ProgramaTecnicoViewModel>>(programasTecnicos);

            ViewBag.ProgramasTecnicosSelect = _commonMethods.SetGenericCatalog(programasTecnicosList, CatalogoConstant.FieldProgramaTecnico);
        }

        private async Task SetDropDownListProyectosTecnicos(int idProgramaArea, int idProgramaTecnico)
        {
            var programasTecnicos = (await _mediator.Send(new GetProyectosTecnicosDisponiblesQuery() { IdProgramaArea = idProgramaArea, IdProgramaTecnico = idProgramaTecnico }))?.Data;
            List<ProyectoTecnicoViewModel> programasTecnicosList = _mapper.Map<List<ProyectoTecnicoViewModel>>(programasTecnicos);

            ViewBag.ProyectosTecnicosSelect = _commonMethods.SetGenericCatalog(programasTecnicosList, CatalogoConstant.FieldProyectoTecnico);
        }

        private async Task<List<ProgramaTecnicoPorProgramaAreaViewModel>> GetLogFrameIndicadoresPRList(int idProgramaArea, int idProgramaTecnico, int idProyectoTecnico)
        {
            var logFrameIndicadoresPR = (await _mediator.Send(new GetLogFrameIndicadorPRByPtQuery() { Include = true, IdProgramaArea = idProgramaArea, IdProgramaTecnico = idProgramaTecnico, Id = idProyectoTecnico }))?.Data;
            var logFrameIndicadoresPtxPA = (await _mediator.Send(new GetAllProgramaTecnicoPorProgramaAreaQuery() { Include = true, IdProgramaArea = idProgramaArea, IdProgramaTecnico = idProgramaTecnico, Id = idProyectoTecnico }))?.Data ?? new List<ProgramaTecnicoPorProgramaAreaResponse>();

            var listaLogFrameIndicadoresPR = _mapper.Map<List<LogFrameIndicadorPRViewModel>>
            (logFrameIndicadoresPR).Select(l => new ProgramaTecnicoPorProgramaAreaViewModel()
            {
                Asignado = true,
                Nuevo = true,
                LogFrameIndicadorPR = l,
                IdLogFrameIndicadorPR = l.Id
            });


            var listaLogFrameIndicadoresPtxPA = _mapper.Map<List<ProgramaTecnicoPorProgramaAreaViewModel>>(logFrameIndicadoresPtxPA);
            listaLogFrameIndicadoresPtxPA.ForEach(l => l.Nuevo = false);

            var final = listaLogFrameIndicadoresPtxPA.Union(listaLogFrameIndicadoresPR);

            ViewBag.BotonHabilitado = final.Where(f => f.Nuevo).Count() > 0;

            return final.ToList();
        }
    }
}
