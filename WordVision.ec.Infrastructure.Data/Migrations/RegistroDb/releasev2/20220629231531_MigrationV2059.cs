using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2059 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "survey");

            migrationBuilder.CreateTable(
                name: "EEvaluaciones",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eva_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eva_Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eva_Hasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EEvaluaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaKobos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    enk_Id_string = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enk_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enk_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enk_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enk_Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaKobos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EObjetivos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    obj_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EObjetivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EProgramas",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pa_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EProgramas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ERegiones",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reg_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERegiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ETabulados",
                schema: "survey",
                columns: table => new
                {
                    CodigoIndicador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indicador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoIndicador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTotal = table.Column<int>(type: "int", nullable: false),
                    EntrevistadosTotal = table.Column<int>(type: "int", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodigoRegion = table.Column<int>(type: "int", nullable: false),
                    CodigoProvincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoCanton = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EncuestadoKobos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    eko_xform_id_string = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_formhub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eko_end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eko_today = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eko_deviceid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_imei = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_secuencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eko_pa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_canton = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_parroquia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_comunidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_desastre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eko_nombre_encuestador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eko_ref_vivienda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eko_nombre_nino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_patrocinio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncuestaKoboId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestadoKobos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestadoKobos_EncuestaKobos_EncuestaKoboId",
                        column: x => x.EncuestaKoboId,
                        principalSchema: "survey",
                        principalTable: "EncuestaKobos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreguntaKobos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prk_CodigoWVE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prk_CodigoKobo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prk_Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prk_Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncuestaKoboId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntaKobos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreguntaKobos_EncuestaKobos_EncuestaKoboId",
                        column: x => x.EncuestaKoboId,
                        principalSchema: "survey",
                        principalTable: "EncuestaKobos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EIndicadores",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ind_LogFrame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_Resultado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ind_Definicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ind_Fuente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_Seccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_Preguntas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_Medicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    int_PlanTabulados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_UnidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ind_Frecuencia = table.Column<int>(type: "int", nullable: false),
                    ind_tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_proyecto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EObjetivoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EIndicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EIndicadores_EObjetivos_EObjetivoId",
                        column: x => x.EObjetivoId,
                        principalSchema: "survey",
                        principalTable: "EObjetivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EProvincias",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pro_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eRegionId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EProvincias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EProvincias_ERegiones_eRegionId",
                        column: x => x.eRegionId,
                        principalSchema: "survey",
                        principalTable: "ERegiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EncuestadoPreguntaKobos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncuestadoKoboId = table.Column<int>(type: "int", nullable: true),
                    PreguntaKoboId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestadoPreguntaKobos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestadoPreguntaKobos_EncuestadoKobos_EncuestadoKoboId",
                        column: x => x.EncuestadoKoboId,
                        principalSchema: "survey",
                        principalTable: "EncuestadoKobos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EncuestadoPreguntaKobos_PreguntaKobos_PreguntaKoboId",
                        column: x => x.PreguntaKoboId,
                        principalSchema: "survey",
                        principalTable: "PreguntaKobos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EIndicadorUsuarios",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    EIndicadorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EIndicadorUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EIndicadorUsuarios_EIndicadores_EIndicadorId",
                        column: x => x.EIndicadorId,
                        principalSchema: "survey",
                        principalTable: "EIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMetas",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    met_valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EEvaluacionId = table.Column<int>(type: "int", nullable: false),
                    EIndicadorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EProgramaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMetas_EEvaluaciones_EEvaluacionId",
                        column: x => x.EEvaluacionId,
                        principalSchema: "survey",
                        principalTable: "EEvaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMetas_EIndicadores_EIndicadorId",
                        column: x => x.EIndicadorId,
                        principalSchema: "survey",
                        principalTable: "EIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMetas_EProgramas_EProgramaId",
                        column: x => x.EProgramaId,
                        principalSchema: "survey",
                        principalTable: "EProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EProgramaIndicadores",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EProgramaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EIndicadorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EProgramaIndicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EProgramaIndicadores_EIndicadores_EIndicadorId",
                        column: x => x.EIndicadorId,
                        principalSchema: "survey",
                        principalTable: "EIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EProgramaIndicadores_EProgramas_EProgramaId",
                        column: x => x.EProgramaId,
                        principalSchema: "survey",
                        principalTable: "EProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ECantones",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    can_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EProvinciaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECantones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ECantones_EProvincias_EProvinciaId",
                        column: x => x.EProvinciaId,
                        principalSchema: "survey",
                        principalTable: "EProvincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EParroquias",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    par_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EProgramaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ECantonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EParroquias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EParroquias_ECantones_ECantonId",
                        column: x => x.ECantonId,
                        principalSchema: "survey",
                        principalTable: "ECantones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EParroquias_EProgramas_EProgramaId",
                        column: x => x.EProgramaId,
                        principalSchema: "survey",
                        principalTable: "EProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EReporteTabulados",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rta_nombre_indicador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rta_tipo_indicador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rta_proyecto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rta_nombre_pa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rta_numerador = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rta_denominador = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rta_porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rta_resultado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EEvaluacionId = table.Column<int>(type: "int", nullable: false),
                    EProgramaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EIndicadorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ERegionId = table.Column<int>(type: "int", nullable: false),
                    EProvinciaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ECantonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EReporteTabulados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_ECantones_ECantonId",
                        column: x => x.ECantonId,
                        principalSchema: "survey",
                        principalTable: "ECantones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_EEvaluaciones_EEvaluacionId",
                        column: x => x.EEvaluacionId,
                        principalSchema: "survey",
                        principalTable: "EEvaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_EIndicadores_EIndicadorId",
                        column: x => x.EIndicadorId,
                        principalSchema: "survey",
                        principalTable: "EIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_EProgramas_EProgramaId",
                        column: x => x.EProgramaId,
                        principalSchema: "survey",
                        principalTable: "EProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_EProvincias_EProvinciaId",
                        column: x => x.EProvinciaId,
                        principalSchema: "survey",
                        principalTable: "EProvincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_ERegiones_ERegionId",
                        column: x => x.ERegionId,
                        principalSchema: "survey",
                        principalTable: "ERegiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EComunidades",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    com_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eParroquiaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EComunidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EComunidades_EParroquias_eParroquiaId",
                        column: x => x.eParroquiaId,
                        principalSchema: "survey",
                        principalTable: "EParroquias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ECantones_EProvinciaId",
                schema: "survey",
                table: "ECantones",
                column: "EProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_EComunidades_eParroquiaId",
                schema: "survey",
                table: "EComunidades",
                column: "eParroquiaId");

            migrationBuilder.CreateIndex(
                name: "IX_EIndicadores_EObjetivoId",
                schema: "survey",
                table: "EIndicadores",
                column: "EObjetivoId");

            migrationBuilder.CreateIndex(
                name: "IX_EIndicadorUsuarios_EIndicadorId",
                schema: "survey",
                table: "EIndicadorUsuarios",
                column: "EIndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EMetas_EEvaluacionId",
                schema: "survey",
                table: "EMetas",
                column: "EEvaluacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EMetas_EIndicadorId",
                schema: "survey",
                table: "EMetas",
                column: "EIndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EMetas_EProgramaId",
                schema: "survey",
                table: "EMetas",
                column: "EProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestadoKobos_EncuestaKoboId",
                schema: "survey",
                table: "EncuestadoKobos",
                column: "EncuestaKoboId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestadoPreguntaKobos_EncuestadoKoboId",
                schema: "survey",
                table: "EncuestadoPreguntaKobos",
                column: "EncuestadoKoboId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestadoPreguntaKobos_PreguntaKoboId",
                schema: "survey",
                table: "EncuestadoPreguntaKobos",
                column: "PreguntaKoboId");

            migrationBuilder.CreateIndex(
                name: "IX_EParroquias_ECantonId",
                schema: "survey",
                table: "EParroquias",
                column: "ECantonId");

            migrationBuilder.CreateIndex(
                name: "IX_EParroquias_EProgramaId",
                schema: "survey",
                table: "EParroquias",
                column: "EProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_EProgramaIndicadores_EIndicadorId",
                schema: "survey",
                table: "EProgramaIndicadores",
                column: "EIndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EProgramaIndicadores_EProgramaId",
                schema: "survey",
                table: "EProgramaIndicadores",
                column: "EProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_EProvincias_eRegionId",
                schema: "survey",
                table: "EProvincias",
                column: "eRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_ECantonId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "ECantonId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_EEvaluacionId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EEvaluacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_EIndicadorId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EIndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_EProgramaId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_EProvinciaId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_ERegionId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "ERegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaKobos_EncuestaKoboId",
                schema: "survey",
                table: "PreguntaKobos",
                column: "EncuestaKoboId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EComunidades",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EIndicadorUsuarios",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EMetas",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EncuestadoPreguntaKobos",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EProgramaIndicadores",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EReporteTabulados",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "ETabulados",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EParroquias",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EncuestadoKobos",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "PreguntaKobos",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EEvaluaciones",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EIndicadores",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "ECantones",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EProgramas",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EncuestaKobos",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EObjetivos",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EProvincias",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "ERegiones",
                schema: "survey");
        }
    }
}
