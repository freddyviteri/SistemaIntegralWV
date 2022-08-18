using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Update
{
    public class UpdateLogFrameCommand : LogFrameResponse, IRequest<Result<int>>
    {
    }

    public class UpdateLogFrameCommandHandler : IRequestHandler<UpdateLogFrameCommand, Result<int>>
    {
        private readonly ILogFrameRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateLogFrameCommandHandler(ILogFrameRepository repository, IUnitOfWork unitOfWork,
               IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateLogFrameCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id, true);

            if (entity == null)
            {
                return Result<int>.Fail($"LogFrame no encontrado.");
            }
            else
            {
                //await _repository.DeleteLogFrameIndicadorPRAsync(entity.LogFrameIndicadores);
                //var logIndcadores = update.LogFrameIndicadores.Where(l => l.Selected).ToList();
                //entity.LogFrameIndicadores= _mapper.Map<List<LogFrameIndicadorPR>>(logIndcadores);
                entity.OutPut = update.OutPut;
                entity.OutCome = update.OutCome;
                entity.Activity = update.Activity;
                entity.SumaryObjetives = update.SumaryObjetives;
                entity.Cobertura = update.Cobertura;
                entity.IdEstado = update.IdEstado;
                entity.IdNivel = update.IdNivel;
                entity.IdRubro = update.IdRubro;
                entity.IdTipoActividad = update.IdTipoActividad;
                entity.IdSectorProgramatico = update.IdSectorProgramatico;
                entity.IdProyectoTecnico = update.IdProyectoTecnico;
                //entity.IdIndicadorPR = update.IdIndicadorPR;               

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
