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
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.MarcoLogico.Commands.Update
{
    public class UpdateMarcoLogicoCommand : MarcoLogicoResponse, IRequest<Result<int>>
    {
    }

    public class UpdateMarcoLogicoCommandHandler : IRequestHandler<UpdateMarcoLogicoCommand, Result<int>>
    {
        private readonly IMarcoLogicoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateMarcoLogicoCommandHandler(IMarcoLogicoRepository repository, IUnitOfWork unitOfWork,
               IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateMarcoLogicoCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id, true);

            if (entity == null)
            {
                return Result<int>.Fail($"MarcoLogico no encontrado.");
            }
            else
            {


                entity.IdLogFrame = update.IdLogFrame;
                entity.IdIndicadorML = update.IdIndicadorML;

                // Se valida que no se repita el logFrame e indicador
                var listEtaparMP = await ValidateInsert(entity);

                if (listEtaparMP.Count > 0)
                {
                    var first = listEtaparMP.First();
                    return Result<int>.Fail($"ModeloLogico con LogFrame: {first.LogFrame.SumaryObjetives} e Indicador: {first.IndicadorML.Codigo} ya existe.");
                }

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }

        private async Task<List<Domain.Entities.Maestro.MarcoLogico>> ValidateInsert(Domain.Entities.Maestro.MarcoLogico etapaModelo)
        {
            var list = await _repository.GetListAsync(new Domain.Entities.Maestro.MarcoLogico() { Include = true });

            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.MarcoLogico>();

            return list.FindAll(x => x.IdLogFrame == etapaModelo.IdLogFrame && x.IdIndicadorML == etapaModelo.IdIndicadorML && x.Id != etapaModelo.Id);

        }
    }
}
