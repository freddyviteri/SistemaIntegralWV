using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Commands.Delete
{
    public class DeleteModeloProyectoEtapaAccionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteModeloProyectoEtapaAccionModeloProyectoCommandHandler : IRequestHandler<DeleteModeloProyectoEtapaAccionCommand, Result<int>>
        {
            private readonly IModeloProyectoEtapaAccionRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteModeloProyectoEtapaAccionModeloProyectoCommandHandler(IModeloProyectoEtapaAccionRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteModeloProyectoEtapaAccionCommand command, CancellationToken cancellationToken)
            {
                var ModeloProyectoEtapaAccionModeloProyecto = await _repository.GetByIdAsync(command.Id, true);
                try
                {
                    await _repository.DeleteAsync(ModeloProyectoEtapaAccionModeloProyecto);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(ModeloProyectoEtapaAccionModeloProyecto.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"La ModeloProyectoEtapaAccionModeloProyecto con ModeloProyectoEtapaAccion:  no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
