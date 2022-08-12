using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class EtapaViewModel : Domain.Entities.Maestro.Etapa
    {
        public new DetalleCatalogoViewModel Estado { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
