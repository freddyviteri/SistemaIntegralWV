using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Debitos
{
    public class DebitosInteracionResponse
    {
        public int Id { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }

        public decimal? Cantidad { get; set; }

        public string RespuestaBanco { get; set; }

        public int EstadoDebito { get; set; }
    }
}
