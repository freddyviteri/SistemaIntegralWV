using Microsoft.AspNetCore.Mvc.Rendering;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class ProyectoTecnicoViewModel : ProyectoTecnico
    {
        public ProyectoTecnicoViewModel()
        {
            ProgramaArea = new ProgramaAreaViewModel();
            ProgramaTecnico = new ProgramaTecnicoViewModel();
        }
        public new ProgramaAreaViewModel ProgramaArea { get; set; }

        public new ProgramaTecnicoViewModel ProgramaTecnico { get; set; }

        public new DetalleCatalogoViewModel Ubicacion { get; set; }

        public new DetalleCatalogoViewModel Financiamiento { get; set; }
        public new DetalleCatalogoViewModel Estado { get; set; }

        private string _nombreproyecto;
        public override string? NombreProyecto
        {
            get
            {
                _nombreproyecto =ProgramaArea?.Descripcion + " " + ProgramaTecnico?.Nombre;
                return _nombreproyecto;
            }
            set => _nombreproyecto = value;
        }

        public SelectList UbicacionList { get; set; }
        public SelectList FinanciamientoList { get; set; }
        public SelectList EstadoList { get; set; }
        public SelectList ProgramaAreaList { get; set; }
        public SelectList ProgramaTecnicoList { get; set; }

    }
}
