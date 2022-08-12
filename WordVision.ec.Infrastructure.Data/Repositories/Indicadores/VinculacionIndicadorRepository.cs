using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Infrastructure.Data.Repositories.Indicadores
{
    public class VinculacionIndicadorRepository : IVinculacionIndicadorRepository
    {
        private readonly IRepositoryAsync<VinculacionIndicador> _repository;
        public VinculacionIndicadorRepository(IRepositoryAsync<VinculacionIndicador> repository)
        {
            _repository = repository;
        }

        public async Task<VinculacionIndicador> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<VinculacionIndicador> list = _repository.Entities.Where(p => p.Id == id);
            if (include)
            {
                list = list.
                    Include(o => o.OtroIndicador).
                    Include(m => m.MarcoLogico).ThenInclude(i => i.IndicadorML).
                    Include(m => m.MarcoLogico).ThenInclude(i => i.LogFrame).
                    Include(e => e.Estado);
            }

            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<VinculacionIndicador>> GetListAsync(VinculacionIndicador entity)
        {
            IQueryable<VinculacionIndicador> list = _repository.Entities;

            if (entity?.IdMarcoLogico != null)
            {
                if (entity?.IdMarcoLogico > 0)
                {
                    list.Where(x => x.IdMarcoLogico == entity.IdMarcoLogico);
                }
            }

            if (entity.Include)
            {
                list = list.
                    Include(o => o.OtroIndicador).ThenInclude(x => x.TipoIndicador).
                    Include(m => m.MarcoLogico).ThenInclude(i => i.IndicadorML).
                    Include(m => m.MarcoLogico).ThenInclude(i => i.LogFrame).
                    Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }


        public async Task<int> InsertAsync(VinculacionIndicador entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<List<VinculacionIndicador>> InsertRangeAsync(List<VinculacionIndicador> entities)
        {
            await _repository.AddRangeAsync(entities);
            return entities;
        }

        public async Task UpdateAsync(VinculacionIndicador entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
