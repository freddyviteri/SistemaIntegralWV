using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;

namespace WordVision.ec.Application.Features.Maestro.ProgramaArea
{
    public class ProgramaAreaResponse : GenericResponse
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public int IdProyectoTecnico { get; set; }
        public ProyectoTecnicoResponse ProyectoTecnico { get; set; }

        public int IdEstado { get; set; }

        public DetalleCatalogoResponse Estado { get; set; }

    }
}
