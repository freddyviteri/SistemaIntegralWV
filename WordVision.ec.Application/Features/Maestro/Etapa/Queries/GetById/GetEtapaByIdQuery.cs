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
    public class GetEtapaByIdQuery : EtapaResponse, IRequest<Result<EtapaResponse>>
    {
    }

    public class GetEtapaModeloProyectoByIdQueryHandler : IRequestHandler<GetEtapaByIdQuery, Result<EtapaResponse>>
    {
        private readonly IEtapaRepository _repository;
        private readonly IMapper _mapper;

        public GetEtapaModeloProyectoByIdQueryHandler(IEtapaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<EtapaResponse>> Handle(GetEtapaByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<EtapaResponse>(result);

            return Result<EtapaResponse>.Success(response);
        }
    }
}
