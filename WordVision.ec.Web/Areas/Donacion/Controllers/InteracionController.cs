using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Donacion.Donantes.Commands.Update;
using WordVision.ec.Application.Features.Donacion.Interaciones.Commands.Create;
using WordVision.ec.Application.Features.Donacion.Interaciones.Commands.Update;
using WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAll;
using WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAllCached;
using WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Donacion.Models;


namespace WordVision.ec.Web.Areas.Donacion.Controllers
{
    [Area("Donacion")]
    [Authorize]//Sirve para dar permiso cuando esta logeado
    public class InteracionController : BaseController<InteracionController>
    {
        public async Task<JsonResult> OnGetCreateOrEdit(int idDonante, int tipoPantalla = 0 )                      
       {

            try
            {
                int numCatalogo = 67; 
                if (tipoPantalla == 2) 
                {
                    numCatalogo = 72;
                }
                if (tipoPantalla == 3)
                {
                    numCatalogo = 69;
                }

                var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = numCatalogo, Ninguno = true });
                    var interacion = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                   
                    catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 68, Ninguno = true });
                    var tipointeracion = new SelectList(catalogo.Data, "Secuencia", "Nombre");

                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 72, Ninguno = true });
                var estadokitcourier = new SelectList(catalogo.Data, "Secuencia", "Nombre");

                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 71, Ninguno = true });
                var motivobajacartera = new SelectList(catalogo.Data, "Secuencia", "Nombre");

                var entidadViewModel = new InteracionViewModel();
                    entidadViewModel.interacionesList = interacion;
                    entidadViewModel.tipoList = tipointeracion;
                entidadViewModel.EstadoCourierList = estadokitcourier;
                entidadViewModel.MotivoBajaCarteraList = motivobajacartera;


                var viewModel = await _mediator.Send(new GetAllInteracionesXDonanteQuery() { idDonante = idDonante , tipo = tipoPantalla});// estadoCourier = estadoKitCourier
                    
                if (viewModel.Succeeded)
                    {
                        entidadViewModel.ListaInteracciones = _mapper.Map<List<InteracionListaViewModel>>(viewModel.Data);//para hacer lista y poder visualizar


                    var viewModelDebitos = await _mediator.Send(new GetDebitosXDonanteQuery() { idDonante = idDonante });
                    if (viewModelDebitos.Succeeded)
                    {

                        entidadViewModel.ListaDebitos = _mapper.Map<List<ListaDebitoInteracionResponseViewModel>>(viewModelDebitos.Data);//para hacer lista y poder visualizar
                    }




                }
              

                    entidadViewModel.IdDonante = idDonante;
                    entidadViewModel.TipoPantalla = tipoPantalla;
                   //ntidadViewModel.EstadoKitCourier = estadoKitCourier;

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });


               



            }
            catch (Exception ex)
            {
                _logger.LogError("OnGetCreateOrEdit", ex);
                _notify.Error("Error al Crear la Interación");
            }
            return null;

        }



       



        [HttpPost]
        public async Task<IActionResult> OnPostCreateOrEdit(int? id, InteracionViewModel entidad)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                  
                    if (id == 0)
                    {
                       
                        var createEntidadCommand = _mapper.Map<CreateInteracionCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                          
                            id = result.Data;
                            if (entidad.TipoPantalla == 1)// if (entidad.Gestion == 4)
                            {
                                await _mediator.Send(new UpdateDonanteXEstadoCommand() { Id = entidad.IdDonante, EstadoDonante = 5 });
                                
                                
                             
                            }
                            _notify.Success($"Interacción Creada.");

                        }
                        else _notify.Error(result.Message);
                    }
                    //else ESTO ES PARA EDITAR 
                    //{
                    //    var updateEntidadCommand = _mapper.Map<UpdateInteracionCommand>(entidad);
                    //    var result = await _mediator.Send(updateEntidadCommand);
                    //    if (result.Succeeded) _notify.Information($"Donante con ID {result.Data} Actualizado.");
                    //    if (entidad.ComentarioActualizacion != null && entidad.ComentarioResolucion != null)
                    //    {
                    //        if (entidad.ComentarioActualizacion.Length != 0 && entidad.ComentarioResolucion.Length == 0)
                    //            await EnviarMail(result.Data, 2);
                    //        else if (entidad.ComentarioResolucion.Length != 0)
                    //            await EnviarMail(result.Data, 3);
                    //    }

                    //}
                    

                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "Ingrese todos los datos Obligatorios" });

                }

                return new JsonResult(new { isValid = true, Id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar el Interacción");
            }
            return null;
        }
    }
}
