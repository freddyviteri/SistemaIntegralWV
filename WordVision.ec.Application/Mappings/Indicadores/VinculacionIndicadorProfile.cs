using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Update;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Queries.GetAll;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Mappings.Indicadores
{
    internal class VinculacionIndicadorProfile : Profile
    {
        public VinculacionIndicadorProfile()
        {
            CreateMap<CreateVinculacionIndicadorCommand, VinculacionIndicador>().ReverseMap();
            CreateMap<VinculacionIndicadorResponse, VinculacionIndicador>().ReverseMap();
            CreateMap<UpdateVinculacionIndicadorCommand, VinculacionIndicador>().ReverseMap();
            CreateMap<GetAllVinculacionIndicadorQuery, VinculacionIndicador>().ReverseMap();
            CreateMap<DetalleVinculacionIndicadorResponse, DetalleVinculacionIndicador>().ReverseMap();
        }
       
    }
}
