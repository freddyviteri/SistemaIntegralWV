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

namespace WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Commands.Create
{
    public class CreateProyectoTecnicoCommand : ProyectoTecnicoResponse, IRequest<Result<int>>
    {
    }

    public class CreateProyectoTecnicoCommandHandler : IRequestHandler<CreateProyectoTecnicoCommand, Result<int>>
    {
        private readonly IProyectoTecnicoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateProyectoTecnicoCommandHandler(IProyectoTecnicoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateProyectoTecnicoCommand request, CancellationToken cancellationToken)
        {
            var proyecto = _mapper.Map<Domain.Entities.Maestro.ProyectoTecnico>(request);
            if (!await ValidateInsert(proyecto))
            {
                await _repository.InsertAsync(proyecto);
                await _unitOfWork.Commit(cancellationToken);
            }
            else
                return Result<int>.Fail($"Proyecto Técnico con Código: {request.Codigo} ya existe.");

            return Result<int>.Success(proyecto.Id);
        }

        private async Task<bool> ValidateInsert(Domain.Entities.Maestro.ProyectoTecnico proyectoTecnico)
        {
            bool exist = false;
            var list = await _repository.GetListAsync(proyectoTecnico);
            if (list.Count > 0)
                exist = true;
            return exist;

        }
    }
}
