using AutoMapper;

using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Create;
using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Update;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Mappings
{
    internal class ColaboradorProfile : Profile
    {
        public ColaboradorProfile()
        {
            CreateMap<GetAllColaboradoresCachedResponse, ColaboradorViewModel>()
                   .ForMember(d => d.Nombres, n => n.MapFrom(x => string.Format("{0} {1} {2} {3}", x.Apellidos, x.ApellidoMaterno, x.PrimerNombre, x.SegundoNombre)))
                   .ReverseMap();
            CreateMap<GetColaboradorByIdResponse, ColaboradorViewModel>().ForMember(d => d.Nombres, n => n.MapFrom(x => string.Format("{0} {1} {2} {3}", x.Apellidos, x.ApellidoMaterno, x.PrimerNombre, x.SegundoNombre)))
                   .ReverseMap();
            CreateMap<CreateColaboradorCommand, ColaboradorViewModel>().ReverseMap();
            CreateMap<UpdateColaboradorCommand, ColaboradorViewModel>().ReverseMap();
        }
    }
}
