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
    public class IndicadorPR : AuditableEntity
    {
        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(500)]
        public string Asunciones { get; set; }

        [Required]
        [StringLength(500)]
        public string MedioVerificacion { get; set; }

        [Required]
        public decimal Poblacion { get; set; }

        [StringLength(10)]
        public string CWB { get; set; }

        public bool InclucionRC { get; set; }

        public bool IncluyeAdvovacy { get; set; }

        public int IdTarget { get; set; }
        [ForeignKey("IdTarget")]
        public DetalleCatalogo Target { get; set; }

        public int IdFrecuencia { get; set; }
        [ForeignKey("IdFrecuencia")]
        public DetalleCatalogo Frecuencia { get; set; }

        public int IdTipoMedida { get; set; }
        [ForeignKey("IdTipoMedida")]
        public DetalleCatalogo TipoMedida { get; set; }

        public int IdActorParticipante { get; set; }
        [ForeignKey("IdActorParticipante")]
        public ActorParticipante ActorParticipante { get; set; }        

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }
    }
}
