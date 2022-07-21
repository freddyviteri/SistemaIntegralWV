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

namespace WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Queries.GetAll
{
    public class GetAllProgramaTecnicoQuery : ProgramaTecnicoResponse, IRequest<Result<List<ProgramaTecnicoResponse>>>
    {
    }

    public class GetAllProyectoTecnicoQueryHandler : IRequestHandler<GetAllProgramaTecnicoQuery, Result<List<ProgramaTecnicoResponse>>>
    {
        private readonly IProgramaTecnicoRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProyectoTecnicoQueryHandler(IProgramaTecnicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProgramaTecnicoResponse>>> Handle(GetAllProgramaTecnicoQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.ProgramaTecnico>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<ProgramaTecnicoResponse>>(rcPatrocinadoList);

            return Result<List<ProgramaTecnicoResponse>>.Success(responseList);
        }
    }
}
