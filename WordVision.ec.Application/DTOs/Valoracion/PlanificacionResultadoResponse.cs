﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.DTOs.Valoracion
{
    public class ObjetivoResponse
    {
        public int IdColaborador { get; set; }
        public int IdObjetivo { get; set; }
        public string NombreObjetivo { get; set; }
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public int? EstadoProceso { get; set; }
        public string DescEstadoProceso { get; set; }
        public int Perfil { get; set; }
        public string ComentarioColaborador { get; set; }
        public string ComentarioLider1 { get; set; }
        public string ComentarioLider2 { get; set; }
        public string ComentarioLiderMatricial { get; set; }
        public decimal? ValorValoracionFinal { get; set; }
        public string ValoracionFinal { get; set; }
        public string ValoracionLider1 { get; set; }
        public List<ObjetivoAnioFiscalResponse> AnioFiscales { get; set; }
        public decimal PonderacionObjetivo { get; set; }

        
    }
    public class ObjetivoAnioFiscalResponse
    {
        public int Id { get; set; }
        public int AnioFiscal { get; set; }
        public decimal Ponderacion { get; set; }
        public int IdObjetivo { get; set; }
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public decimal? ValorValoracionFinal { get; set; }
        public List<PlanificacionResultadoResponse> PlanificacionResultados { get; set; }
    }
    public class PlanificacionResultadoResponse
    {
        
        public int IdResultado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EsObligatorio { get; set; }
        public string Indicador { get; set; }
        public int Tipo { get; set; }
        public int TipoObjetivo { get; set; }
        public int IdColaborador { get; set; }
        public int IdPlanificacion { get; set; }
        public decimal? Meta { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? Ponderacion { get; set; }
        public string DatoManual1 { get; set; }
        public int IdObjetivoAnioFiscal { get; set; }
        public string DatoManual2 { get; set; }
        public int DatoManual3 { get; set; }
        public int Estado { get; set; }
        public string DescEstado { get; set; }
        public string ObservacionLider { get; set; }
        public string NombreColaborador { get; set; }
        public DateTime? FechaCumplimiento { get; set; }
        public decimal? PorcentajeCumplimiento { get; set; }
        public decimal? PonderacionResultado { get; set; }
        public List<ComportamientoResponse> Comportamientos { get; set; }
}
}
