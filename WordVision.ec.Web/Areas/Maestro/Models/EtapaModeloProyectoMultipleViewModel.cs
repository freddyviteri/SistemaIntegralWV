using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class EtapaModeloProyectoMultipleViewModel
    {
        public string Etapa { get; set; }

        public List<DetalleCatalogoViewModel> ListaAcciones { get; set; }
    }
}
