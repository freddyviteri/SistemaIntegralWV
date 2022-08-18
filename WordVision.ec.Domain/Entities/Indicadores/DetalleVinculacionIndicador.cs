using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class DetalleVinculacionIndicador : AuditableEntity
    {
        public int IdVinculacionIndicador { get; set; }
        [ForeignKey("IdVinculacionIndicador")]
        public VinculacionIndicador VinculacionIndicador { get; set; }

        //public int IdIndicadorPR { get; set; }
        //[ForeignKey("IdIndicadorPR")]
        //public IndicadorPR IndicadorPR { get; set; }

        public int IdOtroIndicador { get; set; }
        [ForeignKey("IdOtroIndicador")]
        public OtroIndicador OtroIndicador { get; set; }
    }
}
