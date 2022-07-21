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
    public class ProgramaAreaRepository : IProgramaAreaRepository
    {
        private readonly IRepositoryAsync<ProgramaArea> _repository;
        public ProgramaAreaRepository(IRepositoryAsync<ProgramaArea> repository)
        {
            _repository = repository;
        }

        public async Task<ProgramaArea> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProgramaArea>> GetListAsync(ProgramaArea programaArea)
        {
            IQueryable<ProgramaArea> list = _repository.Entities;

            if (!string.IsNullOrEmpty(programaArea.Codigo))
                list = list.Where(c => c.Codigo == programaArea.Codigo);

            if (programaArea.Include)
            {
                list = list.Include(p => p.ProyectoTecnico).Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(ProgramaArea programaArea)
        {
            await _repository.AddAsync(programaArea);
            return programaArea.Id;
        }

        public async Task UpdateAsync(ProgramaArea programaArea)
        {
            await _repository.UpdateAsync(programaArea);
        }
    }
}
