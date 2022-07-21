using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class ProgramaTecnicoViewModel : ProgramaTecnico
    {
        public new string Codigo { get; set; }

        public new string Nombre { get; set; }
        public new DetalleCatalogoViewModel TipoProyecto { get; set; }

        public new DetalleCatalogoViewModel Estado { get; set; }

        public SelectList TipoProyectoList { get; set; }
        public SelectList EstadoList { get; set; }
    }
}
