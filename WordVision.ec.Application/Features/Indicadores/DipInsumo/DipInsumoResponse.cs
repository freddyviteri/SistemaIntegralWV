using System;
using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto;
using WordVision.ec.Application.Features.Maestro.IndicadorPR;
using WordVision.ec.Application.Features.Maestro.LogFrame;
using WordVision.ec.Application.Features.Maestro.OtroIndicador;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;

namespace WordVision.ec.Application.Features.Indicadores.DipInsumo
{
    public class DipInsumoResponse : GenericResponse
    {
        public int Id { get; set; }
        public string Dip { get; set; }

        public string AnualMensual { get; set; }

        public decimal Q1 { get; set; }

        public decimal Octubre { get; set; }

        public decimal Noviembre { get; set; }

        public decimal Diciembre { get; set; }

        public decimal Q2 { get; set; }

        public decimal Enero { get; set; }

        public decimal Febrero { get; set; }

        public decimal Marzo { get; set; }

        public decimal Q3 { get; set; }

        public decimal Abril { get; set; }

        public decimal Mayo { get; set; }

        public decimal Junio { get; set; }

        public decimal Q4 { get; set; }

        public decimal Julio { get; set; }

        public decimal Agosto { get; set; }

        public decimal Septiembre { get; set; }

        public decimal Anual { get; set; }

        public int IdLogFrameOutCome { get; set; }
        public LogFrameResponse LogFrameOutCome { get; set; }

        public int IdLogFrameOutPut { get; set; }
        public LogFrameResponse LogFrameOutPut { get; set; }

        public int IdEtapaModeloProyecto { get; set; }

        public EtapaModeloProyectoResponse EtapaModeloProyecto { get; set; }

        public int IdAccionOperativa { get; set; }

        public DetalleCatalogoResponse AccionOperativa { get; set; }

        public virtual ICollection<DetalleDipInsumoResponse> DetalleDipInsumos { get; set; }

    }
}
