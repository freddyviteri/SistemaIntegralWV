using AutoMapper;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Commands.Create;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class LogFrameIndicadorPRProfile : Profile
    {
        public LogFrameIndicadorPRProfile()
        {            
            CreateMap<LogFrameIndicadorPRResponse, LogFrameIndicadorPRViewModel>().ReverseMap();
            CreateMap<CreateLogFrameIndicadorPRCommand, LogFrameIndicadorPRViewModel>().ReverseMap();
            CreateMap<UpdateLogFrameIndicadorPRCommand, LogFrameIndicadorPRViewModel>().ReverseMap();
        }
        
    }
}
