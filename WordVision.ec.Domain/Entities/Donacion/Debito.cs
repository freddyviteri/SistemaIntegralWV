using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Donacion
{
    public class Debito : AuditableEntity
    {
        [Required]
        public int CodigoBanco { get; set; }

        [Required]
        public int Anio { get; set; }

        [Required]
        public int Mes { get; set; }

        public int? Quincena { get; set; }

        [Required]
        public int Intento { get; set; }

        [Required]
        public decimal? Valor { get; set; }
        public string CodigoRespuesta { get; set; }
        public int Estado { get; set; }

        public int IdDonante { get; set; }
        [Required]
        public int FormaPago { get; set; }
        [Required]
        [StringLength(50)]
        public string Contrapartida { get; set; }
        public DateTime? FechaDebito { get; set; }
        public Donante Donantes { get; set; }

    }
}
