using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Indicadores
{
    public interface IProgramaTecnicoPorProgramaAreaRepository
    {

        Task<ProgramaTecnicoPorProgramaArea> GetByIdAsync(int id);
        Task<List<ProgramaTecnicoPorProgramaArea>> GetListAsync(ProyectoTecnico entity);
        Task<int> InsertAsync(ProgramaTecnicoPorProgramaArea entity);
        Task<List<ProgramaTecnicoPorProgramaArea>> InsertRangeAsync(List<ProgramaTecnicoPorProgramaArea> entities);
        Task UpdateAsync(ProgramaTecnicoPorProgramaArea entity);      
    }
}
