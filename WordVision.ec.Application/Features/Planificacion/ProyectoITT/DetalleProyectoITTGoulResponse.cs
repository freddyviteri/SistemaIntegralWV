using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.ProyectoITT
{
    public class DetalleProyectoITTGoulResponse : DetalleProyectoITTGoul
    {
        public new MarcoLogicoAsignadoResponse MarcoLogicoAsignado { get; set; }

        public new ProyectoITTResponse ProyectoITT { get; set; }
    }
}
