using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto
{
    public class ModeloProyectoEtapaAccionResponse : ModeloProyectoEtapaAccion, IGenericResponse
    {
        public new AccionOperativaResponse AccionOperativa { get; set; }
        public new EtapaResponse Etapa { get; set; }
        public new ModeloProyectoResponse ModeloProyecto { get; set; }
        public new DetalleCatalogoResponse Estado { get; set; }

        public List<ModeloProyectoEtapaAccionResponse> ListModeloProyectoEtapaAccionResponse { get; set; }

    }
}
