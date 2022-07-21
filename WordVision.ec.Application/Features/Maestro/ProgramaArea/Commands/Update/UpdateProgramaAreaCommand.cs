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

namespace WordVision.ec.Application.Features.Maestro.ProgramaArea.Commands.Update
{
    public class UpdateProgramaAreaCommand : ProgramaAreaResponse, IRequest<Result<int>>
    {
    }

    public class UpdateProgramaAreaCommandHandler : IRequestHandler<UpdateProgramaAreaCommand, Result<int>>
    {
        private readonly IProgramaAreaRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateProgramaAreaCommandHandler(IProgramaAreaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateProgramaAreaCommand update, CancellationToken cancellationToken)
        {
            var programaArea = await _repository.GetByIdAsync(update.Id);

            if (programaArea == null)
            {
                return Result<int>.Fail($"ProgramaArea no encontrado.");
            }
            else
            {
                var list = await _repository.GetListAsync(new Domain.Entities.Maestro.ProgramaArea());
                if (list.Where(r => r.Codigo == update.Codigo && r.Id != update.Id).Count() > 0)
                    return Result<int>.Fail($"ProgramaArea con Código: {update.Codigo} ya existe.");

                programaArea.Codigo = update.Codigo;
                programaArea.Descripcion = update.Descripcion;
                programaArea.IdProyectoTecnico = update.IdProyectoTecnico;
                programaArea.IdEstado = update.IdEstado;              

                await _repository.UpdateAsync(programaArea);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(programaArea.Id);
            }
        }
    }
}
