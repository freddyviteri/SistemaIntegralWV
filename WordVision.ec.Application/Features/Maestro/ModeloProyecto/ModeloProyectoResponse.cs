using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto;

namespace WordVision.ec.Application.Features.Maestro.ModeloProyecto
{
    public class ModeloProyectoResponse : GenericResponse
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        //public string Responsable { get; set; }

        public int IdEtapaModeloProyecto { get; set; }
        public EtapaModeloProyectoResponse EtapaModeloProyecto { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }

    }
}
