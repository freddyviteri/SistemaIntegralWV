namespace WordVision.ec.Web.Common.Models
{
    public class GenericCatalog
    {
        public int IdCatalogo { get; set; }
        public string Secuencia { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }

        public int IdEstado { get; set; }
        public int IdAccionOperativa { get; set; }
        public int IdNivel { get; set; }
        public int IdUbicacion { get; set; }
        public int IdFinanciamiento { get; set; }
        public int IdTipoProyecto { get; set; }
        public int IdGenero { get; set; }
        public int IdGrupoEtario { get; set; }        
        public int IdFrecuencia { get; set; }
        public int IdArea { get; set; }
        public int IdTipoMedida { get; set; }
        public int IdTipoIndicador { get; set; }
        public int IdTarget { get; set; }
        public int IdRubro { get; set; }
        public int IdTipoActividad { get; set; }
        public int IdSectorProgramatico { get; set; }
        public int IdFaseProyecto { get; set; }
        public int IdProceso { get; set; }
        public int IdEstadoAnioFiscal { get; set; }

        public int IdProgramaArea { get; set; }
        public int IdProyectoTecnico { get; set; }
        public int IdEtapaModeloProyecto { get; set; }
        public int IdActorParticipante { get; set; }
        public int IdOtroIndicador { get; set; }
        public int IdIndicadorPR { get; set; }
        public int IdLogFrame { get; set; }
    }
}
