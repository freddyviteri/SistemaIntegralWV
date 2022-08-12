using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Commands.Update;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Queries.GetAll;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Queries.GetById;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Mappings.Indicadores
{
    public class OtroIndicadorPadreHijoProfile : Profile
    {
        public OtroIndicadorPadreHijoProfile()
        {
            CreateMap<CreateOtroIndicadorPadreHijoCommand, OtroIndicadorPadreHijo>().ReverseMap();
            CreateMap<OtroIndicadorPadreHijoResponse, OtroIndicadorPadreHijo>().ReverseMap();
            CreateMap<UpdateOtroIndicadorPadreHijoCommand, OtroIndicadorPadreHijo>().ReverseMap();
            CreateMap<GetAllOtroIndicadorPadreHijoQuery, OtroIndicadorPadreHijo>().ReverseMap();
            CreateMap<GetOtroIndicadorPadreHijoByIdQuery, OtroIndicadorPadreHijo>().ReverseMap();
        }
    }
}
