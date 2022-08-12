using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.ProgramaTecnico;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Queries.GetAll
{
    public class GetAllMarcoLogicoAsignadoQuery : MarcoLogicoAsignadoResponse, IRequest<Result<List<MarcoLogicoAsignadoResponse>>>
    {
    }

    public class GetAllMarcoLogicoAsignadoHandler : IRequestHandler<GetAllMarcoLogicoAsignadoQuery, Result<List<MarcoLogicoAsignadoResponse>>>
    {
        private readonly IMarcoLogicoAsignadoRepository _repository;
        private readonly IMapper _mapper;

        public GetAllMarcoLogicoAsignadoHandler(IMarcoLogicoAsignadoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<MarcoLogicoAsignadoResponse>>> Handle(GetAllMarcoLogicoAsignadoQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.MarcoLogicoAsignado>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<MarcoLogicoAsignadoResponse>>(rcPatrocinadoList);

            return Result<List<MarcoLogicoAsignadoResponse>>.Success(responseList);
        }
    }

}
