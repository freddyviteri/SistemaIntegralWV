﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WordVision.ec.Web.Abstractions;

namespace WordVision.ec.Web.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("Dashboard")]
    public class HomeController : BaseController<HomeController>
    {
        public IActionResult Index()
        {
            _notify.Information("Bienvenidos!");
            return View();
        }
    }
}
