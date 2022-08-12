using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Create
{

    public class CreateMultipleVinculacionIndicadoresCommand : List<VinculacionIndicadorResponse>, IRequest<List<Result<int>>>
    {
    }

    public class CreateMultipleVinculacionIndicadoresCommandHandler : IRequestHandler<CreateMultipleVinculacionIndicadoresCommand, List<Result<int>>>
    {
        private readonly IVinculacionIndicadorRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateMultipleVinculacionIndicadoresCommandHandler(IVinculacionIndicadorRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Result<int>>> Handle(CreateMultipleVinculacionIndicadoresCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<List<Domain.Entities.Indicadores.VinculacionIndicador>>(request);
            await _repository.InsertRangeAsync(entity);
            await _unitOfWork.Commit(cancellationToken);
            return entity.Select(e => Result<int>.Success(e.Id)).ToList();
        }
    }

}
