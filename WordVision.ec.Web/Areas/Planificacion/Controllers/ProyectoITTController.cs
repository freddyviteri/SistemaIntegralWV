using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Indicadores.MarcoLogicoAsignado.Queries.GetAll;
using WordVision.ec.Application.Features.Indicadores.Planificacion.Queries.GetById;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador;
using WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Queries.GetAll;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ProyectoITT.Queries.GetAll;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{

    [Area("Planificacion")]
    public class ProyectoITTController : BaseController<ProyectoITTController>
    {
        private readonly CommonMethods _commonMethods;

        public ProyectoITTController()
        {
            _commonMethods = new CommonMethods();
        }

        public IActionResult Index()
        {
            var entidadViewModel = new ProyectoITTViewModel();
            //await SetDropDownList(entidadViewModel);
            return View(entidadViewModel);
        }

        public async Task<JsonResult> Cargarcombos()
        {
            var response = await _mediator.Send(new GetAllFaseProgramaAreaQuery() { Include = true });

            var listadistinct = ((List<FaseProgramaAreaResponse>)(response.Data))
                .Select(x => new
                {
                    id = x.Id,
                    idpa = x.ProyectoTecnico.ProgramaArea.Id,
                    nombreprograma = x.ProyectoTecnico.ProgramaArea.Descripcion,

                    idpt = x.ProyectoTecnico.Id,
                    nombreproyecto = x.ProyectoTecnico.NombreProyecto,

                    idfase = x.IdFaseProyecto,
                    fase = x.FaseProyecto.Nombre
                }).ToList();

            return Json(listadistinct);
        }

        public async Task<JsonResult> CargarInfoPreyTecnico(int idproyecto)
        {
            _commonMethods.SetProperties(_notify, _logger);
            string observ = "[]";
            string respon = "[]";
            string superv = "[]";
            string listoutcome = "[]";
            string listalloutcome = "[]";
            string listalloutput = "[]";
            string listallactivity = "[]";

            // var rprytec = await _mediator.Send(new GetProyectoTecnicoByIdQuery() { Id = idproyecto });


            var fpa = new FaseProgramaAreaResponse()
            {
                IdProyectoTecnico = idproyecto
            };

            var response = await _mediator.Send(new GetAllProyectoITTQuery { Include = true, FaseProgramaArea = fpa });
            if (response.Succeeded)
            {
                if (response.Data.Count() > 0)
                {
                    _notify.Information("Ya se encuentra creado el Proyecto ITT desde proyecto tecnico");
                    return new JsonResult(new
                    {
                        isValid = false
                    });
                }
            }


            var listmla = await _mediator.Send(new GetAllMarcoLogicoAsignadoQuery() { IdProyectoTecnico = idproyecto, Include = true });
            if (listmla.Succeeded)
            {
                if (listmla.Data.Count == 0)
                {
                    _notify.Information("No se ha encontrado marco logico vinculado.");
                    return new JsonResult(new
                    {
                        isValid = false
                    });
                }
                var mla = listmla.Data;



                var distinctListSumaryobsrv = mla
                    .Where(x => x.MarcoLogico.LogFrame != null && x.MarcoLogico.LogFrame.IdNivel == CatalogoConstant.IdCatalogoNivelGoul)
                    .Select(x => new { x.Id, sumaryobjetives = x.MarcoLogico.LogFrame.SumaryObjetives })
                    .Distinct();

                var distinctListResponsable = mla.Where(x => x.Responsable != null).Select(x => new { id = x.Responsable.Id, fullname = x.Responsable.FullName }).Distinct();

                var distinctListSupervisor = mla.Where(x => x.Supervisor != null).Select(x => new { id = x.Supervisor.Id, fullname = x.Supervisor.FullName }).Distinct();

                observ = JsonConvert.SerializeObject(distinctListSumaryobsrv);
                respon = JsonConvert.SerializeObject(distinctListResponsable);
                superv = JsonConvert.SerializeObject(distinctListSupervisor);


                var distinctMarcoLogio = mla
                                        .Select(x => new
                                        {
                                            x.IdMarcoLogico
                                        }).Distinct();


                var ListVinculacionIndicadores = distinctMarcoLogio
                        .Select(x => new
                        {
                            x.IdMarcoLogico,
                            VinculacionIndicadorString = CargarVinculacionMarcadores(x.IdMarcoLogico).Result
                        });

                var distinctListOutcome = mla
                    .Select(x => new ProyectoDetalleittViewModelHelp()
                    {
                        Id = 0,
                        IdMarcoLogicoAsignado = x.Id,
                        IdMarcoLogico = x.IdMarcoLogico,
                        IdLogFrame = x.MarcoLogico.IdLogFrame,
                        OutCome = x.MarcoLogico.LogFrame.OutCome,
                        OutPut = x.MarcoLogico.LogFrame.OutPut,
                        Activity = x.MarcoLogico.LogFrame.Activity,
                        SumaryObjetives = x.MarcoLogico.LogFrame.SumaryObjetives,
                        IdNivel = x.MarcoLogico.LogFrame.IdNivel,
                        IdEstado = x.MarcoLogico.LogFrame.IdEstado,
                        Cobertura = x.MarcoLogico.LogFrame.Cobertura,
                        IdProgramaTecnico = x.MarcoLogico.LogFrame.IdProgramaTecnico,
                        ProgramaTecnico = x.MarcoLogico.LogFrame.ProgramaTecnico.Nombre,
                        //x.MarcoLogico.LogFrame.IdSectorProgramatico,
                        //SectorProgramatico = x.MarcoLogico.LogFrame.SectorProgramatico.Nombre,
                        IdTipoActividad = x.MarcoLogico.LogFrame.IdTipoActividad,
                        TipoActividad = x.MarcoLogico.LogFrame.TipoActividad.Nombre,
                        IdModeloProyecto = x.MarcoLogico.LogFrame.IdModeloProyecto,
                        ModeloProyecto = x.MarcoLogico.LogFrame.ModeloProyecto.Descripcion,
                        CodigoML = x.MarcoLogico.IndicadorML.Codigo,
                        NombreML = x.MarcoLogico.IndicadorML.Descripcion,
                        Target = x.MarcoLogico.IndicadorML.Target.Nombre,
                        Unidad = x.MarcoLogico.IndicadorML.TipoMedida.Nombre,
                        Frecuencia = x.MarcoLogico.IndicadorML.Frecuencia.Nombre,
                        Participante = x.MarcoLogico.IndicadorML.ActorParticipante.Descripcion,
                        Vindicadores = ListVinculacionIndicadores.Where(a => a.IdMarcoLogico == x.IdMarcoLogico).FirstOrDefault().VinculacionIndicadorString,
                        Valorlineabase = 0,
                        Valormetaa = 0,
                        Valormetab = 0,
                        Valormetac = 0,
                        Valormetad = 0,
                        Valormetae = 0,
                    })
                    .Distinct();




                int[] Outcomes = new int[] { CatalogoConstant.IdCatalogoNivelOutcome };

                var distinctListoutcomes = distinctListOutcome
                    .Where(x => Outcomes.Contains(x.IdNivel)).Select(x => new { x.OutCome, x.SumaryObjetives }).Distinct();
                listoutcome = JsonConvert.SerializeObject(distinctListoutcomes);

                var LogListoutcomes = distinctListOutcome.Where(x => Outcomes.Contains(x.IdNivel)).Distinct();
                listalloutcome = JsonConvert.SerializeObject(LogListoutcomes);

                int[] Output = new int[] { CatalogoConstant.IdCatalogoNivelOutput };
                var LogListoutput = distinctListOutcome.Where(x => Output.Contains(x.IdNivel)).Distinct();
                listalloutput = JsonConvert.SerializeObject(LogListoutput);

                int[] Activity = new int[] { CatalogoConstant.IdCatalogoNivelActivity };
                var LogListactivity = distinctListOutcome.Where(x => Activity.Contains(x.IdNivel)).Distinct();
                listallactivity = JsonConvert.SerializeObject(LogListactivity);
            }
            else
            {
                _notify.Information("No se ha encontrado marco logico vinculado.");
                return new JsonResult(new
                {
                    isValid = false
                });
            }



            return await Task.FromResult(Json(new
            {
                isValid = true,
                prygoal = observ,
                supervisor = superv,
                responsable = respon,
                outcome = listoutcome,
                tbloutcome = listalloutcome,
                tbloutput = listalloutput,
                tblactivity = listallactivity
            }));
        }


        public async Task<JsonResult> CargarProyectoITT(int idproyectoitt)
        {
            _commonMethods.SetProperties(_notify, _logger);
            string observ = "[]";
            string respon = "[]";
            string superv = "[]";
            string listoutcome = "[]";
            string listalloutcome = "[]";
            string listalloutput = "[]";
            string listallactivity = "[]";

            // var rprytec = await _mediator.Send(new GetProyectoTecnicoByIdQuery() { Id = idproyecto });

            try
            {
                var listpitt = await _mediator.Send(new GetProyectoITTByIdQuery() { Id = idproyectoitt, Include = true });
                if (listpitt.Succeeded)
                {
                    if (listpitt.Data == null)
                    {
                        _notify.Information("No se ha encontrado PROYECTO ITT.");
                        return new JsonResult(new
                        {
                            isValid = false
                        });
                    }

                    var pryitt = listpitt.Data;
                    var detalle = pryitt.DetalleProyectoITTs.AsEnumerable();
                    var detallegoul = pryitt.DetalleProyectoITTGouls.AsEnumerable();

                    var mla = detalle.Select(x => x.MarcoLogicoAsignado).ToList();
                    var mlagoul = detallegoul.Select(x => x.MarcoLogicoAsignado).ToList();
                    mla.AddRange(mlagoul);


                    var distinctListSumaryobsrv = mla
                            .Where(x => x.MarcoLogico.LogFrame != null && x.MarcoLogico.LogFrame.IdNivel == CatalogoConstant.IdCatalogoNivelGoul)
                            .Select(x => new { x.Id, sumaryobjetives = x.MarcoLogico.LogFrame.SumaryObjetives })
                            .Distinct();

                    var distinctListResponsable = mla.Where(x => x.Responsable != null).Select(x => new { id = x.Responsable.Id, fullname = x.Responsable.FullName }).Distinct();

                    var distinctListSupervisor = mla.Where(x => x.Supervisor != null).Select(x => new { id = x.Supervisor.Id, fullname = x.Supervisor.FullName }).Distinct();

                    observ = JsonConvert.SerializeObject(distinctListSumaryobsrv);
                    respon = JsonConvert.SerializeObject(distinctListResponsable);
                    superv = JsonConvert.SerializeObject(distinctListSupervisor);


                    var distinctMarcoLogio = mla
                                            .Select(x => new
                                            {
                                                x.IdMarcoLogico
                                            }).Distinct();


                    var ListVinculacionIndicadores = distinctMarcoLogio
                            .Select(x => new
                            {
                                x.IdMarcoLogico,
                                VinculacionIndicadorString = CargarVinculacionMarcadores(x.IdMarcoLogico).Result
                            });

                    var distinctListOutcome = detalle
                        .Select(x => new ProyectoDetalleittViewModelHelp()
                        {
                            Id = x.Id,
                            IdMarcoLogicoAsignado = x.MarcoLogicoAsignado.Id,
                            IdMarcoLogico = x.MarcoLogicoAsignado.IdMarcoLogico,
                            IdLogFrame = x.MarcoLogicoAsignado.MarcoLogico.IdLogFrame,
                            OutCome = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.OutCome,
                            OutPut = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.OutPut,
                            Activity = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.Activity,
                            SumaryObjetives = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.SumaryObjetives,
                            IdNivel = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.IdNivel,
                            IdEstado = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.IdEstado,
                            Cobertura = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.Cobertura,
                            IdProgramaTecnico = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.IdProgramaTecnico,
                            ProgramaTecnico = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.ProgramaTecnico.Nombre,
                            //x.MarcoLogico.LogFrame.IdSectorProgramatico,
                            //SectorProgramatico = x.MarcoLogico.LogFrame.SectorProgramatico.Nombre,
                            IdTipoActividad = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.IdTipoActividad,
                            TipoActividad = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.TipoActividad.Nombre,
                            IdModeloProyecto = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.IdModeloProyecto,
                            //ModeloProyecto = x.MarcoLogicoAsignado.MarcoLogico.LogFrame.ModeloProyecto.Descripcion,
                            CodigoML = x.MarcoLogicoAsignado.MarcoLogico.IndicadorML.Codigo,
                            NombreML = x.MarcoLogicoAsignado.MarcoLogico.IndicadorML.Descripcion,
                            Target = x.MarcoLogicoAsignado.MarcoLogico.IndicadorML.Target.Nombre,
                            Unidad = x.MarcoLogicoAsignado.MarcoLogico.IndicadorML.TipoMedida.Nombre,
                            Frecuencia = x.MarcoLogicoAsignado.MarcoLogico.IndicadorML.Frecuencia.Nombre,
                            Participante = x.MarcoLogicoAsignado.MarcoLogico.IndicadorML.ActorParticipante.Descripcion,
                            Vindicadores = ListVinculacionIndicadores.Where(a => a.IdMarcoLogico == x.MarcoLogicoAsignado.IdMarcoLogico).FirstOrDefault().VinculacionIndicadorString,
                            Valorlineabase = decimal.Parse("0" + x.LineBase),// decimal.Parse("0" + detalle.Where(y => y.IdProyectoITT == x.Id).FirstOrDefault().LineBase),
                            Valormetaa = x.MetaAF1,// detalle.FirstOrDefault(y => y.IdMarcoLogicoAsignado == x.Id).MetaAF1,
                            Valormetab = x.MetaAF2,// detalle.FirstOrDefault(y => y.IdMarcoLogicoAsignado == x.Id).MetaAF2,
                            Valormetac = x.MetaAF3,// detalle.FirstOrDefault(y => y.IdMarcoLogicoAsignado == x.Id).MetaAF3,
                            Valormetad = x.MetaAF4,//  detalle.FirstOrDefault(y => y.IdMarcoLogicoAsignado == x.Id).MetaAF4,
                            Valormetae = x.MetaAF5 //detalle.Where(y => y.IdMarcoLogicoAsignado == x.Id).FirstOrDefault().MetaAF5,
                        })
                        .Distinct();




                    int[] Outcomes = new int[] { CatalogoConstant.IdCatalogoNivelOutcome };

                    var distinctListoutcomes = distinctListOutcome
                        .Where(x => Outcomes.Contains(x.IdNivel)).Select(x => new { x.OutCome, x.SumaryObjetives }).Distinct();
                    listoutcome = JsonConvert.SerializeObject(distinctListoutcomes);

                    var LogListoutcomes = distinctListOutcome.Where(x => Outcomes.Contains(x.IdNivel)).Distinct();
                    listalloutcome = JsonConvert.SerializeObject(LogListoutcomes);

                    int[] Output = new int[] { CatalogoConstant.IdCatalogoNivelOutput };
                    var LogListoutput = distinctListOutcome.Where(x => Output.Contains(x.IdNivel)).Distinct();
                    listalloutput = JsonConvert.SerializeObject(LogListoutput);

                    int[] Activity = new int[] { CatalogoConstant.IdCatalogoNivelActivity };
                    var LogListactivity = distinctListOutcome.Where(x => Activity.Contains(x.IdNivel)).Distinct();
                    listallactivity = JsonConvert.SerializeObject(LogListactivity);
                }
                else
                {
                    _notify.Information("No se ha encontrado PROYECTO ITT.");
                    return new JsonResult(new
                    {
                        isValid = false
                    });
                }



                return await Task.FromResult(Json(new
                {
                    isValid = true,
                    prygoal = observ,
                    supervisor = superv,
                    responsable = respon,
                    outcome = listoutcome,
                    tbloutcome = listalloutcome,
                    tbloutput = listalloutput,
                    tblactivity = listallactivity
                }));
            }
            catch (Exception ex)
            {
                _notify.Error(ex.Message);
                return await Task.FromResult(Json(new
                {
                    isValid = false,
                    msg = ex.InnerException.Message
                }));
            }
        }


        [HttpGet]
        public async Task<IActionResult> LoadAll(int idpt)
        {
            List<ProyectoITTViewModel> viewModels = new List<ProyectoITTViewModel>();

            var fpa = new FaseProgramaAreaResponse()
            {
                IdProyectoTecnico = idpt
            };

            var response = await _mediator.Send(new GetAllProyectoITTQuery { Include = true, FaseProgramaArea = fpa });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<ProyectoITTViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }


        public async Task<string> CargarVinculacionMarcadores(int idmarcologico)
        {
            var res = await _mediator.Send(new GetAllVinculacionIndicadorQuery() { IdMarcoLogico = idmarcologico, Include = true });
            var list = new List<VinculacionIndicadorResponse>();
            if (res.Succeeded)
            {
                if (res.Data.Count > 0)
                {
                    list = res.Data;
                    var valores = list.Select(x => x.OtroIndicador.Codigo + " " + x.OtroIndicador.TipoIndicador.Nombre).Distinct().ToList();
                    return string.Join(",", valores);
                }
            }
            return string.Empty;
        }



        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new ProyectoITTViewModel
                {
                    //FechaInicio = DateTime.Now,
                    //FechaFin = DateTime.Now,
                    //FechaDisenio = DateTime.Now,
                    //FechaRedisenio = DateTime.Now,
                    //FechaTransicion = DateTime.Now,
                };
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetProyectoITTByIdQuery() { Id = id, Include = true });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<ProyectoITTViewModel>(response.Data);
                        entidadViewModel.IdProgramaArea = entidadViewModel.FaseProgramaArea.ProyectoTecnico.IdProgramaArea;
                        entidadViewModel.ProgramaArea = entidadViewModel.FaseProgramaArea.ProyectoTecnico.ProgramaArea;
                        entidadViewModel.IdProyectoTecnico = entidadViewModel.FaseProgramaArea.ProyectoTecnico.Id;
                        entidadViewModel.ProyectoTecnico = entidadViewModel.FaseProgramaArea.ProyectoTecnico;
                        //entidadViewModel.ProyectoTecnico.NombreProyecto = entidadViewModel.ProyectoTecnico.NombreProyecto + "--" + entidadViewModel.FaseProgramaArea.FaseProyecto.Nombre + "--" + entidadViewModel.FaseProgramaArea.Id.ToString();
                        await SetDropDownList(entidadViewModel);
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                    }
                    return new JsonResult(new
                    {
                        isValid = false,
                        msg = "No ingreso"
                    });
                }
            }
            catch (Exception ex)
            {
                _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar ProyectoITT.", ex.Message);
                return new JsonResult(new
                {
                    isValid = false,
                    msg = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(CabeceraPitt viewmodel)
        {
            _commonMethods.SetProperties(_notify, _logger);

            try
            {
                if (viewmodel.id == 0)
                {
                    List<DetalleProyectoITTResponse> lista = new List<DetalleProyectoITTResponse>();
                    foreach (var item in viewmodel.Detalle)
                    {
                        lista.Add(new DetalleProyectoITTResponse()
                        {
                            LineBase = item.Valorlineabase.ToString(),
                            MetaAF1 = (decimal)item.Valormetaa,
                            MetaAF2 = (decimal)item.Valormetab,
                            MetaAF3 = (decimal)item.Valormetac,
                            MetaAF4 = (decimal)item.Valormetad,
                            MetaAF5 = (decimal)item.Valormetae,
                            MetaAF6 = 0,
                            IdMarcoLogicoAsignado = item.IdMarcoLogicoAsignado,
                        });
                    }

                    List<DetalleProyectoITTGoulResponse> listaGoul = new List<DetalleProyectoITTGoulResponse>();
                    foreach (var item in viewmodel.DetalleGoul)
                    {
                        listaGoul.Add(new DetalleProyectoITTGoulResponse()
                        {
                            IdMarcoLogicoAsignado = item.IdMarcoLogicoAsignado,
                        });
                    }


                    CreateProyectoITTCommand model = new CreateProyectoITTCommand()
                    {
                        Id = viewmodel.id,
                        IdFaseProgramaArea = viewmodel.idfapa,
                        DetalleProyectoITTs = lista,
                        DetalleProyectoITTGouls = listaGoul
                    };

                    var result = await _mediator.Send(model);
                    if (result.Succeeded)
                    {
                        _notify.Success($"ProyectoITT con ID {result.Data} Creado.");
                        return await Task.FromResult(new JsonResult(new { isValid = true }));
                    }
                    else
                    {
                        _commonMethods.SaveError($"OnGetCreateOrEdit Error al guardar ProyectoITT.", "Error");
                        return await Task.FromResult(new JsonResult(new { isValid = false, msg = "No se guardo la información." }));
                    }
                }
                else
                {

                    //var response = await _mediator.Send(new GetProyectoITTByIdQuery() { Id = viewmodel.id, Include = true });
                    //if (response.Succeeded)
                    //{
                    //    var UpddentidadViewModel = _mapper.Map<UpdateProyectoITTCommand>(response.Data);
                    //    List<DetalleProyectoITTResponse> DetalleProyectoITTs = new List<DetalleProyectoITTResponse>();


                    //    foreach (var item in viewmodel.Detalle)
                    //    {
                    //        var reg = UpddentidadViewModel.DetalleProyectoITTs.Where(x => x.Id == item.Id).FirstOrDefault();

                    //        reg.LineBase = item.Valorlineabase.ToString();
                    //        reg.MetaAF1 = item.Valormetaa;
                    //        reg.MetaAF2 = item.Valormetab;
                    //        reg.MetaAF3 = item.Valormetac;
                    //        reg.MetaAF4 = item.Valormetad;
                    //        reg.MetaAF5 = item.Valormetae;
                    //        // reg.MetaAF6 = 0;
                    //        DetalleProyectoITTs.Add(reg);
                    //    }
                    //    UpddentidadViewModel.DetalleProyectoITTs = DetalleProyectoITTs;


                    UpdateProyectoITTCommand updated = new UpdateProyectoITTCommand();
                    List<DetalleProyectoITTResponse> DetalleProyectoITTs = new List<DetalleProyectoITTResponse>();
                    updated.Id = viewmodel.id;

                    foreach (var item in viewmodel.Detalle)
                    {
                        var reg = new DetalleProyectoITTResponse();
                        reg.Id = item.Id;
                        reg.LineBase = item.Valorlineabase.ToString();
                        reg.MetaAF1 = item.Valormetaa;
                        reg.MetaAF2 = item.Valormetab;
                        reg.MetaAF3 = item.Valormetac;
                        reg.MetaAF4 = item.Valormetad;
                        reg.MetaAF5 = item.Valormetae;
                        // reg.MetaAF6 = 0;
                        DetalleProyectoITTs.Add(reg);
                    }
                    updated.DetalleProyectoITTs = DetalleProyectoITTs;

                    var result = await _mediator.Send(updated);
                    if (result.Succeeded)
                    {
                        _notify.Information($"PITT con ID {result.Data} Actualizado.");
                        return await Task.FromResult(new JsonResult(new { isValid = true, msg = "Se actualizo PITT" }));
                    }
                    else
                    {
                        _commonMethods.SaveError(result.Message);
                        return await Task.FromResult(new JsonResult(new { isValid = false, msg = "No Se actualizo PITT" }));
                    }

                }

            }
            catch (Exception ex)
            {

                _commonMethods.SaveError($"OnGetCreateOrEdit Error al actualizar ProyectoITT.", ex.Message);
                return await Task.FromResult(new JsonResult(new { isValid = false, msg = ex.InnerException.Message }));
            }
        }
        public async Task<JsonResult> OnInsumos(int id = 0)
        {
            try
            {
                var entidadViewModel = new ProyectoITTViewModel();
                //{
                //    //FechaInicio = DateTime.Now,
                //    //FechaFin = DateTime.Now,
                //    //FechaDisenio = DateTime.Now,
                //    //FechaRedisenio = DateTime.Now,
                //    //FechaTransicion = DateTime.Now,
                //};
                //if (id == 0)
                //{
                //    await SetDropDownList(entidadViewModel);
                //    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                //}
                //else
                //{
                //    var response = await _mediator.Send(new GetProyectoITTByIdQuery() { Id = id });
                //    if (response.Succeeded)
                //    {
                //        entidadViewModel = _mapper.Map<ProyectoITTViewModel>(response.Data);
                //        await SetDropDownList(entidadViewModel);
                //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                //    }
                //    return new JsonResult(new
                //    {
                //        isValid = false
                //    });
                //}
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_Insumos", entidadViewModel) });
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnInsumos Error al consultar ProyectoITT.", ex.Message);
            }
        }


        [HttpPost]
        public async Task<JsonResult> OnInsumos(ProyectoITTViewModel viewmodel)
        {
            var entidadViewModel = new ProyectoITTViewModel();
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_Insumos", entidadViewModel) });
        }

        private async Task SetDropDownList(ProyectoITTViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;

            /*todo: ver el estado activo*/
            var response = await _mediator.Send(new GetAllFaseProgramaAreaQuery() { Include = true });
            var listadistinct = ((List<FaseProgramaAreaResponse>)(response.Data))
                .Select(x => new
                {
                    idfa = x.Id,
                    idpt = x.ProyectoTecnico.Id,
                    nombreproyecto = x.ProyectoTecnico.NombreProyecto,
                    idpa = x.ProyectoTecnico.ProgramaArea.Id,
                    nombreprograma = x.ProyectoTecnico.ProgramaArea.Descripcion,
                    idfase = x.IdFaseProyecto,
                    fase = x.FaseProyecto.Nombre
                }).ToList();

            var distinpa = listadistinct.Select(x => new { x.idpa, x.nombreprograma }).Distinct().ToList();


            List<SelectListItem> items = new SelectList(distinpa, "idpa", "nombreprograma").ToList();

            items.Insert(0, (new SelectListItem
            {
                Text = "Selecionar",
                Value = "0",
                Selected = true
            }));
            entidadViewModel.ProgramaAreaList = new SelectList(items, "Value", "Text");


            SelectListItem selListItem = new SelectListItem() { Value = "0", Text = "Seleccionar" };
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(selListItem);

            if (isNew == false)
            {
                var distinpt = listadistinct.Select(x => new { x.idpt, nombrepry = x.nombreproyecto + "--" + x.fase + "--" + x.idfa }).Distinct().ToList();

                List<SelectListItem> itemspt = new SelectList(distinpt, "idpt", "nombrepry").ToList();
                newList.AddRange(itemspt);
            }

            entidadViewModel.ProyectoTecnicoList = new SelectList(newList, "Value", "Text");

        }
    }



}
