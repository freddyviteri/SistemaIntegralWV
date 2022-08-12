using System;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.OtroIndicador;

namespace WordVision.ec.Application.Features.Indicadores.VinculacionIndicador
{
    public class DetalleVinculacionIndicadorResponse : GenericResponse
    {
        public int Id { get; set; }

        public int IdVinculacionIndicador { get; set; }
        public VinculacionIndicadorResponse VinculacionIndicador { get; set; }
        public int IdOtroIndicador { get; set; }
        public OtroIndicadorResponse OtroIndicador { get; set; }
        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }
        public bool Selected { get; set; }
    }
}
