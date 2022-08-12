using AutoMapper;
using WordVision.ec.Application.Features.Maestro.IndicadorML;
using WordVision.ec.Application.Features.Maestro.IndicadorML.Commands.Create;
using WordVision.ec.Application.Features.Maestro.IndicadorML.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class IndicadorMLProfile : Profile
    {
        public IndicadorMLProfile()
        {            
            CreateMap<IndicadorMLResponse, IndicadorMLViewModel>().ReverseMap();
            CreateMap<CreateIndicadorMLCommand, IndicadorMLViewModel>().ReverseMap();
            CreateMap<UpdateIndicadorMLCommand, IndicadorMLViewModel>().ReverseMap();
        }
        
    }
}
