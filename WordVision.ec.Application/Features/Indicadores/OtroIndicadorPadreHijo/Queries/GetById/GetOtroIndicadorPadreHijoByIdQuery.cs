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

namespace WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Queries.GetById
{
    public class GetOtroIndicadorPadreHijoByIdQuery : OtroIndicadorPadreHijoResponse, IRequest<Result<OtroIndicadorPadreHijoResponse>>
    {
    }

    public class GetOtroIndicadorPadreHijoByIdQueryHandler : IRequestHandler<GetOtroIndicadorPadreHijoByIdQuery, Result<OtroIndicadorPadreHijoResponse>>
    {
        private readonly IOtroIndicadorPadreHijoRepository _repository;
        private readonly IMapper _mapper;

        public GetOtroIndicadorPadreHijoByIdQueryHandler(IOtroIndicadorPadreHijoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<OtroIndicadorPadreHijoResponse>> Handle(GetOtroIndicadorPadreHijoByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<OtroIndicadorPadreHijoResponse>(result);

            return Result<OtroIndicadorPadreHijoResponse>.Success(response);
        }
    }
}
