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
    public class UpdateEtapaCommand : EtapaResponse, IRequest<Result<int>>
    {
    }

    public class UpdateEtapaModeloProyectoCommandHandler : IRequestHandler<UpdateEtapaCommand, Result<int>>
    {
        private readonly IEtapaRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateEtapaModeloProyectoCommandHandler(IEtapaRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateEtapaCommand update, CancellationToken cancellationToken)
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
                var listEtaparMP = await ValidateInsert(_mapper.Map<Domain.Entities.Maestro.Etapa>(update));


                etapaModeloProyecto.Codigo = update.Codigo;
                etapaModeloProyecto.IdEstado = update.IdEstado;
                etapaModeloProyecto.Descripcion = update.Descripcion;

                await _repository.UpdateAsync(etapaModeloProyecto);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(etapaModeloProyecto.Id);
            }
        }

        private async Task<List<Domain.Entities.Maestro.Etapa>> ValidateInsert(Domain.Entities.Maestro.Etapa etapaModelo)
        {
            var list = await _repository.GetListAsync(etapaModelo);

            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.Etapa>();

            // Se filtra solo los registros que son diferentes al Id que se va actualizar
            var listFilter = list.FindAll(x => x.Id != etapaModelo.Id);

            return listFilter;

        }
    }
}
