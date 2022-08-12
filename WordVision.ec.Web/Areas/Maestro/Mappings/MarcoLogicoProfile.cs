using AutoMapper;
using WordVision.ec.Application.Features.Maestro.MarcoLogico;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Commands.Create;
using WordVision.ec.Application.Features.Maestro.MarcoLogico.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class MarcoLogicoProfile : Profile
    {
        public MarcoLogicoProfile()
        {            
            CreateMap<MarcoLogicoResponse, MarcoLogicoViewModel>().ReverseMap();
            CreateMap<CreateMarcoLogicoCommand, MarcoLogicoViewModel>().ReverseMap();
            CreateMap<UpdateMarcoLogicoCommand, MarcoLogicoViewModel>().ReverseMap();
        }
        
    }
}
