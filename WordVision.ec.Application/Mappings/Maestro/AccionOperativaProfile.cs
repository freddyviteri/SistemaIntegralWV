using AutoMapper;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class AccionOperativaProfile : Profile
    {
        public AccionOperativaProfile()
        {
            CreateMap<CreateAccionOperativaCommand, AccionOperativa>().ReverseMap();
            CreateMap<AccionOperativaResponse, AccionOperativa>().ReverseMap();
            CreateMap<UpdateAccionOperativaCommand, AccionOperativa>().ReverseMap();
            CreateMap<GetAllAccionOperativaQuery, AccionOperativa>().ReverseMap();
        }

    }
}
