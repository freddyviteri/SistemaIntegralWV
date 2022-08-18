using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IEtapaModeloProyectoRepository
    {
        Task<EtapaModeloProyecto> GetByIdAsync(int id, bool include = false);
        Task<List<EtapaModeloProyecto>> GetListAsync(EtapaModeloProyecto etapaModelo);
        Task<int> InsertAsync(EtapaModeloProyecto etapaModeloProyecto);
        Task UpdateAsync(EtapaModeloProyecto etapaModeloProyecto);
        Task DeleteAsync(EtapaModeloProyecto etapaModeloProyecto);
    }
}
