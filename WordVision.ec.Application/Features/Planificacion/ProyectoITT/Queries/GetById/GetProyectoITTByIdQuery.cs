using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Indicadores.Planificacion.Queries.GetById
{
    public class GetProyectoITTByIdQuery : ProyectoITTResponse, IRequest<Result<ProyectoITTResponse>>
    {
    }

    public class GetProyectoITTByIdQueryHandler : IRequestHandler<GetProyectoITTByIdQuery, Result<ProyectoITTResponse>>
    {
        private readonly IProyectoITTRepository _repository;
        private readonly IMapper _mapper;

        public GetProyectoITTByIdQueryHandler(IProyectoITTRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ProyectoITTResponse>> Handle(GetProyectoITTByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<ProyectoITTResponse>(result);

            return Result<ProyectoITTResponse>.Success(response);
        }
    }
}
