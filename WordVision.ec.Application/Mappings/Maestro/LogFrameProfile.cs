using AutoMapper;
using WordVision.ec.Application.Features.Maestro.LogFrame;
using WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Create;
using WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Update;
using WordVision.ec.Application.Features.Maestro.LogFrame.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class LogFrameProfile : Profile
    {
        public LogFrameProfile()
        {
            CreateMap<CreateLogFrameCommand, LogFrame>().ReverseMap();
            CreateMap<LogFrameResponse, LogFrame>().ReverseMap();
            //CreateMap<LogFrameIndicadorPRResponse, LogFrameIndicadorPR>().ReverseMap();
            CreateMap<UpdateLogFrameCommand, LogFrame>().ReverseMap();
            CreateMap<GetAllLogFrameQuery, LogFrame>().ReverseMap();
        }
       
    }
}
