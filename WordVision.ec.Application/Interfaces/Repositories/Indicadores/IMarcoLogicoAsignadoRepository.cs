using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Indicadores
{
    public interface IMarcoLogicoAsignadoRepository
    {

        Task<MarcoLogicoAsignado> GetByIdAsync(int id);
        Task<List<MarcoLogicoAsignado>> GetListAsync(MarcoLogicoAsignado entity);
        Task<int> InsertAsync(MarcoLogicoAsignado entity);
        Task<List<MarcoLogicoAsignado>> InsertRangeAsync(List<MarcoLogicoAsignado> entities);
        Task UpdateAsync(MarcoLogicoAsignado entity);      
    }
}
