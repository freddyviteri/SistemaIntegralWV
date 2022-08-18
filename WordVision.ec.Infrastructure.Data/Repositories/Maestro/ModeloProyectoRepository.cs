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
    public class ModeloProyectoRepository : IModeloProyectoRepository
    {
        private readonly IRepositoryAsync<ModeloProyecto> _repository;
        public ModeloProyectoRepository(IRepositoryAsync<ModeloProyecto> repository)
        {
            _repository = repository;
        }

        public async Task<ModeloProyecto> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ModeloProyecto>> GetListAsync(ModeloProyecto modelo)
        {
            IQueryable<ModeloProyecto> list = _repository.Entities;

            if (!string.IsNullOrEmpty(modelo.Codigo))
                list = list.Where(c => c.Codigo == modelo.Codigo);

            if (modelo.Include)
            {
                list = list.Include(p => p.EtapaModeloProyecto).Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(ModeloProyecto modeloProyecto)
        {
            await _repository.AddAsync(modeloProyecto);
            return modeloProyecto.Id;
        }

        public async Task UpdateAsync(ModeloProyecto modeloProyecto)
        {
            await _repository.UpdateAsync(modeloProyecto);
        }

        public async Task DeleteAsync(ModeloProyecto modeloProyecto)
        {
            await _repository.DeleteAsync(modeloProyecto);
        }
    }
}
