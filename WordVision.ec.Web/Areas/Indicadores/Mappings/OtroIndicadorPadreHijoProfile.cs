using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo;
using WordVision.ec.Web.Areas.Indicadores.Models;
using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Commands.Update;

namespace WordVision.ec.Web.Areas.Indicadores.Mappings
{
    public class OtroIndicadorPadreHijoProfile : Profile
    {
        public OtroIndicadorPadreHijoProfile()
        {
            CreateMap<CreateMultipleOtroIndicadorPadreHijoCommand, VinculacionIndicadorViewModel>().ReverseMap();
            CreateMap<OtroIndicadorPadreHijoResponse, OtroIndicadorPadreHijoViewModel>().ReverseMap();
            CreateMap<CreateOtroIndicadorPadreHijoCommand, OtroIndicadorPadreHijoViewModel>().ReverseMap();
            CreateMap<UpdateOtroIndicadorPadreHijoCommand, OtroIndicadorPadreHijoViewModel>().ReverseMap();
        }
    }
}
