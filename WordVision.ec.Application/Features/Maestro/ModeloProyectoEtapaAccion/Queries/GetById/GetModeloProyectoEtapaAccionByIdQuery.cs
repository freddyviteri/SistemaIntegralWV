using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Queries.GetById
{
    public class GetModeloProyectoEtapaAccionByIdQuery : ModeloProyectoEtapaAccionResponse, IRequest<Result<ModeloProyectoEtapaAccionResponse>>
    {
    }

    public class GetModeloProyectoEtapaAccionModeloProyectoByIdQueryHandler : IRequestHandler<GetModeloProyectoEtapaAccionByIdQuery, Result<ModeloProyectoEtapaAccionResponse>>
    {
        private readonly IModeloProyectoEtapaAccionRepository _repository;
        private readonly IMapper _mapper;

        public GetModeloProyectoEtapaAccionModeloProyectoByIdQueryHandler(IModeloProyectoEtapaAccionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ModeloProyectoEtapaAccionResponse>> Handle(GetModeloProyectoEtapaAccionByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<ModeloProyectoEtapaAccionResponse>(result);

            return Result<ModeloProyectoEtapaAccionResponse>.Success(response);
        }
    }
}
