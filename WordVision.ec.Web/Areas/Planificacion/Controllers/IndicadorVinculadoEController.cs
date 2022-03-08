﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using WordVision.ec.Application.Features.Planificacion.IndicadorVinculadoEs.Commands.Delete;
using WordVision.ec.Web.Abstractions;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class IndicadorVinculadoEController :  BaseController<IndicadorVinculadoEController>
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> OnPostDelete(int id = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteIndicadorVinculadoECommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Indicador con Id {id} Eliminado.");
                return new JsonResult(new { isValid = true });
            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return new JsonResult(new { isValid = false});
            }
           
        }
    }
}