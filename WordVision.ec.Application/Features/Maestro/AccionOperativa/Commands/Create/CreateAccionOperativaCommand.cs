using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.AccionOperativaModeloProyecto.Commands.Create
{
    public class CreateAccionOperativaCommand : AccionOperativaResponse, IRequest<Result<int>>
    {
    }

    public class CreateAccionOperativaModeloProyectoCommandHandler : IRequestHandler<CreateAccionOperativaCommand, Result<int>>
    {
        private readonly IAccionOperativaRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateAccionOperativaModeloProyectoCommandHandler(IAccionOperativaRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateAccionOperativaCommand request, CancellationToken cancellationToken)
        {
            var AccionOperativaModeloProyecto = _mapper.Map<Domain.Entities.Maestro.AccionOperativa>(request);

            // Se valida que no se repita la AccionOperativa y la Acción Operativa
            AccionOperativaModeloProyecto.Include = true;
            var listAccionOperativarMP = await ValidateInsert(AccionOperativaModeloProyecto);


            await _repository.InsertAsync(AccionOperativaModeloProyecto);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(AccionOperativaModeloProyecto.Id);
        }

        private async Task<List<Domain.Entities.Maestro.AccionOperativa>> ValidateInsert(Domain.Entities.Maestro.AccionOperativa AccionOperativaModelo)
        {
            var list = await _repository.GetListAsync(AccionOperativaModelo);

            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.AccionOperativa>();

            return list;

        }
    }
}
