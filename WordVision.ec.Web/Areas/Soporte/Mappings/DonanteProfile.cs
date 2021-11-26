﻿using AutoMapper;
using WordVision.ec.Application.Features.Soporte.Donantes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Donantes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetById;
using WordVision.ec.Domain.Entities.Soporte;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Soporte.Mappings
{
    public class DonanteProfile : Profile
    {

        public DonanteProfile()
        {
            CreateMap<CreateDonanteCommand, DonanteViewModel>().ReverseMap();
            CreateMap<UpdateDonanteCommand, DonanteViewModel>().ReverseMap();
            CreateMap<GetAllDonantesResponse, DonanteViewModel>().ReverseMap();
            CreateMap<GetDonantesByIdResponse, DonanteViewModel>().ReverseMap();
            CreateMap<Donante, DonanteViewModel>().ReverseMap();
        }
    }

}
