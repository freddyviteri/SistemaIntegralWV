using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WordVision.ec.Application.Interfaces.CacheRepositories;

using WordVision.ec.Application.Interfaces.CacheRepositories.Maestro;
using WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion;
using WordVision.ec.Application.Interfaces.CacheRepositories.Valoracion;
using WordVision.ec.Application.Interfaces.Contexts;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Log;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Infrastructure.Data.CacheRepositories;

using WordVision.ec.Infrastructure.Data.CacheRepositories.Maestro;
using WordVision.ec.Infrastructure.Data.CacheRepositories.Planificacion;
using WordVision.ec.Infrastructure.Data.CacheRepositories.Valoracion;
using WordVision.ec.Infrastructure.Data.Contexts;
using WordVision.ec.Infrastructure.Data.Repositories.Donacion;
using WordVision.ec.Infrastructure.Data.Repositories.Indicadores;
using WordVision.ec.Infrastructure.Data.Repositories.Log;
using WordVision.ec.Infrastructure.Data.Repositories.Maestro;
using WordVision.ec.Infrastructure.Data.Repositories.Mensajeria;
using WordVision.ec.Infrastructure.Data.Repositories.Planificacion;
using WordVision.ec.Infrastructure.Data.Repositories.Presupuesto;
using WordVision.ec.Infrastructure.Data.Repositories.Registro;
using WordVision.ec.Infrastructure.Data.Repositories.Soporte;
using WordVision.ec.Infrastructure.Data.Repositories.Valoracion;

using WordVision.ec.Infrastructure.Data.Repositories.Encuesta;


