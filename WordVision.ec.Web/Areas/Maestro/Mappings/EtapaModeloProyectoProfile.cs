using AutoMapper;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class EtapaModeloProyectoProfile : Profile
    {
        public EtapaModeloProyectoProfile()
        {            
            CreateMap<EtapaModeloProyectoResponse, EtapaModeloProyectoViewModel>().ReverseMap();
            CreateMap<CreateEtapaModeloProyectoCommand, EtapaModeloProyectoViewModel>().ReverseMap();
            CreateMap<UpdateEtapaModeloProyectoCommand, EtapaModeloProyectoViewModel>().ReverseMap();
        }
        
    }
}
