using AutoMapper;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class EtapaModeloProyectoProfile : Profile
    {
        public EtapaModeloProyectoProfile()
        {
            CreateMap<CreateEtapaModeloProyectoCommand, EtapaModeloProyecto>().ReverseMap();
            CreateMap<EtapaModeloProyectoResponse, EtapaModeloProyecto>().ReverseMap();
            CreateMap<UpdateEtapaModeloProyectoCommand, EtapaModeloProyecto>().ReverseMap();
            CreateMap<GetAllEtapaModeloProyectoQuery, EtapaModeloProyecto>().ReverseMap();
        }
       
    }
}
