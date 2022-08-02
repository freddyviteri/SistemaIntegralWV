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
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Donacion;

namespace WordVision.ec.Application.Features.Donacion.Interaciones.Commands.Create
{
    public partial class CreateInteracionCommand : IRequest<Result<int>>
    {
        public int Gestion { get; set; }

        public int Tipo { get; set; }

        public string Observacion { get; set; }

        public int EstadoKitCourier { get; set; }

        public DateTime? FechaEntregaKit { get; set; }

        public string NumeroGuiaKit { get; set; }

        public int MotivoBajaCartera { get; set; }

        public DateTime? FechaBajaCartera { get; set; }

        public int IdDonante { get; set; }
    }

    public class CreateInteracionCommandHandler : IRequestHandler<CreateInteracionCommand, Result<int>>
    {
        private readonly IInteracionRepository _interacionRepository;


        private readonly IMapper _mapper;//coge los campos de la interfaz con la bbdd hace un mapeo

        private IUnitOfWork _unitOfWork { get; set; }// hace la transaccionabilidad crea la cabecera y luego detalle



        public CreateInteracionCommandHandler(IInteracionRepository interacionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _interacionRepository = interacionRepository;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateInteracionCommand request, CancellationToken cancellationToken)
        {
            var interacion = _mapper.Map<Interacion>(request);//mapea
            await _interacionRepository.InsertAsync(interacion);//INsertar a la BBDD


            await _unitOfWork.Commit(cancellationToken);//commit
            return Result<int>.Success(interacion.Id);//devuelve le id existoso de la persona;
        }
    }
}
