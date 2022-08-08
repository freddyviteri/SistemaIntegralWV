using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using WordVision.ec.Application.Interfaces.Repositories.Donacion;

namespace WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAll
{
    public  class GetAllInteracionesXDonanteQuery : IRequest<Result<List<GetAllInteracionesResponse>>>
    {
        public int idDonante { set; get; }
        public int tipo { set; get; }

        public int tipoPantalla { set; get; }
        public int Anio { get; set; }
        public int Mes { get; set; }

        public decimal Cantidad { get; set; }

        public string RespuestaBanco { get; set; }

        public GetAllInteracionesXDonanteQuery()
        {
        }
        public class GetAllInteracionesXDonanteQueryHandler : IRequestHandler<GetAllInteracionesXDonanteQuery, Result<List<GetAllInteracionesResponse>>>
        {
            private readonly IInteracionRepository _interacion;
            private readonly IMapper _mapper;


            //Ejecuta el select
            public GetAllInteracionesXDonanteQueryHandler(IInteracionRepository interacion, IMapper mapper)
            {
                _interacion = interacion;
                _mapper = mapper;

            }

            public async Task<Result<List<GetAllInteracionesResponse>>> Handle(GetAllInteracionesXDonanteQuery request, CancellationToken cancellationToken)
            {
                var interacionList = await _interacion.GetInteracionXDonanteAsync( request.idDonante , request.tipo  );  //,request.estadoCourier
                var mappedInteracion = _mapper.Map<List<GetAllInteracionesResponse>>(interacionList);

                return Result<List<GetAllInteracionesResponse>>.Success(mappedInteracion);
            }


        }
    }
}
