using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Models
{
    public class VinculacionIndicadorViewModel
    {
        public int Id { get; set; }
        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }
        public int IdMarcoLogico { get; set; }
        public MarcoLogicoViewModel MarcoLogico { get; set; }
        public int IdOtroIndicador { get; set; }
        public OtroIndicadorViewModel OtroIndicador { get; set; }
        public int? IdTipoIndicador { get; set; }
        public DetalleCatalogoViewModel TipoIndicador { get; set; }
        public List<int> IdOtrosIndicadores { get; set; }
        public List<OtroIndicadorViewModel> OtrosIndicadores { get; set; }


        public SelectList IndicadorMLList { get; set; }
        public SelectList EstadoList { get; set; }
        public SelectList MarcoLogicoList { get; set; }
        public SelectList OtroIndicadorList { get; set; }
        public SelectList TipoIndicadorList { get; set; }

    }
}
