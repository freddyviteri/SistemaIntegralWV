using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR;

namespace WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea
{
    public class ProyectoTecnicoPorProgramaAreaResponse : GenericResponse
    {
        public int Id { get; set; }
        public int IdLogFrameIndicadorPR { get; set; }
        public LogFrameIndicadorPRResponse LogFrameIndicadorPR { get; set; }
        public bool Asignado { get; set; }
    }
}
