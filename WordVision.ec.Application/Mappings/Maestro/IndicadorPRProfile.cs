using AutoMapper;
using WordVision.ec.Application.Features.Maestro.IndicadorPR;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Commands.Create;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Commands.Update;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class IndicadorPRProfile : Profile
    {
        public IndicadorPRProfile()
        {
            CreateMap<CreateIndicadorPRCommand, IndicadorPR>().ReverseMap();
            CreateMap<IndicadorPRResponse, IndicadorPR>().ReverseMap();
            CreateMap<UpdateIndicadorPRCommand, IndicadorPR>().ReverseMap();
            CreateMap<GetAllIndicadorPRQuery, IndicadorPR>().ReverseMap();
        }
       
    }
}
