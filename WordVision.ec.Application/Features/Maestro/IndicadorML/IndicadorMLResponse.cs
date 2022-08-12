using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.ActorParticipante;
using WordVision.ec.Application.Features.Maestro.Catalogos;

namespace WordVision.ec.Application.Features.Maestro.IndicadorML
{
    public class IndicadorMLResponse : GenericResponse
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion    { get; set; }
        public string Asunciones { get; set; }
        public string MedioVerificacion { get; set; }
        public string CWB { get; set; }
        public bool InclucionRC { get; set; }
        public bool IncluyeAdvovacy { get; set; }
        public int IdTarget { get; set; }
        public DetalleCatalogoResponse Target { get; set; }
        public int IdFrecuencia { get; set; }
        public DetalleCatalogoResponse Frecuencia { get; set; }
        public int IdTipoMedida { get; set; }
        public DetalleCatalogoResponse TipoMedida { get; set; }
        public int IdArea { get; set; }
        public DetalleCatalogoResponse Area { get; set; }
        public int IdActorParticipante { get; set; }
        public ActorParticipanteResponse ActorParticipante { get; set; }
        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }
    }
}
