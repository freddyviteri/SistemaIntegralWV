using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Command.Create;
using WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Command.Update;
using WordVision.ec.Web.Areas.Indicadores.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Mappings
{
    public class ProgramaTecnicoPorProgramaAreaProfile : Profile
    {
        public ProgramaTecnicoPorProgramaAreaProfile()
        {
            CreateMap<ProgramaTecnicoPorProgramaAreaResponse, ProgramaTecnicoPorProgramaAreaViewModel>().ReverseMap();
            CreateMap<CreateProgramaTecnicoPorProgramaAreaCommand, ProgramaTecnicoPorProgramaAreaViewModel>().ReverseMap();
            CreateMap<UpdateProgramaTecnicoPorProgramaAreaCommand, ProgramaTecnicoPorProgramaAreaViewModel>().ReverseMap();
        }
    }
}
