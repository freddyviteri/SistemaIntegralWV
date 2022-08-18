using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class VinculacionIndicador : AuditableEntity
    {
        [StringLength(250)]
        public string Riesgos { get; set; }

        [StringLength(250)]
        public string PlanNacionalDesarrollo { get; set; }

        public int IdIndicadorPR { get; set; }
        [ForeignKey("IdIndicadorPR")]
        public IndicadorPR IndicadorPR { get; set; }

        //public int IdOtroIndicador { get; set; }
        //[ForeignKey("IdOtroIndicador")]
        //public OtroIndicador OtroIndicador { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }

        public virtual List<DetalleVinculacionIndicador> DetalleVinculacionIndicadores { get; set; }
    }
}
