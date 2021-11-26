﻿using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class IndicadorCicloEstrategicoViewModel
    {
        public int Id { get; set; }
        public string IndicadorCiclo { get; set; }
        public int IdEstrategia { get; set; }
        public ICollection<MetaCicloEstrategicoViewModel> MetaCicloEstrategicos { get; set; }
    }
}
