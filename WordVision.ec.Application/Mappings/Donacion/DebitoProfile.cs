using AutoMapper;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.Features.Donacion.Debitos.Commands.Create;
using WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById;
using WordVision.ec.Domain.Entities.Donacion;


namespace WordVision.ec.Application.Mappings.Donacion
{
    public class DebitoProfile : Profile
    {

        public DebitoProfile()
        {
            CreateMap<CreateDebitoCommand, Debito>().ReverseMap();
           
            CreateMap<GetAllDebitosResponse, Debito>().ReverseMap();
            CreateMap<GetDebitosByIdResponse, Debito>().ReverseMap();
            CreateMap<DebitoResponse, Debito>().ReverseMap();
            CreateMap<DebitosInteracionResponse, Debito>().ReverseMap();
        }
    }

}
