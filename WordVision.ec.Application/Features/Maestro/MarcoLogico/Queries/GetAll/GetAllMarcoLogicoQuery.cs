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

namespace WordVision.ec.Application.Features.Maestro.MarcoLogico.Queries.GetAll
{
    public class GetAllMarcoLogicoQuery : MarcoLogicoResponse, IRequest<Result<List<MarcoLogicoResponse>>>
    {
    }

    public class GetAllMarcoLogicoQueryHandler : IRequestHandler<GetAllMarcoLogicoQuery, Result<List<MarcoLogicoResponse>>>
    {
        private readonly IMarcoLogicoRepository _repository;
        private readonly IMapper _mapper;

        public GetAllMarcoLogicoQueryHandler(IMarcoLogicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<MarcoLogicoResponse>>> Handle(GetAllMarcoLogicoQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.MarcoLogico>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<MarcoLogicoResponse>>(list);

            return Result<List<MarcoLogicoResponse>>.Success(responseList);
        }
    }
}
