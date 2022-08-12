using System;
using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.IndicadorML;
using WordVision.ec.Application.Features.Maestro.MarcoLogico;
using WordVision.ec.Application.Features.Maestro.OtroIndicador;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;

namespace WordVision.ec.Application.Features.Indicadores.VinculacionIndicador
{
    public class VinculacionIndicadorResponse : GenericResponse
    {
        public int Id { get; set; }
        public int IdIndicadorML { get; set; }
        public IndicadorMLResponse IndicadorML { get; set; }
        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }
        public int IdMarcoLogico { get; set; }
        public MarcoLogicoResponse MarcoLogico { get; set; }
        public int IdOtroIndicador { get; set; }
        public OtroIndicadorResponse OtroIndicador { get; set; }
    }
}
