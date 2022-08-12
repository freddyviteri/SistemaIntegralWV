using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico;

namespace WordVision.ec.Application.Features.Maestro.ProyectoTecnico
{
    public class ProyectoTecnicoResponse : Domain.Entities.Maestro.ProyectoTecnico, IGenericResponse
    {
        public new ProgramaAreaResponse ProgramaArea { get; set; }

        public new ProgramaTecnicoResponse ProgramaTecnico { get; set; }
        public new DetalleCatalogoResponse Ubicacion { get; set; }

        public new DetalleCatalogoResponse Financiamiento { get; set; }

        public new DetalleCatalogoResponse Estado { get; set; }
        public bool Include { get; set; }
    }
}
