using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Debitos
{
    public class ReporteDonantesResponse
    {
        public int Id { get; set; }
        public DateTime FechaCaptacion { get; set; }
        public string Canal { get; set; }
        public string Campana { get; set; }
        public string Frecuencia { get; set; }
        public string Genero { get; set; }
        public string Provincia { get; set; }
        public string NombreDonante { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Identificacion { get; set; }
        public string FormaPago { get; set; }
        public string EntidadBancaria { get; set; }
        public string TipoCuenta { get; set; }
        public string Cuenta { get; set; }
        public decimal Valor { get; set; }
       
        public string Mes { get; set; }
        public string Anio { get; set; }
        public int CodigoSCI { get; set; }

        public string Categoria { get; set; }
        public string TipoDonante { get; set; }
        public string EstadoDebito { get; set; }
        public DateTime? FechaDebito { get; set; }
        public string Estado { get; set; }


    }
}
