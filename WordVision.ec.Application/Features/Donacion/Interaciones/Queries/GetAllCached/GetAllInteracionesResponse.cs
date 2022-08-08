using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAllCached
{
    public class GetAllInteracionesResponse
    {
        public int Gestion { get; set; }

        public int Tipo { get; set; }

        public string Observacion { get; set; }

        public string EstadoKitCourier { get; set; }

        public DateTime? FechaEntregaKit { get; set; }

        public string NumeroGuiaKit { get; set; }

        public int IdDonante { get; set; }
    }
}
