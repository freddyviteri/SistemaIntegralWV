using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class OtroIndicadorPadreHijo : AuditableEntity
    {
        public int IdPadre { get; set; }
        [ForeignKey("IdPadre")]
        public OtroIndicador Padre { get; set; }
        public int IdHijo { get; set; }
        [ForeignKey("IdHijo")]
        public OtroIndicador Hijo { get; set; }
        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }
    }
}
