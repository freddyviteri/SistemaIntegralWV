using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Command.Create;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Command.Update;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Queries.GetAll;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Mappings.Indicadores
{
    public class MarcoLogicoAsignadoProfile : Profile
    {
        public MarcoLogicoAsignadoProfile()
        {
            CreateMap<CreateMarcoLogicoAsignadoCommand, MarcoLogicoAsignado>().ReverseMap();
            CreateMap<MarcoLogicoAsignadoResponse, MarcoLogicoAsignado>().ReverseMap();
            CreateMap<UpdateMarcoLogicoAsignadoCommand, MarcoLogicoAsignado>().ReverseMap();
            CreateMap<GetAllMarcoLogicoAsignadoQuery, MarcoLogicoAsignado>().ReverseMap();
        }
    }
}
