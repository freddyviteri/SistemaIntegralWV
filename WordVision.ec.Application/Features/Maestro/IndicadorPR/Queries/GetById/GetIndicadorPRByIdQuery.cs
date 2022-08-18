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

namespace WordVision.ec.Application.Features.Maestro.IndicadorPR.Queries.GetById
{
    public class GetIndicadorPRByIdQuery : IndicadorPRResponse, IRequest<Result<IndicadorPRResponse>>
    {
    }

    public class GetIndicadorPRByIdQueryHandler : IRequestHandler<GetIndicadorPRByIdQuery, Result<IndicadorPRResponse>>
    {
        private readonly IIndicadorPRRepository _repository;
        private readonly IMapper _mapper;

        public GetIndicadorPRByIdQueryHandler(IIndicadorPRRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<IndicadorPRResponse>> Handle(GetIndicadorPRByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<IndicadorPRResponse>(result);

            return Result<IndicadorPRResponse>.Success(response);
        }
    }
}
