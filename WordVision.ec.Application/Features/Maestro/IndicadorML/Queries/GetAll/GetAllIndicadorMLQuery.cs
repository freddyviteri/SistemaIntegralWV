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

namespace WordVision.ec.Application.Features.Maestro.IndicadorML.Queries.GetAll
{
    public class GetAllIndicadorMLQuery : IndicadorMLResponse, IRequest<Result<List<IndicadorMLResponse>>>
    {
    }

    public class GetAllIndicadorMLQueryHandler : IRequestHandler<GetAllIndicadorMLQuery, Result<List<IndicadorMLResponse>>>
    {
        private readonly IIndicadorMLRepository _repository;
        private readonly IMapper _mapper;

        public GetAllIndicadorMLQueryHandler(IIndicadorMLRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<IndicadorMLResponse>>> Handle(GetAllIndicadorMLQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.IndicadorML>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<IndicadorMLResponse>>(rcPatrocinadoList);

            return Result<List<IndicadorMLResponse>>.Success(responseList);
        }
    }
}
