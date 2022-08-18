namespace WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllPaged
{
    public class GetAllColaboradoresResponse
    {
        public int Id { get; set; }
        public string Apellidos { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string Identificacion { get; set; }
        public int? Cargo { get; set; }

        public int? Area { get; set; }

        public int? LugarTrabajo { get; set; }
        public int Estado { get; set; }
    }
}