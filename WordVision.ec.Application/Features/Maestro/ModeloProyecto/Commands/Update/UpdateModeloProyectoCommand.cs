﻿using AspNetCoreHero.Results;
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

namespace WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Update
{
    public class UpdateModeloProyectoCommand : ModeloProyectoResponse, IRequest<Result<int>>
    {
    }

    public class UpdateModeloProyectoCommandHandler : IRequestHandler<UpdateModeloProyectoCommand, Result<int>>
    {
        private readonly IModeloProyectoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateModeloProyectoCommandHandler(IModeloProyectoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateModeloProyectoCommand update, CancellationToken cancellationToken)
        {
            var modeloProyecto = await _repository.GetByIdAsync(update.Id);

            if (modeloProyecto == null)
            {
                return Result<int>.Fail($"ModeloProyecto no encontrado.");
            }
            else
            {
                // Se valida que la actualización no seleccione una etapa o acción operativa que ya existe
                update.Include = true;

                modeloProyecto.Descripcion = update.Descripcion;
                modeloProyecto.IdEstado = update.IdEstado;
                modeloProyecto.Codigo = update.Codigo;

                await _repository.UpdateAsync(modeloProyecto);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(modeloProyecto.Id);
            }
        }



    }
}
