using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Queries.GetProgramasAreaDisponiblesQuery
{
    public class GetProgramasAreaDisponiblesQuery : ProyectoTecnicoResponse, IRequest<Result<List<ProgramaAreaResponse>>>
    {
    }

    public class GetProgramasAreaDsiponiblesQueryHandler : IRequestHandler<GetProgramasAreaDisponiblesQuery, Result<List<ProgramaAreaResponse>>>
    {
        private readonly IProyectoTecnicoRepository _repository;
        private readonly IMapper _mapper;

        public GetProgramasAreaDsiponiblesQueryHandler(IProyectoTecnicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProgramaAreaResponse>>> Handle(GetProgramasAreaDisponiblesQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.GetAvailableProgramasAreaAsync();
            var responseList = _mapper.Map<List<ProgramaAreaResponse>>(lista);

            return Result<List<ProgramaAreaResponse>>.Success(responseList);
        }
    }

}
