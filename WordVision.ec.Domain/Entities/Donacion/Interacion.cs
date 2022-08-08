using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Donacion
{
    public class Interacion : AuditableEntity
    {

        public int Gestion  { get; set; }

        public int Tipo { get; set; }

        public string Observacion { get; set; }

        public int IdDonante { get; set; }

        public int EstadoKitCourier { get; set; }

        public DateTime? FechaEntregaKit { get; set; }

        [StringLength(50)]
        public string NumeroGuiaKit { get; set; }

         public int MotivoBajaCartera { get; set; } 

        public DateTime? FechaBajaCartera { get; set; }

        public Donante Donantes { get; set; }
    }
}
