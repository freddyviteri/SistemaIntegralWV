using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class ModeloProyectoEtapaAccionProfile : Profile
    {
        public ModeloProyectoEtapaAccionProfile()
        {
            CreateMap<CreateModeloProyectoEtapaAccionCommand, ModeloProyectoEtapaAccion>().ReverseMap();
            CreateMap<ModeloProyectoEtapaAccionResponse, ModeloProyectoEtapaAccion>().ReverseMap();
            CreateMap<UpdateModeloProyectoEtapaAccionCommand, ModeloProyectoEtapaAccion>().ReverseMap();
            CreateMap<GetAllModeloProyectoEtapaAccionQuery, ModeloProyectoEtapaAccion>().ReverseMap();
        }

    }
}
