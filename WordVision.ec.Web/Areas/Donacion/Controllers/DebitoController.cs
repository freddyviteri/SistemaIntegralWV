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
using WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById;
using WordVision.ec.Application.Features.Donacion.Debitos.Commands.Create;
using WordVision.ec.Application.Features.Donacion.Debitos.Commands.Update;

namespace WordVision.ec.Web.Areas.Donacion.Controllers
{
    [Area("Donacion")]
    [Authorize]//Sirve para dar permiso cuando esta logeado
    public class DebitoController : BaseController<DebitoController>
    {
        // ejecuta una accion
        public async Task<IActionResult> Index()
        {
            //var entidadViewModel = new DonanteViewModel();
            //var responseCola = await _mediator.Send(new GetColaboradorByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
            //if (responseCola.Succeeded)
            //{
            //    entidadViewModel.Colaborador = responseCola.Data.Apellidos + " " + responseCola.Data.ApellidoMaterno + " " + responseCola.Data.PrimerNombre + " " + responseCola.Data.SegundoNombre;
            //    entidadViewModel.Colaborador = entidadViewModel.Colaborador + "-" + responseCola.Data.Estructuras?.Designacion;
            //}

            var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 21, Ninguno = true });
            var formaPago = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 63, Ninguno = true });
            var banco = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            var entidadViewModel = new DebitoFiltroViewModel();
            entidadViewModel.FormaPagoList = formaPago;
            entidadViewModel.BancosList = banco;

            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year; i++)
            {
                items.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }

            var anio = new SelectList(items, "Value", "Text");
            entidadViewModel.AnioList = anio;

            items = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                items.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }

            var mes = new SelectList(items, "Value", "Text");
            entidadViewModel.MesList = mes;
            return View(entidadViewModel);// dirije a la carpeta Views
        }

        [HttpPost]
        public async Task<JsonResult> LoadDebitos([FromBody] DebitoFiltroViewModel filtro)
        {
            try
            {
                if (filtro == null)
                    return Json(new { data = new List<DebitoResponseViewModel>() });

                var response = await _mediator.Send(new GetDebitosSeleccionarQuery() { formaPago = filtro.FormaPago, bancoTarjeta = filtro.BancoTarjeta, anio = filtro.Anio, mes = filtro.Mes });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<DebitoResponseViewModel>>(response.Data);

                    return Json(new { data = viewModel });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en traer los debitos.");
            }


            return Json(new { data = new List<DebitoResponseViewModel>() });

        }
        public async Task<JsonResult> GetFormaPago(int idFormaPago)
        {

            var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = idFormaPago == 2 ? 63 : idFormaPago==4 ? 36 : 37, Ninguno = true });
            var banco = new SelectList(catalogo.Data, "Secuencia", "Nombre");

            //var entidadModel = await _mediator.Send(new GetProvinciaByIdRegionQuery() { IdRegion = idRegion });
            //var lista = _mapper.Map<List<ProvinciaViewModel>>(entidadModel.Data);
            return Json(catalogo.Data);

        }
        public async Task<FileContentResult> DescargarExportableTXT(int formaPago, int bancoTarjeta, int anio, int mes, int quincena = 0)
        {
 
            var response = await _mediator.Send(new GetDebitosSeleccionarQuery() { formaPago = formaPago, bancoTarjeta = bancoTarjeta, anio = anio, mes = mes });
            if (response.Succeeded)
            {

                var viewModel = _mapper.Map<List<DebitoResponseViewModel>>(response.Data);
                int numeroItems = viewModel.Count();
                int contador = 1;
                string nombreArchivo = "";
                StringWriter sw = new StringWriter();
                using (sw)
                {
                    var listDebito = new List<DebitoViewModel>();

                    switch (formaPago)
                    {
                        case 2:
                            switch (bancoTarjeta)
                            {
                                case 1:
                                    nombreArchivo = "PICHINCHA_DIRECTO_";
                                    break;
                                case 2:
                                    nombreArchivo = "PICHINCHA_INTERBANCARIO:";
                                    break;
                            }
                            break;
                        case 4:
                            switch (bancoTarjeta)
                            {
                                case 1:
                                    nombreArchivo = "DINERS_";
                                    string lineaCabecera = "1" + DateTime.Now.Year.ToString().Substring(2, 2).PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + numeroItems.ToString().PadLeft(4, '0');
                                    lineaCabecera = lineaCabecera + "1829557".PadLeft(10, '0') + "FUNDACIONVISIONMUNDI" + "0000000" + "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                                    sw.WriteLine(
                                            lineaCabecera
                                         );
                                    break;
                                case 2:
                                    nombreArchivo = "VISA_";
                                    break;
                                case 3:
                                    nombreArchivo = "DISCOVER_";
                                    break;
                                case 4:
                                    nombreArchivo = "MASTERCARD_";
                                    break;
                            }
                            break;
                    }
                    var count = 0;
                    foreach (DebitoResponseViewModel item in viewModel)
                    {
                        count++;
                        var debito = new DebitoViewModel();
                        debito.Anio = anio;
                        debito.CodigoBanco = Convert.ToInt32(item.BancoTarjeta);
                        debito.Estado = 1;
                        debito.Intento = 1;
                        debito.Mes = mes;
                        debito.Valor = item.Valor;
                        debito.IdDonante = item.Id;
                        debito.Contrapartida = formaPago == 4 ? item.CuentaTarjeta : item.Identificacion;
                        debito.FormaPago = formaPago;
                        string linea = "";
                        switch (formaPago)
                        {
                            case 2:

                                linea = @"CO" + "\t" + "2100101057" + "\t" + count + "\t" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-";
                                linea = linea + DateTime.Now.ToString("yy") + "\t" + item.Identificacion + "\t" + "USD" + "\t" + Math.Round(item.Valor, 2).ToString().Replace(",", "").Replace(".", "");
                                linea = linea + "\t" + "CTA" + "\t" + item.BancoTarjeta;
                                linea = linea + "\t" + (item.TipoCuenta == 1 ? "CTE" : "AHO") + "\t" + item?.CuentaTarjeta;
                                linea = linea + "\t" + (item.TipoId == 1 ? "R" : item.TipoId == 2 ? "C" : item.TipoId == 3 ? "P" : "N");
                                linea = linea + "\t" + item.Identificacion + "\t" + item.NombreDonante + "\t" + "\t" + "\t" + "\t" + "\t" + "Gracias por tu Donación";
                                linea = linea + "\t" + "\t" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-";
                                linea = linea + DateTime.Now.Day.ToString() + "\t" + "\t" + "\t" + "332" + "\t" + "\t" + "\t" + "332" + "\t" + "\t" + "\t" + "7" + "\t" + "\t" + "\t" + "7";
                                break;

                            case 4:
                                switch (bancoTarjeta)
                                {
                                    case 1:
                                        linea = "2" + item.CuentaTarjeta.PadLeft(16, '0') + DateTime.Now.Year.ToString().Substring(2, 2).PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                                        linea = linea + contador.ToString().PadLeft(7, '0') + "00" + "000000" + Math.Round(item.Valor, 2).ToString().Replace(",", "").Replace(".", "").PadLeft(13, '0');
                                        linea = linea + "0".PadLeft(13, '0') + Math.Round(item.Valor, 2).ToString().Replace(",", "").Replace(".", "").PadLeft(13, '0');
                                        linea = linea + "0".PadLeft(2, '0') + "1" + "0".PadLeft(12, '0') + "0" + "00" + "000" + "0" + "000" + "0" + "0" + "0".PadLeft(30, '0') + "0".PadLeft(13, '0');
                                        linea = linea + Math.Round(item.Valor, 2).ToString().Replace(",", "").Replace(".", "").PadLeft(13, '0') + "0".PadLeft(13, '0');
                                        break;
                                    case 2:
                                        linea = item.CuentaTarjeta.PadLeft(16, '0') + "1829557".PadLeft(8, '0') + DateTime.Now.Year.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                                        linea = linea + Math.Round(item.Valor, 2).ToString().Replace(",", "").Replace(".", "").PadLeft(17, '0') + "0".PadLeft(17, '0') + "202" + "0".PadLeft(6, '0') + "0".PadLeft(2, '0') + "0".PadLeft(6, '0') + "454819";
                                        linea = linea + item.FechaCaducidad.Year.ToString() + item.FechaCaducidad.Month.ToString().PadLeft(2, '0') + "0".PadLeft(17, '0') + "00" + "D" + "0".PadLeft(5, '0') + "0".PadLeft(14, '0') + Math.Round(item.Valor, 2).ToString().Replace(",", "").Replace(".", "").PadLeft(14, '0') + "0".PadLeft(14, '0');
                                        break;
                                    case 3:
                                        linea = item.CuentaTarjeta.PadLeft(16, '0') + "1829557".PadLeft(8, '0') + DateTime.Now.Year.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                                        linea = linea + Math.Round(item.Valor, 2).ToString().Replace(",", "").Replace(".", "").PadLeft(17, '0') + "0".PadLeft(17, '0') + "202" + "0".PadLeft(6, '0') + "0".PadLeft(2, '0') + "0".PadLeft(6, '0') + "454819";
                                        linea = linea + item.FechaCaducidad.Year.ToString() + item.FechaCaducidad.Month.ToString().PadLeft(2, '0') + "0".PadLeft(17, '0') + "00" + "D" + "0".PadLeft(5, '0') + "0".PadLeft(14, '0') + Math.Round(item.Valor, 2).ToString().Replace(",", "").Replace(".", "").PadLeft(14, '0') + "0".PadLeft(14, '0');

                                        break;
                                    case 4:
                                        linea = item.CuentaTarjeta.PadLeft(16, '0') + "1829557".PadLeft(8, '0') + DateTime.Now.Year.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                                        linea = linea + Math.Round(item.Valor, 2).ToString().Replace(",", "").Replace(".", "").PadLeft(17, '0') + "0".PadLeft(17, '0') + "202" + "0".PadLeft(6, '0') + "0".PadLeft(2, '0') + "0".PadLeft(6, '0') + "454819";
                                        linea = linea + item.FechaCaducidad.Year.ToString() + item.FechaCaducidad.Month.ToString().PadLeft(2, '0') + "0".PadLeft(17, '0') + "00" + "D" + "0".PadLeft(5, '0') + "0".PadLeft(14, '0') + Math.Round(item.Valor, 2).ToString().Replace(",", "").Replace(".", "").PadLeft(14, '0') + "0".PadLeft(14, '0');

                                        break;
                                }

                                break;

                        }

                        sw.WriteLine(
                            linea
                         );

                        listDebito.Add(debito);
                        contador++;
                    }

                    var entidad = new DebitoViewModel();
                    entidad.ListaDebitos = listDebito;
                    var createEntidadCommand = _mapper.Map<CreateDebitoCommand>(entidad);
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                    {
                        String contenido = sw.ToString();
                        nombreArchivo = nombreArchivo + DateTime.Now.Date;
                        String ExtensionArchivo = "txt";
                        _notify.Success($"Archivo " + nombreArchivo + " Txt generado");
                        return File(new System.Text.UTF8Encoding().GetBytes(contenido), "text/" + ExtensionArchivo, nombreArchivo + "." + ExtensionArchivo);

                    }
                    else
                    {
                        _notify.Error($"Archivo Txt no se pudo generar.");
                        return null;
                    }

                }

              
            }
            return null;
        }




        public async Task<IActionResult> LoadRespuestas(int formaPago, int bancoTarjeta, int anio, int mes)
        {

            try
            {
                
                var responseExiste = await _mediator.Send(new GetArchivoGeneradoQuery() { formaPago = formaPago, bancoTarjeta = bancoTarjeta, anio = anio, mes = mes });;
                if (responseExiste.Succeeded)
                {
                    if ((int)responseExiste.Data<=0)
                    {
                        // _notify.Success($"Genere Primero el archivo Txt");

                        return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "Genere Primero el archivo Txt" });

                    }

                }
                var responseExisteRespuesta = await _mediator.Send(new GetExisteCargaRespuestaQuery() { formaPago = formaPago, bancoTarjeta = bancoTarjeta, anio = anio, mes = mes }); ;
                if (responseExisteRespuesta.Succeeded)
                {
                    if ((int)responseExisteRespuesta.Data > 0)
                    {
                        //_notify.Success($"Ya se ha cargado las respuestas para este mes y este año");
                        return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "Ya se ha cargado las respuestas para este mes y este año." });

                       // return new JsonResult(new { mensaje = "Ya se ha cargado las respuestas para este mes y este año" });
                    }

                }
                int i = 0;
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    var filename = Path.GetFileName(file.FileName);
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Upload\\" + filename;
                    using (Stream fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    List<DebitoViewModel> listaDatos = new List<DebitoViewModel>();
                    List<string> strContent = new List<string>();
                    using (var stream = new StreamReader(file.OpenReadStream()))
                    {
                        while (!stream.EndOfStream)
                        {
                            var linea = stream.ReadLine();
                            strContent.Add(linea);//agrego al List el contenido del archivo                   
                        }
                        if (strContent.Count == 0)
                        {
                            //_notify.Success($"No existen registros en el archivo.");
                            return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "No existen registros en el archivo." });

                        }
                        i = 0;
                        foreach (var item in strContent.Skip(1))//salteo las cabeceras
                        {
                            var cells = item.Split(";");//separo por ;
                            var debito = new DebitoViewModel();
                            debito.Anio = anio;
                            debito.CodigoBanco = bancoTarjeta == 1 ? 10 : bancoTarjeta;
                            debito.Mes = mes;
                            debito.Contrapartida = cells[0];
                            debito.FormaPago = formaPago;
                            debito.CodigoRespuesta = cells[1];
                            debito.FechaDebito = cells[2];
                           
                                i++;
                 

                            listaDatos.Add(debito);
                        }


                        var entidad = new DebitoViewModel();
                        entidad.ListaDebitos = listaDatos;
                        var createEntidadCommand = _mapper.Map<UpdateDebitoCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            // _notify.Success($"{i} Registros almacenadas.");
                            return StatusCode(StatusCodes.Status200OK, new { mensaje = $"{i} Registros almacenadas." });

                        }
                        else
                        {
                            //_notify.Success($"Error en almacenar los registros.");
                            return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = $"Error en almacenar los registros." });
                        }

                    }

                }
                else
                {
                    //_notify.Success($"No existe archivo para cargar.");
                    return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = $"No existe archivo para cargar." });

                }
            }
            catch (Exception ex)
            {
               // _notify.Error($"No se puedo cargar el archivo.");
                _logger.LogError(ex, $"Error al Insertar archivo respuesta.");
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = $"No se puedo cargar el archivo." });
            }

        }

        public async Task<IActionResult> OnGetCreate(int id = 0)
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
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 32, Ninguno = true });
            var provincia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
            var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 34, Ninguno = true });
            var frecuencia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 35, Ninguno = true });
            var tipoCuenta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 36, Ninguno = true });
            var tipoTarjeta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 37, Ninguno = true });
            var banco = new SelectList(catalogo.Data, "Secuencia", "Nombre");
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
                entidadViewModel.ProvinciaList = provincia;
                entidadViewModel.CiudadList = ciudad;
                entidadViewModel.FrecuenciaList = frecuencia;
                entidadViewModel.TipoCuentaList = tipoCuenta;
                entidadViewModel.TipoTarjetaList = tipoTarjeta;
                entidadViewModel.BancoList = banco;
                //entidadViewModel.QuincenaList = quincena;
                entidadViewModel.FechaConversion = DateTime.Now;
                return PartialView("_CreateOrEdit", entidadViewModel);
            }
            return null;

        }

        public async Task<IActionResult> IngresarDonante()
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


        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
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
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 32, Ninguno = true });
            var provincia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
            var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 34, Ninguno = true });
            var frecuencia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 35, Ninguno = true });
            var tipoCuenta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 36, Ninguno = true });
            var tipoTarjeta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 37, Ninguno = true });
            var banco = new SelectList(catalogo.Data, "Secuencia", "Nombre");
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
                entidadViewModel.ProvinciaList = provincia;
                entidadViewModel.CiudadList = ciudad;
                entidadViewModel.FrecuenciaList = frecuencia;
                entidadViewModel.TipoCuentaList = tipoCuenta;
                entidadViewModel.TipoTarjetaList = tipoTarjeta;
                entidadViewModel.BancoList = banco;
                //entidadViewModel.QuincenaList = quincena;
                entidadViewModel.FechaConversion = DateTime.Now;

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetDonantesByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<DonanteViewModel>(response.Data);
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
                    entidadViewModel.ProvinciaList = provincia;
                    entidadViewModel.CiudadList = ciudad;
                    entidadViewModel.FrecuenciaList = frecuencia;
                    entidadViewModel.TipoCuentaList = tipoCuenta;
                    entidadViewModel.TipoTarjetaList = tipoTarjeta;
                    entidadViewModel.BancoList = banco;

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int? id, DonanteViewModel entidad)
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
                        if (entidad.ComentarioActualizacion.Length != 0 && entidad.ComentarioResolucion.Length == 0)
                            await EnviarMail(result.Data, 2);
                        else if (entidad.ComentarioResolucion.Length != 0)
                            await EnviarMail(result.Data, 3);
                    }

                    var response = await _mediator.Send(new GetAllDonantesQuery());
                    if (response.Succeeded)
                    {

                        DonanteViewModelView donante = new DonanteViewModelView();

                        var viewModel = _mapper.Map<List<DonanteViewModel>>(response.Data);
                        donante.DonanteViewModels = viewModel;
                        var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 26, Ninguno = true });
                        var campana = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                        donante.CampanaList = campana;
                        catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 27, Ninguno = true });
                        var estadoDonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                        donante.EstadoDonanteList = estadoDonante;
                        catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
                        var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                        donante.CiudadList = ciudad;
                        var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", donante);
                        return new JsonResult(new { isValid = true, html = html1 });


                    }


                }
                else
                {
                    return new JsonResult(new { isValid = false });
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

            try
            {
                var response = await _mediator.Send(new GetDonantesByIdQuery() { Id = idDonante });
                if (response.Succeeded)
                {
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
                        asunto = "Ingreso de nuevo donante: " + primerNombre + " " + primerApellido;
                        email = _configuration["DestinoDonante"];
                        break;
                    case 2:
                        plantilla = "Donantes\\Devolucion.html";
                        email = emailResponsable;
                        asunto = "Realizar cambios en la información del donante " + primerNombre + " " + primerApellido;
                        break;
                    case 3:
                        plantilla = "Donantes\\Realizacion.html";
                        asunto = "Confirmación de cambios realizados " + primerNombre + " " + primerApellido;
                        email = _configuration["DestinoDonante"];
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
        public async Task<JsonResult> UpdateEstadoDebito(int id, int estadoDebito)
        {

            var cuenta = await _mediator.Send(new UpdateEstadoDebitoXInteracionCommand() { Id = id, EstadoDebito = estadoDebito });

            return Json(cuenta.Data);

        }

    }
}

