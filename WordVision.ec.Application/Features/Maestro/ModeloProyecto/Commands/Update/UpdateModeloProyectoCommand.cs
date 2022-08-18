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
                var listaValCE = await ValidateInsert(_mapper.Map<Domain.Entities.Maestro.ModeloProyecto>(update));
                if (listaValCE.Count > 0)
                    return Result<int>.Fail($"ModeloProyecto con Código: {update.Codigo} y Etapa: {listaValCE[0].EtapaModeloProyecto.Etapa} ya existe.");

                modeloProyecto.Descripcion = update.Descripcion;
                modeloProyecto.IdEstado = update.IdEstado;
                modeloProyecto.IdEtapaModeloProyecto = update.IdEtapaModeloProyecto;            

                await _repository.UpdateAsync(modeloProyecto);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(modeloProyecto.Id);
            }
        }


        private async Task<List<Domain.Entities.Maestro.ModeloProyecto>> ValidateInsert(Domain.Entities.Maestro.ModeloProyecto modeloProyecto)
        {
            modeloProyecto.Include = true;
            var list = await _repository.GetListAsync(modeloProyecto);
            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.ModeloProyecto>();

            return list.FindAll(x => x.IdEtapaModeloProyecto == modeloProyecto.IdEtapaModeloProyecto && x.Id != modeloProyecto.Id);

        }
    }
}
