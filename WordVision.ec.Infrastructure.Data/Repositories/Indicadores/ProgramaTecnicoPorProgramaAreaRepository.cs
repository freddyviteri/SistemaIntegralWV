using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Indicadores
{
    public class ProgramaTecnicoPorProgramaAreaRepository : IProgramaTecnicoPorProgramaAreaRepository
    {
        private readonly IRepositoryAsync<ProgramaTecnicoPorProgramaArea> _repository;

        public ProgramaTecnicoPorProgramaAreaRepository(IRepositoryAsync<ProgramaTecnicoPorProgramaArea> repository)
        {
            _repository = repository;
        }

        public async Task<ProgramaTecnicoPorProgramaArea> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProgramaTecnicoPorProgramaArea>> GetListAsync(ProyectoTecnico entity)
        {
            //List<ProgramaTecnicoPorProgramaArea> list2 = await _repository.GetAllAsync();
            IQueryable<ProgramaTecnicoPorProgramaArea> list = _repository.Entities.Where(p => p.LogFrameIndicadorPR.LogFrame.ProyectoTecnico.Id == entity.Id && p.LogFrameIndicadorPR.LogFrame.ProyectoTecnico.IdProgramaArea == entity.IdProgramaArea && p.LogFrameIndicadorPR.LogFrame.ProyectoTecnico.IdProgramaTecnico == entity.IdProgramaTecnico);

            if (entity.Include)
            {
                list = list.Include(e => e.LogFrameIndicadorPR).ThenInclude(pr => pr.IndicadorPR)
                            .Include(e => e.LogFrameIndicadorPR)
                            .ThenInclude(l => l.LogFrame).ThenInclude(p => p.ProyectoTecnico);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(ProgramaTecnicoPorProgramaArea entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<List<ProgramaTecnicoPorProgramaArea>> InsertRangeAsync(List<ProgramaTecnicoPorProgramaArea> entities)
        {
            await _repository.AddRangeAsync(entities);
            return entities;
        }

        public async Task UpdateAsync(ProgramaTecnicoPorProgramaArea entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
