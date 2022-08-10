using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Donacion.Donantes.Commands.Create;
using WordVision.ec.Application.Features.Donacion.Donantes.Commands.Update;
using WordVision.ec.Application.Features.Donacion.Donantes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Donacion.Donantes.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Donacion.Models;
using WordVision.ec.Application.Features.Maestro.DivisionPolitica.Queries.GetById;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetById;

namespace WordVision.ec.Web.Areas.Donacion.Controllers
{
    [Area("Donacion")]
    [Authorize]//Sirve para dar permiso cuando esta logeado
    public class DonanteController : BaseController<DonanteController>
    {
        // ejecuta una accion
        public async Task<IActionResult> Index(int tipoPantalla=0)
        {
            var entidadViewModel = new DonanteViewModel();
            var responseCola = await _mediator.Send(new GetColaboradorByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
            if (responseCola.Succeeded)
            {
                entidadViewModel.Colaborador = responseCola.Data.Apellidos + " " + responseCola.Data.ApellidoMaterno + " " + responseCola.Data.PrimerNombre + " " + responseCola.Data.SegundoNombre;
                entidadViewModel.Colaborador = entidadViewModel.Colaborador + "-" + responseCola.Data.Estructuras?.Designacion;
            }

            var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 27, Ninguno = true });
            var estadoDonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            entidadViewModel.EstadoDonanteList = estadoDonante;

            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 25, Ninguno = true });
            var categoria = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            entidadViewModel.CategoriaList = categoria;

            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 31, Ninguno = true });
            var region = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            entidadViewModel.RegionList = region;

            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 26, Ninguno = true });
            var campana = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            entidadViewModel.CampanaList = campana;
            entidadViewModel.TipoPantalla = tipoPantalla;

            return View(entidadViewModel);// dirije a la carpeta Views
        }

        public async Task<IActionResult> LoadAll([FromBody]  DonanteFiltroViewModel filtro)
        {
            if (filtro == null)
            
                return Json(new { data = new List<DonanteResponseViewModel>() });

            if (filtro.TipoPantalla==3 && filtro.CuotaDebe==0)
                return Json(new { data = new List<DonanteResponseViewModel>() });

            var response = await _mediator.Send(new GetAllDonantesQuery() { EstadoDonante = filtro.Estado , Categoria = filtro.Categoria, Campana = filtro.Campana , Ciudad = filtro.Ciudad, Identificacion = filtro.Identificacion , NombresDonante=filtro.NombreDonante, TipoPantalla=filtro.TipoPantalla , Validacion =filtro.Validacion , CuotaDebe=filtro.CuotaDebe} );
            if (response.Succeeded)
            {
                //DonanteViewModelView entidad = new DonanteViewModelView();

                var viewModel = _mapper.Map<List<DonanteResponseViewModel>>(response.Data);
                //entidad.DonanteViewModels = viewModel;
                //var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 26, Ninguno = true });
                //var campana = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                //entidad.CampanaList = campana;
                //catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 27, Ninguno = true });
                //var estadoDonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                //entidad.EstadoDonanteList = estadoDonante;
                //catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
                //var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                //entidad.CiudadList = ciudad;
                // return PartialView("_ViewAll", viewModel);
                return Json(new { data = viewModel });
            }

             return Json(new { data = new List<DonanteResponseViewModel>() }); ;

        }
       
        public async Task<IActionResult> OnGetCreate(int id = 0, int vienede= 0)
        {

            try
            {
                var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 21, Ninguno = true });
                var formaPago = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 22, Ninguno = true });
                var canal = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 23, Ninguno = true });
                var responsable = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 24, Ninguno = true });
                var tipo = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 25, Ninguno = true });
                var categoria = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 26, Ninguno = true });
                var campana = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 27, Ninguno = true });
                var estadoDonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 28, Ninguno = true });
                var genero = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 30, Ninguno = true });
                var tipoId = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 31, Ninguno = true });
                var region = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                //catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 32, Ninguno = true });
                //var provincia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                //catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
                //var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 34, Ninguno = true });
                var frecuencia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 35, Ninguno = true });
                var tipoCuenta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 36, Ninguno = true });
                var tipoTarjeta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 37, Ninguno = true });
                var banco = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 65, Ninguno = true });
                var periodoDonacion = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 66, Ninguno = true });
                var calificaciondonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 71, Ninguno = true });
                var motivobaja = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 72, Ninguno = true });
                var estadocourier = new SelectList(catalogo.Data, "Secuencia", "Nombre");

                //catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 60, Ninguno = true });
                //var quincena = new SelectList(catalogo.Data, "Secuencia", "Nombre");



                if (id == 0)
                {
                    List<SelectListItem> items = new List<SelectListItem>();
                    var entidadViewModel = new DonanteViewModel();
                    entidadViewModel.FormaPagoList = formaPago;
                    entidadViewModel.CanalList = canal;
                    entidadViewModel.ResponsableList = responsable;
                    entidadViewModel.TipoList = tipo;
                    entidadViewModel.CategoriaList = categoria;
                    entidadViewModel.CampanaList = campana;
                    entidadViewModel.EstadoDonanteList = estadoDonante;
                    entidadViewModel.GeneroList = genero;
                    entidadViewModel.TipoIdList = tipoId;
                    entidadViewModel.RegionList = region;
                    entidadViewModel.ProvinciaList = new SelectList(items, "Value", "Text");
                    entidadViewModel.CiudadList = new SelectList(items, "Value", "Text");
                    entidadViewModel.FrecuenciaList = frecuencia;
                    entidadViewModel.TipoCuentaList = tipoCuenta;
                    entidadViewModel.TipoTarjetaList = tipoTarjeta;
                    entidadViewModel.BancoList = banco;
                    //entidadViewModel.QuincenaList = quincena;
                    entidadViewModel.FechaConversion = DateTime.Now;
                    entidadViewModel.Edad = 0; 
                    entidadViewModel.CalificacionDonanteList = calificaciondonante;
                    entidadViewModel.PeriodoDonacionList = periodoDonacion;
                    entidadViewModel.Vienede = vienede;
                    entidadViewModel.FechaNacimiento = DateTime.Now;
                    entidadViewModel.MotivosBajaList = motivobaja;
                    entidadViewModel.EstadoCourierList = estadocourier;
                    return PartialView("_CreateOrEdit", entidadViewModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("OnGetCreateOrEdit", ex);
                _notify.Error("Error al crear el Donante");
            }
        
            return null;

        }

        public async Task<IActionResult> IngresarDonante(int vienede = 0)
        {

            var entidadViewModel = new DonanteViewModel();
            entidadViewModel.Vienede = vienede;
            var responseCola = await _mediator.Send(new GetColaboradorByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
            if (responseCola.Succeeded)
            {
                entidadViewModel.Colaborador = responseCola.Data.Apellidos + " " + responseCola.Data.ApellidoMaterno + " " + responseCola.Data.PrimerNombre + " " + responseCola.Data.SegundoNombre;
                entidadViewModel.Colaborador = entidadViewModel.Colaborador + "-" + responseCola.Data.Estructuras?.Designacion;
            }
            return View("_IngresoDonantes", entidadViewModel);

        }
        


        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0,int tipoPantalla=0)
        {
            try
            {
                var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 21, Ninguno = true });
                var formaPago = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 22, Ninguno = true });
                var canal = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 23, Ninguno = true });
                var responsable = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 24, Ninguno = true });
                var tipo = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 25, Ninguno = true });
                var categoria = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 26, Ninguno = true });
                var campana = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 27, Ninguno = true });
                var estadoDonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 28, Ninguno = true });
                var genero = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 30, Ninguno = true });
                var tipoId = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 31, Ninguno = true });
                var region = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                //catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 32, Ninguno = true });
                //var provincia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                //catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
                //var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 34, Ninguno = true });
                var frecuencia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 35, Ninguno = true });
                var tipoCuenta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 36, Ninguno = true });
                var tipoTarjeta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 37, Ninguno = true });
                var banco = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 65, Ninguno = true });
                var periodoDonacion = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 66, Ninguno = true });
                var calificaciondonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 71, Ninguno = true });
                var motivobaja = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 72, Ninguno = true });
                var estadocourier = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                //catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 60, Ninguno = true });
                //var quincena = new SelectList(catalogo.Data, "Secuencia", "Nombre");



                if (id == 0)
                {
                    var entidadViewModel = new DonanteViewModel();
                    entidadViewModel.FormaPagoList = formaPago;
                    entidadViewModel.CanalList = canal;
                    entidadViewModel.ResponsableList = responsable;
                    entidadViewModel.TipoList = tipo;
                    entidadViewModel.CategoriaList = categoria;
                    entidadViewModel.CampanaList = campana;
                    entidadViewModel.EstadoDonanteList = estadoDonante;
                    entidadViewModel.GeneroList = genero;
                    entidadViewModel.TipoIdList = tipoId;
                    entidadViewModel.RegionList = region;
                    //entidadViewModel.ProvinciaList = provincia;
                    //entidadViewModel.CiudadList = ciudad;
                    entidadViewModel.FrecuenciaList = frecuencia;
                    entidadViewModel.TipoCuentaList = tipoCuenta;
                    entidadViewModel.TipoTarjetaList = tipoTarjeta;
                    entidadViewModel.BancoList = banco;
                    //entidadViewModel.QuincenaList = quincena;
                    entidadViewModel.FechaConversion = DateTime.Now;
                    //entidadViewModel.FechaNacimiento = DateTime.Now;
                    entidadViewModel.CalificacionDonanteList = calificaciondonante;
                    entidadViewModel.PeriodoDonacionList = periodoDonacion;
                    entidadViewModel.MotivosBajaList = motivobaja;
                    entidadViewModel.EstadoCourierList = estadocourier;
                    entidadViewModel.TipoPantalla = tipoPantalla;

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetDonantesByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        var entidadViewModel = _mapper.Map<DonanteViewModel>(response.Data);
                        var entidadModel = await _mediator.Send(new GetProvinciaByIdRegionQuery() { IdRegion = entidadViewModel.Region });
                        var lista = _mapper.Map<List<ProvinciaViewModel>>(entidadModel.Data);

                        entidadViewModel.ProvinciaList = new SelectList(lista, "Id", "Nombre");
                        var entidadModelC = await _mediator.Send(new GetCiudadByIdProvinciaQuery() { IdProvincia = entidadViewModel.Provincia});
                        var listaC = _mapper.Map<List<CiudadViewModel>>(entidadModelC.Data);
                        entidadViewModel.CiudadList = new SelectList(listaC, "Id", "Nombre");


                        entidadViewModel.FormaPagoList = formaPago;
                        entidadViewModel.CanalList = canal;
                        entidadViewModel.ResponsableList = responsable;
                        entidadViewModel.TipoList = tipo;
                        entidadViewModel.CategoriaList = categoria;
                        entidadViewModel.CampanaList = campana;
                        entidadViewModel.EstadoDonanteList = estadoDonante;
                        entidadViewModel.GeneroList = genero;
                        entidadViewModel.TipoIdList = tipoId;
                        entidadViewModel.RegionList = region;
                        
                        entidadViewModel.FrecuenciaList = frecuencia;
                        entidadViewModel.TipoCuentaList = tipoCuenta;
                        entidadViewModel.TipoTarjetaList = tipoTarjeta;
                        entidadViewModel.BancoList = banco;
                        entidadViewModel.FechaConversion = DateTime.Now;
                        //entidadViewModel.FechaNacimiento = DateTime.Now;
                        entidadViewModel.CalificacionDonanteList = calificaciondonante;
                        entidadViewModel.PeriodoDonacionList = periodoDonacion;
                        entidadViewModel.MotivosBajaList = motivobaja;
                        entidadViewModel.EstadoCourierList = estadocourier;
                        entidadViewModel.TipoPantalla = tipoPantalla;
                        //entidadViewModel.QuincenaList = quincena;

                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("OnGetCreateOrEdit", ex);
                _notify.Error("Error al insertar el Donante");
            }
            return null;

        }


        [HttpPost]
        public async Task<IActionResult> OnPostCreateOrEdit(int? id, DonanteViewModel entidad, int vienede, int estadoDonante, int categoria)
        {
            try
            {
                if (entidad.EsAdmin != null)
                {
                    var updateEntidadCommand = _mapper.Map<UpdateDonanteCommand>(entidad);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Donante con ID {result.Data} Actualizado.");
                }

               

                if (ModelState.IsValid)
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        IFormFile file = Request.Form.Files.FirstOrDefault();
                        var image = file.OpenReadStream();
                        MemoryStream ms = new MemoryStream();
                        image.CopyTo(ms);
                        entidad.EvidenciaConversion = ms.ToArray();
                    }

                    if (id == 0)
                    {
                        
                        var createEntidadCommand = _mapper.Map<CreateDonanteCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Donante con ID {result.Data} Creado.");

                            await EnviarMail(result.Data, 1);
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateDonanteCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Donante con ID {result.Data} Actualizado.");
                        //if (entidad.ComentarioActualizacion  != null && entidad.ComentarioResolucion != null)
                        //{
                        //    if (entidad.ComentarioActualizacion != null && entidad.ComentarioResolucion == null)
                                await EnviarMail(result.Data,3);
                        //    else if (entidad.ComentarioResolucion.Length != 0)
                        //        await EnviarMail(result.Data, 3);
                        //}
                           
                    }
                    if (vienede == 0 )
                    {
                        var response = await _mediator.Send(new GetAllDonantesQuery() { EstadoDonante = estadoDonante, Categoria = categoria });
                        if (response.Succeeded)
                        {

                            //DonanteViewModelView donante = new DonanteViewModelView();

                            var viewModel = _mapper.Map<List<DonanteResponseViewModel>>(response.Data);
                            //donante.DonanteViewModels = viewModel;
                            //var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 26, Ninguno = true });
                            //var campana = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                            //donante.CampanaList = campana;
                            //catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 27, Ninguno = true });
                            ////var estadoDonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                            ////donante.EstadoDonanteList = estadoDonante;
                            //catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
                            //var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                            //donante.CiudadList = ciudad;
                            var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                            return new JsonResult(new { isValid = true, html = html1 });


                        }

                    }
                    else
                    {
                        var entidadViewModel = new DonanteViewModel();
                        var responseCola = await _mediator.Send(new GetColaboradorByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
                        if (responseCola.Succeeded)
                        {
                            entidadViewModel.Colaborador = responseCola.Data.Apellidos + " " + responseCola.Data.ApellidoMaterno + " " + responseCola.Data.PrimerNombre + " " + responseCola.Data.SegundoNombre;
                            entidadViewModel.Colaborador = entidadViewModel.Colaborador + "-" + responseCola.Data.Estructuras?.Designacion;
                        }
                        return View("_IngresoDonantes", entidadViewModel);
                    }
                  
                       
                        

                  
                    
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "" });

                }

                return new JsonResult(new { isValid = true, Id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar el Donante");
            }
            return null;
        }

        public async Task<FileResult> ShowPDF(int id, int tipo)
        {
            var responseC = await _mediator.Send(new GetDonantesByIdQuery() { Id = id });
            if (responseC.Succeeded)
            {
                var entidadViewModel = _mapper.Map<DonanteViewModel>(responseC.Data);
                switch (tipo)
                {
                    case 1:
                        if (entidadViewModel.EvidenciaConversion != null)
                        {
                            byte[] dataArray = entidadViewModel.EvidenciaConversion;
                            return File(dataArray, "application/pdf");
                        }
                        break;

                }


            }

            return null;
        }


        public async Task<ActionResult> EnviarMail(int idDonante, int estado)
        {

            DateTime fechaEnvio = DateTime.Now;
            string identificacion = "";
            string primerNombre = "";
            string segundoNombre = "";
            string primerApellido = "";
            string segundoApellido = "";
            string fechaConversion = "";
            string comentario = "";
            string comentarioResponsable = "";
            string email = "";
            string celular = "";
            string responsable = "";
            string emailResponsable = "";
            int canal = 0; 
            

            try
            {
                var response = await _mediator.Send(new GetDonantesByIdQuery() { Id = idDonante });
                if (response.Succeeded)
                {
                    identificacion = response.Data.RUC;
                    primerNombre = response.Data.Nombre1;
                    segundoNombre = response.Data.Nombre2;
                    primerApellido = response.Data.Apellido1;
                    segundoApellido = response.Data.Apellido2;
                    fechaConversion = response.Data.FechaConversion.ToString();
                    email = response.Data.Email;
                    celular = response.Data.TelefonoCelular;
                    comentario = response.Data.ComentarioActualizacion;
                    comentarioResponsable = response.Data.ComentarioResolucion;
                    responsable = response.Data.CreatedBy;
                    canal = response.Data.Canal;
                }

                var responseC = await _mediator.Send(new GetColaboradorByUserNameQuery() { UserName = responsable });
                if (responseC.Succeeded)
                {
                    emailResponsable = responseC.Data.Email;
                    responsable = responseC.Data.PrimerNombre + " " + responseC.Data.Apellidos;
                }

                string plantilla = "";
                string asunto = "";
                switch (estado)
                {

                    case 1:
                        plantilla = "Donantes\\Nuevo.html";
                       // asunto = "Ingreso de nuevo donante: " + primerNombre + " " + primerApellido;
                        switch (canal)
                        {
                            case 1:
                                canal = 1;
                                asunto = "Ingreso de nuevo donante: " + primerNombre + " " + primerApellido + " Canal: Digital-Inbound ";
                                email = _configuration["CanalDigitalInbound"];
                                break;

                            case 2:
                                canal = 2;
                                asunto = "Ingreso de nuevo donante: " + primerNombre + " " + primerApellido + " Canal: Face to Face " ;
                                email = _configuration["CanalFacetoFace"];
                                break;

                            case 3:
                                canal = 3;
                                asunto = "Ingreso de nuevo donante: " + primerNombre + " " + primerApellido + " Canal: Telemarketing-Outbound";
                                email = _configuration["CanalTelemarketingOutbound"];
                                break;
                        }
                        
                        break;
                    case 2:
                        plantilla = "Donantes\\Devolucion.html";
                        email = emailResponsable;
                        asunto = "Realizar cambios en la información del donante " + primerNombre + " " + primerApellido;
                        break;
                    case 3:
                        plantilla = "Donantes\\Realizacion.html";
                        asunto = "Actualización de Información del Donante con Identificación :" + identificacion;

                        switch (canal)
                        {
                            case 1:
                                canal = 1;
                                asunto = "Actualización de Información del Donante con Identificación :" + identificacion + " Canal: Digital-Inbound ";
                                email = _configuration["CanalDigitalInbound"];
                                break;

                            case 2:
                                canal = 2;
                                asunto = "Ingreso de nuevo donante: " + primerNombre + " " + primerApellido + "Canal: Face to Face ";
                                email = _configuration["CanalFacetoFace"];
                                break;

                            case 3:
                                canal = 3;
                                asunto = "Ingreso de nuevo donante: " + primerNombre + " " + primerApellido + "Canal: Telemarketing-Outbound";
                                email = _configuration["CanalTelemarketingOutbound"];
                                break;
                        }
                        //asunto = "Confirmación de cambios realizados " + primerNombre + " " + primerApellido;
                     
                        comentario = comentarioResponsable;
                        break;



                }
                //Get TemplateFile located at wwwroot/Templates/EmailTemplate/Register_EmailTemplate.html  
                var pathToFile = _env.WebRootPath
                        + Path.DirectorySeparatorChar.ToString()
                        + "Templates"
                        + Path.DirectorySeparatorChar.ToString()
                        + "EmailTemplate"
                        + Path.DirectorySeparatorChar.ToString()
                        + plantilla;


                var builder = new BodyBuilder();
                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }


                string messageBody = string.Format(builder.HtmlBody,
                    string.Format("{0:dddd, d MMMM yyyy}", fechaConversion),
                    primerNombre + " " + segundoNombre + " " + primerApellido + " " + segundoApellido,
                    email,
                    celular,
                    responsable,
                    comentario,
                    string.Format("{0:dddd, d MMMM yyyy}", DateTime.Now)
                    );


                await _emailSender
                    .SendEmailAsync(email, asunto, messageBody)
                    .ConfigureAwait(false);


                _notify.Success($"Mail Enviado.");


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en enviar Mail.");
            }

            //   return new JsonResult(new { isValid = true });
            // return RedirectToPage("/Wizard/Index", new { area = "Registro" });
            return null;
        }
        

    }
}

