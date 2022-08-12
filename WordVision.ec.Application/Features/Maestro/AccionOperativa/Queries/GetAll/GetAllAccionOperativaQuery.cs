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

namespace WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Queries.GetAll
{
    public class GetAllAccionOperativaQuery : AccionOperativaResponse, IRequest<Result<List<AccionOperativaResponse>>>
    {
    }

    public class GetAllAccionOperativaModeloProyectoQueryHandler : IRequestHandler<GetAllAccionOperativaQuery, Result<List<AccionOperativaResponse>>>
    {
        private readonly IAccionOperativaRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAccionOperativaModeloProyectoQueryHandler(IAccionOperativaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<AccionOperativaResponse>>> Handle(GetAllAccionOperativaQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.AccionOperativa>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<AccionOperativaResponse>>(list);

            return Result<List<AccionOperativaResponse>>.Success(responseList);
        }
    }
}
