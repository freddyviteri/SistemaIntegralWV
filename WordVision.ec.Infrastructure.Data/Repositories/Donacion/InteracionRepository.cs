using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.DTOs.Donantes;
using WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAll;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Donacion;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Infrastructure.Data.Contexts;

namespace WordVision.ec.Infrastructure.Data.Repositories.Donacion
{
    public class InteracionRepository : IInteracionRepository
    {
        private readonly RegistroDbContext _db;
        private readonly IRepositoryAsync<Interacion> _repository;
        private readonly IRepositoryAsync<DetalleCatalogo> _repositoryDetalle;
        private readonly IRepositoryAsync<Debito> _repositoryDebito;


        public InteracionRepository(RegistroDbContext db, IRepositoryAsync<Interacion> repository, IRepositoryAsync<DetalleCatalogo> repositoryDetalle, IRepositoryAsync<Debito> repositoryDebito)
        {
            _repository = repository;
            _db = db;
            _repositoryDetalle = repositoryDetalle;
            _repositoryDebito = repositoryDebito;
        }

        public IQueryable<Interacion> interaciones => _repository.Entities;

        public async Task<List<DebitosInteracionResponse>> GetDebitoXDonanteAsync(int idDonante)
        {
            var resultado1 = _repositoryDebito.Entities.Where(x => x.IdDonante == idDonante && x.CodigoRespuesta != "PROCESO OK" && x.Estado < 3)
                         .Select(a => new DebitosInteracionResponse
                         {
                             Id = a.Id,
                             Anio = a.Anio,
                             Mes = a.Mes,
                             Cantidad = a.Valor,
                             RespuestaBanco = a.CodigoRespuesta,
                             EstadoDebito = a.Estado,
                         }
                         ).ToListAsync();

            return await resultado1;

        }

        public async Task<List<GetAllInteracionesResponse>> GetInteracionXDonanteAsync(int idDonante, int tipo)
        {
           
            var resultado1 = _repository.Entities.Where(x => x.IdDonante == idDonante && x.Tipo == tipo) 
                              .Select(a => new GetAllInteracionesResponse
                              {
                                  IdDonante = a.Id,
                                  DescGestion = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 70 && c.Secuencia == a.Gestion.ToString()).FirstOrDefault().Nombre,
                                  DescTipo = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 68 && c.Secuencia == a.Tipo.ToString()).FirstOrDefault().Nombre,
                                  Observacion = a.Observacion,
                                  DescEstadoKitCourier = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 72 && c.Secuencia == a.EstadoKitCourier.ToString()).FirstOrDefault().Nombre,
                                  FechaEntregaKit = a.FechaEntregaKit,
                                  NumeroGuiaKit = a.NumeroGuiaKit,
                                  Gestion = a.Gestion,
                                  Tipo = a.Tipo,
                                  EstadoKitCourier = a.EstadoKitCourier,
                                  CreatedBy = a.CreatedBy,
                                  CreatedOn = a.CreatedOn,
                                  DescMotivoBajaCartera = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 71 && c.Secuencia == a.MotivoBajaCartera.ToString()).FirstOrDefault().Nombre,
                                  MotivoBajaCartera = a.MotivoBajaCartera,
                                  FechaBajaCartera = a.FechaBajaCartera,
                                  
                              }
                              ).ToListAsync();
            return await resultado1;




        }




        //public async Task<List<Interacion>> GetInteracionXDonanteAsync(int idDonante, int tipo)
        //{
        //    return await _repository.Entities.Where(x => x.IdDonante == idDonante && x.Tipo == tipo).ToListAsync();

        //}

        public async Task<int> InsertAsync(Interacion interacion)
        {
            string numguia = _repository.Entities.Where(x => x.IdDonante == interacion.IdDonante && x.Tipo == interacion.Tipo && x.NumeroGuiaKit != null)?.FirstOrDefault()?.NumeroGuiaKit;
            if (numguia != null)
                interacion.NumeroGuiaKit = numguia;

            await _repository.AddAsync(interacion);
            return interacion.Id;
        }

        public async Task<int> InteracionXDonanteAsync(int idDonante, int tipo, int gestion)
        {
            return await _repository.Entities.Where(d => d.IdDonante == idDonante && d.Tipo == tipo && d.Gestion == gestion).CountAsync();
        }
    }
}
