using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Donantes;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Donacion.Donantes.Queries.GetAllCached
{
    public class GetAllDonantesQuery : IRequest<Result<List<DonanteResponse>>>
    {
       
        public int EstadoDonante { get; set; }
        public int Categoria { get; set; }
        public int Ciudad { get; set; }

        public int Campana { get; set; }

        public string Identificacion { get; set; }

        public string NombresDonante { get; set; }

        public int TipoPantalla { get; set; }

        public bool Validacion { get; set; }

        public int CuotaDebe { get; set; }
        public GetAllDonantesQuery()
        {
        }
        public class GetAllDonantesQueryHandler : IRequestHandler<GetAllDonantesQuery, Result<List<DonanteResponse>>>
        {
            private readonly IDonanteRepository _donante;
            private readonly IMapper _mapper;


            //Ejecuta el select
            public GetAllDonantesQueryHandler(IDonanteRepository donante, IMapper mapper)
            {
                _donante = donante;
                _mapper = mapper;

            }

            public async Task<Result<List<DonanteResponse>>> Handle(GetAllDonantesQuery request, CancellationToken cancellationToken)
            {
                var DonanteList = await _donante.GetListAsync(request.EstadoDonante, request.Categoria, request.Campana,request.Ciudad,request.Identificacion,request.NombresDonante, request.TipoPantalla, request.Validacion , request.CuotaDebe);
                var mappedDonantes = _mapper.Map<List<DonanteResponse>>(DonanteList);

                return Result<List<DonanteResponse>>.Success(mappedDonantes);
            }
        }
    }
}
