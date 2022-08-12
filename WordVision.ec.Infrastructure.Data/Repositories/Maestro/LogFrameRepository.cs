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
        private readonly IRepositoryAsync<MarcoLogico> _repositoryLogIndicador;


        public LogFrameRepository(IRepositoryAsync<LogFrame> repository,
            IRepositoryAsync<MarcoLogico> repositoryLogIndicador)
        {
            _repository = repository;
            _repositoryLogIndicador = repositoryLogIndicador;
        }

        public async Task<LogFrame> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<LogFrame> list = _repository.Entities.Where(p => p.Id == id);
            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<LogFrame>> GetListAsync(LogFrame logFrame)
        {
            IQueryable<LogFrame> list = _repository.Entities;

            if (logFrame.IdProgramaTecnico != null)
            {
                if (logFrame.IdProgramaTecnico > 0)
                {
                    list.Where(x => x.IdProgramaTecnico == logFrame.IdProgramaTecnico);
                }
            }

            if (logFrame?.IdNivel != null)
            {
                if (logFrame.IdNivel > 0)
                {
                    list.Where(x => x.IdProgramaTecnico == logFrame.IdProgramaTecnico);
                }
            }

            if (logFrame.Include)
            {
                list = list.Include(p => p.Nivel).Include(r => r.ModeloProyecto)
                    .Include(r => r.TipoActividad).Include(r => r.ProgramaTecnico)
                    .Include(r => r.SectorProgramatico)
                    .Include(e => e.Estado)
                    .Include(e => e.ProgramaTecnico);

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

        public async Task DeleteMarcoLogicoAsync(List<MarcoLogico> list)
        {
            foreach (var item in list)
                await _repositoryLogIndicador.DeleteAsync(item);
        }

        public async Task DeleteAsync(LogFrame logFrame)
        {
            await _repository.DeleteAsync(logFrame);
        }

        public async Task<List<LogFrame>> ListaLogFrameFromNivel(int idprogramaatecnico, int[] ids)
        {
            var query = from item in _repository.Entities
                        where ids.Contains(item.IdNivel) && item.IdProgramaTecnico == idprogramaatecnico
                        select item;
            var res = await query.Include(x => x.Nivel)
                                .Include(x => x.TipoActividad)
                                .Include(x => x.SectorProgramatico)
                                .Include(x => x.ModeloProyecto)
                                .ToListAsync();
            return res;
        }
    }
}
