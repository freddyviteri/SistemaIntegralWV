using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea;

namespace WordVision.ec.Application.Features.Planificacion.ProyectoITT
{
    public class ProyectoITTResponse : Domain.Entities.Planificacion.ProyectoITT
    {
        public new FaseProgramaAreaResponse FaseProgramaArea { get; set; }
        public new List<DetalleProyectoITTResponse> DetalleProyectoITTs { get; set; }
        public new List<DetalleProyectoITTGoulResponse> DetalleProyectoITTGouls { get; set; }

    }
}
