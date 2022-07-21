using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class ProgramaAreaViewModel
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public int IdProyectoTecnico { get; set; }
        public ProyectoTecnicoViewModel ProyectoTecnico { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public SelectList ProyectoTecnicoList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
