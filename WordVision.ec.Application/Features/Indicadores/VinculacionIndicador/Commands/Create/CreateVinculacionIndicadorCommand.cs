using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Create
{
    public class CreateVinculacionIndicadorCommand : VinculacionIndicadorResponse, IRequest<Result<int>>
    {
    }

    public class CreateVinculacionIndicadorCommandHandler : IRequestHandler<CreateVinculacionIndicadorCommand, Result<int>>
    {
        private readonly IVinculacionIndicadorRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateVinculacionIndicadorCommandHandler(IVinculacionIndicadorRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateVinculacionIndicadorCommand request, CancellationToken cancellationToken)
        {
            request.DetalleVinculacionIndicadores = request.DetalleVinculacionIndicadores.Where(l => l.Selected).ToList();
            var entity = _mapper.Map<Domain.Entities.Indicadores.VinculacionIndicador>(request);
            await _repository.InsertAsync(entity);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(entity.Id);
        }
    }
}
