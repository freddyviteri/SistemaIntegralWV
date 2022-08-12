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
    public class ProgramaTecnicoRepository : IProgramaTecnicoRepository
    {
        private readonly IRepositoryAsync<ProgramaTecnico> _repository;
        public ProgramaTecnicoRepository(IRepositoryAsync<ProgramaTecnico> repository)
        {
            _repository = repository;
        }

        public async Task<ProgramaTecnico> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProgramaTecnico>> GetListAsync(ProgramaTecnico model)
        {
            IQueryable<ProgramaTecnico> list = _repository.Entities;

            //if (!string.IsNullOrEmpty(model.Codigo))
            //    list = list.Where(c => c.Codigo == model.Codigo);

            if (model.Include)
            {
                list = list.Include(p => p.TipoProyecto).Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(ProgramaTecnico model)
        {
            await _repository.AddAsync(model);
            return model.Id;
        }

        public async Task UpdateAsync(ProgramaTecnico model)
        {
            await _repository.UpdateAsync(model);
        }
    }
}
