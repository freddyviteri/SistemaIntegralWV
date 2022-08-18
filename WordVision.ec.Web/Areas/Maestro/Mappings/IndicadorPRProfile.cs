using AutoMapper;
using WordVision.ec.Application.Features.Maestro.IndicadorPR;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Commands.Create;
using WordVision.ec.Application.Features.Maestro.IndicadorPR.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class IndicadorPRProfile : Profile
    {
        public IndicadorPRProfile()
        {            
            CreateMap<IndicadorPRResponse, IndicadorPRViewModel>().ReverseMap();
            CreateMap<CreateIndicadorPRCommand, IndicadorPRViewModel>().ReverseMap();
            CreateMap<UpdateIndicadorPRCommand, IndicadorPRViewModel>().ReverseMap();
        }
        
    }
}
