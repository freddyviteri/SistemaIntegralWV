using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Queries.GetProyectosTecnicosDisponiblesQuery
{
    public class GetProyectosTecnicosDisponiblesQuery : ProyectoTecnicoResponse, IRequest<Result<List<ProyectoTecnicoResponse>>>
    {
    }

    public class GetProyectosTecnicosDisponiblesQueryHandler : IRequestHandler<GetProyectosTecnicosDisponiblesQuery, Result<List<ProyectoTecnicoResponse>>>
    {
        private readonly IProyectoTecnicoRepository _repository;
        private readonly IMapper _mapper;

        public GetProyectosTecnicosDisponiblesQueryHandler(IProyectoTecnicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProyectoTecnicoResponse>>> Handle(GetProyectosTecnicosDisponiblesQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.ProyectoTecnico>(request);

            var lista = await _repository.GetAvailableProyectosTecnicosAsync(entity.IdProgramaArea, entity.IdProgramaTecnico);
            var responseList = _mapper.Map<List<ProyectoTecnicoResponse>>(lista);

            return Result<List<ProyectoTecnicoResponse>>.Success(responseList);
        }
    }
}
