﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class Colaborador : AuditableEntity
    {
        [StringLength(500)]
        [Required]
        public string Apellidos { get; set; }

        [StringLength(500)]
        public string ApellidoMaterno { get; set; }

        [StringLength(150)]
        [Required]
        public string PrimerNombre { get; set; }

        [StringLength(150)]
        public string SegundoNombre { get; set; }

        [StringLength(25)]
        [Required]
        public string Identificacion { get; set; }

        [StringLength(150)]
        [Required]
        public string Email { get; set; }

        public int? Cargo { get; set; }


        public int? Area { get; set; }


        public int? LugarTrabajo { get; set; }

        [StringLength(100)]
        public string Alias { get; set; }
        public int Estado { get; set; }

        [ForeignKey("IdColaborador")]
        public ICollection<Respuesta> Respuestas { get; set; }

        [ForeignKey("IdColaborador")]
        public ICollection<Firma> Firmas { get; set; }

        [ForeignKey("IdColaborador")]
        public virtual ICollection<Formulario> Formularios { get; set; }
        [ForeignKey("IdColaborador")]
        public virtual ICollection<Solicitud> Solicitudes { get; set; }
        public int IdEstructura { get; set; }
        public Estructura Estructuras { get; set; }

    }
}
