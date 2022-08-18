using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.IndicadorPR;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;

namespace WordVision.ec.Application.Features.Maestro.LogFrame
{
    public class LogFrameResponse : GenericResponse
    {
        public int Id { get; set; }
        public string OutCome { get; set; }

        public string OutPut { get; set; }

        public string Activity { get; set; }

        public string SumaryObjetives { get; set; }

        public string Cobertura { get; set; }

        public int IdNivel { get; set; }
        public DetalleCatalogoResponse Nivel { get; set; }

        public int? IdProyectoTecnico { get; set; }
        public ProyectoTecnicoResponse ProyectoTecnico { get; set; }

        public int? IdTipoActividad { get; set; }
        public DetalleCatalogoResponse TipoActividad { get; set; }

        public int? IdSectorProgramatico { get; set; }
        public DetalleCatalogoResponse SectorProgramatico { get; set; }

        public int? IdRubro { get; set; }
        public DetalleCatalogoResponse Rubro { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }

        //public virtual List<LogFrameIndicadorPRResponse> LogFrameIndicadores { get; set; }

    }
}
