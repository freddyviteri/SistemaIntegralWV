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

namespace WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Command.Update
{
    public class UpdateProyectoTecnicoPorProgramaAreaCommand : ProyectoTecnicoPorProgramaAreaResponse, IRequest<Result<int>>
    {
    }

    public class UpdateProyectoTecnicoPorProgramaAreaCommandHandler : IRequestHandler<UpdateProyectoTecnicoPorProgramaAreaCommand, Result<int>>
    {
        private readonly IProyectoTecnicoPorProgramaAreaRepository _repository;
        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateProyectoTecnicoPorProgramaAreaCommandHandler(IProyectoTecnicoPorProgramaAreaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }



        public async Task<Result<int>> Handle(UpdateProyectoTecnicoPorProgramaAreaCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"EstadoPorAnioFiscal no encontrada.");
            }
            else
            {
                entity.Asignado = update.Asignado;
                entity.IdLogFrameIndicadorPR = update.IdLogFrameIndicadorPR;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
