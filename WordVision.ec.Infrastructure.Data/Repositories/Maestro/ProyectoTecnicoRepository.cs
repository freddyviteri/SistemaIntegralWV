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
    public class ProyectoTecnicoRepository : IProyectoTecnicoRepository
    {
        private readonly IRepositoryAsync<ProyectoTecnico> _repository;
        public ProyectoTecnicoRepository(IRepositoryAsync<ProyectoTecnico> repository)
        {
            _repository = repository;
        }

        public async Task<ProyectoTecnico> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProyectoTecnico>> GetListAsync(ProyectoTecnico proyectoTecnico)
        {
            IQueryable<ProyectoTecnico> list = _repository.Entities;

            if (!string.IsNullOrEmpty(proyectoTecnico.Codigo))
                list = list.Where(c => c.Codigo == proyectoTecnico.Codigo);

            if (proyectoTecnico.Include)
            {
                list = list.Include(p => p.Financiamiento).Include(g => g.Ubicacion)
                .Include(e => e.TipoProyecto).Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(ProyectoTecnico proyectoTecnico)
        {
            await _repository.AddAsync(proyectoTecnico);
            return proyectoTecnico.Id;
        }

        public async Task UpdateAsync(ProyectoTecnico proyectoTecnico)
        {
            await _repository.UpdateAsync(proyectoTecnico);
        }
    }
}
