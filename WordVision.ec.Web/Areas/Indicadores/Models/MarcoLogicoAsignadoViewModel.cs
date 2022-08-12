using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Models
{
    public class MarcoLogicoAsignadoViewModel : IEquatable<MarcoLogicoAsignadoViewModel>
    {
        public int Id { get; set; }
        public int IdMarcoLogico { get; set; }
        public MarcoLogicoViewModel MarcoLogico { get; set; }
        public bool Asignado { get; set; }
        public int IdProyectoTecnico { get; set; }
        public ProyectoTecnicoViewModel ProyectoTecnico { get; set; }
        public int? IdResponsable { get; set; }
        public ColaboradorViewModel Responsable { get; set; }
        public int IdSupervisor { get; set; }
        public ColaboradorViewModel Supervisor { get; set; }
        public bool Nuevo { get; set; }
        public String Descripcion
        {
            get
            {
                if (MarcoLogico == null) return "";
                var prefijoObj = MarcoLogico.LogFrame.OutPut == "1" ? "Objectivo: " : "";

                var output = prefijoObj + MarcoLogico?.LogFrame?.OutPut ?? "";
                var outcome = MarcoLogico.LogFrame.OutPut != null ? "." + MarcoLogico.LogFrame.OutCome : MarcoLogico.LogFrame.OutCome;
                var activity = MarcoLogico.LogFrame.Activity != null ? "." + MarcoLogico.LogFrame.Activity : MarcoLogico.LogFrame.Activity;

                return output + outcome + activity + " - " + MarcoLogico.IndicadorML.Descripcion + " - " + MarcoLogico.IndicadorML.Codigo;
            }
        }

        public bool EsActividad
        {
            get
            {
                return (MarcoLogico?.LogFrame?.Nivel?.Nombre ?? "") == "Activity";
            }
        }
        public bool EsProducto
        {
            get
            {
                return (MarcoLogico?.LogFrame?.Nivel?.Nombre ?? "") == "Output";
            }
        }
        public bool EsResultado
        {
            get
            {
                return (MarcoLogico?.LogFrame?.Nivel?.Nombre ?? "") == "Outcome";
            }
        }
        public bool EsObjetivo
        {
            get
            {
                return (MarcoLogico?.LogFrame?.Nivel?.Nombre ?? "") == "Goal";
            }
        }



        public bool Equals(MarcoLogicoAsignadoViewModel other)
        {
            return IdMarcoLogico == other.IdMarcoLogico;
        }
        public override int GetHashCode()
        {
            return IdMarcoLogico.GetHashCode();
        }

        public double Poblacion { get; set; }

    }
}
