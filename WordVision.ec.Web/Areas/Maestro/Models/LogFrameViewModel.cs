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
        public int? IdProgramaTecnico { get; set; }
        public ProgramaTecnicoViewModel ProgramaTecnico { get; set; }
        public int? IdIndicadorML { get; set; }
        public IndicadorMLViewModel IndicadorML { get; set; }
        public int? IdTipoActividad { get; set; }
        public DetalleCatalogoViewModel TipoActividad { get; set; }
        public int? IdSectorProgramatico { get; set; }
        public DetalleCatalogoViewModel SectorProgramatico { get; set; }
        public int? IdModeloProyecto { get; set; }
        public ModeloProyectoViewModel ModeloProyecto { get; set; }
        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }
        public virtual List<MarcoLogicoViewModel> MarcoLogicos { get; set; }
        public SelectList NivelList { get; set; }
        public SelectList ProgramaTecnicoList { get; set; }
        public SelectList IndicadorMLList { get; set; }
        public SelectList TipoActividadList { get; set; }
        public SelectList SectorProgramaticoList { get; set; }
        public SelectList ModeloProyectoList { get; set; }
        public SelectList EstadoList { get; set; }
    }
}
