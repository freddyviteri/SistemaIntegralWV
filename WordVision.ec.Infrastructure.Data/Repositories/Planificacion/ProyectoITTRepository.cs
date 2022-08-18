using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class ProyectoITTRepository : IProyectoITTRepository
    {
        private readonly IRepositoryAsync<ProyectoITT> _repository;
        public ProyectoITTRepository(IRepositoryAsync<ProyectoITT> repository)
        {
            _repository = repository;
        }

        public async Task<ProyectoITT> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProyectoITT>> GetListAsync(ProyectoITT entity)
        {
            IQueryable<ProyectoITT> list = _repository.Entities;

            if (entity.Include)
            {
                list = list.Include(p => p.FaseProgramaArea)
                    .ThenInclude(pt => pt.ProyectoTecnico)
                    .Include(x => x.FaseProgramaArea).ThenInclude(pa => pa.ProgramaArea);

                if (entity.FaseProgramaArea != null)
                {
                    if (entity.FaseProgramaArea.IdProyectoTecnico != 0)
                    {
                        list.Where(x => x.FaseProgramaArea.IdProyectoTecnico == entity.FaseProgramaArea.IdProyectoTecnico);
                    }

                    if (entity.FaseProgramaArea.IdProgramaArea != 0)
                    {
                        list.Where(x => x.FaseProgramaArea.IdProgramaArea == entity.FaseProgramaArea.IdProgramaArea);
                    }

                }
            }

            

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(ProyectoITT entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(ProyectoITT entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
