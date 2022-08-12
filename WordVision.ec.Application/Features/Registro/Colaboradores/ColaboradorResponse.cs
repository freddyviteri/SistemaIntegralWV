using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Registro.Colaboradores
{
    public class ColaboradorResponse
    {
        public int Id { get; set; }
        public string Apellidos { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Identificacion { get; set; }
        public string Email { get; set; }
        public int? Cargo { get; set; }
        public int? Area { get; set; }
        public int? LugarTrabajo { get; set; }
        public string Alias { get; set; }
        public int Estado { get; set; }
        //public List<RespuestaResponse> Respuestas { get; set; }
        //public List<FirmaResponse> Firmas { get; set; }
        //public virtual List<FormularioResponse> Formularios { get; set; }
        //public virtual List<SolicitudResponse> Solicitudes { get; set; }
        public int IdEstructura { get; set; }
        //public EstructuraResponse Estructuras { get; set; }
    }
}
