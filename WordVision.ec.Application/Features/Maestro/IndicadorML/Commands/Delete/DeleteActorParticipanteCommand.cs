using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.IndicadorML.Commands.Delete
{
    public class DeleteIndicadorMLCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteIndicadorMLCommandHandler : IRequestHandler<DeleteIndicadorMLCommand, Result<int>>
        {
            private readonly IIndicadorMLRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteIndicadorMLCommandHandler(IIndicadorMLRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteIndicadorMLCommand command, CancellationToken cancellationToken)
            {
                var indicadorML = await _repository.GetByIdAsync(command.Id);
                try
                {
                    await _repository.DeleteAsync(indicadorML);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(indicadorML.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"El IndicadorML con Código: {indicadorML.Codigo} no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
