﻿using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Identity.Models
{
    public class UsuarioViewModel
    {
        public int OID { get; set; }
        public string DisplayName { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }
        public string Company { get; set; }
        public string PhysicalDeliveryOfficeName { get; set; }
        public string Department { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Usuario obligatorio")]
        public string UserNameRegular { get; set; }
        public string Cedula { get; set; }

        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }

        public string UrlRetorno { get; set; }
        public IList<AuthenticationScheme> LoginExterno { get; set; }
    }
}
