using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class MapeoMarcoLogico : AuditableEntity
    {
        public int IdProgramaArea { get; set; }
        [ForeignKey("IdProgramaArea")]
        public ProgramaArea ProgramaArea { get; set; }

        public int IdProyectoTecnico { get; set; }
        [ForeignKey("IdProyectoTecnico")]
        public ProyectoTecnico ProyectoTecnico { get; set; }

        public string CodigoSupervisor { get; set; }
        public string NombreSupervisor { get; set; }
    }
}
