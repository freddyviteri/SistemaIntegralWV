using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IAccionOperativaRepository
    {
        Task<AccionOperativa> GetByIdAsync(int id, bool include = false);
        Task<List<AccionOperativa>> GetListAsync(AccionOperativa etapaModelo);
        Task<int> InsertAsync(AccionOperativa etapaModeloProyecto);
        Task UpdateAsync(AccionOperativa etapaModeloProyecto);
        Task DeleteAsync(AccionOperativa etapaModeloProyecto);
    }
}
