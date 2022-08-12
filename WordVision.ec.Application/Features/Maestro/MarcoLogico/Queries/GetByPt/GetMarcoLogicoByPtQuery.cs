using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.MarcoLogico.Queries.GetByPt
{
    public class GetMarcoLogicoByPtQuery : ProgramaTecnicoResponse, IRequest<Result<List<MarcoLogicoResponse>>>
    {
    }

    public class GetMarcoLogicoByPtQueryHandler : IRequestHandler<GetMarcoLogicoByPtQuery, Result<List<MarcoLogicoResponse>>>
    {
        private readonly IMarcoLogicoRepository _repository;
        private readonly IMapper _mapper;

        public GetMarcoLogicoByPtQueryHandler(IMarcoLogicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<MarcoLogicoResponse>>> Handle(GetMarcoLogicoByPtQuery query, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.ProgramaTecnico>(query);
            var list = await _repository.GetByPtAsync(entity);
            var responseList = _mapper.Map<List<MarcoLogicoResponse>>(list);

            return Result<List<MarcoLogicoResponse>>.Success(responseList);
        }
    }
}
