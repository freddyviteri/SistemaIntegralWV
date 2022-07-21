using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class ProgramaArea : AuditableEntity
    {
        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        public int IdProyectoTecnico { get; set; }
        [ForeignKey("IdProyectoTecnico")]
        public ProyectoTecnico ProyectoTecnico { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }
    }
}
