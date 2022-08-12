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
    public class LogFrame : AuditableEntity
    {
        [Required]
        [StringLength(2)]
        public string OutCome { get; set; }

        [StringLength(2)]
        public string OutPut { get; set; }

        [StringLength(2)]
        public string Activity { get; set; }

        [StringLength(50)]
        public string Cobertura { get; set; }

        [Required]
        [StringLength(500)]
        public string SumaryObjetives { get; set; }

        public int IdNivel { get; set; }
        [ForeignKey("IdNivel")]
        public DetalleCatalogo Nivel { get; set; }
        public int? IdProgramaTecnico { get; set; }
        [ForeignKey("IdProgramaTecnico")]
        public ProgramaTecnico ProgramaTecnico { get; set; }

        public int? IdTipoActividad { get; set; }
        [ForeignKey("IdTipoActividad")]
        public DetalleCatalogo TipoActividad { get; set; }

        public int? IdSectorProgramatico { get; set; }
        [ForeignKey("IdSectorProgramatico")]
        public DetalleCatalogo SectorProgramatico { get; set; }

        public int? IdModeloProyecto { get; set; }
        [ForeignKey("IdModeloProyecto")]
        public ModeloProyecto ModeloProyecto { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }

    }
}
