using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.ProyectoITT.Commands.Update
{
    public class UpdateProyectoITTCommand : ProyectoITTResponse, IRequest<Result<int>>
    {
    }

    public class UpdateProyectoITTCommandHandler : IRequestHandler<UpdateProyectoITTCommand, Result<int>>
    {
        private readonly IProyectoITTRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateProyectoITTCommandHandler(IProyectoITTRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateProyectoITTCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id, true);

            if (entity == null)
            {
                return Result<int>.Fail($"ProyectoITT no encontrada.");
            }
            else
            {
                //entity.DetalleProyectoITTs = _mapper.Map<List<DetalleProyectoITT>>(update.DetalleProyectoITTs);
                foreach (var item in update.DetalleProyectoITTs)
                {
                    var reg = entity.DetalleProyectoITTs
                                                        .Where(x => x.Id == item.Id)
                                                        .FirstOrDefault();
                    reg.LineBase = item.LineBase;
                    reg.MetaAF1 = item.MetaAF1;
                    reg.MetaAF2 = item.MetaAF2;
                    reg.MetaAF3 = item.MetaAF3;
                    reg.MetaAF4 = item.MetaAF4;
                    reg.MetaAF5 = item.MetaAF5;
                    reg.MetaAF6 = item.MetaAF6;
                }

            }

            await _repository.UpdateAsync(entity);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(entity.Id);
            //}
        }
    }
}
