﻿using AutoMapper;
using WordVision.ec.Application.Features.Registro.Idiomas.Commands.Create;
using WordVision.ec.Application.Features.Registro.Idiomas.Queries.GetById;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Mappings
{
    internal class IdiomaProfile : Profile
    {
        public IdiomaProfile()
        {
            CreateMap<CreateIdiomaCommand, Idioma>().ReverseMap();
            CreateMap<GetByIdResponse, Idioma>().ReverseMap();

        }
    }
}
