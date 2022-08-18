using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class ProyectoTecnicoViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string NombreProyecto { get; set; }

        public int IdUbicacion { get; set; }
        public DetalleCatalogoViewModel Ubicacion { get; set; }

        public int IdFinanciamiento { get; set; }
        public DetalleCatalogoViewModel Financiamiento { get; set; }

        public int IdTipoProyecto { get; set; }
        public DetalleCatalogoViewModel TipoProyecto { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public SelectList UbicacionList { get; set; }
        public SelectList FinanciamientoList { get; set; }
        public SelectList TipoProyectoList { get; set; }
        public SelectList EstadoList { get; set; }
    }
}
