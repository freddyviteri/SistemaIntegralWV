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
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.ProgramaTecnicoPorProgramaArea.Queries.GetByProyectoTecnico
{
    public class GetAllProgramaTecnicoPorProgramaAreaQuery : ProyectoTecnicoResponse, IRequest<Result<List<ProgramaTecnicoPorProgramaAreaResponse>>>
    {
    }

    public class GetAllProgramaTecnicoPorProgramaAreaHandler : IRequestHandler<GetAllProgramaTecnicoPorProgramaAreaQuery, Result<List<ProgramaTecnicoPorProgramaAreaResponse>>>
    {
        private readonly IProgramaTecnicoPorProgramaAreaRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProgramaTecnicoPorProgramaAreaHandler(IProgramaTecnicoPorProgramaAreaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProgramaTecnicoPorProgramaAreaResponse>>> Handle(GetAllProgramaTecnicoPorProgramaAreaQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.ProyectoTecnico>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<ProgramaTecnicoPorProgramaAreaResponse>>(rcPatrocinadoList);

            return Result<List<ProgramaTecnicoPorProgramaAreaResponse>>.Success(responseList);
        }
    }

}
