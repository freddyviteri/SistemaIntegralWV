﻿using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Infrastructure.Data.CacheKeys.Planificacion;

namespace WordVision.ec.Infrastructure.Data.CacheRepositories.Planificacion
{
    public class GestionCacheRepository : IGestionCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IGestionRepository _repository;
        public GestionCacheRepository(IDistributedCache distributedCache, IGestionRepository repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public async Task<Gestion> GetByIdAsync(int gestionId)
        {
            string cacheKey = GestionCacheKeys.GetKey(gestionId);
            var entidad = await _distributedCache.GetAsync<Gestion>(cacheKey);
            if (entidad == null)
            {
                entidad = await _repository.GetByIdAsync(gestionId);
                Throw.Exception.IfNull(entidad, "Gestion", "Gestion no encontrado");
                await _distributedCache.SetAsync(cacheKey, entidad);
            }
            return entidad;
        }

        public async Task<List<Gestion>> GetCachedListAsync()
        {
            string cacheKey = GestionCacheKeys.ListKey;
            var entidadList = await _distributedCache.GetAsync<List<Gestion>>(cacheKey);
            if (entidadList == null)
            {
                entidadList = await _repository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, entidadList);
            }
            return entidadList;
        }
    }
}
