using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IMarcoLogicoRepository
    {
        Task<MarcoLogico> GetByIdAsync(int id, bool include = false);
        Task<List<MarcoLogico>> GetListAsync(MarcoLogico entity);
        Task<int> InsertAsync(MarcoLogico entity);
        Task UpdateAsync(MarcoLogico entity);
        Task<List<MarcoLogico>> GetByPtAsync(ProgramaTecnico entity);
        Task DeleteAsync(MarcoLogico entity);
    }
}
