using System;
using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.IndicadorPR;
using WordVision.ec.Application.Features.Maestro.LogFrame;
using WordVision.ec.Application.Features.Maestro.OtroIndicador;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;

namespace WordVision.ec.Application.Features.Indicadores.ProyectoITTDIP
{
    public class ProyectoITTDIPResponse : GenericResponse
    {
        public int Id { get; set; }
        public int IdProyectoTecnico { get; set; }
        public ProyectoTecnicoResponse ProyectoTecnico { get; set; }
        public int IdProgramaArea { get; set; }
        public ProgramaAreaResponse ProgramaArea { get; set; }

        public int IdLogFrameOutCome { get; set; }
        public LogFrameResponse LogFrameOutCome { get; set; }

        public virtual ICollection<DetalleProyectoITTDIPResponse> DetalleProyectoITTDIPs { get; set; }

    }
}
