using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class LogFrameViewModel
    {
        public int Id { get; set; }
        public string OutCome { get; set; }

        public string OutPut { get; set; }

        public string Activity { get; set; }

        public string SumaryObjetives { get; set; }

        public string Cobertura { get; set; }

        public int IdNivel { get; set; }
        public DetalleCatalogoViewModel Nivel { get; set; }

        public int? IdProyectoTecnico { get; set; }
        public ProyectoTecnicoViewModel ProyectoTecnico { get; set; }

        public int? IdIndicadorPR { get; set; }
        public IndicadorPRViewModel IndicadorPR { get; set; }

        public int? IdTipoActividad { get; set; }
        public DetalleCatalogoViewModel TipoActividad { get; set; }

        public int? IdSectorProgramatico { get; set; }
        public DetalleCatalogoViewModel SectorProgramatico { get; set; }

        public int? IdRubro { get; set; }
        public DetalleCatalogoViewModel Rubro { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public virtual List<LogFrameIndicadorPRViewModel> LogFrameIndicadores { get; set; }

        public SelectList NivelList { get; set; }
        public SelectList ProyectoTecnicoList { get; set; }

        public SelectList IndicadorPRList { get; set; }
        public SelectList TipoActividadList { get; set; }
        public SelectList SectorProgramaticoList { get; set; }
        public SelectList RubroList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
