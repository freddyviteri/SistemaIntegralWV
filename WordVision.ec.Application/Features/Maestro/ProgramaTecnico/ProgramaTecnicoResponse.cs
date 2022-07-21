using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.ProgramaTecnico
{
    public class ProgramaTecnicoResponse : Domain.Entities.Maestro.ProgramaTecnico, IGenericResponse
    {

        public new virtual DetalleCatalogoResponse? TipoProyecto { get; set; }

        public new virtual DetalleCatalogoResponse? Estado { get; set; }
        public bool Include { get; set; }
    }
}
