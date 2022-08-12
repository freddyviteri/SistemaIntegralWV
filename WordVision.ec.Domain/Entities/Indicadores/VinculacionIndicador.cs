using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class VinculacionIndicador : AuditableEntity
    {
        //public int IdIndicadorML { get; set; }
        //[ForeignKey("IdIndicadorML")]
        //public IndicadorML IndicadorML { get; set; }
        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }
        //[Index("IX_IdML_IdOI", 1, IsUnique = true)]
        public int IdMarcoLogico { get; set; }
        [ForeignKey("IdMarcoLogico")]
        public MarcoLogico MarcoLogico { get; set; }
        //[Index("IX_IdML_IdOI", 1, IsUnique = true)]
        public int IdOtroIndicador { get; set; }
        [ForeignKey("IdOtroIndicador")]
        public OtroIndicador OtroIndicador { get; set; }
        //public virtual List<DetalleVinculacionIndicador> DetalleVinculacionIndicadores { get; set; }
    }
}
