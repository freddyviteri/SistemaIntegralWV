using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.ModeloProyectoEtapaAccionModeloProyecto.Commands.Create
{
    public class CreateModeloProyectoEtapaAccionCommand : ModeloProyectoEtapaAccionResponse, IRequest<Result<int>>
    {
    }

    public class CreateModeloProyectoEtapaAccionModeloProyectoCommandHandler : IRequestHandler<CreateModeloProyectoEtapaAccionCommand, Result<int>>
    {
        private readonly IModeloProyectoEtapaAccionRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateModeloProyectoEtapaAccionModeloProyectoCommandHandler(IModeloProyectoEtapaAccionRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateModeloProyectoEtapaAccionCommand request, CancellationToken cancellationToken)
        {

            var modelo = _mapper.Map<Domain.Entities.Maestro.ModeloProyectoEtapaAccion>(request);

            ModeloProyectoEtapaAccion entidad = new ModeloProyectoEtapaAccion();
            entidad.IdModeloProyecto = request.IdModeloProyecto;
            entidad.IdEtapa = request.IdEtapa;
            entidad.Include = false;

            var lista = await _repository.GetListAsync(entidad);

            foreach (var item in lista)
            {
                if (!request.ListModeloProyectoEtapaAccionResponse.Exists(x => x.IdModeloProyecto == item.IdModeloProyecto && x.IdEtapa == item.IdEtapa && x.IdAccionOperativa == item.IdAccionOperativa))
                {
                    await _repository.DeleteAsync(item);
                }
            }

            foreach (var item in request.ListModeloProyectoEtapaAccionResponse)
            {
                if (!lista.Exists(x => x.IdModeloProyecto == item.IdModeloProyecto && x.IdEtapa == item.IdEtapa && x.IdAccionOperativa == item.IdAccionOperativa))
                {
                    await _repository.InsertAsync(item);
                }
            }

            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(1);
        }


    }
}
