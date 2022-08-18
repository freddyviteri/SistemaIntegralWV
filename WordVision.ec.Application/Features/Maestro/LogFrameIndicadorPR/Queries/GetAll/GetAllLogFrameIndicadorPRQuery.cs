using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Queries.GetAll
{
    public class GetAllLogFrameIndicadorPRQuery : LogFrameIndicadorPRResponse, IRequest<Result<List<LogFrameIndicadorPRResponse>>>
    {
    }

    public class GetAllLogFrameIndicadorPRQueryHandler : IRequestHandler<GetAllLogFrameIndicadorPRQuery, Result<List<LogFrameIndicadorPRResponse>>>
    {
        private readonly ILogFrameIndicadorPRRepository _repository;
        private readonly IMapper _mapper;

        public GetAllLogFrameIndicadorPRQueryHandler(ILogFrameIndicadorPRRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<LogFrameIndicadorPRResponse>>> Handle(GetAllLogFrameIndicadorPRQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.LogFrameIndicadorPR>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<LogFrameIndicadorPRResponse>>(list);

            return Result<List<LogFrameIndicadorPRResponse>>.Success(responseList);
        }
    }
}
