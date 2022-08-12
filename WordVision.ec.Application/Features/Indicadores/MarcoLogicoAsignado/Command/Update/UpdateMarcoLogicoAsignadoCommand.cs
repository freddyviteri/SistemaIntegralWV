using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Identity;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Command.Update
{
    public class UpdateMarcoLogicoAsignadoCommand : MarcoLogicoAsignadoResponse, IRequest<Result<int>>
    {
    }

    public class UpdateMarcoLogicoAsignadoCommandHandler : IRequestHandler<UpdateMarcoLogicoAsignadoCommand, Result<int>>
    {
        private readonly IMarcoLogicoAsignadoRepository _repository;
        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateMarcoLogicoAsignadoCommandHandler(IMarcoLogicoAsignadoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }



        public async Task<Result<int>> Handle(UpdateMarcoLogicoAsignadoCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"EstadoPorAnioFiscal no encontrada.");
            }
            else
            {
                entity.Poblacion = update.Poblacion;
                entity.Asignado = update.Asignado;
                entity.IdMarcoLogico = update.IdMarcoLogico;
                entity.IdProyectoTecnico = update.IdProyectoTecnico;
                entity.IdResponsable = update.IdResponsable;
                entity.IdSupervisor = update.IdSupervisor;
                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
