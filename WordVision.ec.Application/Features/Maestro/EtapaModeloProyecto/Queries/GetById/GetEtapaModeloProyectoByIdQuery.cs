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

namespace WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Queries.GetById
{
    public class GetEtapaModeloProyectoByIdQuery : EtapaModeloProyectoResponse, IRequest<Result<EtapaModeloProyectoResponse>>
    {
    }

    public class GetEtapaModeloProyectoByIdQueryHandler : IRequestHandler<GetEtapaModeloProyectoByIdQuery, Result<EtapaModeloProyectoResponse>>
    {
        private readonly IEtapaModeloProyectoRepository _repository;
        private readonly IMapper _mapper;

        public GetEtapaModeloProyectoByIdQueryHandler(IEtapaModeloProyectoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<EtapaModeloProyectoResponse>> Handle(GetEtapaModeloProyectoByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<EtapaModeloProyectoResponse>(result);

            return Result<EtapaModeloProyectoResponse>.Success(response);
        }
    }
}
