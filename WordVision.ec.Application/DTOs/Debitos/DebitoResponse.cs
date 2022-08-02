using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Debitos
{
    public class DebitoResponse
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string Categoria { get; set; }
        public string Campana { get; set; }
        public string Frecuencia { get; set; }
        public string Identificacion { get; set; }
        public string NombreDonante { get; set; }
        public string BancoTarjeta { get; set; }
        public string CuentaTarjeta { get; set; }
        public decimal Valor { get; set; }

        
        public int TipoId { get; set; }
        public int TipoCuenta { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string RespuestaBanco { get; set; }
        public DateTime? FechaDebito { get; set; }


    }
}
