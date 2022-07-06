﻿using AspNetCoreHero.Results;
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

namespace WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR.Commands.Create
{
    public class CreateLogFrameIndicadorPRCommand : LogFrameIndicadorPRResponse, IRequest<Result<int>>
    {
    }

    public class CreateLogFrameIndicadorPRCommandHandler : IRequestHandler<CreateLogFrameIndicadorPRCommand, Result<int>>
    {
        private readonly ILogFrameIndicadorPRRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateLogFrameIndicadorPRCommandHandler(ILogFrameIndicadorPRRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateLogFrameIndicadorPRCommand request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<Domain.Entities.Maestro.LogFrameIndicadorPR>(request);

            // Se valida que no se repita el logFrame e indicador
            var listEtaparMP = await ValidateInsert(entity);

            if (listEtaparMP.Count > 0)
            {
                var first = listEtaparMP.First();
                return Result<int>.Fail($"ModeloLogico con LogFrame: {first.LogFrame.SumaryObjetives} e Indicador: {first.IndicadorPR.Codigo} ya existe.");
            }

            await _repository.InsertAsync(entity);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(entity.Id);
        }

        private async Task<List<Domain.Entities.Maestro.LogFrameIndicadorPR>> ValidateInsert(Domain.Entities.Maestro.LogFrameIndicadorPR etapaModelo)
        {
            var list = await _repository.GetListAsync(new Domain.Entities.Maestro.LogFrameIndicadorPR() { Include = true});

            if (list.Count == 0)
                return new List<Domain.Entities.Maestro.LogFrameIndicadorPR>();

            return list.FindAll(x => x.IdLogFrame == etapaModelo.IdLogFrame && x.IdIndicadorPR == etapaModelo.IdIndicadorPR);

        }
    }
}