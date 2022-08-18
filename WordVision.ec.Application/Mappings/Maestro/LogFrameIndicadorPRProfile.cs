using AutoMapper;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Commands.Create;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Commands.Update;
using WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class LogFrameIndicadorPRProfile : Profile
    {
        public LogFrameIndicadorPRProfile()
        {
            CreateMap<CreateLogFrameIndicadorPRCommand, LogFrameIndicadorPR>().ReverseMap();
            CreateMap<LogFrameIndicadorPRResponse, LogFrameIndicadorPR>().ReverseMap();
            CreateMap<UpdateLogFrameIndicadorPRCommand, LogFrameIndicadorPR>().ReverseMap();
            CreateMap<GetAllLogFrameIndicadorPRQuery, LogFrameIndicadorPR>().ReverseMap();
        }
       
    }
}
