using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Indicadores
{
    public interface IProyectoTecnicoPorProgramaAreaRepository
    {

        Task<ProyectoTecnicoPorProgramaArea> GetByIdAsync(int id);
        Task<List<ProyectoTecnicoPorProgramaArea>> GetListAsync(ProyectoTecnicoPorProgramaArea entity,int idPt);
        Task<int> InsertAsync(ProyectoTecnicoPorProgramaArea entity);
        Task<List<ProyectoTecnicoPorProgramaArea>> InsertRangeAsync(List<ProyectoTecnicoPorProgramaArea> entities);
        Task UpdateAsync(ProyectoTecnicoPorProgramaArea entity);      
    }
}
