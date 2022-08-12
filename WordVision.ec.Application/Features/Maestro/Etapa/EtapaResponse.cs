
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto
{
    public class EtapaResponse : Etapa, IGenericResponse
    {
        public new DetalleCatalogoResponse Estado { get; set; }

    }
}
