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
    public class LogFrameIndicadorPR : AuditableEntity
    {
        public int IdLogFrame { get; set; }
        [ForeignKey("IdLogFrame")]
        public LogFrame LogFrame { get; set; }

        public int IdIndicadorPR { get; set; }
        [ForeignKey("IdIndicadorPR")]
        public IndicadorPR IndicadorPR { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }

        //public virtual ICollection<IndicadorPR> IndicadoresPR { get; set; }

    }
}
