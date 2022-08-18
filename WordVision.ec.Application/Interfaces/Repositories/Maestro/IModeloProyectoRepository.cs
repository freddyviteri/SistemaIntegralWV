using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IModeloProyectoRepository
    {
        Task<ModeloProyecto> GetByIdAsync(int id);
        Task<List<ModeloProyecto>> GetListAsync(ModeloProyecto modelo);
        Task<int> InsertAsync(ModeloProyecto modeloProyecto);
        Task UpdateAsync(ModeloProyecto modeloProyecto);
        Task DeleteAsync(ModeloProyecto modeloProyecto);
    }
}
