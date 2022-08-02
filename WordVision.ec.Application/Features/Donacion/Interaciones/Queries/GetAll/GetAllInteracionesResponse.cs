using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAll
{
    public class GetAllInteracionesResponse
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


        public int MotivoBajaCartera { get; set; }
        public string DescMotivoBajaCartera { get; set; }

        public DateTime? FechaBajaCartera { get; set; }



    }
}
