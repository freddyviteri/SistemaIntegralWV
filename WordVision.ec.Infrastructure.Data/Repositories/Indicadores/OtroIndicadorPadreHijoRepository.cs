using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Infrastructure.Data.Repositories.Indicadores
{
    public class OtroIndicadorPadreHijoRepository : IOtroIndicadorPadreHijoRepository
    {
        private readonly IRepositoryAsync<OtroIndicadorPadreHijo> _repository;
        public OtroIndicadorPadreHijoRepository(IRepositoryAsync<OtroIndicadorPadreHijo> repository)
        {
            _repository = repository;
        }

        public async Task<OtroIndicadorPadreHijo> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id)
                .Include(e => e.Padre)
                .Include(s => s.Hijo)
                .Include(s => s.Estado)
                .FirstOrDefaultAsync();
        }

        public async Task<List<OtroIndicadorPadreHijo>> GetListAsync(OtroIndicadorPadreHijo entity)
        {
            IQueryable<OtroIndicadorPadreHijo> list = _repository.Entities;

            if (entity.Include)
            {
                list = list
                    .Include(e => e.Padre)
                    .Include(s => s.Hijo)
                    .Include(s => s.Estado);

            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(OtroIndicadorPadreHijo entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<List<OtroIndicadorPadreHijo>> InsertRangeAsync(List<OtroIndicadorPadreHijo> entities)
        {
            await _repository.AddRangeAsync(entities);
            return entities;
        }

        public async Task UpdateAsync(OtroIndicadorPadreHijo entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }

}
