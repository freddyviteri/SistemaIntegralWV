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

namespace WordVision.ec.Application.Features.Maestro.IndicadorML.Commands.Create
{
    public class CreateIndicadorMLCommand : IndicadorMLResponse, IRequest<Result<int>>
    {
    }

    public class CreateIndicadorMLCommandHandler : IRequestHandler<CreateIndicadorMLCommand, Result<int>>
    {
        private readonly IIndicadorMLRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateIndicadorMLCommandHandler(IIndicadorMLRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateIndicadorMLCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.IndicadorML>(request);
            if (!await ValidateInsert(entity))
            {
                await _repository.InsertAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
            }
            else
                return Result<int>.Fail($"Indicador con Código: {request.Codigo} ya existe.");

            return Result<int>.Success(entity.Id);
        }

        private async Task<bool> ValidateInsert(Domain.Entities.Maestro.IndicadorML entity)
        {
            bool exist = false;
            int count = await _repository.CountAsync(entity);
            if (count > 0)
                exist = true;
            return exist;

        }
    }
}
