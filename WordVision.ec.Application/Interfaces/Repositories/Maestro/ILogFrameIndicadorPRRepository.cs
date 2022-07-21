using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface ILogFrameIndicadorPRRepository
    {
        Task<LogFrameIndicadorPR> GetByIdAsync(int id, bool include = false);
        Task<List<LogFrameIndicadorPR>> GetListAsync(LogFrameIndicadorPR entity);
        Task<int> InsertAsync(LogFrameIndicadorPR entity);
        Task UpdateAsync(LogFrameIndicadorPR entity);
        Task<List<LogFrameIndicadorPR>> GetByPtAsync(LogFrameIndicadorPR entity, int idPT);

        //Task DeleteLogFrameIndicadorPRIndicadorPRAsync(List<LogFrameIndicadorPRIndicadorPR> list);
        Task DeleteAsync(LogFrameIndicadorPR entity);
    }
}
