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

namespace WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Queries.GetByPt
{
    public class GetLogFrameIndicadorPRByPtQuery : LogFrameIndicadorPRResponse, IRequest<Result<List<LogFrameIndicadorPRResponse>>>
    {
        public int IdPt { get; set; }
    }

    public class GetLogFrameIndicadorPRByPtQueryHandler : IRequestHandler<GetLogFrameIndicadorPRByPtQuery, Result<List<LogFrameIndicadorPRResponse>>>
    {
        private readonly ILogFrameIndicadorPRRepository _repository;
        private readonly IMapper _mapper;

        public GetLogFrameIndicadorPRByPtQueryHandler(ILogFrameIndicadorPRRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<LogFrameIndicadorPRResponse>>> Handle(GetLogFrameIndicadorPRByPtQuery query, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.LogFrameIndicadorPR>(query);
            var list = await _repository.GetByPtAsync(entity, query.IdPt);
            var responseList = _mapper.Map<List<LogFrameIndicadorPRResponse>>(list);

            return Result<List<LogFrameIndicadorPRResponse>>.Success(responseList);
        }
    }
}
