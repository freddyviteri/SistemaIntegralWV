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

namespace WordVision.ec.Application.Features.Maestro.LogFrame.Queries.GetAll
{
    public class GetListLogFrameFromNivel : LogFrameResponse, IRequest<Result<List<LogFrameResponse>>>
    {
    }

    public class GetListLogFrameFromNivelHandler : IRequestHandler<GetListLogFrameFromNivel, Result<List<LogFrameResponse>>>
    {
        private readonly ILogFrameRepository _repository;
        private readonly IMapper _mapper;

        public GetListLogFrameFromNivelHandler(ILogFrameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<List<LogFrameResponse>>> Handle(GetListLogFrameFromNivel request, CancellationToken cancellationToken)
        {
            //var entity = _mapper.Map<Domain.Entities.Maestro.LogFrame>(request);
            var list = await _repository.ListaLogFrameFromNivel(request.IdProgramaTecnico.Value, request.ids);
            var responseList = _mapper.Map<List<LogFrameResponse>>(list);

            return Result<List<LogFrameResponse>>.Success(responseList);
        }
    }
}