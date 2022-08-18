using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class ProyectoITT : AuditableEntity
    {
        public int IdFaseProgramaArea { get; set; }
        [ForeignKey("IdFaseProgramaArea")]
        public FaseProgramaArea FaseProgramaArea { get; set; }

        public int IdLogFrameOutCome { get; set; }
        [ForeignKey("IdLogFrameOutCome")]
        public LogFrame LogFrameOutCome { get; set; }


        public virtual ICollection<DetalleProyectoITT> DetalleProyectoITTs { get; set; }
    }
}
