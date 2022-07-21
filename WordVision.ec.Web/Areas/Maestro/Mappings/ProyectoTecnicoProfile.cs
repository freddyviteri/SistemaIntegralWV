using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class ProyectoTecnicoProfile : Profile
    {
        public ProyectoTecnicoProfile()
        {            
            CreateMap<ProyectoTecnicoResponse, ProyectoTecnicoViewModel>().ReverseMap();
            CreateMap<CreateProyectoTecnicoCommand, ProyectoTecnicoViewModel>().ReverseMap();
            CreateMap<UpdateProyectoTecnicoCommand, ProyectoTecnicoViewModel>().ReverseMap();
        }
        
    }
}
