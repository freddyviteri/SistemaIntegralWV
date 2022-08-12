using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class AccionOperativaViewModel : Domain.Entities.Maestro.AccionOperativa
    {
        public new DetalleCatalogoViewModel Estado { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
