using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.ProgramaTecnico.Commands.Update
{
    public class UpdateProgramaTecnicoCommand : ProgramaTecnicoResponse, IRequest<Result<int>>
    {
    }

    public class UpdateProyectoTecnicoCommandHandler : IRequestHandler<UpdateProgramaTecnicoCommand, Result<int>>
    {
        private readonly IProgramaTecnicoRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateProyectoTecnicoCommandHandler(IProgramaTecnicoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateProgramaTecnicoCommand update, CancellationToken cancellationToken)
        {
            var proyecto = await _repository.GetByIdAsync(update.Id);

            if (proyecto == null)
            {
                return Result<int>.Fail($"Proyecto Técnico no encontrado.");
            }
            else
            {
                var list = await _repository.GetListAsync(new Domain.Entities.Maestro.ProgramaTecnico());
                if (list.Where(r => r.Codigo == update.Codigo && r.Id != update.Id).Count() > 0)
                    return Result<int>.Fail($"Proyecto Técnico con Código: {update.Codigo} ya existe.");

                proyecto.Codigo = update.Codigo;
                proyecto.Nombre = update.Nombre;
                proyecto.Descripcion = update.Descripcion;
                proyecto.IdTipoProyecto = update.IdTipoProyecto;
                proyecto.IdEstado = update.IdEstado;

                await _repository.UpdateAsync(proyecto);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(proyecto.Id);
            }
        }
    }
}
