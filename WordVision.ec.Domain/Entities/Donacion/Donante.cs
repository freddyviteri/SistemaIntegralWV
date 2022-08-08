using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Donacion
{
    public class Donante : AuditableEntity
    {
        public DateTime? FechaConversion { get; set; }
        public byte[] EvidenciaConversion { get; set; }
        public int Canal { get; set; }
        public int Responsable { get; set; }
        public int Tipo { get; set; }
        public int Categoria { get; set; }
        public int Campana { get; set; }
        public int EstadoDonante { get; set; }

        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Genero { get; set; }
        public int Cedula { get; set; }
        public string RUC { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int Region { get; set; }
        public int Provincia { get; set; }

        public int Ciudad { get; set; }
        public string Direccion { get; set; }
        public string CodigoArea { get; set; }
        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }
        public bool WhatsApp { get; set; }
        public string Email { get; set; }
        public int FrecuenciaDonacion { get; set; }
        public decimal Cantidad { get; set; }
        //public int? Quincena { get; set; }
        public DateTime? MesInicialDebito { get; set; }

        public int FormaPago { get; set; }
        public string NumReferencia { get; set; }
        public int? TipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public int? TiposTarjetasCredito { get; set; }
        public string NumeroTarjeta { get; set; }

        public DateTime? FechaCaducidad { get; set; }
        public int? Banco { get; set; }


        public string NumReferenciaBp { get; set; }
        public int? TipoCuentaBp { get; set; }
        public string NumeroCuentaBp { get; set; }
        public int? TiposTarjetasCreditoBp { get; set; }
        public string NumeroTarjetaBp { get; set; }
        public DateTime? FechaCaducidadBp { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? BancoBp { get; set; }

        public string ComentarioActualizacion { get; set; }
        public string ComentarioResolucion { get; set; }
        
        [StringLength(50)]
        public string Hubspot { get; set; }

        [StringLength(50)]
        public string Formulario { get; set; }

        public int? PeriodoDonacion { get; set; }

        public int? CalificacionDonante { get; set; }

        [StringLength(50)]
        public string NumeroGuia { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public int? EstadoCourier { get; set; }

        public string MotivosBaja { get; set; } // agregar

        public DateTime? FechaBaja { get; set; } // agregar campo 


        [ForeignKey("IdDonante")]
        public ICollection<Debito> Debitos { get; set; }

        [ForeignKey("IdDonante")]
        public ICollection<ProductoDonante> ProductoDonantes { get; set; }

        [ForeignKey("IdDonante")]
        public ICollection<Interacion> Interaciones { get; set; }
    }
}
