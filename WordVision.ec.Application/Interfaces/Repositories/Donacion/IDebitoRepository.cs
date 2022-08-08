using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Domain.Entities.Donacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Donacion
{
    public interface IDebitoRepository
    {
        IQueryable<Debito> debitos { get; }
       
        Task<int> InsertAsync(Debito debito);

        Task UpdateAsync(Debito debito);
        Task<Debito> GetByIdAsync(int idDebito);
        Task<List<Debito>> GetListAsync();

        Task<List<DebitoResponse>> GetListDebitosSeleccionarAsync(int formaPago,int bancoTarjeta,int anio, int mes);
        Task<Debito> GetByContrapartidaAsync(int formaPago, int bancoTarjeta, int anio, int mes, string contrapartida);

        Task<int> GetByArchivoGeneradoAsync(int formaPago, int bancoTarjeta, int anio, int mes);
        Task<int> GetByExisteCargaRespuestaAsync(int formaPago, int bancoTarjeta, int anio, int mes);
        Task<int> GetByPersonaAsync(int formaPago, int bancoTarjeta, int anio, int mes , string contrapartida);

        Task UpdateEstadoAsync(int idDonante, int estadoDebito);

    }
}
