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
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Create
{
    public class CreateLogFrameCommand : LogFrameResponse, IRequest<Result<int>>
    {
    }

    public class CreateLogFrameCommandHandler : IRequestHandler<CreateLogFrameCommand, Result<int>>
    {
        private readonly ILogFrameRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateLogFrameCommandHandler(ILogFrameRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateLogFrameCommand request, CancellationToken cancellationToken)
        {

            //request.LogFrameIndicadores = request.LogFrameIndicadores.Where(l => l.Selected).ToList();
            var logFrame = _mapper.Map<Domain.Entities.Maestro.LogFrame>(request);
            await _repository.InsertAsync(logFrame);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(logFrame.Id);
        }
    }
}
