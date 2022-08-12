using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class DetalleProyectoITTGoul : AuditableEntity
    {
        public int IdMarcoLogicoAsignado { get; set; }
        [ForeignKey("IdMarcoLogicoAsignado")]
        public MarcoLogicoAsignado MarcoLogicoAsignado { get; set; }

        public int IdProyectoITT { get; set; }
        [ForeignKey("IdProyectoITT")]
        public ProyectoITT ProyectoITT { get; set; }
    }
}
