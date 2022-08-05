using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Donacion.Donantes.Queries.GetAllCached
{
    public class GetReporteDonantesQuery : IRequest<Result<List<ReporteDonantesResponse>>>
    {
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }

        public int tipoDonante { get; set; }
        public int formaPago { get; set; }
        public int estadoDonante { get; set; }

        public int estadoPago { get; set; }
        public GetReporteDonantesQuery()
        {
        }
        public class GetReporteDonantesQueryHandler : IRequestHandler<GetReporteDonantesQuery, Result<List<ReporteDonantesResponse>>>
        {
            private readonly IDonanteRepository _donante;
            private readonly IMapper _mapper;


            //Ejecuta el select
            public GetReporteDonantesQueryHandler(IDonanteRepository donante, IMapper mapper)
            {
                _donante = donante;
                _mapper = mapper;

            }

            public async Task<Result<List<ReporteDonantesResponse>>> Handle(GetReporteDonantesQuery request, CancellationToken cancellationToken)
            {
                var DonanteList = await _donante.GetReporteDonantesAsync(request.fechaDesde, request.fechaHasta, request.tipoDonante, request.formaPago, request.estadoDonante, request.estadoPago);
                var mappedDonantes = _mapper.Map<List<ReporteDonantesResponse>>(DonanteList);

                return Result<List<ReporteDonantesResponse>>.Success(mappedDonantes);
            }
        }
    }
}
