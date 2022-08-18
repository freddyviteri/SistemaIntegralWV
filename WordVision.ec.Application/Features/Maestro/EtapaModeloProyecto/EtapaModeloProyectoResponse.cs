using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;

namespace WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto
{
    public class EtapaModeloProyectoResponse : GenericResponse
    {
        public int Id { get; set; }
        public string Etapa { get; set; }

        public int IdAccionOperativa { get; set; }
        public DetalleCatalogoResponse AccionOperativa { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }

    }
}
