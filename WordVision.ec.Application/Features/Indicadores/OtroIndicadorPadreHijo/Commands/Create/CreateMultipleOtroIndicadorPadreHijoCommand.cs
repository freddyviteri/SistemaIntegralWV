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
    public class CreateMultipleOtroIndicadorPadreHijoCommand : List<OtroIndicadorPadreHijoResponse>, IRequest<List<Result<int>>>
    {
    }

    public class CreateMultipleOtroIndicadorPadreHijoCommandHandler : IRequestHandler<CreateMultipleOtroIndicadorPadreHijoCommand, List<Result<int>>>
    {
        private readonly IOtroIndicadorPadreHijoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateMultipleOtroIndicadorPadreHijoCommandHandler(IOtroIndicadorPadreHijoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Result<int>>> Handle(CreateMultipleOtroIndicadorPadreHijoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<List<Domain.Entities.Indicadores.OtroIndicadorPadreHijo>>(request);
            await _repository.InsertRangeAsync(entity);
            await _unitOfWork.Commit(cancellationToken);
            return entity.Select(e => Result<int>.Success(e.Id)).ToList();
        }
    }

}
