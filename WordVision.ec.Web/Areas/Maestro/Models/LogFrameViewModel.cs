﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class LogFrameViewModel
    {
        public int Id { get; set; }
        public string OutCome { get; set; }

        public string OutPut { get; set; }

        public string Activity { get; set; }

        public string SumaryObjetives { get; set; }

        public int IdNivel { get; set; }
        public DetalleCatalogoViewModel Nivel { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public SelectList NivelList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
