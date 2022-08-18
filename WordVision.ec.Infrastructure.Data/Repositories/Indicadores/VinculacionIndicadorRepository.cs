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
        private readonly IRepositoryAsync<DetalleVinculacionIndicador> _detalleRepository;
        public VinculacionIndicadorRepository(IRepositoryAsync<VinculacionIndicador> repository,
               IRepositoryAsync<DetalleVinculacionIndicador> detalleRepository)
        {
            _repository = repository;
            _detalleRepository = detalleRepository;
        }

        public async Task<VinculacionIndicador> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<VinculacionIndicador> list = _repository.Entities.Where(p => p.Id == id);
            if (include)
            {
                list = list.Include(d => d.DetalleVinculacionIndicadores).
                    ThenInclude(t => t.OtroIndicador.TipoIndicador).
                    Include(i => i.IndicadorPR);
            }

            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<VinculacionIndicador>> GetListAsync(VinculacionIndicador entity)
        {
            IQueryable<VinculacionIndicador> list = _repository.Entities;

            if (entity.Include)
            {
                list = list.Include(d => d.DetalleVinculacionIndicadores).
                    ThenInclude(t => t.OtroIndicador.TipoIndicador).
                    Include(i => i.IndicadorPR).Include(e=> e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(VinculacionIndicador entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(VinculacionIndicador entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteDetalleVinculacionIndicadorAsync(List<DetalleVinculacionIndicador> list)
        {
            foreach (var item in list)
                await _detalleRepository.DeleteAsync(item);
        }
    }
}
