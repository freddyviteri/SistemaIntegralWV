using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.LogFrame;

namespace WordVision.ec.Application.Features.Planificacion.ProyectoITT
{
    public class DetalleProyectoITTResponse : GenericResponse
    {
        public int Id { get; set; }
        public string LineBase { get; set; }

        public decimal MetaAF1 { get; set; }

        public decimal MetaAF2 { get; set; }

        public decimal MetaAF3 { get; set; }

        public decimal MetaAF4 { get; set; }

        public decimal MetaAF5 { get; set; }

        public decimal MetaAF6 { get; set; }

        public int IdLogFrame { get; set; }
        public LogFrameResponse LogFrame { get; set; }

        public int IdProyectoITT { get; set; }
        public ProyectoITTResponse ProyectoITT { get; set; }
    }
}
