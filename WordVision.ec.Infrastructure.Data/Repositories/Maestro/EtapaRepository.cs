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
    public class EtapaRepository : IEtapaRepository
    {
        private readonly IRepositoryAsync<Etapa> _repository;
        public EtapaRepository(IRepositoryAsync<Etapa> repository)
        {
            _repository = repository;
        }

        public async Task<Etapa> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<Etapa> list = _repository.Entities.Where(p => p.Id == id);

            if (include)
            {
                list = list.Include(g => g.Estado);
            }

            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<Etapa>> GetListAsync(Etapa etapaModelo)
        {
            IQueryable<Etapa> list = _repository.Entities;


            if (etapaModelo.Include)
            {
                list = list.Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(Etapa etapaModeloProyecto)
        {
            await _repository.AddAsync(etapaModeloProyecto);
            return etapaModeloProyecto.Id;
        }

        public async Task UpdateAsync(Etapa etapaModeloProyecto)
        {
            await _repository.UpdateAsync(etapaModeloProyecto);
        }

        public async Task DeleteAsync(Etapa etapaModeloProyecto)
        {
            await _repository.DeleteAsync(etapaModeloProyecto);
        }
    }
}
