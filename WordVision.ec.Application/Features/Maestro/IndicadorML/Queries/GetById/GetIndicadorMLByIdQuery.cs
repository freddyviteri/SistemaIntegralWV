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

namespace WordVision.ec.Application.Features.Maestro.IndicadorML.Queries.GetById
{
    public class GetIndicadorMLByIdQuery : IndicadorMLResponse, IRequest<Result<IndicadorMLResponse>>
    {
    }

    public class GetIndicadorMLByIdQueryHandler : IRequestHandler<GetIndicadorMLByIdQuery, Result<IndicadorMLResponse>>
    {
        private readonly IIndicadorMLRepository _repository;
        private readonly IMapper _mapper;

        public GetIndicadorMLByIdQueryHandler(IIndicadorMLRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<IndicadorMLResponse>> Handle(GetIndicadorMLByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<IndicadorMLResponse>(result);

            return Result<IndicadorMLResponse>.Success(response);
        }
    }
}
