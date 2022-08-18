using System;
using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.IndicadorPR;
using WordVision.ec.Application.Features.Maestro.OtroIndicador;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;

namespace WordVision.ec.Application.Features.Indicadores.VinculacionIndicador
{
    public class VinculacionIndicadorResponse : GenericResponse
    {
        public int Id { get; set; }
        public string Riesgos { get; set; }

        public string PlanNacionalDesarrollo { get; set; }

        public string CWB { get; set; }

        public int IdIndicadorPR { get; set; }
        public IndicadorPRResponse IndicadorPR { get; set; }

        //public int IdOtroIndicador { get; set; }
        //public OtroIndicadorResponse OtroIndicador { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }

        public List<DetalleVinculacionIndicadorResponse> DetalleVinculacionIndicadores { get; set; }
    }
}
