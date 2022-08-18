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
    public class GetAllEtapaModeloProyectoQuery : EtapaModeloProyectoResponse, IRequest<Result<List<EtapaModeloProyectoResponse>>>
    {
    }

    public class GetAllEtapaModeloProyectoQueryHandler : IRequestHandler<GetAllEtapaModeloProyectoQuery, Result<List<EtapaModeloProyectoResponse>>>
    {
        private readonly IEtapaModeloProyectoRepository _repository;
        private readonly IMapper _mapper;

        public GetAllEtapaModeloProyectoQueryHandler(IEtapaModeloProyectoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<EtapaModeloProyectoResponse>>> Handle(GetAllEtapaModeloProyectoQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.EtapaModeloProyecto>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<EtapaModeloProyectoResponse>>(list);

            return Result<List<EtapaModeloProyectoResponse>>.Success(responseList);
        }
    }
}
