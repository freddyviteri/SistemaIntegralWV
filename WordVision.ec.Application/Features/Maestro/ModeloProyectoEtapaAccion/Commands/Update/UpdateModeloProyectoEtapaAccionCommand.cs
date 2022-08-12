using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Commands.Update
{
    public class UpdateModeloProyectoEtapaAccionCommand : ModeloProyectoEtapaAccionResponse, IRequest<Result<int>>
    {
    }

    public class UpdateModeloProyectoEtapaAccionModeloProyectoCommandHandler : IRequestHandler<UpdateModeloProyectoEtapaAccionCommand, Result<int>>
    {
        private readonly IModeloProyectoEtapaAccionRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateModeloProyectoEtapaAccionModeloProyectoCommandHandler(IModeloProyectoEtapaAccionRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateModeloProyectoEtapaAccionCommand update, CancellationToken cancellationToken)
        {
            var ModeloProyectoEtapaAccionModeloProyecto = await _repository.GetByIdAsync(update.Id);

            if (ModeloProyectoEtapaAccionModeloProyecto == null)
            {
                return Result<int>.Fail($"ModeloProyectoEtapaAccionModeloProyecto no encontrado.");
            }
            else
            {
                // Se valida que la actualización no seleccione una ModeloProyectoEtapaAccion o acción operativa que ya existe
                update.Include = true;
                var listModeloProyectoEtapaAccionrMP = await ValidateInsert(_mapper.Map<Domain.Entities.Maestro.ModeloProyectoEtapaAccion>(update));


                ModeloProyectoEtapaAccionModeloProyecto.IdEtapa = update.IdEtapa;
                ModeloProyectoEtapaAccionModeloProyecto.IdAccionOperativa = update.IdAccionOperativa;
                ModeloProyectoEtapaAccionModeloProyecto.IdModeloProyecto = update.IdModeloProyecto;
                ModeloProyectoEtapaAccionModeloProyecto.IdEstado = update.IdEstado;


                await _repository.UpdateAsync(ModeloProyectoEtapaAccionModeloProyecto);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(ModeloProyectoEtapaAccionModeloProyecto.Id);
            }
        }

        private async Task<List<Domain.Entities.Maestro.ModeloProyectoEtapaAccion>> ValidateInsert(Domain.Entities.Maestro.ModeloProyectoEtapaAccion ModeloProyectoEtapaAccionModelo)
        {
            var list = await _repository.GetListAsync(ModeloProyectoEtapaAccionModelo);

            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.ModeloProyectoEtapaAccion>();

            // Se filtra solo los registros que son diferentes al Id que se va actualizar
            var listFilter = list.FindAll(x => x.Id != ModeloProyectoEtapaAccionModelo.Id);

            return listFilter;

        }
    }
}
