using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Command.Create;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Command.Update;
using WordVision.ec.Web.Areas.Indicadores.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Mappings
{
    public class ProyectoTecnicoPorProgramaAreaProfile : Profile
    {
        public ProyectoTecnicoPorProgramaAreaProfile()
        {
            CreateMap<ProyectoTecnicoPorProgramaAreaResponse, ProyectoTecnicoPorProgramaAreaViewModel>().ReverseMap();
            CreateMap<CreateProyectoTecnicoPorProgramaAreaCommand, ProyectoTecnicoPorProgramaAreaViewModel>().ReverseMap();
            CreateMap<UpdateProyectoTecnicoPorProgramaAreaCommand, ProyectoTecnicoPorProgramaAreaViewModel>().ReverseMap();
        }
    }
}
