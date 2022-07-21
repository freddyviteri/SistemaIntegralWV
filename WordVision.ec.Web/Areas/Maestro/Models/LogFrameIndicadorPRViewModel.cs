using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class LogFrameIndicadorPRViewModel
    {
        public int Id { get; set; }
       
        public int IdLogFrame { get; set; }
        public LogFrameViewModel LogFrame { get; set; }

        public int IdIndicadorPR { get; set; }
        public IndicadorPRViewModel IndicadorPR { get; set; }

        [Display(Name = "Estado")]
        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public SelectList LogFrameList { get; set; }
        public SelectList IndicadorPRList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
