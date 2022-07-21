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

namespace WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Commands.Update
{
    public class UpdateProyectoTecnicoCommand : ProyectoTecnicoResponse, IRequest<Result<int>>
    {
    }

    public class UpdateProyectoTecnicoCommandHandler : IRequestHandler<UpdateProyectoTecnicoCommand, Result<int>>
    {
        private readonly IProyectoTecnicoRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateProyectoTecnicoCommandHandler(IProyectoTecnicoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateProyectoTecnicoCommand update, CancellationToken cancellationToken)
        {
            var proyecto = await _repository.GetByIdAsync(update.Id);

            if (proyecto == null)
            {
                return Result<int>.Fail($"Proyecto Técnico no encontrado.");
            }
            else
            {
                var list = await _repository.GetListAsync(new Domain.Entities.Maestro.ProyectoTecnico());
                if (list.Where(r => r.Codigo == update.Codigo && r.Id != update.Id).Count() > 0)
                    return Result<int>.Fail($"Proyecto Técnico con Código: {update.Codigo} ya existe.");

                proyecto.Codigo = update.Codigo;
                proyecto.NombreProyecto = update.NombreProyecto;
                proyecto.IdUbicacion = update.IdUbicacion;
                proyecto.IdFinanciamiento = update.IdFinanciamiento;
                proyecto.IdTipoProyecto = update.IdTipoProyecto;
                proyecto.IdEstado = update.IdEstado;

                await _repository.UpdateAsync(proyecto);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(proyecto.Id);
            }
        }
    }
}
