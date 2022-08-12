using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class ProgramaTecnicoProfile : Profile
    {
        public ProgramaTecnicoProfile()
        {
            CreateMap<CreateProgramaTecnicoCommand, ProgramaTecnico>().ReverseMap();
            CreateMap<ProgramaTecnicoResponse, ProgramaTecnico>().ReverseMap();
            CreateMap<UpdateProgramaTecnicoCommand, ProgramaTecnico>().ReverseMap();
            CreateMap<GetAllProgramaTecnicoQuery, ProgramaTecnico>().ReverseMap();
        }

    }
}
