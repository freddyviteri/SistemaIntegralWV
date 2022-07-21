using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class ProyectoITTDIP : AuditableEntity
    {
        public int IdProyectoTecnico { get; set; }
        [ForeignKey("IdProyectoTecnico")]
        public ProyectoTecnico ProyectoTecnico { get; set; }

        public int IdProgramaArea { get; set; }
        [ForeignKey("IdProgramaArea")]
        public ProgramaArea ProgramaArea { get; set; }

        public int IdEstadoPorAnioFiscal { get; set; }
        [ForeignKey("IdEstadoPorAnioFiscal")]
        public EstadoPorAnioFiscal EstadoPorAnioFiscal { get; set; }

        public int IdLogFrameOutCome { get; set; }
        [ForeignKey("IdLogFrameOutCome")]
        public LogFrame LogFrameOutCome { get; set; }

        public virtual ICollection<DetalleProyectoITTDIP> DetalleProyectoITTDIPs { get; set; }
    }
}
