using AutoMapper;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class EtapaProfile : Profile
    {
        public EtapaProfile()
        {
            CreateMap<EtapaResponse, EtapaViewModel>().ReverseMap();
            CreateMap<CreateEtapaCommand, EtapaViewModel>().ReverseMap();
            CreateMap<UpdateEtapaCommand, EtapaViewModel>().ReverseMap();
        }

    }
}
