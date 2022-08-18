using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common.Models;

namespace WordVision.ec.Web.Common
{
    public class CommonMethods
    {
        public INotyfService _notify;
        public ILogger<object> _logger;

        public SelectList SetGenericCatalog(List<GetListByIdDetalleResponse> items, string valueField)
        {
            List<GenericCatalog> genericCatalogs = new List<GenericCatalog>();
            foreach (GetListByIdDetalleResponse item in items)
                genericCatalogs.Add(new GenericCatalog
                {
                    IdCatalogo = item.IdCatalogo,
                    Secuencia = item.Secuencia,
                    Nombre = $"{item.Secuencia} - {item.Nombre}" ,
                    Estado = item.Estado,

                    IdEstado = item.Id,
                    IdAccionOperativa = item.Id,
                    IdFinanciamiento = item.Id,
                    IdNivel = item.Id,
                    IdTipoProyecto = item.Id,
                    IdUbicacion = item.Id,
                    IdGenero = item.Id,
                    IdGrupoEtario = item.Id,
                    IdFrecuencia = item.Id,
                    IdArea = item.Id,
                    IdTipoMedida = item.Id,
                    IdTipoIndicador = item.Id,
                    IdRubro = item.Id,
                    IdTarget = item.Id,
                    IdSectorProgramatico = item.Id,
                    IdTipoActividad = item.Id,
                    IdFaseProyecto = item.Id,
                    IdProceso = item.Id,
                    IdEstadoAnioFiscal = item.Id,
                });

            return new SelectList(genericCatalogs, valueField, "Nombre");
        }

        public SelectList SetGenericCatalogWithoutIdLabel(List<GetListByIdDetalleResponse> items, string valueField)
        {
            List<GenericCatalog> genericCatalogs = new List<GenericCatalog>();
            foreach (GetListByIdDetalleResponse item in items)
                genericCatalogs.Add(new GenericCatalog
                {
                    IdCatalogo = item.IdCatalogo,
                    Secuencia = item.Secuencia,
                    Nombre = $"{item.Nombre}",
                    Estado = item.Estado,

                    IdEstado = item.Id,
                    IdAccionOperativa = item.Id,
                    IdFinanciamiento = item.Id,
                    IdNivel = item.Id,
                    IdTipoProyecto = item.Id,
                    IdUbicacion = item.Id,
                    IdGenero = item.Id,
                    IdGrupoEtario = item.Id,
                    IdFrecuencia = item.Id,
                    IdArea = item.Id,
                    IdTipoMedida = item.Id,
                    IdTipoIndicador = item.Id,
                    IdRubro = item.Id,
                    IdTarget = item.Id,
                    IdSectorProgramatico = item.Id,
                    IdTipoActividad = item.Id,
                    IdFaseProyecto = item.Id,
                    IdProceso = item.Id,
                    IdEstadoAnioFiscal = item.Id,
                });

            return new SelectList(genericCatalogs, valueField, "Nombre");
        }

        public SelectList SetGenericCatalog(List<ProgramaAreaViewModel> items, string valueField)
        {
            List<GenericCatalog> genericCatalogs = new List<GenericCatalog>();
            foreach (ProgramaAreaViewModel item in items)
                genericCatalogs.Add(new GenericCatalog
                {
                    Nombre = $"{item.Codigo} - {item.Descripcion}",
                    IdProgramaArea = item.Id,
                });

            return new SelectList(genericCatalogs, valueField, "Nombre");
        }

        public SelectList SetGenericCatalog(List<ProyectoTecnicoViewModel> items, string valueField)
        {
            List<GenericCatalog> genericCatalogs = new List<GenericCatalog>();
            foreach (ProyectoTecnicoViewModel item in items)
                genericCatalogs.Add(new GenericCatalog
                {
                    Nombre = $"{item.Codigo} - {item.NombreProyecto}",
                    IdProyectoTecnico = item.Id,
                });

            return new SelectList(genericCatalogs, valueField, "Nombre");
        }

        public SelectList SetGenericCatalog(List<EtapaModeloProyectoViewModel> items, string valueField)
        {
            List<GenericCatalog> genericCatalogs = new List<GenericCatalog>();
            foreach (EtapaModeloProyectoViewModel item in items)
                genericCatalogs.Add(new GenericCatalog
                {
                    Nombre = item.Etapa,
                    IdEtapaModeloProyecto = item.Id
                });

            return new SelectList(genericCatalogs, valueField, "Nombre");
        }

        public SelectList SetGenericCatalog(List<ActorParticipanteViewModel> items, string valueField)
        {
            List<GenericCatalog> genericCatalogs = new List<GenericCatalog>();
            foreach (ActorParticipanteViewModel item in items)
                genericCatalogs.Add(new GenericCatalog
                {
                    Nombre = item.ActoresParticipantes,
                    IdActorParticipante = item.Id
                });

            return new SelectList(genericCatalogs, valueField, "Nombre");
        }

        public SelectList SetGenericCatalog(List<OtroIndicadorViewModel> items, string valueField)
        {
            List<GenericCatalog> genericCatalogs = new List<GenericCatalog>();
            foreach (OtroIndicadorViewModel item in items)
                genericCatalogs.Add(new GenericCatalog
                {
                    Nombre = item.Descripcion,
                    IdOtroIndicador = item.Id
                });

            return new SelectList(genericCatalogs, valueField, "Nombre");
        }

        public SelectList SetGenericCatalog(List<IndicadorPRViewModel> items, string valueField)
        {
            List<GenericCatalog> genericCatalogs = new List<GenericCatalog>();
            foreach (IndicadorPRViewModel item in items)
                genericCatalogs.Add(new GenericCatalog
                {
                    Nombre = $"{item.Codigo} - {item.Descripcion}",
                    IdIndicadorPR = item.Id
                });

            return new SelectList(genericCatalogs, valueField, "Nombre");
        }

        public SelectList SetGenericCatalog(List<LogFrameViewModel> items, string valueField)
        {
            List<GenericCatalog> genericCatalogs = new List<GenericCatalog>();
            foreach (LogFrameViewModel item in items)
                genericCatalogs.Add(new GenericCatalog
                {
                    Nombre = item.SumaryObjetives,
                    IdLogFrame = item.Id
                });

            return new SelectList(genericCatalogs, valueField, "Nombre");
        }

        public SelectList SetGenericCatalogWithCode(List<LogFrameViewModel> items, string valueField)
        {
            List<GenericCatalog> genericCatalogs = new List<GenericCatalog>();
            foreach (LogFrameViewModel item in items)
            {
                item.OutPut = !string.IsNullOrEmpty(item.OutPut) ? $".{item.OutPut}" : "";
                item.Activity = !string.IsNullOrEmpty(item.Activity) ? $".{item.Activity}" : "";
                genericCatalogs.Add(new GenericCatalog
                {
                    Nombre = $"{item.OutCome}{item.OutPut}{item.Activity} - {item.SumaryObjetives}",
                    IdLogFrame = item.Id
                });
            }

            return new SelectList(genericCatalogs, valueField, "Nombre");
        }

        public void SetProperties(INotyfService notify, ILogger<object> logger)
        {
            _notify = notify;
            _logger = logger;
        }
        public JsonResult SaveError(string message, string message2 = "", bool isValid = false)
        {
            string error = message + message2;
            _notify.Error(message);
            _logger.LogError(error);
            return new JsonResult(new { isValid = isValid });
        }

    }
}
