﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Models
{
    public class VinculacionIndicadorViewModel
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Riesgos { get; set; }

        [StringLength(250)]
        public string PlanNacionalDesarrollo { get; set; }

        [StringLength(10)]
        public string CWB { get; set; }

        public int IdIndicadorPR { get; set; }
        public IndicadorPRViewModel IndicadorPR { get; set; }

        public int IdOtroIndicador { get; set; }
        public OtroIndicadorViewModel OtroIndicador { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public List<OtroIndicadorViewModel> OtrosIndicadores { get; set; }

        public SelectList IndicadorPRList { get; set; }
        public SelectList OtroIndicadorList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}