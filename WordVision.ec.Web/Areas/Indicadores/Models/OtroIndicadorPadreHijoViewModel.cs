using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Models
{
    public class OtroIndicadorPadreHijoViewModel
    {
        internal object OtroIndicadorPadreList;

        public int Id { get; set; }
        public int IdPadre { get; set; }
        public OtroIndicadorViewModel Padre { get; set; }
        public int IdHijo { get; set; }
        public OtroIndicadorViewModel Hijo { get; set; }
        public int IdEstado { get; set; }
        public int IdEstadoPadreHijo { get; set; }

        public List<int> IdOtrosIndicadoresHijos { get; set; }
        //public List<OtroIndicadorViewModel> OtrosIndicadores { get; set; }

        public DetalleCatalogoViewModel Estado { get; set; }
        //public SelectList OtroIndicadorList { get; set; }
        public SelectList TipoIndicadorList { get; set; }
        public SelectList EstadoList { get; set; }
        public SelectList TipoIndicadorPadreList { get; set; }
        public int IdTipoIndicadorPadre { get; set; }


    }
}
