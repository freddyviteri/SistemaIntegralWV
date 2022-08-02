using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Donacion;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Infrastructure.Data.Contexts;

namespace WordVision.ec.Infrastructure.Data.Repositories.Donacion
{
    public class DebitoRepository : IDebitoRepository
    {
        private readonly RegistroDbContext _db;
        private readonly IRepositoryAsync<Debito> _repository;
        private readonly IRepositoryAsync<Donante> _repositoryDonante;
        private readonly IRepositoryAsync<DetalleCatalogo> _repositoryDetalleCatalogo;
        public DebitoRepository( RegistroDbContext db,IRepositoryAsync<Debito> repository, IRepositoryAsync<Donante> repositoryDonante, IRepositoryAsync<DetalleCatalogo> repositoryDetalleCatalogo)
        {
            _repository = repository;
            _repositoryDonante = repositoryDonante;
            _repositoryDetalleCatalogo = repositoryDetalleCatalogo;
            _db = db;
        }
        public IQueryable<Debito> debitos => _repository.Entities;

        public async Task<int> GetByArchivoGeneradoAsync(int formaPago, int bancoTarjeta, int anio, int mes)
        {
            switch (formaPago)
            {
                case 1:
                    break;
                case 2:
                    if (bancoTarjeta == 1)
                    {
                        return await _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == 10 && d.Anio == anio && d.Mes == mes).CountAsync();

                    }
                    else
                    {
                        return await _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco !=10 && d.Anio == anio && d.Mes == mes).CountAsync();
                    }
                    break;

