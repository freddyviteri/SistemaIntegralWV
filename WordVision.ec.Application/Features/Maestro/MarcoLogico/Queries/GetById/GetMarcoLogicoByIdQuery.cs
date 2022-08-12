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

namespace WordVision.ec.Application.Features.Maestro.MarcoLogico.Queries.GetById
{
    public class GetMarcoLogicoByIdQuery : MarcoLogicoResponse, IRequest<Result<MarcoLogicoResponse>>
    {
    }

    public class GetMarcoLogicoByIdQueryHandler : IRequestHandler<GetMarcoLogicoByIdQuery, Result<MarcoLogicoResponse>>
    {
        private readonly IMarcoLogicoRepository _repository;
        private readonly IMapper _mapper;

        public GetMarcoLogicoByIdQueryHandler(IMarcoLogicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<MarcoLogicoResponse>> Handle(GetMarcoLogicoByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id, query.Include);
            var response = _mapper.Map<MarcoLogicoResponse>(result);

            return Result<MarcoLogicoResponse>.Success(response);
        }
    }
}
