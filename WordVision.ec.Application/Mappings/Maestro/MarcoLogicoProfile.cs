using AutoMapper;
using WordVision.ec.Application.Features.Maestro.MarcoLogico;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Commands.Create;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Commands.Update;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class MarcoLogicoProfile : Profile
    {
        public MarcoLogicoProfile()
        {
            CreateMap<CreateMarcoLogicoCommand, MarcoLogico>().ReverseMap();
            CreateMap<MarcoLogicoResponse, MarcoLogico>().ReverseMap();
            CreateMap<UpdateMarcoLogicoCommand, MarcoLogico>().ReverseMap();
            CreateMap<GetAllMarcoLogicoQuery, MarcoLogico>().ReverseMap();
        }
       
    }
}
