using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Command.Create
{
    public class CreateProyectoTecnicoPorProgramaAreaCommand : List<ProyectoTecnicoPorProgramaAreaResponse>, IRequest<List<Result<int>>>
    {
    }

    public class CreateProyectoTecnicoPorProgramaAreaCommandHanlder : IRequestHandler<CreateProyectoTecnicoPorProgramaAreaCommand, List<Result<int>>>
    {

        private readonly IProyectoTecnicoPorProgramaAreaRepository _repository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }


        public CreateProyectoTecnicoPorProgramaAreaCommandHanlder(IProyectoTecnicoPorProgramaAreaRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Result<int>>> Handle(CreateProyectoTecnicoPorProgramaAreaCommand request, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<Domain.Entities.Indicadores.ProyectoTecnicoPorProgramaArea>>(request);
            await _repository.InsertRangeAsync(entities);
            await _unitOfWork.Commit(cancellationToken);

            return entities.Select(e => Result<int>.Success(e.Id)).ToList();
        }
    }
}
