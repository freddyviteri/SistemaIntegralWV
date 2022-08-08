using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Donacion.Models
{
    public class DonanteViewModelView
    {
        public List<DonanteViewModel> DonanteViewModels { get; set; }
        public SelectList CampanaList { get; set; }
        public SelectList EstadoDonanteList { get; set; }
        public SelectList CiudadList { get; set; }
    }
    public class DonanteViewModel
    {
        public int Vienede { get; set; }
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Conversión")]
        public DateTime? FechaConversion { get; set; }
        [Display(Name = "Evidencia de Conversión")]
        public byte[] EvidenciaConversion { get; set; }
        [Display(Name = "Canal")]
        public int Canal { get; set; }
        public int Responsable { get; set; }
        public int Tipo { get; set; }
        [Display(Name = "Categoría")]
        public int Categoria { get; set; }
        [Display(Name = "Campaña")]
        public int Campana { get; set; }
        [Display(Name = "Estado del Donante")]
        public int EstadoDonante { get; set; }
        [Display(Name = "Primer Nombre")]
        public string Nombre1 { get; set; }
        [Display(Name = "Segundo Nombre")]
        public string Nombre2 { get; set; }
        [Display(Name = "Primer Apellido")]
        public string Apellido1 { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }
        [Display(Name = "Género")]
        public int Genero { get; set; }

        [Display(Name = "Tipo Id.")]
        public int Cedula { get; set; }

        [Display(Name = "Identificación")]
        public string RUC { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        [Display(Name = "Región")]
        public int Region { get; set; }
        public int Provincia { get; set; }

        public int Ciudad { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Area")]
        public string CodigoArea { get; set; }

        [Display(Name = "Teléfono")]
        public string TelefonoConvencional { get; set; }
        [Display(Name = "Celular")]
        public string TelefonoCelular { get; set; }
        public bool WhatsApp { get; set; }
        [EmailAddress]

        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Frecuencia de Donación")]
        public int FrecuenciaDonacion { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$" , ErrorMessage = "Ingrese un valor decimal")]
        public string Cantidad { get; set; }

        //[Display(Name = "Quincena")]
        //public int? Quincena { get; set; }

        [Display(Name = "Fecha de Inicio de Débito")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? MesInicialDebito { get; set; }

        [Display(Name = "Forma de Pago")]
        public int FormaPago { get; set; }
        [Display(Name = "Num. Referencia")]
        public string NumReferencia { get; set; }
        [Display(Name = "Tipo de Cuenta")]
        public int? TipoCuenta { get; set; }
        [Display(Name = "Número de Cuenta")]
        public string NumeroCuenta { get; set; }
        [Display(Name = "Tipo de Tarjetas")]
        public int? TiposTarjetasCredito { get; set; }
        [Display(Name = "Número de Tarjeta")]
        public string NumeroTarjeta { get; set; }

        [Display(Name = "Fecha de Caducidad")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCaducidad { get; set; }

        [Display(Name = "Banco")]
        public int? Banco { get; set; }


        [Display(Name = "Num. Referencia")]
        public string NumReferenciaBp { get; set; }
        public int? TipoCuentaBp { get; set; }
        public string NumeroCuentaBp { get; set; }
        public int? TiposTarjetasCreditoBp { get; set; }
        public string NumeroTarjetaBp { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCaducidadBp { get; set; }

        [Display(Name = "Fecha de Vencimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaVencimiento { get; set; }
        public int? BancoBp { get; set; }
        [Display(Name = "Comentario Actualización")]
        public string ComentarioActualizacion { get; set; }
        [Display(Name = "Comentario Resolución")]
        public string ComentarioResolucion { get; set; }

        public string Hubspot { get; set; }
        public string Formulario { get; set; }

        [Display(Name = "Periodo de Donación ")]
        public int? PeriodoDonacion { get; set; }

        [Display(Name = "Calificación  del Donante")]
        public int? CalificacionDonante { get; set; }
        
        [Display(Name = "Número de Guía")]
        public string NumeroGuia { get; set; }

        [Display(Name = "Fecha de Entrega")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntrega { get; set; }

        [Display(Name = "Estado del Courier")]
        public string EstadoCourier { get; set; }

        [Display(Name = "Motivos de Baja")]
        public string MotivosBaja { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Baja")]
        public DateTime? FechaBaja { get; set; }
        public string Colaborador { get; set; }

       
        public int? EsAdmin { get; set; }
        public SelectList FormaPagoList { get; set; }
        public SelectList CanalList { get; set; }
        public SelectList ResponsableList { get; set; }
        public SelectList TipoList { get; set; }
        public SelectList CategoriaList { get; set; }
        public SelectList CampanaList { get; set; }
        public SelectList EstadoDonanteList { get; set; }
        public SelectList GeneroList { get; set; }
        public SelectList TipoIdList { get; set; }
        public SelectList RegionList { get; set; }
        public SelectList ProvinciaList { get; set; }
        public SelectList CiudadList { get; set; }
        public SelectList FrecuenciaList { get; set; }
        public SelectList TipoCuentaList { get; set; }
        public SelectList TipoTarjetaList { get; set; }
        public SelectList BancoList { get; set; }
        public SelectList CodigoAreaList { get; set; }
        public SelectList PeriodoDonacionList { get; set; }

        public SelectList CalificacionDonanteList { get; set; }
        public SelectList MotivosBajaList { get; set; }

        public SelectList EstadoCourierList { get; set; }

        public int TipoPantalla { get; set; }

        public bool Validacion { get; set; }

        public int CuotaDebe { get; set; }

        //public SelectList QuincenaList { get; set; }
    }

    public class DonanteResponseViewModel
    {
        public string Id { get; set; }
        public string Campana { get; set; }
        public string Donante { get; set; }
        public string Cedula { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public decimal Cantidad { get; set; }
    }
    public class DonanteFiltroViewModel
    {
        
        public int Categoria { get; set; }
        public int Campana { get; set; }
        public string Identificacion { get; set; }
        public int Estado { get; set; }
        public int Ciudad { get; set; }
         public string NombreDonante { get; set; }
        public int TipoPantalla { get; set; }

        public bool Validacion { get; set; }

        public int CuotaDebe { get; set; }
    }


   
}


