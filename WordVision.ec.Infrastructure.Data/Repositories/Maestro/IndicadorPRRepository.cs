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
    public class IndicadorPRRepository : IIndicadorPRRepository
    {
        private readonly IRepositoryAsync<IndicadorPR> _repository;
        public IndicadorPRRepository(IRepositoryAsync<IndicadorPR> repository)
        {
            _repository = repository;
        }

        public async Task<IndicadorPR> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<IndicadorPR>> GetListAsync(IndicadorPR IndicadorPR)
        {
            return await GetQueryable(IndicadorPR).ToListAsync();
        }

        public async Task<int> CountAsync(IndicadorPR IndicadorPR)
        {
            return await GetQueryable(IndicadorPR).CountAsync();
        }

        private IQueryable<IndicadorPR> GetQueryable(IndicadorPR IndicadorPR)
        {
            IQueryable<IndicadorPR> list = _repository.Entities;

            if (!string.IsNullOrEmpty(IndicadorPR.Codigo))
                list = list.Where(c => c.Codigo == IndicadorPR.Codigo);

            if (IndicadorPR.Include)
            {
                list = list.Include(p => p.Frecuencia).Include(p => p.ActorParticipante)
                       .Include(p => p.TipoMedida).Include(i => i.Target)
                       .Include(e => e.Estado);
            }

            return list;
        }

        public async Task<int> InsertAsync(IndicadorPR IndicadorPR)
        {
            await _repository.AddAsync(IndicadorPR);
            return IndicadorPR.Id;
        }

        public async Task UpdateAsync(IndicadorPR IndicadorPR)
        {
            await _repository.UpdateAsync(IndicadorPR);
        }

        public async Task DeleteAsync(IndicadorPR IndicadorPR)
        {
            await _repository.DeleteAsync(IndicadorPR);
        }
    }
}
