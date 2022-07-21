using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea;

namespace WordVision.ec.Application.Features.Planificacion.ProyectoITT
{
    public class ProyectoITTResponse : GenericResponse
    {
        public int Id { get; set; }
        public int IdFaseProgramaArea { get; set; }
        public FaseProgramaAreaResponse FaseProgramaArea { get; set; }

        public virtual ICollection<DetalleProyectoITTResponse> DetalleProyectoITTs { get; set; }

    }
}
