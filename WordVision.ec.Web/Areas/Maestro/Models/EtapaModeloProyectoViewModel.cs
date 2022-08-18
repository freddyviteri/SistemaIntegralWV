using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class EtapaModeloProyectoViewModel
    {
        public int Id { get; set; }
        public string Etapa { get; set; }

        public int IdAccionOperativa { get; set; }
        public DetalleCatalogoViewModel AccionOperativa { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public SelectList EstadoList { get; set; }
        public SelectList AccionOperativaList { get; set; }

    }
}
