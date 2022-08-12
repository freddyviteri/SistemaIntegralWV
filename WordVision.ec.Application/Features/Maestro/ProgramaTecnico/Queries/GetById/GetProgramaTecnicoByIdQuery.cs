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

namespace WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Queries.GetById
{
    public class GetProgramaTecnicoByIdQuery : ProgramaTecnicoResponse, IRequest<Result<ProgramaTecnicoResponse>>
    {
    }

    public class GetProyectoTecnicoByIdQueryHandler : IRequestHandler<GetProgramaTecnicoByIdQuery, Result<ProgramaTecnicoResponse>>
    {
        private readonly IProgramaTecnicoRepository _proyectoTecnicoRepository;
        private readonly IMapper _mapper;

        public GetProyectoTecnicoByIdQueryHandler(IProgramaTecnicoRepository proyectoTecnicoRepository, IMapper mapper)
        {
            _proyectoTecnicoRepository = proyectoTecnicoRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProgramaTecnicoResponse>> Handle(GetProgramaTecnicoByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _proyectoTecnicoRepository.GetByIdAsync(query.Id);
            var response = _mapper.Map<ProgramaTecnicoResponse>(result);

            return Result<ProgramaTecnicoResponse>.Success(response);
        }
    }
}
