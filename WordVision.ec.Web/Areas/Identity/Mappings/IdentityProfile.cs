﻿
using AutoMapper;
using WordVision.ec.Application.Features.Identity.Usuarios.Queries.GetById;
using WordVision.ec.Web.Areas.Identity.Models;

namespace WordVision.ec.Web.Areas.Identity.Mappings
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            //CreateMap<GetAllUsuariosCachedResponse, UsuarioViewModel>().ReverseMap();
            CreateMap<GetUsuarioByIdResponse, UsuarioViewModel>().ReverseMap();
            //CreateMap<UpdateUsuarioCommand, UsuarioViewModel>().ReverseMap();

        }
    }
}
