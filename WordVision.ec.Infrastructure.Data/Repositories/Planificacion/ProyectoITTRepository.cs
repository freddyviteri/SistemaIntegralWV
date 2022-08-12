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

        public async Task<ProyectoITT> GetByIdAsync(int id, bool include = true)
        {
            IQueryable<ProyectoITT> model = _repository.Entities.Where(p => p.Id == id);

            if (include == true)
            {
                model = model.Include(x => x.FaseProgramaArea)
                    .ThenInclude(x => x.ProyectoTecnico)
                        .ThenInclude(x => x.ProgramaArea)
                .Include(x => x.FaseProgramaArea)
                    .ThenInclude(x => x.ProyectoTecnico)
                        .ThenInclude(x => x.ProgramaTecnico)
                .Include(x => x.FaseProgramaArea)
                    .ThenInclude(x => x.FaseProyecto)
                .Include(x => x.DetalleProyectoITTs)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.Supervisor)

                .Include(x => x.DetalleProyectoITTs)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.Responsable)
                .Include(x => x.DetalleProyectoITTs)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.MarcoLogico)
                            .ThenInclude(x => x.LogFrame)
                //.ThenInclude(x => x.ModeloProyecto)
                .Include(x => x.DetalleProyectoITTs)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.MarcoLogico)
                            .ThenInclude(x => x.LogFrame)
                                .ThenInclude(x => x.TipoActividad)
                .Include(x => x.DetalleProyectoITTs)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.MarcoLogico)
                            .ThenInclude(x => x.LogFrame)
                                .ThenInclude(x => x.SectorProgramatico)
                .Include(x => x.DetalleProyectoITTs)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.MarcoLogico)
                            .ThenInclude(x => x.IndicadorML)
                                .ThenInclude(x => x.Target)
                .Include(x => x.DetalleProyectoITTs)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.MarcoLogico)
                            .ThenInclude(x => x.IndicadorML)
                                .ThenInclude(x => x.TipoMedida)
                .Include(x => x.DetalleProyectoITTs)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.MarcoLogico)
                            .ThenInclude(x => x.IndicadorML)
                                .ThenInclude(x => x.Frecuencia)
                .Include(x => x.DetalleProyectoITTs)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.MarcoLogico)
                            .ThenInclude(x => x.IndicadorML)
                                .ThenInclude(x => x.ActorParticipante)
                .Include(x => x.DetalleProyectoITTGouls)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.MarcoLogico)
                            .ThenInclude(x => x.LogFrame)
                .Include(x => x.DetalleProyectoITTGouls)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.Supervisor)
                .Include(x => x.DetalleProyectoITTGouls)
                    .ThenInclude(x => x.MarcoLogicoAsignado)
                        .ThenInclude(x => x.Responsable);
            }

            var modelo = await model.FirstOrDefaultAsync();
            return modelo;
        }

        public async Task<List<ProyectoITT>> GetListAsync(ProyectoITT entity)
        {
            IQueryable<ProyectoITT> list = _repository.Entities;

            if (entity.Include)
            {
                list = list.Include(p => p.FaseProgramaArea)
                    .ThenInclude(pt => pt.ProyectoTecnico).ThenInclude(x => x.ProgramaArea)
                    .Include(x => x.DetalleProyectoITTs)
                    .Include(x => x.DetalleProyectoITTGouls);

                if (entity.FaseProgramaArea != null)
                {
                    if (entity.FaseProgramaArea.IdProyectoTecnico > 0)
                    {
                        list = list.Where(x => x.FaseProgramaArea.IdProyectoTecnico == entity.FaseProgramaArea.IdProyectoTecnico);
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
