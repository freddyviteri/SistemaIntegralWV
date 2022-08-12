using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }
    }
}
