using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Indicadores
{
    public class MarcoLogicoAsignadoaRepository : IMarcoLogicoAsignadoRepository
    {
        private readonly IRepositoryAsync<MarcoLogicoAsignado> _repository;

        public MarcoLogicoAsignadoaRepository(IRepositoryAsync<MarcoLogicoAsignado> repository)
        {
            _repository = repository;
        }

        public async Task<MarcoLogicoAsignado> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id)
                .Include(e => e.MarcoLogico)
                    .ThenInclude(pr => pr.IndicadorML)
                        .ThenInclude(x => x.Target)
                .Include(x => x.MarcoLogico)
                    .ThenInclude(x => x.IndicadorML)
                        .ThenInclude(x => x.Frecuencia)
                .Include(x => x.MarcoLogico)
                    .ThenInclude(x => x.IndicadorML)
                        .ThenInclude(x => x.TipoMedida)
                .Include(x => x.MarcoLogico)
                    .ThenInclude(x => x.IndicadorML)
                        .ThenInclude(x => x.ActorParticipante)
                .Include(e => e.MarcoLogico)
                    .ThenInclude(l => l.LogFrame)
                        .ThenInclude(p => p.ProgramaTecnico)
                .Include(c => c.Responsable)
                .Include(s => s.Supervisor)
                .Include(e => e.MarcoLogico)
                            .ThenInclude(l => l.LogFrame).ThenInclude(n => n.Nivel).FirstOrDefaultAsync();
        }

        public async Task<List<MarcoLogicoAsignado>> GetListAsync(MarcoLogicoAsignado entity)
        {
            //List<ProgramaTecnicoPorProgramaArea> list2 = await _repository.GetAllAsync();
            IQueryable<MarcoLogicoAsignado> list = _repository.Entities;

            if (entity?.IdProyectoTecnico != null)
            {
                if (entity?.IdProyectoTecnico > 0)
                {
                    list = list.Where(p => p.IdProyectoTecnico == entity.IdProyectoTecnico);
                }
            }
            if (entity.Include)
            {
                list = list.Include(e => e.MarcoLogico)
                            .ThenInclude(pr => pr.IndicadorML)
                                .ThenInclude(x => x.Target)
                            .Include(x => x.MarcoLogico)
                            .ThenInclude(x => x.IndicadorML)
                                .ThenInclude(x => x.Frecuencia)
                            .Include(x => x.MarcoLogico)
                                .ThenInclude(x => x.IndicadorML)
                                    .ThenInclude(x => x.TipoMedida)
                            .Include(x => x.MarcoLogico)
                                .ThenInclude(x => x.IndicadorML)
                                    .ThenInclude(x => x.ActorParticipante)
                            .Include(e => e.MarcoLogico)
                                .ThenInclude(l => l.LogFrame)
                            .ThenInclude(p => p.ProgramaTecnico)
                             .Include(e => e.MarcoLogico)
                                .ThenInclude(l => l.LogFrame)
                                    .ThenInclude(p => p.SectorProgramatico)
                            .Include(e => e.MarcoLogico)
                                .ThenInclude(l => l.LogFrame)
                                    .ThenInclude(p => p.TipoActividad)
                            .Include(e => e.MarcoLogico)
                                .ThenInclude(l => l.LogFrame)
                                    .ThenInclude(p => p.ModeloProyecto)
                            .Include(c => c.Responsable)
                            .Include(s => s.Supervisor)
                            .Include(e => e.MarcoLogico)
                            .ThenInclude(l => l.LogFrame).ThenInclude(n => n.Nivel);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(MarcoLogicoAsignado entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<List<MarcoLogicoAsignado>> InsertRangeAsync(List<MarcoLogicoAsignado> entities)
        {
            await _repository.AddRangeAsync(entities);
            return entities;
        }

        public async Task UpdateAsync(MarcoLogicoAsignado entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
