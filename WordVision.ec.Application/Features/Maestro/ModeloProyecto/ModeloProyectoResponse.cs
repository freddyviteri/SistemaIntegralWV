using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto;

namespace WordVision.ec.Application.Features.Maestro.ModeloProyecto
{
    public class ModeloProyectoResponse : Domain.Entities.Maestro.ModeloProyecto, IGenericResponse
    {
        public new DetalleCatalogoResponse Estado { get; set; }
    }
}
