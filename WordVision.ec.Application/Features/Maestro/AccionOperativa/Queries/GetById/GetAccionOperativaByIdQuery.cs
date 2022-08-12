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

namespace WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Queries.GetById
{
    public class GetAccionOperativaByIdQuery : AccionOperativaResponse, IRequest<Result<AccionOperativaResponse>>
    {
    }

    public class GetAccionOperativaModeloProyectoByIdQueryHandler : IRequestHandler<GetAccionOperativaByIdQuery, Result<AccionOperativaResponse>>
    {
        private readonly IAccionOperativaRepository _repository;
        private readonly IMapper _mapper;

        public GetAccionOperativaModeloProyectoByIdQueryHandler(IAccionOperativaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<AccionOperativaResponse>> Handle(GetAccionOperativaByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<AccionOperativaResponse>(result);

            return Result<AccionOperativaResponse>.Success(response);
        }
    }
}
