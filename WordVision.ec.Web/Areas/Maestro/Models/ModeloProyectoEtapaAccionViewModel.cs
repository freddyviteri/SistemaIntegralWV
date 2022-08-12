using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class ModeloProyectoEtapaAccionViewModel : Domain.Entities.Maestro.ModeloProyectoEtapaAccion
    {
        public string codigosao { get; set; }
        public new AccionOperativaViewModel AccionOperativa { get; set; }
        public new EtapaViewModel Etapa { get; set; }
        public new ModeloProyectoViewModel ModeloProyecto { get; set; }
        public new DetalleCatalogoViewModel Estado { get; set; }
        public SelectList ModeloProyectoList { get; set; }
        public SelectList EtapaList { get; set; }
        public SelectList AccionoperativaList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
