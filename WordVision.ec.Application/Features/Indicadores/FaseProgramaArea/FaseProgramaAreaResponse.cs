using System;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;

namespace WordVision.ec.Application.Features.Indicadores.FaseProgramaArea
{
    public class FaseProgramaAreaResponse : GenericResponse
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Observacion { get; set; }


        public DateTime FechaDisenio { get; set; }
        public DateTime FechaRedisenio { get; set; }
        public DateTime FechaTransicion { get; set; }

        public string Dip1 { get; set; }

        public string Dip2 { get; set; }

        public string Dip3 { get; set; }

        public string Dip4 { get; set; }

        public string Dip5 { get; set; }

        public string Dip6 { get; set; }

        public int IdProgramaArea { get; set; }
        public ProgramaAreaResponse ProgramaArea { get; set; }

        public int IdProyectoTecnico { get; set; }
        public ProyectoTecnicoResponse ProyectoTecnico { get; set; }

        public int IdFaseProyecto { get; set; }
        public DetalleCatalogoResponse FaseProyecto { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }


    }
}
