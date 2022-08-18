using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Models
{
    public class DetalleVinculacionIndicadorViewModel
    {
        public int Id { get; set; }

        public int IdVinculacionIndicador { get; set; }
        public VinculacionIndicadorViewModel VinculacionIndicador { get; set; }

        //public int IdIndicadorPR { get; set; }
        //public IndicadorPRViewModel IndicadorPR { get; set; }

        public int IdOtroIndicador { get; set; }
        public OtroIndicadorViewModel OtroIndicador { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public bool Selected { get; set; }

    }
}
