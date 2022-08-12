using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Commands.Update
{
    public class UpdateOtroIndicadorPadreHijoCommand : OtroIndicadorPadreHijoResponse, IRequest<Result<int>>
    {
    }

    public class UpdateOtroIndicadorPadreHijoCommandHandler : IRequestHandler<UpdateOtroIndicadorPadreHijoCommand, Result<int>>
    {
        private readonly IOtroIndicadorPadreHijoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateOtroIndicadorPadreHijoCommandHandler(IOtroIndicadorPadreHijoRepository repository,
               IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateOtroIndicadorPadreHijoCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"OtroIndicadorPadreHijo no encontrada.");
            }
            else
            {
                entity.IdPadre = update.IdPadre;
                entity.IdHijo = update.IdHijo;
                entity.IdEstado = update.IdEstado;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
