using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IEtapaRepository
    {
        Task<Etapa> GetByIdAsync(int id, bool include = false);
        Task<List<Etapa>> GetListAsync(Etapa etapaModelo);
        Task<int> InsertAsync(Etapa etapaModeloProyecto);
        Task UpdateAsync(Etapa etapaModeloProyecto);
        Task DeleteAsync(Etapa etapaModeloProyecto);
    }
}
