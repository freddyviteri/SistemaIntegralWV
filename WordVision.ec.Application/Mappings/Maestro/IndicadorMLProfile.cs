using AutoMapper;
using WordVision.ec.Application.Features.Maestro.IndicadorML;
using WordVision.ec.Application.Features.Maestro.IndicadorML.Commands.Create;
using WordVision.ec.Application.Features.Maestro.IndicadorML.Commands.Update;
using WordVision.ec.Application.Features.Maestro.IndicadorML.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class IndicadorMLProfile : Profile
    {
        public IndicadorMLProfile()
        {
            CreateMap<CreateIndicadorMLCommand, IndicadorML>().ReverseMap();
            CreateMap<IndicadorMLResponse, IndicadorML>().ReverseMap();
            CreateMap<UpdateIndicadorMLCommand, IndicadorML>().ReverseMap();
            CreateMap<GetAllIndicadorMLQuery, IndicadorML>().ReverseMap();
        }
       
    }
}
