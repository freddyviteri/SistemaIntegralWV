using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Command.Create;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Command.Update;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Queries.GetByProyectoTecnico;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Mappings.Indicadores
{
    public class ProgramaTecnicoPorProgramaAreaProfile : Profile
    {
        public ProgramaTecnicoPorProgramaAreaProfile()
        {
            CreateMap<CreateProgramaTecnicoPorProgramaAreaCommand, ProgramaTecnicoPorProgramaArea>().ReverseMap();
            CreateMap<ProgramaTecnicoPorProgramaAreaResponse, ProgramaTecnicoPorProgramaArea>().ReverseMap();
            CreateMap<UpdateProgramaTecnicoPorProgramaAreaCommand, ProgramaTecnicoPorProgramaArea>().ReverseMap();
            CreateMap<GetAllProgramaTecnicoPorProgramaAreaQuery, ProgramaTecnicoPorProgramaArea>().ReverseMap();
        }
    }
}
