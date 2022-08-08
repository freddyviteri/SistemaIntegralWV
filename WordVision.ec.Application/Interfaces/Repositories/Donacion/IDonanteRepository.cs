using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.DTOs.Donantes;
using WordVision.ec.Domain.Entities.Donacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Donacion
{
    public interface IDonanteRepository
    {
        IQueryable<Donante> donantes { get; }
        Task<List<DonanteResponse>> GetListAsync(int estadoDonante, int categoria, int campana , int ciudad , string identificacion, string nombresdonante, int tipoPantalla, bool validacion, int cuotaDebe);

        Task<int> InsertAsync(Donante donante);

        Task UpdateAsync(Donante donante);
        Task DeleteAsync(Donante donante);
        Task<Donante> GetDonantesAsync(int idDonante);
        Task<Donante> GetByIdAsync(int idDonante);
        Task UpdateAsyncXEstado(int idDonante, int estadoDonante);


        Task<List<ReporteDonantesResponse>> GetReporteDonantesAsync(DateTime fechaDesde, DateTime fechaHasta, int tipoDonante, int formaPago, int estadoDonante);
    }
}
