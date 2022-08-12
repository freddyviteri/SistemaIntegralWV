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

namespace WordVision.ec.Application.Features.Indicadores.OtroIndicadorPadreHijo.Queries.GetAll
{
    public class GetAllOtroIndicadorPadreHijoQuery : OtroIndicadorPadreHijoResponse, IRequest<Result<List<OtroIndicadorPadreHijoResponse>>>
    {
    }

    public class GetAllOtroIndicadorPadreHijoQueryHandler : IRequestHandler<GetAllOtroIndicadorPadreHijoQuery, Result<List<OtroIndicadorPadreHijoResponse>>>
    {
        private readonly IOtroIndicadorPadreHijoRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOtroIndicadorPadreHijoQueryHandler(IOtroIndicadorPadreHijoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<OtroIndicadorPadreHijoResponse>>> Handle(GetAllOtroIndicadorPadreHijoQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.OtroIndicadorPadreHijo>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<OtroIndicadorPadreHijoResponse>>(rcPatrocinadoList);

            return Result<List<OtroIndicadorPadreHijoResponse>>.Success(responseList);
        }
    }
}