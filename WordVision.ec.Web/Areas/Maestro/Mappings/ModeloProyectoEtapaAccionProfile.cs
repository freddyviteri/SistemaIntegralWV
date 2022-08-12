using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class ModeloProyectoEtapaAccionProfile : Profile
    {
        public ModeloProyectoEtapaAccionProfile()
        {
            CreateMap<ModeloProyectoEtapaAccionResponse, ModeloProyectoEtapaAccionViewModel>().ReverseMap();
            CreateMap<CreateModeloProyectoEtapaAccionCommand, ModeloProyectoEtapaAccionViewModel>().ReverseMap();
            CreateMap<UpdateModeloProyectoEtapaAccionCommand, ModeloProyectoEtapaAccionViewModel>().ReverseMap();
        }

    }
}
