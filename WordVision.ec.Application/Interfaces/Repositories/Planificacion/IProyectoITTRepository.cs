using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IProyectoITTRepository
    {
        Task<ProyectoITT> GetByIdAsync(int id);
        Task<List<ProyectoITT>> GetListAsync(ProyectoITT entity);
        Task<int> InsertAsync(ProyectoITT entity);
        Task UpdateAsync(ProyectoITT entity);
    }
}
