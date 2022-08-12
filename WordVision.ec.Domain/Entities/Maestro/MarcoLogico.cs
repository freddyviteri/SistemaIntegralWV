using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class MarcoLogico : AuditableEntity
    {
        public int IdLogFrame { get; set; }
        [ForeignKey("IdLogFrame")]
        public LogFrame LogFrame { get; set; }

        public int IdIndicadorML { get; set; }
        [ForeignKey("IdIndicadorML")]
        public IndicadorML IndicadorML { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }

    }
}
