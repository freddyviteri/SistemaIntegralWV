using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Update;
using WordVision.ec.Web.Areas.Indicadores.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Mappings
{
    internal class VinculacionIndicadorProfile : Profile
    {
        public VinculacionIndicadorProfile()
        {
            CreateMap<VinculacionIndicadorResponse, VinculacionIndicadorViewModel>().ReverseMap();
            CreateMap<CreateVinculacionIndicadorCommand, VinculacionIndicadorViewModel>().ReverseMap();
            CreateMap<UpdateVinculacionIndicadorCommand, VinculacionIndicadorViewModel>().ReverseMap();
            CreateMap<DetalleVinculacionIndicadorResponse, DetalleVinculacionIndicadorViewModel>().ReverseMap();
        }
    }
}
