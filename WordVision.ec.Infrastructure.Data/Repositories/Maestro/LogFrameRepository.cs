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
    public class LogFrameRepository : ILogFrameRepository
    {
        private readonly IRepositoryAsync<LogFrame> _repository;
        private readonly IRepositoryAsync<LogFrameIndicadorPR> _repositoryLogIndicador;
        public LogFrameRepository(IRepositoryAsync<LogFrame> repository,
            IRepositoryAsync<LogFrameIndicadorPR> repositoryLogIndicador)
        {
            _repository = repository;
            _repositoryLogIndicador = repositoryLogIndicador;
        }

        public async Task<LogFrame> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<LogFrame> list = _repository.Entities.Where(p => p.Id == id);
            //if (include)
            //{
            //    list = list.Include(p => p.LogFrameIndicadores);
            //}
            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<LogFrame>> GetListAsync(LogFrame logFrame)
        {
            IQueryable<LogFrame> list = _repository.Entities;

            if (logFrame.Include)
            {
                list = list.Include(p => p.Nivel).Include(r => r.Rubro)
                    .Include(r => r.TipoActividad).Include(r => r.ProyectoTecnico)
                    .Include(r => r.SectorProgramatico)//.Include(r => r.LogFrameIndicadores)
                    //.ThenInclude(i=> i.IndicadorPR)
                    .Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(LogFrame logFrame)
        {
            await _repository.AddAsync(logFrame);
            return logFrame.Id;
        }

        public async Task UpdateAsync(LogFrame logFrame)
        {
            await _repository.UpdateAsync(logFrame);
        }

        public async Task DeleteLogFrameIndicadorPRAsync(List<LogFrameIndicadorPR> list)
        {
            foreach(var item in list)
            await _repositoryLogIndicador.DeleteAsync(item);
        }

        public async Task DeleteAsync(LogFrame logFrame)
        {
            await _repository.DeleteAsync(logFrame);
        }
    }
}
