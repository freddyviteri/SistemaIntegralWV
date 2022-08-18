using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Delete
{
    public class DeleteEtapaModeloProyectoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteEtapaModeloProyectoCommandHandler : IRequestHandler<DeleteEtapaModeloProyectoCommand, Result<int>>
        {
            private readonly IEtapaModeloProyectoRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEtapaModeloProyectoCommandHandler(IEtapaModeloProyectoRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEtapaModeloProyectoCommand command, CancellationToken cancellationToken)
            {
                var etapaModeloProyecto = await _repository.GetByIdAsync(command.Id, true);
                try
                {
                    await _repository.DeleteAsync(etapaModeloProyecto);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(etapaModeloProyecto.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"La EtapaModeloProyecto con Etapa: {etapaModeloProyecto.Etapa} y Acción Operativa: {etapaModeloProyecto.AccionOperativa.Nombre} no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
