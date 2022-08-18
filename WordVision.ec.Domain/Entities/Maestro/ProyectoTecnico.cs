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
    public class ProyectoTecnico : AuditableEntity
    {
        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(500)]
        public string NombreProyecto { get; set; }

        public int IdUbicacion { get; set; }
        [ForeignKey("IdUbicacion")]
        public DetalleCatalogo Ubicacion { get; set; }

        public int IdFinanciamiento { get; set; }
        [ForeignKey("IdFinanciamiento")]
        public DetalleCatalogo Financiamiento { get; set; }

        public int IdTipoProyecto { get; set; }
        [ForeignKey("IdTipoProyecto")]
        public DetalleCatalogo TipoProyecto { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }

    }
}
