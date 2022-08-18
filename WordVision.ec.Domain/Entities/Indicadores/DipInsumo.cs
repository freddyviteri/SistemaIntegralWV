using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class DipInsumo : AuditableEntity
    {
        //public int IdProyectoTecnico { get; set; }
        //[ForeignKey("IdProyectoTecnico")]
        //public ProyectoTecnico ProyectoTecnico { get; set; }

        //public int IdProgramaArea { get; set; }
        //[ForeignKey("IdProgramaArea")]
        //public ProgramaArea ProgramaArea { get; set; }
        public string Dip { get; set; }

        [StringLength(1)]
        public string AnualMensual { get; set; }

        //public decimal Q1 { get; set; }

        //public decimal Octubre { get; set; }

        //public decimal Noviembre { get; set; }

        //public decimal Diciembre { get; set; }

        //public decimal Q2 { get; set; }

        //public decimal Enero { get; set; }

        //public decimal Febrero { get; set; }

        //public decimal Marzo { get; set; }

        //public decimal Q3 { get; set; }

        //public decimal Abril { get; set; }

        //public decimal Mayo { get; set; }

        //public decimal Junio { get; set; }

        //public decimal Q4 { get; set; }

        //public decimal Julio { get; set; }

        //public decimal Agosto { get; set; }

        //public decimal Septiembre { get; set; }

        //[Required]
        //public decimal Anual { get; set; }

        public int IdLogFrameOutCome { get; set; }
        [ForeignKey("IdLogFrameOutCome")]
        public LogFrame LogFrameOutCome { get; set; }

        public int IdLogFrameOutPut { get; set; }
        [ForeignKey("IdLogFrameOutPut")]
        public LogFrame LogFrameOutPut { get; set; }


        public int IdEtapaModeloProyecto { get; set; }
        [ForeignKey("IdEtapaModeloProyecto")]
        public EtapaModeloProyecto EtapaModeloProyecto { get; set; }

        public int IdAccionOperativa { get; set; }
        [ForeignKey("IdAccionOperativa")]
        public DetalleCatalogo AccionOperativa { get; set; }

        public int IdDetalleProyectoITTDIP { get; set; }
        [ForeignKey("IdDetalleProyectoITTDIP")]
        public DetalleProyectoITTDIP DetalleProyectoITTDIP { get; set; }

        public virtual ICollection<DetalleDipInsumo> DetalleDipInsumos { get; set; }
    }
}
