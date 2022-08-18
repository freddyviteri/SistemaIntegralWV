using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Commands.Delete
{
    public class DeleteLogFrameIndicadorPRCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteLogFrameIndicadorPRCommandHandler : IRequestHandler<DeleteLogFrameIndicadorPRCommand, Result<int>>
        {
            private readonly ILogFrameIndicadorPRRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteLogFrameIndicadorPRCommandHandler(ILogFrameIndicadorPRRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteLogFrameIndicadorPRCommand command, CancellationToken cancellationToken)
            {
                var logFrameIndicadorPR = await _repository.GetByIdAsync(command.Id);
                try
                {
                    await _repository.DeleteAsync(logFrameIndicadorPR);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(logFrameIndicadorPR.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"El LogFrameIndicadorPR con Id: {logFrameIndicadorPR.Id} no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