                case 3:
                    break;
                case 4:
                    return await _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco ==bancoTarjeta && d.Anio == anio && d.Mes == mes).CountAsync();
                    break;

            }
            return 0;
        }

        public async Task<Debito> GetByContrapartidaAsync(int formaPago, int bancoTarjeta, int anio, int mes, string contrapartida)
        {
            return await _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == bancoTarjeta && d.Anio == anio && d.Mes == mes && d.Contrapartida == contrapartida && d.Estado ==1 ).FirstOrDefaultAsync();
        }

        public async Task<int> GetByExisteCargaRespuestaAsync(int formaPago, int bancoTarjeta, int anio, int mes)
        {
            switch (formaPago)
            {
                case 1:
                    break;
                case 2:
                    if (bancoTarjeta == 1)
                    {
                        return await _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == 10 && d.Anio == anio && d.Mes == mes && d.CodigoRespuesta != null ).CountAsync();

                    }
                    else
                    {
                        return await _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco != 10 && d.Anio == anio && d.Mes == mes && d.CodigoRespuesta != null).CountAsync();
                    }
                    break;

                case 3:
                    break;
                case 4:
                    return await _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == bancoTarjeta && d.Anio == anio && d.Mes == mes && d.CodigoRespuesta != null).CountAsync();
                    break;

            }
            return 0;
        }

        public async Task<Debito> GetByIdAsync(int idDebito)
        {
            return await _repository.Entities.Where(d => d.Id == idDebito).FirstOrDefaultAsync();
        }

        public async Task<int> GetByPersonaAsync(int formaPago, int bancoTarjeta, int anio, int mes, string contrapartida)
        {
            return await _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == bancoTarjeta && d.Anio == anio && d.Mes == mes && d.Contrapartida == contrapartida).CountAsync();
        }

        public async Task<List<Debito>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<DebitoResponse>> GetListDebitosSeleccionarAsync(int formaPago, int bancoTarjeta, int anio, int mes)
        {
           
            _db.Database.SetCommandTimeout(TimeSpan.FromMinutes(20));
            var fecha = new DateTime(anio, mes, 1);
            switch (formaPago)
            {
                case 1:
                    break;
                case 2:
                    if (bancoTarjeta == 1)
                    {
                        
                        var resultado1 = _repositoryDonante.Entities.Where(c => c.FormaPago == formaPago && c.Banco == 10 && fecha>= c.MesInicialDebito && c.EstadoDonante == 1)
                                     .Select(a => new DebitoResponse
                                     {
                                         Estado = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 64 && c.Secuencia == _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == 10 && d.Anio == anio && d.Mes == mes && d.IdDonante == a.Id).FirstOrDefault().Estado.ToString()).FirstOrDefault().Nombre,
                                         Tipo = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 24 && c.Secuencia == a.Tipo.ToString()).FirstOrDefault().Nombre,
                                         Categoria = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 25 && c.Secuencia == a.Categoria.ToString()).FirstOrDefault().Nombre,
                                         Campana = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 26 && c.Secuencia == a.Campana.ToString()).FirstOrDefault().Nombre,
                                         Frecuencia = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 34 && c.Secuencia == a.FrecuenciaDonacion.ToString()).FirstOrDefault().Nombre,
                                         Identificacion = a.RUC,
                                         NombreDonante = a.Apellido1 + " " + a.Apellido2 + " " + a.Nombre1 + " " + a.Nombre2,
                                         BancoTarjeta = a.Banco.ToString(),
                                         CuentaTarjeta = a.NumeroCuenta,
                                         Valor = a.Cantidad,
                                         TipoId = a.Cedula,
                                         TipoCuenta = (int)a.TipoCuenta,
                                         Id = a.Id,
                                         RespuestaBanco = _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == 10 && d.Anio == anio && d.Mes == mes && d.IdDonante == a.Id).FirstOrDefault().CodigoRespuesta,
                                         FechaDebito = _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == 10 && d.Anio == anio && d.Mes == mes && d.IdDonante == a.Id).FirstOrDefault().FechaDebito


                                     }
                                     ).ToListAsync();

                        return await resultado1;
                    }
                    else
                    {
                        var resultado2 = _repositoryDonante.Entities.Where(c => c.FormaPago == formaPago && c.Banco != 10 && fecha >= c.MesInicialDebito)
                     .Select(a => new DebitoResponse
                     {
                         Estado = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 64 && c.Secuencia == _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco != 10 && d.Anio == anio && d.Mes == mes && d.IdDonante == a.Id).FirstOrDefault().Estado.ToString()).FirstOrDefault().Nombre,
                         Tipo = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 24 && c.Secuencia == a.Tipo.ToString()).FirstOrDefault().Nombre,
                         Categoria = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 25 && c.Secuencia == a.Categoria.ToString()).FirstOrDefault().Nombre,
                         Campana = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 26 && c.Secuencia == a.Campana.ToString()).FirstOrDefault().Nombre,
                         Frecuencia = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 34 && c.Secuencia == a.FrecuenciaDonacion.ToString()).FirstOrDefault().Nombre,
                         Identificacion = a.RUC,
                         NombreDonante = a.Apellido1 + " " + a.Apellido2 + " " + a.Nombre1 + " " + a.Nombre2,
                         BancoTarjeta = a.Banco.ToString(),
                         CuentaTarjeta = a.NumeroCuenta,
                         Valor = a.Cantidad,
                         TipoId = a.Cedula,
                         TipoCuenta = (int)a.TipoCuenta,
                         Id = a.Id,
                         RespuestaBanco = _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco != 10 && d.Anio == anio && d.Mes == mes && d.IdDonante == a.Id).FirstOrDefault().CodigoRespuesta,
                         FechaDebito = _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco != 10 && d.Anio == anio && d.Mes == mes && d.IdDonante == a.Id).FirstOrDefault().FechaDebito



                     }
                     ).ToListAsync();
                        return await resultado2;

                    }
                    break;

                case 3:
                    break;
                case 4:
                    var resultado = _repositoryDonante.Entities.Where(c => c.FormaPago == formaPago && c.TiposTarjetasCredito == bancoTarjeta)
                                    .Select(a => new DebitoResponse
                                    {
                                        Estado = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 64 && c.Secuencia == _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == bancoTarjeta && d.Anio == anio && d.Mes == mes && d.IdDonante == a.Id).FirstOrDefault().Estado.ToString()).FirstOrDefault().Nombre,
                                        Tipo = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 24 && c.Secuencia == a.Tipo.ToString()).FirstOrDefault().Nombre,
                                        Categoria = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 25 && c.Secuencia == a.Categoria.ToString()).FirstOrDefault().Nombre,
                                        Campana = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 26 && c.Secuencia == a.Campana.ToString()).FirstOrDefault().Nombre,
                                        Frecuencia = _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 34 && c.Secuencia == a.FrecuenciaDonacion.ToString()).FirstOrDefault().Nombre,
                                        Identificacion = a.RUC,
                                        NombreDonante = a.Apellido1 + " " + a.Apellido2 + " " + a.Nombre1 + " " + a.Nombre2,
                                        BancoTarjeta = a.TiposTarjetasCredito.ToString(),
                                        CuentaTarjeta = a.NumeroTarjeta,
                                        Valor = a.Cantidad,
                                        TipoId = a.Cedula,
                                        TipoCuenta = 0,
                                        FechaCaducidad = a.FechaCaducidad.Value,
                                        Id = a.Id,
                                        RespuestaBanco = _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == bancoTarjeta && d.Anio == anio && d.Mes == mes && d.IdDonante == a.Id).FirstOrDefault().CodigoRespuesta,
                                        FechaDebito = _repository.Entities.Where(d => d.FormaPago == formaPago && d.CodigoBanco == bancoTarjeta && d.Anio == anio && d.Mes == mes && d.IdDonante == a.Id).FirstOrDefault().FechaDebito


                                    }
                                    ).ToListAsync();

                    return await resultado;
                    break;
            }

            return null;

        }

        public async Task<int> InsertAsync(Debito debito)
        {
            await _repository.AddAsync(debito);
            return debito.Id;
        }

        public async Task UpdateAsync(Debito debito)
        {
            await _repository.UpdateAsync(debito);
        }

        public async Task UpdateEstadoAsync(int idDonante, int estadoDebito)
        {
            Debito entidad = await _repository.Entities.Where(x => x.IdDonante == idDonante).FirstOrDefaultAsync();
            if (entidad == null) return;

            entidad.Estado = estadoDebito;

            await _repository.UpdateAsync(entidad);
        }
    }
}
