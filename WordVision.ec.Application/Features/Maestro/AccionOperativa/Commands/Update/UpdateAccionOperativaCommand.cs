using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Commands.Update
{
    public class UpdateAccionOperativaCommand : AccionOperativaResponse, IRequest<Result<int>>
    {
    }

    public class UpdateAccionOperativaModeloProyectoCommandHandler : IRequestHandler<UpdateAccionOperativaCommand, Result<int>>
    {
        private readonly IAccionOperativaRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateAccionOperativaModeloProyectoCommandHandler(IAccionOperativaRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateAccionOperativaCommand update, CancellationToken cancellationToken)
        {
            var AccionOperativaModeloProyecto = await _repository.GetByIdAsync(update.Id);

            if (AccionOperativaModeloProyecto == null)
            {
                return Result<int>.Fail($"AccionOperativaModeloProyecto no encontrado.");
            }
            else
            {
                // Se valida que la actualización no seleccione una AccionOperativa o acción operativa que ya existe
                update.Include = true;
                var listAccionOperativarMP = await ValidateInsert(_mapper.Map<Domain.Entities.Maestro.AccionOperativa>(update));


                AccionOperativaModeloProyecto.Codigo = update.Codigo;
                AccionOperativaModeloProyecto.IdEstado = update.IdEstado;
                AccionOperativaModeloProyecto.Descripcion = update.Descripcion;

                await _repository.UpdateAsync(AccionOperativaModeloProyecto);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(AccionOperativaModeloProyecto.Id);
            }
        }

        private async Task<List<Domain.Entities.Maestro.AccionOperativa>> ValidateInsert(Domain.Entities.Maestro.AccionOperativa AccionOperativaModelo)
        {
            var list = await _repository.GetListAsync(AccionOperativaModelo);

            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.AccionOperativa>();

            // Se filtra solo los registros que son diferentes al Id que se va actualizar
            var listFilter = list.FindAll(x => x.Id != AccionOperativaModelo.Id);

            return listFilter;

        }
    }
}
