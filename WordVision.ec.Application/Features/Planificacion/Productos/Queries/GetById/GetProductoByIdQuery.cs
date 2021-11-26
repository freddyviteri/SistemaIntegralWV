﻿using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetById
{


    public class GetProductoByIdQuery : IRequest<Result<GetProductoByIdResponse>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public string IdCreadoPor { get; set; }
        public class GetProductoByIdQueryHandler : IRequestHandler<GetProductoByIdQuery, Result<GetProductoByIdResponse>>
        {
            private readonly IProductoRepository _ProductoRepository;

            private readonly IMapper _mapper;

            public GetProductoByIdQueryHandler(IProductoRepository ProductoRepository, IMapper mapper)
            {
                _ProductoRepository = ProductoRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetProductoByIdResponse>> Handle(GetProductoByIdQuery query, CancellationToken cancellationToken)
            {
                var meta = await _ProductoRepository.GetByIdAsync(query.Id, query.IdColaborador, query.IdCreadoPor);
                var mappedMeta = _mapper.Map<GetProductoByIdResponse>(meta);

                return Result<GetProductoByIdResponse>.Success(mappedMeta);
            }
        }
    }
}
