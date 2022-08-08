using AutoMapper;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.Features.Donacion.Interaciones.Commands.Create;
using WordVision.ec.Application.Features.Donacion.Interaciones.Commands.Update;
using WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAll;
using WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetById;
using WordVision.ec.Domain.Entities.Donacion;
using WordVision.ec.Web.Areas.Donacion.Models;

namespace WordVision.ec.Web.Areas.Donacion.Mappings
{
    public class InteracionProfile : Profile
    {
        public InteracionProfile()
        {


            CreateMap<CreateInteracionCommand, InteracionViewModel>().ReverseMap();
            CreateMap<UpdateInteracionCommand, InteracionViewModel>().ReverseMap();
            CreateMap<GetInteracionesByIdResponse, InteracionViewModel>().ReverseMap();
            CreateMap<Interacion, InteracionViewModel>().ReverseMap();

            CreateMap<GetAllInteracionesResponse, InteracionListaViewModel>().ReverseMap();

            CreateMap<DebitosInteracionResponse, ListaDebitoInteracionResponseViewModel>().ReverseMap();
        }

    }
}
