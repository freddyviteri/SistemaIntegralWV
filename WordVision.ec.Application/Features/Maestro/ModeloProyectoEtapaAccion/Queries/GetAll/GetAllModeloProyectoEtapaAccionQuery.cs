using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Queries.GetAll
{
    public class GetAllModeloProyectoEtapaAccionQuery : ModeloProyectoEtapaAccionResponse, IRequest<Result<List<ModeloProyectoEtapaAccionResponse>>>
    {
    }

    public class GetAllModeloProyectoEtapaAccionModeloProyectoQueryHandler : IRequestHandler<GetAllModeloProyectoEtapaAccionQuery, Result<List<ModeloProyectoEtapaAccionResponse>>>
    {
        private readonly IModeloProyectoEtapaAccionRepository _repository;
        private readonly IMapper _mapper;

        public GetAllModeloProyectoEtapaAccionModeloProyectoQueryHandler(IModeloProyectoEtapaAccionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ModeloProyectoEtapaAccionResponse>>> Handle(GetAllModeloProyectoEtapaAccionQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.ModeloProyectoEtapaAccion>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<ModeloProyectoEtapaAccionResponse>>(list);

            return Result<List<ModeloProyectoEtapaAccionResponse>>.Success(responseList);
        }
    }
}
