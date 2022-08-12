using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class MarcoLogicoViewModel
    {
        public int Id { get; set; }
       
        public int IdLogFrame { get; set; }
        public LogFrameViewModel LogFrame { get; set; }

        public int IdIndicadorML { get; set; }
        public IndicadorMLViewModel IndicadorML { get; set; }

        [Display(Name = "Estado")]
        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public SelectList LogFrameList { get; set; }
        public SelectList IndicadorMLList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
