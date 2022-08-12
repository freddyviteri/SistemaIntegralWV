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

namespace WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Commands.Create
{
    public class CreateOtroIndicadorPadreHijoCommand : OtroIndicadorPadreHijoResponse, IRequest<Result<int>>
    {
    }

    public class CreateOtroIndicadorPadreHijoCommandHandler : IRequestHandler<CreateOtroIndicadorPadreHijoCommand, Result<int>>
    {
        private readonly IOtroIndicadorPadreHijoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateOtroIndicadorPadreHijoCommandHandler(IOtroIndicadorPadreHijoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateOtroIndicadorPadreHijoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.OtroIndicadorPadreHijo>(request);
            await _repository.InsertAsync(entity);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(entity.Id);
        }
    }
}
