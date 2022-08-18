using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Interfaces.Repositories.Indicadores
{
    public interface IVinculacionIndicadorRepository
    {
        Task<VinculacionIndicador> GetByIdAsync(int id, bool include = false);
        Task<List<VinculacionIndicador>> GetListAsync(VinculacionIndicador entity);
        Task<int> InsertAsync(VinculacionIndicador entity);
        Task UpdateAsync(VinculacionIndicador entity);
        Task DeleteDetalleVinculacionIndicadorAsync(List<DetalleVinculacionIndicador> list);
    }
}
