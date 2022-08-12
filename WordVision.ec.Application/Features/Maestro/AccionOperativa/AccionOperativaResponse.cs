using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto
{
    public class AccionOperativaResponse : AccionOperativa, IGenericResponse
    {
        public new DetalleCatalogoResponse Estado { get; set; }

    }
}
