using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IIndicadorPRRepository
    {
        Task<IndicadorPR> GetByIdAsync(int id);
        Task<List<IndicadorPR>> GetListAsync(IndicadorPR indicador);
        Task<int> CountAsync(IndicadorPR IndicadorPR);
        Task<int> InsertAsync(IndicadorPR indicador);
        Task UpdateAsync(IndicadorPR indicador);
        Task DeleteAsync(IndicadorPR indicador);
    }
}
