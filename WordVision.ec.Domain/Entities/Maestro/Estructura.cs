﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class Estructura : AuditableEntity
    {
        [Required]
        public string Designacion { get; set; }
        public int ReportaID { get; set; }

        [Required]
        public int Estado { get; set; }

        public int IdEmpresa { get; set; }
        public int Nivel { get; set; }
        public Empresa Empresas { get; set; }

        [ForeignKey("IdEstructura")]
        public virtual ICollection<Colaborador> Colaboradores { get; set; }

    }
}
