using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IIndicadorMLRepository
    {
        Task<IndicadorML> GetByIdAsync(int id);
        Task<List<IndicadorML>> GetListAsync(IndicadorML indicador);
        Task<int> CountAsync(IndicadorML IndicadorML);
        Task<int> InsertAsync(IndicadorML indicador);
        Task UpdateAsync(IndicadorML indicador);
        Task DeleteAsync(IndicadorML indicador);
    }
}
