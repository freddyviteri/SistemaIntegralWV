using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class ProyectoTecnicoProfile : Profile
    {
        public ProyectoTecnicoProfile()
        {
            CreateMap<CreateProyectoTecnicoCommand, ProyectoTecnico>().ReverseMap();
            CreateMap<ProyectoTecnicoResponse, ProyectoTecnico>().ReverseMap();
            CreateMap<UpdateProyectoTecnicoCommand, ProyectoTecnico>().ReverseMap();
            CreateMap<GetAllProyectoTecnicoQuery, ProyectoTecnico>().ReverseMap();
        }
       
    }
}
