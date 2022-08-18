using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Delete
{
    public class DeleteLogFrameCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteLogFrameCommandHandler : IRequestHandler<DeleteLogFrameCommand, Result<int>>
        {
            private readonly ILogFrameRepository _repository;
            private readonly ILogFrameIndicadorPRRepository _repositoryLFI;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteLogFrameCommandHandler(ILogFrameRepository repository, IUnitOfWork unitOfWork, ILogFrameIndicadorPRRepository repositoryLFI)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
                _repositoryLFI = repositoryLFI;            }

            public async Task<Result<int>> Handle(DeleteLogFrameCommand command, CancellationToken cancellationToken)
            {
                var logFrame = await _repository.GetByIdAsync(command.Id);
                try
                {
                    if(await ValidateDelete(command.Id))
                        return Result<int>.Fail($"El LogFrame con Id: {logFrame.Id} no puede ser eliminado porque se encuentra relacionado.");

                    await _repository.DeleteAsync(logFrame);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(logFrame.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"El LogFrame con Id: {logFrame.Id} no puede ser eliminado porque se encuentra relacionado.");

                }
            }

            private async Task<bool> ValidateDelete(int idLogFrame)
            {
                bool exist = false;
                var list = await _repositoryLFI.GetListAsync(new Domain.Entities.Maestro.LogFrameIndicadorPR());
                var listFilter = list.FindAll(x => x.IdLogFrame == idLogFrame);
                if (listFilter.Count > 0)
                    exist = true;
                return exist;

            }
        }
    }
}
