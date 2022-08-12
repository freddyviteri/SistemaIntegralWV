using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Infrastructure.Data.Repositories.Indicadores
{
    public class FaseProgramaAreaRepository : IFaseProgramaAreaRepository
    {
        private readonly IRepositoryAsync<FaseProgramaArea> _repository;
        public FaseProgramaAreaRepository(IRepositoryAsync<FaseProgramaArea> repository)
        {
            _repository = repository;
        }

        public async Task<FaseProgramaArea> GetByIdAsync(int id)
        {
            var cuerpo = await _repository.Entities.Include(p => p.FaseProyecto)
                       .Include(p => p.ProyectoTecnico).ThenInclude(x => x.ProgramaArea)
                       .Include(p => p.ProyectoTecnico).ThenInclude(x => x.ProgramaTecnico).ThenInclude(x => x.TipoProyecto)
                        .Include(p => p.ProyectoTecnico).ThenInclude(x => x.Financiamiento)
                         .Include(p => p.ProyectoTecnico).ThenInclude(x => x.Ubicacion)
                       .Include(e => e.Estado).Where(p => p.Id == id).FirstOrDefaultAsync();
            return cuerpo;
        }

        public async Task<List<FaseProgramaArea>> GetListAsync(FaseProgramaArea entity)
        {
            IQueryable<FaseProgramaArea> list = _repository.Entities;

            if (entity.IdProyectoTecnico > 0)
            {
                list.Where(x => x.IdProyectoTecnico == entity.IdProyectoTecnico);
            }

            if (entity.IdEstado > 0)
            {
                list.Where(x => x.IdEstado == entity.IdEstado);
            }

            if (entity.Include)
            {
                list = list.Include(p => p.FaseProyecto)
                       .Include(p => p.ProyectoTecnico).ThenInclude(x => x.ProgramaArea)
                       .Include(p => p.ProyectoTecnico).ThenInclude(x => x.ProgramaTecnico).ThenInclude(x => x.TipoProyecto)
                        .Include(p => p.ProyectoTecnico).ThenInclude(x => x.Financiamiento)
                         .Include(p => p.ProyectoTecnico).ThenInclude(x => x.Ubicacion)
                       .Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(FaseProgramaArea entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(FaseProgramaArea entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
