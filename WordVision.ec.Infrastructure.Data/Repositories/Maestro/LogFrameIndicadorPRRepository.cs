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
    public class LogFrameIndicadorPRRepository : ILogFrameIndicadorPRRepository
    {
        private readonly IRepositoryAsync<LogFrameIndicadorPR> _repository;

        public LogFrameIndicadorPRRepository(IRepositoryAsync<LogFrameIndicadorPR> repository)
        {
            _repository = repository;
        }

        public async Task<LogFrameIndicadorPR> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<LogFrameIndicadorPR> list = _repository.Entities.Where(p => p.Id == id);
            //if (include)
            //{
            //    list = list.Include(p => p.LogFrameIndicadorPRIndicadores);
            //}
            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<LogFrameIndicadorPR>> GetByPtAsync(LogFrameIndicadorPR entity, int idPT)
        {
            IQueryable<LogFrameIndicadorPR> list = _repository.Entities.Where(p => p.LogFrame.IdProyectoTecnico == idPT);
            if (entity.Include)
            {
                list = list.Include(r => r.LogFrame).ThenInclude(p=> p.ProyectoTecnico).Include(i => i.IndicadorPR)
                       .Include(e => e.Estado);
            }
            return await list.ToListAsync();
        }

        public async Task<List<LogFrameIndicadorPR>> GetListAsync(LogFrameIndicadorPR entity)
        {
            IQueryable<LogFrameIndicadorPR> list = _repository.Entities;

            if (entity.Include)
            {
                list = list.Include(r => r.LogFrame).Include(i => i.IndicadorPR)
                       .Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(LogFrameIndicadorPR entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(LogFrameIndicadorPR entity)
        {
            await _repository.UpdateAsync(entity);
        }

        //public async Task DeleteLogFrameIndicadorPRIndicadorPRAsync(List<LogFrameIndicadorPRIndicadorPR> list)
        //{
        //    foreach (var item in list)
        //        await _repositoryLogIndicador.DeleteAsync(item);
        //}

        public async Task DeleteAsync(LogFrameIndicadorPR entity)
        {
            await _repository.DeleteAsync(entity);
        }
    }
}
