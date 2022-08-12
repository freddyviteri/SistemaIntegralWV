using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class ProgramaTecnicoProfile : Profile
    {
        public ProgramaTecnicoProfile()
        {
            CreateMap<ProgramaTecnicoResponse, ProgramaTecnicoViewModel>().ReverseMap();
            CreateMap<CreateProgramaTecnicoCommand, ProgramaTecnicoViewModel>().ReverseMap();
            CreateMap<UpdateProgramaTecnicoCommand, ProgramaTecnicoViewModel>().ReverseMap();
        }

    }
}
