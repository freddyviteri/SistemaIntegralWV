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

namespace WordVision.ec.Application.Features.Indicadores.ProyectoTecnicoPorProgramaArea.Queries.GetByProyectoTecnico
{
    public class GetAllProyectoTecnicoPorProgramaAreaQuery : ProyectoTecnicoPorProgramaAreaResponse, IRequest<Result<List<ProyectoTecnicoPorProgramaAreaResponse>>>
    {
        public int IdPt { get; set; }
    }

    public class GetAllProyectoTecnicoPorProgramaAreaHandler : IRequestHandler<GetAllProyectoTecnicoPorProgramaAreaQuery, Result<List<ProyectoTecnicoPorProgramaAreaResponse>>>
    {
        private readonly IProyectoTecnicoPorProgramaAreaRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProyectoTecnicoPorProgramaAreaHandler(IProyectoTecnicoPorProgramaAreaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProyectoTecnicoPorProgramaAreaResponse>>> Handle(GetAllProyectoTecnicoPorProgramaAreaQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.ProyectoTecnicoPorProgramaArea>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity, request.IdPt);
            var responseList = _mapper.Map<List<ProyectoTecnicoPorProgramaAreaResponse>>(rcPatrocinadoList);

            return Result<List<ProyectoTecnicoPorProgramaAreaResponse>>.Success(responseList);
        }
    }
}
