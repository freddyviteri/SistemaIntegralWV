﻿using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Update
{
    public class UpdateVinculacionIndicadorCommand : VinculacionIndicadorResponse, IRequest<Result<int>>
    {
    }

    public class UpdateVinculacionIndicadorCommandHandler : IRequestHandler<UpdateVinculacionIndicadorCommand, Result<int>>
    {
        private readonly IVinculacionIndicadorRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateVinculacionIndicadorCommandHandler(IVinculacionIndicadorRepository repository,
               IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateVinculacionIndicadorCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id, true);

            if (entity == null)
            {
                return Result<int>.Fail($"VinculacionIndicador no encontrada.");
            }
            else
            {
                entity.IdEstado = update.IdEstado;
                entity.IdMarcoLogico = update.IdMarcoLogico;
                entity.IdOtroIndicador = update.IdOtroIndicador;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
