using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class ModeloProyectoMultipleViewModel
    {

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public List<EtapaModeloProyectoViewModel> EtapaModeloProyectos { get; set; }


    }
}
