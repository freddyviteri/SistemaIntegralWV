using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.MarcoLogico.Commands.Delete
{
    public class DeleteMarcoLogicoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteMarcoLogicoCommandHandler : IRequestHandler<DeleteMarcoLogicoCommand, Result<int>>
        {
            private readonly IMarcoLogicoRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteMarcoLogicoCommandHandler(IMarcoLogicoRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteMarcoLogicoCommand command, CancellationToken cancellationToken)
            {
                var marcoLogico = await _repository.GetByIdAsync(command.Id);
                try
                {
                    await _repository.DeleteAsync(marcoLogico);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(marcoLogico.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"El MarcoLogico con Id: {marcoLogico.Id} no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
