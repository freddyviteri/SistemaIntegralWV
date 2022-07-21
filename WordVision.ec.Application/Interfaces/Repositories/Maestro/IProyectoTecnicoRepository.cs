using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IProyectoTecnicoRepository
    {
        Task<ProyectoTecnico> GetByIdAsync(int id);
        Task<List<ProyectoTecnico>> GetListAsync(ProyectoTecnico proyectoTecnico);
        Task<int> InsertAsync(ProyectoTecnico proyectoTecnico);
        Task UpdateAsync(ProyectoTecnico proyectoTecnico);
    }
}
