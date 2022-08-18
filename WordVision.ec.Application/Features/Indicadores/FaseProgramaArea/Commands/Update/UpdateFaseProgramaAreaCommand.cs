using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Commands.Update
{
    public class UpdateFaseProgramaAreaCommand : FaseProgramaAreaResponse, IRequest<Result<int>>
    {
    }

    public class UpdateFaseProgramaAreaCommandHandler : IRequestHandler<UpdateFaseProgramaAreaCommand, Result<int>>
    {
        private readonly IFaseProgramaAreaRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateFaseProgramaAreaCommandHandler(IFaseProgramaAreaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateFaseProgramaAreaCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"FaseProgramaArea no encontrada.");
            }
            else
            {

                entity.FechaInicio = update.FechaInicio;
                entity.FechaFin = update.FechaFin;
                entity.Observacion = update.Observacion;
                entity.FechaDisenio = update.FechaDisenio;
                entity.FechaRedisenio = update.FechaRedisenio;
                entity.FechaTransicion = update.FechaTransicion;
                entity.Dip1 = update.Dip1;
                entity.Dip2 = update.Dip2;
                entity.Dip3 = update.Dip3;
                entity.Dip4 = update.Dip4;
                entity.Dip5 = update.Dip5;
                entity.Dip6 = update.Dip6;
                entity.IdProgramaArea = update.IdProgramaArea;
                entity.IdFaseProyecto = update.IdFaseProyecto;
                entity.IdEstado = update.IdEstado;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
