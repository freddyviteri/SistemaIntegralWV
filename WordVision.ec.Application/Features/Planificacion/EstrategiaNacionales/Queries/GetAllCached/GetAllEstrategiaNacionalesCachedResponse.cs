﻿using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetAllCached
{
    public class GetAllEstrategiaNacionalesCachedResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Programa { get; set; }
        public string Cwbo { get; set; }
        public string MetaRegional { get; set; }
        public string MetaNacional { get; set; }
        public int IdEmpresa { get; set; }
        public string Estado { get; set; }
        public string DescEstado { get; set; }
        public string FactorCritico { get; set; }
        public string Indicador { get; set; }
        public virtual List<Gestion> Gestiones { get; set; }
        public virtual List<ObjetivoEstrategico> ObjetivoEstrategicos { get; set; }
        public virtual List<IndicadorCicloEstrategico> IndicadorCicloEstrategicos { get; set; }
    }
}