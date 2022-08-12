using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Queries.GetProgramasTecnicosDsiponiblesQuery
{
    public class GetProgramasTecnicosDsiponiblesQuery : ProyectoTecnicoResponse, IRequest<Result<List<ProgramaTecnicoResponse>>>
    {
    }

    public class GetProgramasTecnicosDsiponiblesQueryHandler : IRequestHandler<GetProgramasTecnicosDsiponiblesQuery, Result<List<ProgramaTecnicoResponse>>>
    {
        private readonly IProyectoTecnicoRepository _repository;
        private readonly IMapper _mapper;

        public GetProgramasTecnicosDsiponiblesQueryHandler(IProyectoTecnicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProgramaTecnicoResponse>>> Handle(GetProgramasTecnicosDsiponiblesQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.ProyectoTecnico>(request);

            var lista = await _repository.GetAvailableProgramasTecnicosAsync(entity.IdProgramaArea);
            var responseList = _mapper.Map<List<ProgramaTecnicoResponse>>(lista);

            return Result<List<ProgramaTecnicoResponse>>.Success(responseList);
        }
    }
}
