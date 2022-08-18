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
    public class EtapaModeloProyecto : AuditableEntity
    {
        [Required]
        [StringLength(250)]
        public string Etapa { get; set; }

        public int IdAccionOperativa { get; set; }
        [ForeignKey("IdAccionOperativa")]
        public DetalleCatalogo AccionOperativa { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }

    }
}
