using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Models
{
    public class ProyectoTecnicoPorProgramaAreaViewModel : IEquatable<ProyectoTecnicoPorProgramaAreaViewModel>
    {
        public int Id { get; set; }
        public int IdLogFrameIndicadorPR { get; set; }
        public LogFrameIndicadorPRViewModel LogFrameIndicadorPR { get; set; }
        public bool Asignado { get; set; }
        public bool Nuevo { get; set; }

        public String Descripcion
        {
            get
            {
                if (LogFrameIndicadorPR == null) return "";
                var prefijoObj = LogFrameIndicadorPR.LogFrame.OutPut == "1" ? "Objectivo: " : "";

                var output = prefijoObj + LogFrameIndicadorPR?.LogFrame?.OutPut ?? "";
                var outcome = LogFrameIndicadorPR.LogFrame.OutPut != null ? "." + LogFrameIndicadorPR.LogFrame.OutCome : LogFrameIndicadorPR.LogFrame.OutCome;
                var activity = LogFrameIndicadorPR.LogFrame.Activity != null ? "." + LogFrameIndicadorPR.LogFrame.Activity : LogFrameIndicadorPR.LogFrame.Activity;

                return output + outcome + activity + " - " + LogFrameIndicadorPR.IndicadorPR.Descripcion;
            }
        }

        public bool Equals(ProyectoTecnicoPorProgramaAreaViewModel other)
        {
            return IdLogFrameIndicadorPR == other.IdLogFrameIndicadorPR;
        }

        public override int GetHashCode()
        {
            return IdLogFrameIndicadorPR.GetHashCode();
        }

    }
}
