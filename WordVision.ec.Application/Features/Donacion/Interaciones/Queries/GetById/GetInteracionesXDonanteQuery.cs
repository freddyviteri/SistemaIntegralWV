using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.DTOs.Donantes;
using WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAll;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetById
{
    public  class GetInteracionesXDonanteQuery : IRequest<Result<int>>
    {
        public int idDonante { set; get; }
        public int tipo { set; get; }

        public GetInteracionesXDonanteQuery()
        {
        }
        public class GetInteracionesXDonanteQueryHandler : IRequestHandler<GetInteracionesXDonanteQuery, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IInteracionRepository _interacionRepository;
            private readonly IMapper _mapper;

            public GetInteracionesXDonanteQueryHandler(IInteracionRepository interacionRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _interacionRepository = interacionRepository;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(GetInteracionesXDonanteQuery query, CancellationToken cancellationToken)
            {
                var interacionList = await _interacionRepository.InteracionXDonanteAsync(query.idDonante, query.tipo);                
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(query.idDonante);
            }

        }
    }
}
