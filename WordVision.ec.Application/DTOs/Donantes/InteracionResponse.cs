using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Donantes
{
    public class InteracionResponse
    {
        public int Gestion { get; set; }

        public string DescGestion { get; set; }

        public int Tipo { get; set; }


        public string DescTipo { get; set; }

        public string Observacion { get; set; }

        public int IdDonante { get; set; }

        public int EstadoKitCourier { get; set; }
        public string DescEstadoKitCourier { get; set; }

        public DateTime? FechaEntregaKit { get; set; }

        public string NumeroGuiaKit { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }


        public int Anio { get; set; }
        public int Mes { get; set; }

        public decimal? Cantidad { get; set; }

        public string RespuestaBanco { get; set; }
    }
}
