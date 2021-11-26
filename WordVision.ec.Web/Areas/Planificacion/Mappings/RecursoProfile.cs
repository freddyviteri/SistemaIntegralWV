﻿using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.Recursos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Recursos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Recursos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    public class RecursoProfile : Profile
    {
        public RecursoProfile()
        {
            CreateMap<CreateRecursoCommand, RecursoViewModel>().ReverseMap();
            CreateMap<GetRecursoByIdResponse, RecursoViewModel>().ReverseMap();
            CreateMap<UpdateRecursoCommand, RecursoViewModel>().ReverseMap();
            CreateMap<FechaCantidadRecursoViewModel, FechaCantidadRecurso>().ReverseMap();
            CreateMap<ActividadViewModel, Actividad>().ReverseMap();
            CreateMap<RecursoViewModel, Recurso>().ReverseMap();

        }
    }
}
