using System;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;

namespace WordVision.ec.Application.Features.Indicadores.FaseProgramaArea
{
    public class FaseProgramaAreaResponse : Domain.Entities.Indicadores.FaseProgramaArea
    {
        public new ProyectoTecnicoResponse ProyectoTecnico { get; set; }

        public new DetalleCatalogoResponse FaseProyecto { get; set; }

        public new DetalleCatalogoResponse Estado { get; set; }


    }
}
