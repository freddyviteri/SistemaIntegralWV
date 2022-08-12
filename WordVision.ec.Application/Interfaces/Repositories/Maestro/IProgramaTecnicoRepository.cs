using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IProgramaTecnicoRepository
    {
        Task<ProgramaTecnico> GetByIdAsync(int id);
        Task<List<ProgramaTecnico>> GetListAsync(ProgramaTecnico proyectoTecnico);
        Task<int> InsertAsync(ProgramaTecnico proyectoTecnico);
        Task UpdateAsync(ProgramaTecnico proyectoTecnico);
    }
}
