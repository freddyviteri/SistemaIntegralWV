using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
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

        public int IdLogFrame { get; set; }
        [ForeignKey("IdLogFrame")]
        public LogFrame LogFrame { get; set; }

        public int IdProyectoITT { get; set; }
        [ForeignKey("IdProyectoITT")]
        public ProyectoITT ProyectoITT { get; set; }
    }
}
