using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Commands.Update;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    public class ProyectoITTProfile : Profile
    {
        public ProyectoITTProfile()
        {
            CreateMap<FaseProgramaAreaResponse, FaseProgramaAreaViewModel>().ReverseMap();
            CreateMap<ProyectoITTResponse, ProyectoITTViewModel>().ReverseMap();

            CreateMap<DetalleProyectoITTResponse, DetalleProyectoITTViewModel>().ReverseMap();
            CreateMap<DetalleProyectoITTGoulResponse, DetalleProyectoITTGoulViewModel>().ReverseMap();

            CreateMap<CreateProyectoITTCommand, ProyectoITTViewModel>().ReverseMap();
            CreateMap<UpdateProyectoITTCommand, ProyectoITTViewModel>().ReverseMap();
            CreateMap<UpdateProyectoITTCommand, ProyectoITTResponse>().ReverseMap();
        }
    }
}
