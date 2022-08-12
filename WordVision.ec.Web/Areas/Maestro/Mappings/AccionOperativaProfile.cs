using AutoMapper;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class AccionOperativaProfile : Profile
    {
        public AccionOperativaProfile()
        {
            CreateMap<AccionOperativaResponse, AccionOperativaViewModel>().ReverseMap();
            CreateMap<CreateAccionOperativaCommand, AccionOperativaViewModel>().ReverseMap();
            CreateMap<UpdateAccionOperativaCommand, AccionOperativaViewModel>().ReverseMap();
        }

    }
}
