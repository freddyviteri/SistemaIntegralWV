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
    public class ModeloProyecto : AuditableEntity
    {
        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        //[Required]
        //[StringLength(70)]
        //public string Responsable { get; set; }

        public int IdEtapaModeloProyecto { get; set; }
        [ForeignKey("IdEtapaModeloProyecto")]
        public EtapaModeloProyecto EtapaModeloProyecto { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }

    }
}
