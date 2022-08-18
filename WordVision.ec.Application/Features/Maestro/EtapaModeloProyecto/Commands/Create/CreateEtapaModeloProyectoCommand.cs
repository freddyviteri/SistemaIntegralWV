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

namespace WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Create
{
    public class CreateEtapaModeloProyectoCommand : EtapaModeloProyectoResponse, IRequest<Result<int>>
    {
    }

    public class CreateEtapaModeloProyectoCommandHandler : IRequestHandler<CreateEtapaModeloProyectoCommand, Result<int>>
    {
        private readonly IEtapaModeloProyectoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateEtapaModeloProyectoCommandHandler(IEtapaModeloProyectoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateEtapaModeloProyectoCommand request, CancellationToken cancellationToken)
        {
            var etapaModeloProyecto = _mapper.Map<Domain.Entities.Maestro.EtapaModeloProyecto>(request);

            // Se valida que no se repita la Etapa y la Acción Operativa
            etapaModeloProyecto.Include = true;
            var listEtaparMP = await ValidateInsert(etapaModeloProyecto);

            if (listEtaparMP.Count > 0)
                return Result<int>.Fail($"EtapaModeloPoryecto con Etapa: {request.Etapa} y con Accion Operativa: {listEtaparMP.First().AccionOperativa.Nombre} ya existe.");

            await _repository.InsertAsync(etapaModeloProyecto);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(etapaModeloProyecto.Id);
        }

        private async Task<List<Domain.Entities.Maestro.EtapaModeloProyecto>> ValidateInsert(Domain.Entities.Maestro.EtapaModeloProyecto etapaModelo)
        {
            var list = await _repository.GetListAsync(etapaModelo);

            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.EtapaModeloProyecto>();

            return list;

        }
    }
}