namespace WordVision.ec.Infrastructure.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IRegistroDbContext, RegistroDbContext>();
            //services.AddScoped<IIdentityDbContext, IdentityContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories
            //services.AddTransient(typeof(WordVision.ec.Application.Interfaces.Repositories.Identity.IRepositoryAdAsync<>), typeof(Repositories.Identity.RepositoryAdAsync<>));

            services.AddTransient(typeof(WordVision.ec.Application.Interfaces.Repositories.Identity.IRepositoryAsync<>), typeof(Repositories.Identity.RepositoryAsync<>));
            services.AddTransient<IColaboradorRepository, ColaboradorRepository>();
            services.AddTransient<IColaboradorCacheRepository, ColaboradorCacheRepository>();
            services.AddTransient<IDocumentoRepository, DocumentoRepository>();
            services.AddTransient<IDocumentoCacheRepository, DocumentoCacheRepository>();
            services.AddTransient<IPreguntaRepository, PreguntaRepository>();
            services.AddTransient<IPreguntaCacheRepository, PreguntaCacheRepository>();
            services.AddTransient<IFormularioRepository, FormularioRepository>();
            services.AddTransient<IFormularioCacheRepository, FormularioCacheRepository>();

            //services.AddTransient<IIdentityCacheRepository, IdentityCacheRepository>();
            services.AddTransient<Application.Interfaces.Repositories.Identity.IUnitOfWork, Repositories.Identity.UnitOfWork>();

            services.AddTransient(typeof(WordVision.ec.Application.Interfaces.Repositories.Registro.IRepositoryAsync<>), typeof(Repositories.Registro.RepositoryAsync<>));
            //services.AddTransient<IBrandRepository, BrandRepository>();
            //services.AddTransient<IBrandCacheRepository, BrandCacheRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<Application.Interfaces.Repositories.Registro.IUnitOfWork, Repositories.Registro.UnitOfWork>();
            services.AddTransient<IRespuestaRepository, RespuestaRepository>();
            services.AddTransient<IFirmaRepository, FirmaRepository>();
            services.AddTransient<IDatosT5Repository, DatosT5Repository>();
            services.AddTransient<IDatosLDRRepository, DatosLDRRepository>();
            services.AddTransient<IPresupuestoRepository, PresupuestoRepository>();
            services.AddTransient<ITerceroRepository, TerceroRepository>();
            services.AddTransient<IFormularioTerceroRepository, FormularioTerceroRepository>();
            services.AddTransient<IEstructuraRepository, EstructuraRepository>();
            services.AddTransient<IEstructuraCacheRepository, EstructuraCacheRepository>();
            services.AddTransient<IIdiomaRepository, IdiomaRepository>();
            services.AddTransient<ICatalogoRepository, CatalogoRepository>();
            services.AddTransient<IPaisRepository, PaisRepository>();

            services.AddTransient<ICatalogoCacheRepository, CatalogoCacheRepository>();
            services.AddScoped<IRCNinoPatrocinadoRepository, RCNinoPatrocinadoRepository>();
            services.AddScoped<IProgramaAreaRepository, ProgramaAreaRepository>();
            services.AddScoped<IProyectoTecnicoRepository, ProyectoTecnicoRepository>();
            services.AddScoped<IModeloProyectoRepository, ModeloProyectoRepository>();
            services.AddScoped<ILogFrameRepository, LogFrameRepository>();
            services.AddScoped<IEtapaModeloProyectoRepository, EtapaModeloProyectoRepository>();
            //services.AddScoped<IProyectoTecnicoRepository, ProyectoTecnicoRepository>();
            services.AddScoped<IActorParticipanteRepository, ActorParticipanteRepository>();
            services.AddScoped<IIndicadorPRRepository, IndicadorPRRepository>();
            services.AddScoped<IOtroIndicadorRepository, OtroIndicadorRepository>();
            services.AddScoped<IPresupuestoProyectoRepository, PresupuestoProyectoRepository>();
            services.AddScoped<IVinculacionIndicadorRepository, VinculacionIndicadorRepository>();
            services.AddScoped<IFaseProgramaAreaRepository, FaseProgramaAreaRepository>();
            services.AddScoped<IProyectoITTDIPRepository, ProyectoITTDIPRepository>();
            services.AddScoped<IProyectoITTRepository, ProyectoITTRepository>();
            services.AddScoped<IDipInsumoRepository, DipInsumoRepository>();
            services.AddScoped<IEstadoPorAnioFiscalRepository, EstadoPorAnioFiscalRepository>();
			services.AddScoped<IProyectoTecnicoPorProgramaAreaRepository, ProyectoTecnicoPorProgramaAreaRepository>();																										  
            services.AddScoped<ILogFrameIndicadorPRRepository, LogFrameIndicadorPRRepository>();


            services.AddTransient<IObjetivoEstrategicoCacheRepository, ObjetivoEstrategicoCacheRepository>();
            services.AddTransient<IEstrategiaNacionalCacheRepository, EstrategiaNacionalCacheRepository>();
            services.AddTransient<IFactorCriticoExitoCacheRepository, FactorCriticoExitoCacheRepository>();
            services.AddTransient<IIndicadorEstrategicoCacheRepository, IndicadorEstrategicoCacheRepository>();
            services.AddTransient<IIndicadorAFCacheRepository, IndicadorAFCacheRepository>();
            services.AddTransient<IGestionCacheRepository, GestionCacheRepository>();
            services.AddTransient<IObjetivoEstrategicoRepository, ObjetivoEstrategicoRepository>();
            services.AddTransient<IEstrategiaNacionalRepository, EstrategiaNacionalRepository>();
            services.AddTransient<IFactorCriticoExitoRepository, FactorCriticoExitoRepository>();
            services.AddTransient<IIndicadorEstrategicoRepository, IndicadorEstrategicoRepository>();
            services.AddTransient<IIndicadorAFRepository, IndicadorAFRepository>();
            services.AddTransient<IGestionRepository, GestionRepository>();
            services.AddTransient<IMetaEstrategicaRepository, MetaEstrategicaRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IIndicadorPOARepository, IndicadorPOARepository>();
            services.AddTransient<IMetaTacticaRepository, MetaTacticaRepository>();
            services.AddTransient<IActividadRepository, ActividadRepository>();
            services.AddTransient<IRecursoRepository, RecursoRepository>();
            services.AddTransient<IFechaCantidadRecursoRepository, FechaCantidadRecursoRepository>();
            services.AddTransient<ITechoPresupuestarioRepository, TechoPresupuestarioRepository>();
            services.AddTransient<ISeguimientoRepository, SeguimientoRepository>();
            services.AddTransient<IProductoObjetivoRepository, ProductoObjetivoRepository>();
            services.AddTransient<IIndicadorProductoObjetivoRepository, IndicadorProductoObjetivoRepository>();
            services.AddTransient<IIndicadorCicloEstrategicoRepository, IndicadorCicloEstrategicoRepository>();
            services.AddTransient<ITiposIndicadorRepository, TiposIndicadorRepository>();
            services.AddTransient<IIndicadorVinculadoCERepository, IndicadorVinculadoCERepository>();
            services.AddTransient<IIndicadorVinculadoERepository, IndicadorVinculadoERepository>();

            services.AddTransient<ISolicitudRepository, SolicitudRepository>();
            services.AddTransient<IMensajeriaRepository, MensajeriaRepository>();
            services.AddTransient<IComunicacionRepository, ComunicacionRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IEstadosSolicitudRepository, EstadosSolicitudRepository>();
            services.AddTransient<IPersonalRepository, PersonalRepository>();
            services.AddTransient<IPonenteRepository, PonenteRepository>();
            services.AddTransient<IDonanteRepository, DonanteRepository>();
            services.AddTransient<IDebitoRepository, DebitoRepository>();
            services.AddTransient<IInteracionRepository, InteracionRepository>();

            services.AddTransient<IObjetivoRepository, ObjetivoRepository>();
            services.AddTransient<IResultadoRepository, ResultadoRepository>();
            services.AddTransient<IResultadoCacheRepository, ResultadoCacheRepository>();
            services.AddTransient<IPlanificacionResultadoRepository, PlanificacionResultadoRepository>();
            services.AddTransient<IResponsabilidadRepository, ResponsabilidadRepository>();
            services.AddTransient<IPlanificacionHitoRepository, PlanificacionHitoRepository>();
            services.AddTransient<ICompetenciaRepository, CompetenciaRepository>();
            services.AddTransient<IAvanceObjetivoRepository, AvanceObjetivoRepository>();
            services.AddTransient<ISeguimientoObjetivoRepository, SeguimientoObjetivoRepository>();
            services.AddTransient<IPlanificacionComportamientoRepository, PlanificacionComportamientoRepository>();
            services.AddTransient<IEscalaRepository, EscalaRepository>();

            services.AddTransient<IEncuestaKoboRepository, EncuestaKoboRepository>();
            services.AddTransient<IPreguntaKoboRepository, PreguntaKoboRepository>();
            services.AddTransient<IEncuestadoKoboRepository, EncuestadoKoboRepository>();
            services.AddTransient<IEncuestadoPreguntaKoboRepository, EncuestadoPreguntaKoboRepository>();

            services.AddTransient<IERegionRepository, ERegionRepository>();
            services.AddTransient<IEProvinciaRepository, EProvinciaRepository>();
            services.AddTransient<IECantonRepository, ECantonRepository>();
            services.AddTransient<IEParroquiaRepository, EParroquiaRepository>();
            services.AddTransient<IEComunidadRepository, EComunidadRepository>();

            services.AddTransient<IEEvaluacionRepository, EEvaluacionRepository>();
            services.AddTransient<IEProgramaRepository, EProgramaRepository>();
            services.AddTransient<IEObjetivoRepository, EObjetivoRepository>();
            services.AddTransient<IEIndicadorRepository, EIndicadorRepository>();
            services.AddTransient<IEMetaRepository, EMetaRepository>();
            services.AddTransient<IEIndicadorUsuarioRepository, EIndicadorUsuarioRepository>();
            services.AddTransient<IETabuladoRepository, ETabuladoRepository>();
            services.AddTransient<IEReporteTabuladoRepository, EReporteTabuladoRepository>();
            services.AddTransient<IEReporteConsolidadoRepository, EReporteConsolidadoRepository>();
            services.AddTransient<IEReporteDAPRepository, EReporteDAPRepository>();
            services.AddTransient<IEProyectoRepository, EProyectoRepository>();
            services.AddTransient<IEProgramaIndicadorRepository, EProgramaIndicadorRepository>();

            #endregion Repositories
        }
    }
}
