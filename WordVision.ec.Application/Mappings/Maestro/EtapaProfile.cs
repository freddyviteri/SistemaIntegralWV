using AutoMapper;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class EtapaProfile : Profile
    {
        public EtapaProfile()
        {
            CreateMap<CreateEtapaCommand, Etapa>().ReverseMap();
            CreateMap<EtapaResponse, Etapa>().ReverseMap();
            CreateMap<UpdateEtapaCommand, Etapa>().ReverseMap();
            CreateMap<GetAllEtapaQuery, Etapa>().ReverseMap();
        }
       
    }
}
