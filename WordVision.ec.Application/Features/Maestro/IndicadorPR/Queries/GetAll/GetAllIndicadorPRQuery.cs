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

namespace WordVision.ec.Application.Features.Maestro.IndicadorPR.Queries.GetAll
{
    public class GetAllIndicadorPRQuery : IndicadorPRResponse, IRequest<Result<List<IndicadorPRResponse>>>
    {
    }

    public class GetAllIndicadorPRQueryHandler : IRequestHandler<GetAllIndicadorPRQuery, Result<List<IndicadorPRResponse>>>
    {
        private readonly IIndicadorPRRepository _repository;
        private readonly IMapper _mapper;

        public GetAllIndicadorPRQueryHandler(IIndicadorPRRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<IndicadorPRResponse>>> Handle(GetAllIndicadorPRQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.IndicadorPR>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<IndicadorPRResponse>>(rcPatrocinadoList);

            return Result<List<IndicadorPRResponse>>.Success(responseList);
        }
    }
}
