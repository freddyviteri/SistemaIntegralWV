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

namespace WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Queries.GetById
{
    public class GetLogFrameIndicadorPRByIdQuery : LogFrameIndicadorPRResponse, IRequest<Result<LogFrameIndicadorPRResponse>>
    {
    }

    public class GetLogFrameIndicadorPRByIdQueryHandler : IRequestHandler<GetLogFrameIndicadorPRByIdQuery, Result<LogFrameIndicadorPRResponse>>
    {
        private readonly ILogFrameIndicadorPRRepository _repository;
        private readonly IMapper _mapper;

        public GetLogFrameIndicadorPRByIdQueryHandler(ILogFrameIndicadorPRRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<LogFrameIndicadorPRResponse>> Handle(GetLogFrameIndicadorPRByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id, query.Include);
            var response = _mapper.Map<LogFrameIndicadorPRResponse>(result);

            return Result<LogFrameIndicadorPRResponse>.Success(response);
        }
    }
}
