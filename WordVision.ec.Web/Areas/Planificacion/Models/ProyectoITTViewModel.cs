using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class ProyectoITTViewModel : Domain.Entities.Planificacion.ProyectoITT
    {
        public int IdProyectoTecnico { get; set; }
        public ProyectoTecnicoViewModel ProyectoTecnico { get; set; }
        public int IdProgramaArea { get; set; }
        public ProgramaAreaViewModel ProgramaArea { get; set; }
        public DateTime FechaFase { get; set; }
        public new FaseProgramaAreaViewModel FaseProgramaArea { get; set; }

        public new List<DetalleProyectoITTViewModel> DetalleProyectoITTs { get; set; }
        public new List<DetalleProyectoITTGoulViewModel> DetalleProyectoITTGouls { get; set; }

        string _nombreproyectofase;
        public string NombreProyectoFase
        {
            get
            {
                _nombreproyectofase = FaseProgramaArea?.ProyectoTecnico?.NombreProyecto + "--" + FaseProgramaArea?.FaseProyecto?.Nombre + "--" + FaseProgramaArea?.Id;
                return _nombreproyectofase;
            }
            set => _nombreproyectofase = value;
        }

        public SelectList ProgramaAreaList { get; set; }
        public SelectList ProyectoTecnicoList { get; set; }

    }

    public class DetalleProyectoITTViewModel : Domain.Entities.Planificacion.DetalleProyectoITT
    {
        public new MarcoLogicoAsignadoViewModel MarcoLogicoAsignado { get; set; }

        public new ProyectoITTViewModel ProyectoITT { get; set; }
    }

    public class DetalleProyectoITTGoulViewModel : Domain.Entities.Planificacion.DetalleProyectoITTGoul
    {
        public new MarcoLogicoAsignadoViewModel MarcoLogicoAsignado { get; set; }

        public new ProyectoITTViewModel ProyectoITT { get; set; }
    }


    public class CabeceraPitt
    {
        public int id { get; set; }

        public int idfapa { get; set; }

        public List<ProyectoDetalleittViewModelHelp> Detalle { get; set; }
        public List<ProyectoDetalleittGoulViewModelHelp> DetalleGoul { get; set; }
    }
    public class ProyectoDetalleittViewModelHelp
    {
        public int Id { get; set; }
        public int IdMarcoLogicoAsignado { get; set; }

        public int IdMarcoLogico { get; set; }
        public int IdLogFrame { get; set; }
        public string OutCome { get; set; }
        public string OutPut { get; set; }
        public string Activity { get; set; }
        public string SumaryObjetives { get; set; }
        public int IdNivel { get; set; }
        public int IdEstado { get; set; }
        public string Cobertura { get; set; }
        public int? IdProgramaTecnico { get; set; }
        public string ProgramaTecnico { get; set; }
        public int? IdTipoActividad { get; set; }
        public string TipoActividad { get; set; }
        public int? IdModeloProyecto { get; set; }
        public string ModeloProyecto { get; set; }
        public string CodigoML { get; set; }
        public string NombreML { get; set; }
        public string Target { get; set; }
        public string Unidad { get; set; }
        public string Frecuencia { get; set; }
        public string Participante { get; set; }
        public string Vindicadores { get; set; }
        public decimal Valorlineabase { get; set; }
        public decimal Valormetaa { get; set; }
        public decimal Valormetab { get; set; }
        public decimal Valormetac { get; set; }
        public decimal Valormetad { get; set; }
        public decimal Valormetae { get; set; }
    }

    public class ProyectoDetalleittGoulViewModelHelp
    {
        public int IdMarcoLogicoAsignado { get; set; }

    }

}
