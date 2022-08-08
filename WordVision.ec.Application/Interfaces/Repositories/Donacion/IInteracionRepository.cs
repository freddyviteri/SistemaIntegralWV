using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.DTOs.Donantes;
using WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAll;
using WordVision.ec.Domain.Entities.Donacion;


namespace WordVision.ec.Application.Interfaces.Repositories.Donacion
{
    public interface IInteracionRepository
    {
        IQueryable<Interacion> interaciones { get; }

        Task<int> InsertAsync(Interacion interacion);
         
        Task<List<GetAllInteracionesResponse>> GetInteracionXDonanteAsync(int idDonante, int tipo  );  //, int estadoCourier
        Task<List<DebitosInteracionResponse>> GetDebitoXDonanteAsync(int idDonante );
        


        //Task<List<Interacion>> GetInteracionXDonanteAsync(int idDonante, int tipo);

        //Task UpdateAsync(Interacion interacion);

        //Task DeleteAsync(Interacion interacion);

        //Task<Interacion> GetInteracionAsync(int idInteracion);


        //Task<Interacion> GetByIdAsync(int idInteracion);


    }
}
