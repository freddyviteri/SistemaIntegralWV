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

namespace WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Queries.GetAll
{
    public class GetAllEtapaQuery : EtapaResponse, IRequest<Result<List<EtapaResponse>>>
    {
    }

    public class GetAllEtapaModeloProyectoQueryHandler : IRequestHandler<GetAllEtapaQuery, Result<List<EtapaResponse>>>
    {
        private readonly IEtapaRepository _repository;
        private readonly IMapper _mapper;

        public GetAllEtapaModeloProyectoQueryHandler(IEtapaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<EtapaResponse>>> Handle(GetAllEtapaQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.Etapa>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<EtapaResponse>>(list);

            return Result<List<EtapaResponse>>.Success(responseList);
        }
    }
}
