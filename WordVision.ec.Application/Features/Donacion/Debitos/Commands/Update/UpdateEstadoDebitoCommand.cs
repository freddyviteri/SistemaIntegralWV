using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Donacion;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Commands.Update
{
    public class UpdateEstadoDebitoCommand : IRequest<Result<int>>
    {
        public int IdDonante { get; set; }
        public int EstadoDebito { get; set; }
        public class UpdateDebitoCommandHandler : IRequestHandler<UpdateEstadoDebitoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDebitoRepository _debitoRepository;
            private readonly IMapper _mapper;

            public UpdateDebitoCommandHandler(IDebitoRepository debitoRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _debitoRepository = debitoRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateEstadoDebitoCommand command, CancellationToken cancellationToken)
            {
                await _debitoRepository.UpdateEstadoAsync(command.IdDonante, command.EstadoDebito);

                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(command.IdDonante);


            }
        }

    }
}
