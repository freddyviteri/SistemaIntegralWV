using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.IndicadorPR.Commands.Delete
{
    public class DeleteIndicadorPRCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteIndicadorPRCommandHandler : IRequestHandler<DeleteIndicadorPRCommand, Result<int>>
        {
            private readonly IIndicadorPRRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteIndicadorPRCommandHandler(IIndicadorPRRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteIndicadorPRCommand command, CancellationToken cancellationToken)
            {
                var indicadorPR = await _repository.GetByIdAsync(command.Id);
                try
                {
                    await _repository.DeleteAsync(indicadorPR);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(indicadorPR.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"El IndicadorPR con Código: {indicadorPR.Codigo} no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
