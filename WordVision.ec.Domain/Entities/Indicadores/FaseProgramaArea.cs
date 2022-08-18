using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class FaseProgramaArea : AuditableEntity
    {
        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [StringLength(200)]
        public string Observacion { get; set; }

        [Required]
        public DateTime FechaDisenio { get; set; }

        [Required]
        public DateTime FechaRedisenio { get; set; }

        [Required]
        public DateTime FechaTransicion { get; set; }

        [StringLength(10)]
        public string Dip1 { get; set; }

        [StringLength(10)]
        public string Dip2 { get; set; }

        [StringLength(10)]
        public string Dip3 { get; set; }

        [StringLength(10)]
        public string Dip4 { get; set; }

        [StringLength(10)]
        public string Dip5 { get; set; }

        [StringLength(10)]
        public string Dip6 { get; set; }

        public int IdProgramaArea { get; set; }
        [ForeignKey("IdProgramaArea")]
        public ProgramaArea ProgramaArea { get; set; }

        public int IdProyectoTecnico { get; set; }
        [ForeignKey("IdProyectoTecnico")]
        public ProyectoTecnico ProyectoTecnico { get; set; }

        public int IdFaseProyecto { get; set; }
        [ForeignKey("IdFaseProyecto")]
        public DetalleCatalogo FaseProyecto { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }

    }
}
