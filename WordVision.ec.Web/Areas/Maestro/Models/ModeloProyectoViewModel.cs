using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class ModeloProyectoViewModel
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        //public string Responsable { get; set; }

        public int IdEtapaModeloProyecto { get; set; }
        public EtapaModeloProyectoViewModel EtapaModeloProyecto { get; set; }

        public int IdEstado { get; set; }

        public DetalleCatalogoViewModel Estado { get; set; }

        public SelectList EtapaModeloProyectoList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
