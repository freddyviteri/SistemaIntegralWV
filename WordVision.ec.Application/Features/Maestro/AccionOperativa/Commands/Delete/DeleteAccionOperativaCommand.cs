using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Commands.Delete
{
    public class DeleteAccionOperativaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteAccionOperativaModeloProyectoCommandHandler : IRequestHandler<DeleteAccionOperativaCommand, Result<int>>
        {
            private readonly IAccionOperativaRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteAccionOperativaModeloProyectoCommandHandler(IAccionOperativaRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteAccionOperativaCommand command, CancellationToken cancellationToken)
            {
                var AccionOperativaModeloProyecto = await _repository.GetByIdAsync(command.Id, true);
                try
                {
                    await _repository.DeleteAsync(AccionOperativaModeloProyecto);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(AccionOperativaModeloProyecto.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"La AccionOperativaModeloProyecto con AccionOperativa:  no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
