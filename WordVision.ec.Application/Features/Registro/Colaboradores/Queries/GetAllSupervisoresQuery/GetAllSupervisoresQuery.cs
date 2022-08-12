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

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllSupervisoresQuery
{
    public class GetAllSupervisoresQuery : ColaboradorResponse, IRequest<Result<List<ColaboradorResponse>>>
    {
    }

    public class GetAllSupervisoresQueryHandler : IRequestHandler<GetAllSupervisoresQuery, Result<List<ColaboradorResponse>>>
    {
        private readonly IColaboradorRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSupervisoresQueryHandler(IColaboradorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ColaboradorResponse>>> Handle(GetAllSupervisoresQuery request, CancellationToken cancellationToken)
        {
            //var entity = _mapper.Map<Domain.Entities.Registro.Colaborador>(request);
            var list = await _repository.GetListAsync();
            var responseList = _mapper.Map<List<ColaboradorResponse>>(list);

            return Result<List<ColaboradorResponse>>.Success(responseList);
        }
    }

}
