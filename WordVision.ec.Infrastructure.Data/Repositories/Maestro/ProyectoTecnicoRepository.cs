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

        public async Task<List<ProgramaArea>> GetAvailableProgramasAreaAsync()
        {
            IQueryable<ProyectoTecnico> list = _repository.Entities;

            List<ProgramaArea> programasArea = await list.Select( p => p.ProgramaArea).Distinct().ToListAsync();

            return programasArea;
        }

        public async Task<List<ProgramaTecnico>> GetAvailableProgramasTecnicosAsync(int idProgramaArea)
        {
            IQueryable<ProyectoTecnico> list = _repository.Entities.Where(p => p.IdProgramaTecnico != 0 && p.IdProgramaArea == idProgramaArea).Include(pa => pa.ProgramaArea).Include(pt => pt.ProgramaTecnico);

            List<ProgramaTecnico> proyectosTecnicos = await list.Select(p => p.ProgramaTecnico).Distinct().ToListAsync();

            return proyectosTecnicos;
        }

        public async Task<List<ProyectoTecnico>> GetAvailableProyectosTecnicosAsync(int idProgramaArea, int idProgramaTecnico)
        {
            IQueryable<ProyectoTecnico> list = _repository.Entities.Where(p => p.IdProgramaArea == idProgramaArea && p.IdProgramaTecnico == idProgramaTecnico).Include(pa=> pa.ProgramaArea).Include(pt => pt.ProgramaTecnico);
            return await list.ToListAsync();
        }

        public async Task<ProyectoTecnico> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).Include(p => p.ProgramaArea).Include(g => g.ProgramaTecnico).ThenInclude(x => x.TipoProyecto)
                    .Include(x => x.Ubicacion).Include(x => x.Financiamiento)
                    .Include(e => e.Estado).FirstOrDefaultAsync();
        }

        public async Task<List<ProyectoTecnico>> GetListAsync(ProyectoTecnico proyectoTecnico)
        {
            IQueryable<ProyectoTecnico> list = _repository.Entities;

            if (!string.IsNullOrEmpty(proyectoTecnico.Codigo))
                list = list.Where(c => c.Codigo == proyectoTecnico.Codigo);

            if (proyectoTecnico.Include)
            {
                list = list.Include(p => p.ProgramaArea).Include(g => g.ProgramaTecnico).ThenInclude(x => x.TipoProyecto)
                    .Include(x => x.Ubicacion).Include(x => x.Financiamiento)
                    .Include(e => e.Estado);
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
