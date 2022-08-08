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

namespace WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetById
{
    public  class GetDebitosXDonanteQuery : IRequest<Result<List<DebitosInteracionResponse>>>
    {
        public int idDonante { set; get; }
       
        public GetDebitosXDonanteQuery()
        {
        }
        public class GetDebitosXDonanteQueryHandler : IRequestHandler<GetDebitosXDonanteQuery, Result<List<DebitosInteracionResponse>>>
        {
            private readonly IInteracionRepository _interacionRepository;
            private readonly IMapper _mapper;

            public GetDebitosXDonanteQueryHandler(IInteracionRepository interacionRepository, IMapper mapper)
            {
                _interacionRepository = interacionRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<DebitosInteracionResponse>>> Handle(GetDebitosXDonanteQuery request, CancellationToken cancellationToken)
            {
                var interacionList = await _interacionRepository.GetDebitoXDonanteAsync(request.idDonante);

                var mappedInteracion = _mapper.Map<List<DebitosInteracionResponse>>(interacionList);

                return Result<List<DebitosInteracionResponse>>.Success(mappedInteracion);
            }

        }
    }
}
