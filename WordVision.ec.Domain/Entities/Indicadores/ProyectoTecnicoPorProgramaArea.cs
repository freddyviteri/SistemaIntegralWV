using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class ProyectoTecnicoPorProgramaArea : AuditableEntity
    {
        public int IdLogFrameIndicadorPR { get; set; }
        [ForeignKey("IdLogFrameIndicadorPR")]
        public LogFrameIndicadorPR LogFrameIndicadorPR { get; set; }
        public bool Asignado { get; set; }
    }
}
