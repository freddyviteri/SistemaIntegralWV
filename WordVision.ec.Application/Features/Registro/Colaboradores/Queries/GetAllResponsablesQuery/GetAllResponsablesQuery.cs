using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllResponsablesQuery
{
    public class GetAllResponsablesQuery : ColaboradorResponse, IRequest<Result<List<ColaboradorResponse>>>
    {
    }

    public class GetAllResponsablesQueryHandler : IRequestHandler<GetAllResponsablesQuery, Result<List<ColaboradorResponse>>>
    {
        private readonly IColaboradorRepository _repository;
        private readonly IMapper _mapper;

        public GetAllResponsablesQueryHandler(IColaboradorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ColaboradorResponse>>> Handle(GetAllResponsablesQuery request, CancellationToken cancellationToken)
        {
            //var entity = _mapper.Map<Domain.Entities.Registro.Colaborador>(request);
            var list = await _repository.GetListAsync();
            var responseList = _mapper.Map<List<ColaboradorResponse>>(list);

            return Result<List<ColaboradorResponse>>.Success(responseList);
        }
    }

}
