using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.OtroIndicador;

namespace WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo
{
    public class OtroIndicadorPadreHijoResponse : GenericResponse
    {
        public int Id { get; set; }
        public int IdPadre { get; set; }
        public OtroIndicadorResponse Padre { get; set; }
        public int IdHijo { get; set; }
        public OtroIndicadorResponse Hijo { get; set; }
        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }
    }
}
