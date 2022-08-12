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
    public class IndicadorMLRepository : IIndicadorMLRepository
    {
        private readonly IRepositoryAsync<IndicadorML> _repository;
        public IndicadorMLRepository(IRepositoryAsync<IndicadorML> repository)
        {
            _repository = repository;
        }

        public async Task<IndicadorML> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<IndicadorML>> GetListAsync(IndicadorML IndicadorML)
        {
            return await GetQueryable(IndicadorML).ToListAsync();
        }

        public async Task<int> CountAsync(IndicadorML IndicadorML)
        {
            return await GetQueryable(IndicadorML).CountAsync();
        }

        private IQueryable<IndicadorML> GetQueryable(IndicadorML IndicadorML)
        {
            IQueryable<IndicadorML> list = _repository.Entities;

            if (!string.IsNullOrEmpty(IndicadorML.Codigo))
                list = list.Where(c => c.Codigo == IndicadorML.Codigo);

            if (IndicadorML.Include)
            {
                list = list.Include(p => p.Frecuencia).Include(p => p.ActorParticipante)
                       .Include(p => p.TipoMedida).Include(i => i.Target)
                       .Include(e => e.Estado)
                       .Include(a => a.Area);
            }

            return list;
        }

        public async Task<int> InsertAsync(IndicadorML IndicadorML)
        {
            await _repository.AddAsync(IndicadorML);
            return IndicadorML.Id;
        }

        public async Task UpdateAsync(IndicadorML IndicadorML)
        {
            await _repository.UpdateAsync(IndicadorML);
        }

        public async Task DeleteAsync(IndicadorML IndicadorML)
        {
            await _repository.DeleteAsync(IndicadorML);
        }
    }
}
