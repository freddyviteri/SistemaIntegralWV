using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;

namespace WordVision.ec.Application.Features.Maestro.ProyectoTecnico
{
    public class ProyectoTecnicoResponse : GenericResponse
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string NombreProyecto { get; set; }

        public int IdUbicacion { get; set; }
        public DetalleCatalogoResponse Ubicacion { get; set; }

        public int IdFinanciamiento { get; set; }
        public DetalleCatalogoResponse Financiamiento { get; set; }

        public int IdTipoProyecto { get; set; }
        public DetalleCatalogoResponse TipoProyecto { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }
    }
}
