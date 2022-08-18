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

namespace WordVision.ec.Application.Features.Maestro.IndicadorPR.Commands.Create
{
    public class CreateIndicadorPRCommand : IndicadorPRResponse, IRequest<Result<int>>
    {
    }

    public class CreateIndicadorPRCommandHandler : IRequestHandler<CreateIndicadorPRCommand, Result<int>>
    {
        private readonly IIndicadorPRRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateIndicadorPRCommandHandler(IIndicadorPRRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateIndicadorPRCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.IndicadorPR>(request);
            if (!await ValidateInsert(entity))
            {
                await _repository.InsertAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
            }
            else
                return Result<int>.Fail($"Indicador con Código: {request.Codigo} ya existe.");

            return Result<int>.Success(entity.Id);
        }

        private async Task<bool> ValidateInsert(Domain.Entities.Maestro.IndicadorPR entity)
        {
            bool exist = false;
            int count = await _repository.CountAsync(entity);
            if (count > 0)
                exist = true;
            return exist;

        }
    }
}
