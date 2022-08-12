using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.IndicadorML.Commands.Update
{
    public class UpdateIndicadorMLCommand : IndicadorMLResponse, IRequest<Result<int>>
    {
    }

    public class UpdateIndicadorMLCommandHandler : IRequestHandler<UpdateIndicadorMLCommand, Result<int>>
    {
        private readonly IIndicadorMLRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateIndicadorMLCommandHandler(IIndicadorMLRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateIndicadorMLCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"Indicador no encontrado.");
            }
            else
            {
                var list = await _repository.GetListAsync(new Domain.Entities.Maestro.IndicadorML());
                if (list.Where(r => r.Codigo == update.Codigo && r.Id != update.Id).Count() > 0)
                    return Result<int>.Fail($"Indicador con Código: {update.Codigo} ya existe.");

                entity.Codigo = update.Codigo;
                entity.Descripcion = update.Descripcion;
                entity.Asunciones = update.Asunciones;
                entity.IncluyeAdvovacy = update.IncluyeAdvovacy;
                entity.CWB = update.CWB;
                entity.InclucionRC = update.InclucionRC;
                entity.MedioVerificacion = update.MedioVerificacion;
                entity.IdFrecuencia = update.IdFrecuencia;
                entity.IdTipoMedida = update.IdTipoMedida;
                entity.IdArea = update.IdArea;
                entity.IdActorParticipante = update.IdActorParticipante;
                entity.IdTarget = update.IdTarget;               
                entity.IdEstado = update.IdEstado;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
