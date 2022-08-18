using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Command.Create;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Command.Update;
using WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Queries.GetByProyectoTecnico;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Mappings.Indicadores
{
    public class ProyectoTecnicoPorProgramaAreaProfile : Profile
    {
        public ProyectoTecnicoPorProgramaAreaProfile()
        {
            CreateMap<CreateProyectoTecnicoPorProgramaAreaCommand, ProyectoTecnicoPorProgramaArea>().ReverseMap();
            CreateMap<ProyectoTecnicoPorProgramaAreaResponse, ProyectoTecnicoPorProgramaArea>().ReverseMap();
            CreateMap<UpdateProyectoTecnicoPorProgramaAreaCommand, ProyectoTecnicoPorProgramaArea>().ReverseMap();
            CreateMap<GetAllProyectoTecnicoPorProgramaAreaQuery, ProyectoTecnicoPorProgramaArea>().ReverseMap();
        }
    }
}
