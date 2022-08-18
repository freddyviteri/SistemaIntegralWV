using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Infrastructure.Data.Repositories.Indicadores
{
    public class ProyectoTecnicoPorProgramaAreaRepository : IProyectoTecnicoPorProgramaAreaRepository
    {
        private readonly IRepositoryAsync<ProyectoTecnicoPorProgramaArea> _repository;

        public ProyectoTecnicoPorProgramaAreaRepository(IRepositoryAsync<ProyectoTecnicoPorProgramaArea> repository)
        {
            _repository = repository;
        }

        public async Task<ProyectoTecnicoPorProgramaArea> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProyectoTecnicoPorProgramaArea>> GetListAsync(ProyectoTecnicoPorProgramaArea entity,int idPt)
        {
            //List<ProyectoTecnicoPorProgramaArea> list2 = await _repository.GetAllAsync();
            IQueryable<ProyectoTecnicoPorProgramaArea> list = _repository.Entities.Where(p => p.LogFrameIndicadorPR.LogFrame.ProyectoTecnico.Id == idPt);

            if (entity.Include)
            {
                list = list.Include(e => e.LogFrameIndicadorPR).ThenInclude(pr => pr.IndicadorPR)
                            .Include(e => e.LogFrameIndicadorPR)
                            .ThenInclude(l => l.LogFrame).ThenInclude(p => p.ProyectoTecnico);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(ProyectoTecnicoPorProgramaArea entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<List<ProyectoTecnicoPorProgramaArea>> InsertRangeAsync(List<ProyectoTecnicoPorProgramaArea> entities)
        {
            await _repository.AddRangeAsync(entities);
            return entities;
        }

        public async Task UpdateAsync(ProyectoTecnicoPorProgramaArea entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
