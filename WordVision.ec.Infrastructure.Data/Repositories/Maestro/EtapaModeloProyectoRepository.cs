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
    public class EtapaModeloProyectoRepository : IEtapaModeloProyectoRepository
    {
        private readonly IRepositoryAsync<EtapaModeloProyecto> _repository;
        public EtapaModeloProyectoRepository(IRepositoryAsync<EtapaModeloProyecto> repository)
        {
            _repository = repository;
        }

        public async Task<EtapaModeloProyecto> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<EtapaModeloProyecto> list = _repository.Entities.Where(p => p.Id == id);

            if (include)
            {
                list = list.Include(p => p.AccionOperativa).Include(g => g.Estado);
            }

            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<EtapaModeloProyecto>> GetListAsync(EtapaModeloProyecto etapaModelo)
        {
            IQueryable<EtapaModeloProyecto> list = _repository.Entities;

            if (!string.IsNullOrEmpty(etapaModelo.Etapa) && etapaModelo.IdAccionOperativa != 0)
                list = list.Where(c => c.Etapa == etapaModelo.Etapa && c.IdAccionOperativa == etapaModelo.IdAccionOperativa);

            if (etapaModelo.Include)
            {
                list = list.Include(p => p.AccionOperativa).Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(EtapaModeloProyecto etapaModeloProyecto)
        {
            await _repository.AddAsync(etapaModeloProyecto);
            return etapaModeloProyecto.Id;
        }

        public async Task UpdateAsync(EtapaModeloProyecto etapaModeloProyecto)
        {
            await _repository.UpdateAsync(etapaModeloProyecto);
        }

        public async Task DeleteAsync(EtapaModeloProyecto etapaModeloProyecto)
        {
            await _repository.DeleteAsync(etapaModeloProyecto);
        }
    }
}
