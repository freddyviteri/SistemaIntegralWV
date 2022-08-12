using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class ProgramaTecnico : AuditableEntity
    {
        [Required]
        [StringLength(10)]
        public virtual string Codigo { get; set; }

        [Required]
        [StringLength(200)]
        public virtual string Nombre { get; set; }

        [StringLength(500)]
        public string? Descripcion { get; set; }

        public int? IdTipoProyecto { get; set; }
        [ForeignKey("IdTipoProyecto")]
        public virtual DetalleCatalogo? TipoProyecto { get; set; }

        public int? IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public virtual DetalleCatalogo? Estado { get; set; }

    }
}
