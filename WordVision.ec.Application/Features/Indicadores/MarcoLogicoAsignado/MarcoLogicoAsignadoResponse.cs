using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador;
using WordVision.ec.Application.Features.Maestro.MarcoLogico;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllPaged;

namespace WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado
{
    public class MarcoLogicoAsignadoResponse : GenericResponse
    {
        public int Id { get; set; }
        public int IdMarcoLogico { get; set; }
        public MarcoLogicoResponse MarcoLogico { get; set; }
        public int IdProyectoTecnico { get; set; }
        public ProyectoTecnicoResponse ProyectoTecnico { get; set; }
        public int? IdResponsable { get; set; }
        public GetAllColaboradoresResponse Responsable { get; set; }
        public int IdSupervisor { get; set; }
        public GetAllColaboradoresResponse Supervisor { get; set; }
        public bool Asignado { get; set; }
        public double Poblacion { get; set; }

        public List<VinculacionIndicadorResponse> VinculacionIndicadores { get; set; }
    }
}
