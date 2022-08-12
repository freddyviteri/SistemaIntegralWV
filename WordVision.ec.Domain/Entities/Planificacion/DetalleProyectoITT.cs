using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class DetalleProyectoITT : AuditableEntity
    {

        [StringLength(100)]
        public string LineBase { get; set; }

        [Required]
        public decimal MetaAF1 { get; set; }

        [Required]
        public decimal MetaAF2 { get; set; }

        [Required]
        public decimal MetaAF3 { get; set; }

        [Required]
        public decimal MetaAF4 { get; set; }

        [Required]
        public decimal MetaAF5 { get; set; }

        [Required]
        public decimal MetaAF6 { get; set; }

        public int IdMarcoLogicoAsignado { get; set; }
        [ForeignKey("IdMarcoLogicoAsignado")]
        public MarcoLogicoAsignado MarcoLogicoAsignado { get; set; }

        public int IdProyectoITT { get; set; }
        [ForeignKey("IdProyectoITT")]
        public ProyectoITT ProyectoITT { get; set; }
    }
}
