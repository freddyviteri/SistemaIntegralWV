using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Maestro
{
    public class ModeloProyectoEtapaAccionRepository : IModeloProyectoEtapaAccionRepository
    {
        private readonly IRepositoryAsync<ModeloProyectoEtapaAccion> _repository;
        public ModeloProyectoEtapaAccionRepository(IRepositoryAsync<ModeloProyectoEtapaAccion> repository)
        {
            _repository = repository;
        }

        public async Task<ModeloProyectoEtapaAccion> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<ModeloProyectoEtapaAccion> list = _repository.Entities.Where(p => p.Id == id);

            if (include)
            {
                list = list.Include(x => x.AccionOperativa)
                    .Include(x => x.Etapa)
                    .Include(x => x.ModeloProyecto)
                    .Include(g => g.Estado)
                    ;
            }

            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<ModeloProyectoEtapaAccion>> GetListAsync(ModeloProyectoEtapaAccion modelo)
        {
            IQueryable<ModeloProyectoEtapaAccion> list = _repository.Entities;

            if (modelo.IdModeloProyecto != null)
            {
                if (modelo.IdModeloProyecto > 0)
                {
                    list = list.Where(p => p.IdModeloProyecto == modelo.IdModeloProyecto);
                }
            }

            if (modelo.IdEtapa != null)
            {
                if (modelo.IdEtapa > 0)
                {
                    list = list.Where(p => p.IdEtapa == modelo.IdEtapa);
                }
            }


            if (modelo.Include)
            {
                list = list.Include(x => x.AccionOperativa)
                    .Include(x => x.Etapa)
                    .Include(x => x.ModeloProyecto)
                    .Include(e => e.Estado)
                    ;
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(ModeloProyectoEtapaAccion etapaModeloProyecto)
        {
            await _repository.AddAsync(etapaModeloProyecto);
            return etapaModeloProyecto.Id;
        }

        public async Task UpdateAsync(ModeloProyectoEtapaAccion etapaModeloProyecto)
        {
            await _repository.UpdateAsync(etapaModeloProyecto);
        }

        public async Task DeleteAsync(ModeloProyectoEtapaAccion etapaModeloProyecto)
        {
            await _repository.DeleteAsync(etapaModeloProyecto);
        }

        public async Task DeleteModeloProyectoAllAsync(int idmodeloproyecto)
        {

            var deleteOrderDetails = from details in _repository.Entities
                                     where details.IdModeloProyecto == idmodeloproyecto
                                     select details;

            foreach (var detail in deleteOrderDetails)
            {
                await DeleteAsync(detail);
            }

        }

    }
}
