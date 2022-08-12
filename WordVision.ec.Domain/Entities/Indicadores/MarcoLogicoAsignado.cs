using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class MarcoLogicoAsignado : AuditableEntity
    {
        public int IdMarcoLogico { get; set; }
        [ForeignKey("IdMarcoLogico")]
        public MarcoLogico MarcoLogico { get; set; }
        public int IdProyectoTecnico { get; set; }
        [ForeignKey("IdProyectoTecnico")]
        public ProyectoTecnico ProyectoTecnico { get; set; }
        public int? IdResponsable { get; set; }
        [ForeignKey("IdResponsable")]
        public Colaborador Responsable { get; set; }
        public int IdSupervisor { get; set; }
        [ForeignKey("IdSupervisor")]
        public Colaborador Supervisor { get; set; }
        public bool Asignado { get; set; }
        [Required]
        public double Poblacion { get; set; }
    }
}
