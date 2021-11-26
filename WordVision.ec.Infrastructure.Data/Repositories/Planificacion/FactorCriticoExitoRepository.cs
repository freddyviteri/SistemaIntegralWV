﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class FactorCriticoExitoRepository : IFactorCriticoExitoRepository
    {
        private readonly IRepositoryAsync<FactorCriticoExito> _repository;
        private readonly IDistributedCache _distributedCache;

        public FactorCriticoExitoRepository(IDistributedCache distributedCache, IRepositoryAsync<FactorCriticoExito> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<FactorCriticoExito> FactorCriticoExitoes => _repository.Entities;

        public async Task DeleteAsync(FactorCriticoExito FactorCriticoExito)
        {
            await _repository.DeleteAsync(FactorCriticoExito);
        }

        public async Task<FactorCriticoExito> GetByIdAsync(int FactorCriticoExitoId)
        {
            return await _repository.Entities.Where(p => p.Id == FactorCriticoExitoId).Include(x => x.IndicadorEstrategicos).FirstOrDefaultAsync();
        }

        public async Task<List<FactorCriticoExito>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<FactorCriticoExito>> GetListxObjetivoAsync(int idObjetivo, int idGestion)
        {
            var dd = _repository.Entities.Where(x => x.IdObjetivoEstra == idObjetivo)
                .Include(p => p.IndicadorEstrategicos)
                .ThenInclude(o => o.Productos)
                .ThenInclude(ifs => ifs.IndicadorPOAs)
                .Include(o => o.IndicadorEstrategicos)
                .ThenInclude(af => af.IndicadorAFs.Where(i => i.Anio == idGestion.ToString()))
                .ToListAsync();
            return await dd;
        }

        public async Task<List<FactorCriticoExito>> GetListxObjetivoAsync(int idObjetivo, int idColaborador, int idGestion)
        {
            var dd = _repository.Entities.Where(x => x.IdObjetivoEstra == idObjetivo)
                .Include(p => p.IndicadorEstrategicos.Where(i => i.Responsable == idColaborador)).ThenInclude(o => o.Productos).ThenInclude(ifs => ifs.IndicadorPOAs)
                .Include(o => o.IndicadorEstrategicos)
                .ThenInclude(af => af.IndicadorAFs.Where(i => i.Anio == idGestion.ToString()))
                .ToListAsync();
            return await dd;
        }

        public async Task<int> InsertAsync(FactorCriticoExito FactorCriticoExito)
        {
            await _repository.AddAsync(FactorCriticoExito);
            return FactorCriticoExito.Id;
        }

        public async Task UpdateAsync(FactorCriticoExito FactorCriticoExito)
        {
            await _repository.UpdateAsync(FactorCriticoExito);
        }
    }
}
