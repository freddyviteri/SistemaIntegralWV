using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Queries.GetAll;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class ProyectoITTProfile : Profile
    {
        public ProyectoITTProfile()
        {
            CreateMap<CreateProyectoITTCommand, ProyectoITT>().ReverseMap();
            CreateMap<ProyectoITTResponse, ProyectoITT>().ReverseMap();
            CreateMap<UpdateProyectoITTCommand, ProyectoITT>().ReverseMap();
            CreateMap<GetAllProyectoITTQuery, ProyectoITT>().ReverseMap();
        }
    }
}
