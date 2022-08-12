using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Command.Create;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Command.Update;
using WordVision.ec.Web.Areas.Indicadores.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Mappings
{
    public class MarcoLogicoAsignadoProfile : Profile
    {
        public MarcoLogicoAsignadoProfile()
        {
            CreateMap<MarcoLogicoAsignadoResponse, MarcoLogicoAsignadoViewModel>().ReverseMap();
            CreateMap<CreateMarcoLogicoAsignadoCommand, MarcoLogicoAsignadoViewModel>().ReverseMap();
            CreateMap<UpdateMarcoLogicoAsignadoCommand, MarcoLogicoAsignadoViewModel>().ReverseMap();
        }
    }
}
