using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class ModeloProyectoEtapaAccion : AuditableEntity
    {
        public int? IdModeloProyecto { get; set; }

        [ForeignKey("IdModeloProyecto")]
        public virtual ModeloProyecto ModeloProyecto { get; set; }

        public int? IdEtapa { get; set; }

        [ForeignKey("IdEtapa")]
        public virtual Etapa Etapa { get; set; }

        public int? IdAccionOperativa { get; set; }

        [ForeignKey("IdAccionOperativa")]
        public virtual AccionOperativa AccionOperativa { get; set; }

        public int? IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public virtual DetalleCatalogo Estado { get; set; }
    }
}
