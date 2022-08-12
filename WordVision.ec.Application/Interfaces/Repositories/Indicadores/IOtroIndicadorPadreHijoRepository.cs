using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Interfaces.Repositories.Indicadores
{
    public interface IOtroIndicadorPadreHijoRepository
    {
        Task<OtroIndicadorPadreHijo> GetByIdAsync(int id);
        Task<List<OtroIndicadorPadreHijo>> GetListAsync(OtroIndicadorPadreHijo entity);
        Task<int> InsertAsync(OtroIndicadorPadreHijo entity);
        Task<List<OtroIndicadorPadreHijo>> InsertRangeAsync(List<OtroIndicadorPadreHijo> entities);
        Task UpdateAsync(OtroIndicadorPadreHijo entity);
    }
}
