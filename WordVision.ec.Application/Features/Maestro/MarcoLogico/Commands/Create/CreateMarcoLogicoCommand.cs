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

namespace WordVision.ec.Application.Features.Maestro.MarcoLogico.Commands.Create
{
    public class CreateMarcoLogicoCommand : MarcoLogicoResponse, IRequest<Result<int>>
    {
    }

    public class CreateMarcoLogicoCommandHandler : IRequestHandler<CreateMarcoLogicoCommand, Result<int>>
    {
        private readonly IMarcoLogicoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateMarcoLogicoCommandHandler(IMarcoLogicoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateMarcoLogicoCommand request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<Domain.Entities.Maestro.MarcoLogico>(request);

            // Se valida que no se repita el logFrame e indicador
            var listEtaparMP = await ValidateInsert(entity);

            if (listEtaparMP.Count > 0)
            {
                var first = listEtaparMP.First();
                return Result<int>.Fail($"ModeloLogico con LogFrame: {first.LogFrame.SumaryObjetives} e Indicador: {first.IndicadorML.Codigo} ya existe.");
            }

            await _repository.InsertAsync(entity);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(entity.Id);
        }

        private async Task<List<Domain.Entities.Maestro.MarcoLogico>> ValidateInsert(Domain.Entities.Maestro.MarcoLogico etapaModelo)
        {
            var list = await _repository.GetListAsync(new Domain.Entities.Maestro.MarcoLogico() { Include = true });

            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.MarcoLogico>();

            return list.FindAll(x => x.IdLogFrame == etapaModelo.IdLogFrame && x.IdIndicadorML == etapaModelo.IdIndicadorML);

        }
    }
}
