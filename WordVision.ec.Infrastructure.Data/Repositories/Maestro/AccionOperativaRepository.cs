using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Maestro
{
    public class AccionOperativaRepository : IAccionOperativaRepository
    {
        private readonly IRepositoryAsync<AccionOperativa> _repository;
        public AccionOperativaRepository(IRepositoryAsync<AccionOperativa> repository)
        {
            _repository = repository;
        }

        public async Task<AccionOperativa> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<AccionOperativa> list = _repository.Entities.Where(p => p.Id == id);

            if (include)
            {
                list = list.Include(g => g.Estado);
            }

            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<AccionOperativa>> GetListAsync(AccionOperativa AccionOperativaModelo)
        {
            IQueryable<AccionOperativa> list = _repository.Entities;


            if (AccionOperativaModelo.Include)
            {
                list = list.Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(AccionOperativa AccionOperativaModeloProyecto)
        {
            await _repository.AddAsync(AccionOperativaModeloProyecto);
            return AccionOperativaModeloProyecto.Id;
        }

        public async Task UpdateAsync(AccionOperativa AccionOperativaModeloProyecto)
        {
            await _repository.UpdateAsync(AccionOperativaModeloProyecto);
        }

        public async Task DeleteAsync(AccionOperativa AccionOperativaModeloProyecto)
        {
            await _repository.DeleteAsync(AccionOperativaModeloProyecto);
        }
    }
}
