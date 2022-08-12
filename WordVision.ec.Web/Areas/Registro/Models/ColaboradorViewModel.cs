using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Registro.Models
{
    public class ColaboradorViewModel
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
        public ICollection<RespuestaViewModel> Respuestas { get; set; }
        public ICollection<FirmaViewModel> Firmas { get; set; }
        public virtual ICollection<FormularioViewModel> Formularios { get; set; }
        public virtual ICollection<SolicitudViewModel> Solicitudes { get; set; }
        public int IdEstructura { get; set; }
        public EstructuraViewModel Estructuras { get; set; }
        public SelectList CargoList { get; set; }
        public SelectList AreaList { get; set; }
        public SelectList LugarTrabajoList { get; set; }
        public string ActPoliticas { get; set; }
        public string ActDocumentos { get; set; }
        public string ActDatos { get; set; }
        public string Nombres { get; set; }
        public SelectList EstadoList { get; set; }
        public List<FormularioTerceroViewModel> FormularioTerceros { get; set; }
        //public virtual List<FormularioViewModel> Formularios { get; set; }
        public string NombresCompletos
        {
            get
            {
                return Apellidos + " " + ApellidoMaterno + " " + PrimerNombre + " " + SegundoNombre;
            }
        }

    }
}
