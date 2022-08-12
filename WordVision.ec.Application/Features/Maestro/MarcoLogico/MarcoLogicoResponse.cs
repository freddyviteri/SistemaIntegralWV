using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador;
using WordVision.ec.Application.Features.Maestro.IndicadorML;
using WordVision.ec.Application.Features.Maestro.LogFrame;

namespace WordVision.ec.Application.Features.Maestro.MarcoLogico
{
    public class MarcoLogicoResponse : GenericResponse
    {
        public int Id { get; set; }
        public int IdLogFrame { get; set; }
        public LogFrameResponse LogFrame { get; set; }
        public int IdIndicadorML { get; set; }
        public IndicadorMLResponse IndicadorML { get; set; }
        public int IdEstado { get; set; }

    }
}
