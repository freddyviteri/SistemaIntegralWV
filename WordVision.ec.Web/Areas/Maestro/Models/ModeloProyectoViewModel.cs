using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class ModeloProyectoViewModel : Domain.Entities.Maestro.ModeloProyecto
    {
        public new DetalleCatalogoViewModel Estado { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
