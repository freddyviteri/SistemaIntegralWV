using System;
using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.IndicadorPR;
using WordVision.ec.Application.Features.Maestro.LogFrame;
using WordVision.ec.Application.Features.Maestro.OtroIndicador;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;

namespace WordVision.ec.Application.Features.Planificacion.ProyectoITT
{
    public class ProyectoITTResponse : GenericResponse
    {
        public int Id { get; set; }
        public int IdFaseProgramaArea { get; set; }
        public FaseProgramaAreaResponse FaseProgramaArea { get; set; }

       public virtual ICollection<DetalleProyectoITTResponse> DetalleProyectoITTs { get; set; }

    }
}
