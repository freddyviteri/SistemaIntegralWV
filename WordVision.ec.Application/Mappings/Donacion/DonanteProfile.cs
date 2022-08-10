using AutoMapper;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.Features.Donacion.Donantes.Commands.Create;
using WordVision.ec.Application.Features.Donacion.Donantes.Commands.Update;
using WordVision.ec.Application.Features.Donacion.Donantes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Donacion.Donantes.Queries.GetById;
using WordVision.ec.Domain.Entities.Donacion;


namespace WordVision.ec.Application.Mappings.Donacion
{
    public class DonanteProfile : Profile
    {

        public DonanteProfile()
        {
            CreateMap<CreateDonanteCommand, Donante>().ReverseMap();
            CreateMap<UpdateDonanteCommand, Donante>().ReverseMap();
            CreateMap<GetAllDonantesResponse, Donante>().ReverseMap();
            CreateMap<GetDonantesByIdResponse, Donante>().ReverseMap();
            CreateMap<ReporteDonantesResponse, Donante>().ReverseMap();
            CreateMap<ReporteDonantesResponse, Debito>().ReverseMap();


        }
    }

}
