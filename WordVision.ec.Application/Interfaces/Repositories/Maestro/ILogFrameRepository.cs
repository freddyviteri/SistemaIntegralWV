using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface ILogFrameRepository
    {
        Task<LogFrame> GetByIdAsync(int id, bool include = false);
        Task<List<LogFrame>> GetListAsync(LogFrame logFrame);
        Task<int> InsertAsync(LogFrame logFrame);
        Task UpdateAsync(LogFrame logFrame);
        Task DeleteLogFrameIndicadorPRAsync(List<LogFrameIndicadorPR> list);
        Task DeleteAsync(LogFrame logFrame);
    }
}
