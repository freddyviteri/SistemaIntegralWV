using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class ProyectoITTViewModel
    {
        public int Id { get; set; }
        public int IdProyectoTecnico { get; set; }
        public ProyectoTecnicoViewModel ProyectoTecnico { get; set; }

        public int IdProgramaArea { get; set; }
        public ProgramaAreaViewModel ProgramaArea { get; set; }

        public DateTime FechaFase { get; set; }

        //public int IdFaseProyecto { get; set; }

        public FaseProgramaAreaViewModel FaseProgramaAreaViewModel { get; set; }

        //public virtual ICollection<DetalleProyectoITTViewModel> DetalleProyectoITTs { get; set; }
        //Todo: faltaria fase por area y en las demas entidades

        public SelectList ProgramaAreaList { get; set; }
        public SelectList ProyectoTecnicoList { get; set; }

        public List<ProyectoITTViewModel> ListProyectoITTViewModel { get; set; }
    }

    
}
