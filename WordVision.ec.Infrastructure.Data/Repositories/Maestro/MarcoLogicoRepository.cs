using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Maestro
{
    public class MarcoLogicoRepository : IMarcoLogicoRepository
    {
        private readonly IRepositoryAsync<MarcoLogico> _repository;

        public MarcoLogicoRepository(IRepositoryAsync<MarcoLogico> repository)
        {
            _repository = repository;
        }

        public async Task<MarcoLogico> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<MarcoLogico> list = _repository.Entities.Where(p => p.Id == id);
            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<MarcoLogico>> GetByPtAsync(ProgramaTecnico entity)
        {
            IQueryable<MarcoLogico> list = _repository.Entities.Where(p => p.LogFrame.IdProgramaTecnico == entity.Id);

            list = list.Include(r => r.LogFrame).ThenInclude(p => p.ProgramaTecnico)
            .Include(r => r.LogFrame).ThenInclude(e => e.Nivel)
            .Include(i => i.IndicadorML)
                   .Include(e => e.Estado);

            //  var lista2 = await list.ToListAsync();
            return await list.ToListAsync();
        }

        public async Task<List<MarcoLogico>> GetListAsync(MarcoLogico entity)
        {
            IQueryable<MarcoLogico> list = _repository.Entities;

            if (entity.Include)
            {
                list = list.Include(r => r.LogFrame).ThenInclude(e => e.Nivel)
                    .Include(i => i.IndicadorML)
                    .Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(MarcoLogico entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(MarcoLogico entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(MarcoLogico entity)
        {
            await _repository.DeleteAsync(entity);
        }
    }
}
