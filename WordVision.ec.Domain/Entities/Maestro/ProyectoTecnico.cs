using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class ProyectoTecnico : AuditableEntity
    {
        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }

        public int IdProgramaArea { get; set; }
        [ForeignKey("IdProgramaArea")]
        public ProgramaArea? ProgramaArea { get; set; }

        public int IdProgramaTecnico { get; set; }
        [ForeignKey("IdProgramaTecnico")]
        public ProgramaTecnico? ProgramaTecnico { get; set; }


        public int? IdUbicacion { get; set; }
        [ForeignKey("IdUbicacion")]
        public DetalleCatalogo? Ubicacion { get; set; }

        public int? IdFinanciamiento { get; set; }
        [ForeignKey("IdFinanciamiento")]
        public DetalleCatalogo? Financiamiento { get; set; }

        [Required]
        [StringLength(500)]
        public virtual string? NombreProyecto { get; set; }

        public int? IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo? Estado { get; set; }


    }
}
