using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class Catalogo
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        public int Estado { get; set; }

        public string IdRol { get; set; }

        [ForeignKey("IdCatalogo")]
        public ICollection<DetalleCatalogo> DetalleCatalogos { get; set; }
    }

    public class DetalleCatalogo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdCatalogo { get; set; }

        [Required]
        public string Secuencia { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        public int Estado { get; set; }

        public Catalogo Catalogos { get; set; }
    }
}
