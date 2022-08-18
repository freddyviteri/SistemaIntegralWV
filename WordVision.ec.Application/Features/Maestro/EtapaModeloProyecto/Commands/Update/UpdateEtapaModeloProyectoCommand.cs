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

namespace WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Update
{
    public class UpdateEtapaModeloProyectoCommand : EtapaModeloProyectoResponse, IRequest<Result<int>>
    {
    }

    public class UpdateEtapaModeloProyectoCommandHandler : IRequestHandler<UpdateEtapaModeloProyectoCommand, Result<int>>
    {
        private readonly IEtapaModeloProyectoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateEtapaModeloProyectoCommandHandler(IEtapaModeloProyectoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateEtapaModeloProyectoCommand update, CancellationToken cancellationToken)
        {
            var etapaModeloProyecto = await _repository.GetByIdAsync(update.Id);

            if (etapaModeloProyecto == null)
            {
                return Result<int>.Fail($"EtapaModeloProyecto no encontrado.");
            }
            else
            {
                // Se valida que la actualización no seleccione una etapa o acción operativa que ya existe
                update.Include = true;
                var listEtaparMP = await ValidateInsert(_mapper.Map<Domain.Entities.Maestro.EtapaModeloProyecto>(update));

                if (listEtaparMP.Count > 0)
                    return Result<int>.Fail($"EtapaModeloPoryecto con Etapa: {update.Etapa} y con Accion Operativa: {listEtaparMP.First().AccionOperativa.Nombre} ya existe.");

                etapaModeloProyecto.IdAccionOperativa = update.IdAccionOperativa;
                etapaModeloProyecto.IdEstado = update.IdEstado;
                etapaModeloProyecto.Etapa = update.Etapa;

                await _repository.UpdateAsync(etapaModeloProyecto);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(etapaModeloProyecto.Id);
            }
        }

        private async Task<List<Domain.Entities.Maestro.EtapaModeloProyecto>> ValidateInsert(Domain.Entities.Maestro.EtapaModeloProyecto etapaModelo)
        {
            var list = await _repository.GetListAsync(etapaModelo);

            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.EtapaModeloProyecto>();

            // Se filtra solo los registros que son diferentes al Id que se va actualizar
            var listFilter = list.FindAll(x => x.Id != etapaModelo.Id);

            return listFilter;

        }
    }
}
