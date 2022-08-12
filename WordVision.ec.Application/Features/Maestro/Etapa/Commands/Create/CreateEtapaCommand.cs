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
    public class CreateEtapaCommand : EtapaResponse, IRequest<Result<int>>
    {
    }

    public class CreateEtapaModeloProyectoCommandHandler : IRequestHandler<CreateEtapaCommand, Result<int>>
    {
        private readonly IEtapaRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateEtapaModeloProyectoCommandHandler(IEtapaRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateEtapaCommand request, CancellationToken cancellationToken)
        {
            var etapaModeloProyecto = _mapper.Map<Domain.Entities.Maestro.Etapa>(request);

            // Se valida que no se repita la Etapa y la Acción Operativa
            etapaModeloProyecto.Include = true;
            var listEtaparMP = await ValidateInsert(etapaModeloProyecto);


            await _repository.InsertAsync(etapaModeloProyecto);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(etapaModeloProyecto.Id);
        }

        private async Task<List<Domain.Entities.Maestro.Etapa>> ValidateInsert(Domain.Entities.Maestro.Etapa etapaModelo)
        {
            var list = await _repository.GetListAsync(etapaModelo);

            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.Etapa>();

            return list;

        }
    }
}
