using AspNetCoreHero.EntityFrameworkCore.AuditTrail;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Contexts;
using WordVision.ec.Application.Interfaces.Shared;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Donacion;
using WordVision.ec.Domain.Entities.Indicadores;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Domain.Entities.Presupuesto;
using WordVision.ec.Domain.Entities.Registro;
using WordVision.ec.Domain.Entities.Soporte;
using WordVision.ec.Domain.Entities.Valoracion;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Infrastructure.Data.Contexts
{
    public class RegistroDbContext : AuditableContext, IRegistroDbContext //AuditableContext
    {

        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;
        public RegistroDbContext(DbContextOptions<RegistroDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser)
            : base(options)
        {
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }



        public IDbConnection Connection => Database.GetDbConnection();
        public bool HasChanges => ChangeTracker.HasChanges();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.Username;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.Username;
                        break;
                }
            }
            if (_authenticatedUser.Username == null)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            else
            {
                //return await base.SaveChangesAsync("jlmoreno");//
                return await base.SaveChangesAsync(_authenticatedUser.Username);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*PARA QUE NO SE ELIMINEN EN CASCADA UN OBJETO*/
            //var cascadeFKs = builder.Model
            //    .G­etEntityTypes()
            //    .SelectMany(t => t.GetForeignKeys())
            //    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            //foreach (var fk in cascadeFKs)
            //{
            //    fk.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            builder.Entity<DatosLDR>()
            .ToTable("DatosLDRs", "pres");
            builder.Entity<DatosT5>()
           .ToTable("DatosT5s", "pres");
            builder.Entity<Presupuesto>()
           .ToTable("Presupuestos", "pres");

            builder.Entity<Catalogo>()
           .ToTable("Catalogos", "adm");
            builder.Entity<DetalleCatalogo>()
           .ToTable("DetalleCatalogos", "adm");
            builder.Entity<Pais>()
           .ToTable("Paises", "adm");
            builder.Entity<Provincia>()
          .ToTable("Provincias", "adm");
            builder.Entity<Ciudad>()
        .ToTable("Ciudades", "adm");
            builder.Entity<Estructura>()
        .ToTable("Estructuras", "adm");
            builder.Entity<Empresa>()
        .ToTable("Empresas", "adm");

            builder.Entity<RCNinoPatrocinado>()
            .ToTable("RCNinoPatrocinados", "adm");
            builder.Entity<ProyectoTecnico>()
            .ToTable("ProyectoTecnicos", "adm");
            builder.Entity<ProgramaArea>()
            .ToTable("ProgramaAreas", "adm");
            builder.Entity<EtapaModeloProyecto>()
            .ToTable("EtapaModeloProyectos", "adm");
            builder.Entity<ModeloProyecto>()
            .ToTable("ModeloProyectos", "adm");
            builder.Entity<LogFrame>()
            .ToTable("LogFrames", "adm");
            builder.Entity<ActorParticipante>()
            .ToTable("ActorParticipantes", "adm");
            builder.Entity<IndicadorPR>()
            .ToTable("IndicadoresPR", "adm");
            builder.Entity<OtroIndicador>()
            .ToTable("OtrosIndicadores", "adm");
            builder.Entity<PresupuestoProyecto>()
            .ToTable("PresupuestoProyectos", "adm");
            builder.Entity<LogFrameIndicadorPR>()
            .ToTable("LogFrameIndicadoresPR", "adm");
            builder.Entity<CodigoSCI>()
            .ToTable("CodigoSCIs", "adm");
            builder.Entity<BancosCompania>()
            .ToTable("BancosCompanias", "adm");

            builder.Entity<FaseProgramaArea>()
            .ToTable("FaseProgramaAreas", "indicador");
            builder.Entity<VinculacionIndicador>()
            .ToTable("VinculacionIndicadores", "indicador");
            builder.Entity<DetalleVinculacionIndicador>()
            .ToTable("DetalleVinculacionIndicador", "indicador");
            builder.Entity<EstadoPorAnioFiscal>()
            .ToTable("EstadoPorAnioFiscales", "indicador");
			builder.Entity<ProyectoTecnicoPorProgramaArea>()
            .ToTable("ProyectoTecnicoPorProgramaAreas", "indicador");					

            builder.Entity<EstrategiaNacional>()
          .ToTable("EstrategiaNacionales", "planifica");
            builder.Entity<Gestion>()
           .ToTable("Gestiones", "planifica");
            builder.Entity<ObjetivoEstrategico>()
           .ToTable("ObjetivoEstrategicos", "planifica");
            builder.Entity<FactorCriticoExito>()
          .ToTable("FactorCriticoExitos", "planifica");
            builder.Entity<IndicadorEstrategico>()
          .ToTable("IndicadorEstrategicos", "planifica");
            builder.Entity<IndicadorAF>()
         .ToTable("IndicadorAFs", "planifica");
            builder.Entity<Producto>()
           .ToTable("Productos", "planifica");
            builder.Entity<IndicadorPOA>()
          .ToTable("IndicadorPOAs", "planifica");
            builder.Entity<Actividad>()
      .ToTable("Actividades", "planifica");
            builder.Entity<MetaEstrategica>()
     .ToTable("MetaEstrategicas", "planifica");
            builder.Entity<MetaTactica>()
     .ToTable("MetaTacticas", "planifica");
            builder.Entity<Recurso>()
    .ToTable("Recursos", "planifica");
            builder.Entity<FechaCantidadRecurso>()
    .ToTable("FechaCantidadRecursos", "planifica");
            builder.Entity<TechoPresupuestario>()
    .ToTable("TechoPresupuestarios", "planifica");
            builder.Entity<Seguimiento>()
   .ToTable("Seguimientos", "planifica");
            builder.Entity<ProductoObjetivo>()
 .ToTable("ProductoObjetivos", "planifica");
            builder.Entity<IndicadorProductoObjetivo>()
 .ToTable("IndicadorProductoObjetivos", "planifica");
            builder.Entity<IndicadorCicloEstrategico>()
.ToTable("IndicadorCicloEstrategico", "planifica");
            builder.Entity<TiposIndicador>()
.ToTable("TiposIndicadores", "planifica");

            builder.Entity<IndicadorVinculadoCE>()
.ToTable("IndicadorVinculadoCEs", "planifica");
            builder.Entity<IndicadorVinculadoE>()
.ToTable("IndicadorVinculadoEs", "planifica");
            builder.Entity<IndicadorVinculadoPO>()
.ToTable("IndicadorVinculadoPOs", "planifica");
            builder.Entity<IndicadorVinculadoPOA>()
.ToTable("IndicadorVinculadoPOAs", "planifica");
            //            builder.Entity<MetaCicloEstrategico>()
            //.ToTable("MetaCicloEstrategico", "planifica");
            builder
       .Entity<Tercero>()
       .HasMany(e => e.FormularioTerceros).WithOne(e => e.Terceros)
       .OnDelete(DeleteBehavior.ClientCascade);
            //Aqui se colocan las nuevas tablas
            builder.Entity<Solicitud>()
                 .ToTable("Solicitudes", "soporte");//la palabra "soporte" se refiere al esquema de la base
            builder.Entity<EstadosSolicitud>()
                 .ToTable("EstadosSolicitudes", "soporte");
            builder.Entity<Email>()
                .ToTable("Emails", "soporte");
            builder.Entity<Personal>()
                .ToTable("Personales", "soporte");
            builder.Entity<Ponente>()
               .ToTable("Ponentes", "soporte");
            builder.Entity<Mensajeria>()
                .ToTable("Mensajerias", "soporte");
            builder.Entity<Comunicacion>()
                .ToTable("Comunicaciones", "soporte");
            builder.Entity<LogoSocio>()
               .ToTable("LogoSocios", "soporte");
            builder.Entity<Ponente>()
               .ToTable("Ponentes", "soporte");

            builder.Entity<Objetivo>()
              .ToTable("Objetivos", "valoracion");
            builder.Entity<ObjetivoAnioFiscal>()
             .ToTable("ObjetivoAnioFiscales", "valoracion");
            builder.Entity<Resultado>()
             .ToTable("Resultados", "valoracion");
            builder.Entity<PlanificacionResultado>()
             .ToTable("PlanificacionResultados", "valoracion");

            builder.Entity<PlanificacionHito>()
            .ToTable("PlanificacionHitos", "valoracion");
            builder.Entity<Competencia>()
           .ToTable("Competencias", "valoracion");
            builder.Entity<Responsabilidad>()
           .ToTable("Responsabilidades", "valoracion");
            builder.Entity<AvanceObjetivo>()
           .ToTable("AvanceObjetivos", "valoracion");
            builder.Entity<SeguimientoObjetivo>()
           .ToTable("SeguimientoObjetivos", "valoracion");
            builder.Entity<PlanificacionComportamiento>()
          .ToTable("PlanificacionComportamientos", "valoracion");
            builder.Entity<Escala>()
         .ToTable("Escalas", "valoracion");

            builder.Entity<Donante>()
               .ToTable("Donantes", "donacion");
            builder.Entity<Debito>()
               .ToTable("Debitos", "donacion");
            builder.Entity<ProductoDonante>()
               .ToTable("ProductoDonantes", "donacion");
            builder.Entity<Interacion>()
               .ToTable("Interaciones", "donacion");


            builder.Entity<ETabulado>().HasNoKey();
            builder.Entity<EReporteConsolidado>().ToTable(nameof(EReporteConsolidado), t => t.ExcludeFromMigrations()).HasNoKey();
            builder.Entity<EReporteDAP>().ToTable(nameof(EReporteDAP), t => t.ExcludeFromMigrations()).HasNoKey();

            //builder.Entity<PreguntaKobo>()
            //            .HasIndex(p => p.prk_CodigoKobo);

            //builder.Entity<EncuestadoPreguntaKobo>()
            //            .HasIndex(p => p.Valor);



            //builder.Entity<Colaborador>().HasMany(m => m.Formularios)
            //     .WithOne(c => c.Colaboradores)
            //     .HasForeignKey(k => k.IdColaborador);

            //      builder.Entity<Actividad>()
            //   .HasOne(p => p.IndicadorPOAs)
            //   .WithMany(b => b.Actividades)
            //   .IsRequired(false);

            //      builder.Entity<IndicadorPOA>()
            //  .HasOne(p => p.Productos)
            //  .WithMany(b => b.IndicadorPOAs)
            //  .IsRequired(false);

            //      builder.Entity<Producto>()
            // .HasOne(p => p.IndicadorEstrategicos)
            // .WithMany(b => b.Productos)
            // .IsRequired(false);

            //      builder.Entity<IndicadorEstrategico>()
            //.HasOne(p => p.FactorCriticoExitos)
            //.WithMany(b => b.IndicadorEstrategicos)
            //.IsRequired(false);


            /*carlos cm 29062022*/
            builder.Entity<ProyectoITT>()
          .ToTable("ProyectoITTs", "planifica");
            builder.Entity<DetalleProyectoITT>()
         .ToTable("DetalleProyectoITTs", "planifica");

            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(builder);
        }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Firma> Firmas { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }

        public DbSet<DatosLDR> DatosLDRs { get; set; }
        public DbSet<DatosT5> DatosT5s { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }

        public DbSet<EncuestaKobo> EncuestaKobos { get; set; }
        public DbSet<PreguntaKobo> PreguntaKobos { get; set; }
        public DbSet<EncuestadoKobo> EncuestadoKobos { get; set; }
        public DbSet<EncuestadoPreguntaKobo> EncuestadoPreguntaKobos { get; set; }

        public DbSet<ERegion> ERegiones { get; set; }
        public DbSet<EProvincia> EProvincias { get; set; }
        public DbSet<ECanton> ECantones { get; set; }
        public DbSet<EParroquia> EParroquias { get; set; }
        public DbSet<EPrograma> EProgramas { get; set; }
        public DbSet<EComunidad> EComunidades { get; set; }

        public DbSet<EEvaluacion> EEvaluaciones { get; set; }
        public DbSet<EIndicador> EIndicadores { get; set; }
        public DbSet<EProgramaIndicador> EProgramaIndicadores { get; set; }
        public DbSet<EReporteTabulado> EReporteTabulados { get; set; }
        public DbSet<EReporteConsolidado> EReporteConsolidados { get; set; }
        public DbSet<EReporteDAP> EReporteDAPs { get; set; }

        public DbSet<EObjetivo> EObjetivos { get; set; }
        public DbSet<EMeta> EMetas { get; set; }
        public DbSet<EIndicadorUsuario> EIndicadorUsuarios { get; set; }
        public DbSet<EProyecto> EProyectos { get; set; }


    }
}
