using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IModeloProyectoEtapaAccionRepository
    {
        Task<ModeloProyectoEtapaAccion> GetByIdAsync(int id, bool include = false);
        Task<List<ModeloProyectoEtapaAccion>> GetListAsync(ModeloProyectoEtapaAccion etapaModelo);
        Task<int> InsertAsync(ModeloProyectoEtapaAccion etapaModeloProyecto);
        Task UpdateAsync(ModeloProyectoEtapaAccion etapaModeloProyecto);
        Task DeleteAsync(ModeloProyectoEtapaAccion etapaModeloProyecto);
        Task DeleteModeloProyectoAllAsync(int idmodeloproyecto);
    }
}
