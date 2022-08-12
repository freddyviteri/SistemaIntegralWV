var arrtablageneral = [];
var RegistrosResultado;


var ListaGoul = [];
var ListaResultado = [];
var ListaProducto = [];
var ListaActividad = [];

var currenteindexmarcos = 0;
var idstepspitt;

$(document).ready(function () {



    RegistrosResultado = new Array();
    /*CreateorEdit*/
    var form = $("#create-form");
    
    form.children("div .tabsPITT").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        enableFinishButton: false,
        enablePagination: true,
        enableAllSteps: true,
        titleTemplate: "#title#",
        //cssClass: "tabcontrol",
        autoFocus: true,
        onStepChanging: function (event, currentIndex, newIndex) {
            if (currentIndex > newIndex) {
                $("#" + idstepspitt + "-p-" + currentIndex).hide();
                return true;
            }
            return true;
        },
        onStepChanged: function (event, currentIndex, priorIndex) {
            $($.fn.dataTable.tables(true)).DataTable().columns.adjust();
            if (currenteindexmarcos === 0 && currentIndex === 0) {
                var padreSuperior = $("#tblindres_wrapper").parent();
                $("#" + padreSuperior[0].id).show();
            }
            idstepspitt = event.currentTarget.id;
            $("#" + idstepspitt + "-p-" + currentIndex).show();
        }
    });

    var frminterno = $(".tabsInterno").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "none",
        enableFinishButton: false,
        enablePagination: false,
        enableAllSteps: true,
        titleTemplate: "#title#",
        cssClass: "tabcontrol",
        autoFocus: true,
        onStepChanging: function (event, currentIndex, newIndex) {
            //if (currentIndex > newIndex) {
            //    return true;
            //}
            return true;
        },
        onStepChanged: function (event, currentIndex, priorIndex) {
            $($.fn.dataTable.tables(true)).DataTable().columns.adjust();
            currenteindexmarcos = currentIndex;
        },
        onFinished: function (event, currentIndex)
                    {
                        alert("Submitted!");
                    }
    });


    /*Fin CreateorEdit*/
    if (parseInt($("#Id").val()) > 0) {
        BuscarDetallePII();
    }
});




function BuscarDetallePII() {
    //loader
    $('#idproyectgoulname').empty();
    $('#idsupervisorname').empty();
    $('#idresponsablename').empty();
    $('#loframecodeoutcome').empty();
    $("#tblindres").empty();
    $("#tblprod").empty();
    $("#tblactrel").empty();

    if ($.fn.DataTable.isDataTable('#tblindres')) {
        $('#tblindres').DataTable().destroy();
    }

    if ($.fn.DataTable.isDataTable('#tblprod')) {
        $('#tblprod').DataTable().destroy();
    }

    if ($.fn.DataTable.isDataTable('#tblactrel')) {
        $('#tblactrel').DataTable().destroy();
    }

    $('#create-form').preloader();
        
    $("#idtipopry").val("");
    var combopry = $("#NombreProyectoFase").val();
    const myArraypry = combopry.split("--");
    $("#idtipopry").val(myArraypry[1]);

    //if ($("#IdProyectoTecnico").val() === '0') {
    //    $('#create-form').preloader('remove')
    //    return;
    //}


    $.getJSON('../Planificacion/ProyectoITT/CargarProyectoITT?handler&idproyectoitt=' + $("#Id").val(),
        (data) => {
            if (data === null) {
                return;
            }
            if (data.isValid === false) {
                return;
            }


            ListaGoul = JSON.parse(data.prygoal);
            ListaGoul.forEach(function (dato, index) {
                $("#idproyectgoulname").append('<option value="'
                    + dato.Id + '">'
                    + dato.sumaryobjetives + '</option>');
            });

            var arrcombosup = JSON.parse(data.supervisor);
            arrcombosup.forEach(function (dato, index) {
                $("#idsupervisorname").append('<option value="'
                    + dato.id + '">'
                    + dato.fullname + '</option>');
            });

            var arrcombores = JSON.parse(data.responsable);
            arrcombores.forEach(function (dato, index) {
                $("#idresponsablename").append('<option value="'
                    + dato.id + '">'
                    + dato.fullname + '</option>');
            });

            var arrcombooutcome = JSON.parse(data.outcome);
            arrcombooutcome.forEach(function (dato, index) {
                $("#loframecodeoutcome").append('<option value="'
                    + dato.OutCome + '">'
                    + dato.OutCome + '--' + dato.SumaryObjetives + '</option>');
            });

            ListaResultado = JSON.parse(data.tbloutcome);
            ListaProducto = JSON.parse(data.tbloutput);
            ListaActividad = JSON.parse(data.tblactivity);

            Cargartablaspitt();
            $('#create-form').preloader('remove')

        }).done(function (data) {
            $('#create-form').preloader('remove')
            console.log("second success");
        })
        .fail(function (jqxhr, textStatus, error) {
            $('#create-form').preloader('remove')
            var err = textStatus + ", " + error;
        })
        .always(function () {
            $('#create-form').preloader('remove')
            console.log("complete");
        });


}


/* CREate or Edit */
function BuscarDatosAdicionalesPT() {
    //loader
    $('#idproyectgoulname').empty();
    $('#idsupervisorname').empty();
    $('#idresponsablename').empty();
    $('#loframecodeoutcome').empty();
    $("#tblindres").empty();
    $("#tblprod").empty();
    $("#tblactrel").empty();

    if ($.fn.DataTable.isDataTable('#tblindres')) {
        $('#tblindres').DataTable().destroy();
    }

    if ($.fn.DataTable.isDataTable('#tblprod')) {
        $('#tblprod').DataTable().destroy();
    }

    if ($.fn.DataTable.isDataTable('#tblactrel')) {
        $('#tblactrel').DataTable().destroy();
    }

    $('#create-form').preloader();
        
    $("#idtipopry").val("");
    var combopry = $("#IdProyectoTecnico option:selected").text();
    const myArraypry = combopry.split("--");
    $("#idtipopry").val(myArraypry[1]);

    if ($("#IdProyectoTecnico").val() === '0') {
        $('#create-form').preloader('remove')
        return;
    }


    $.getJSON('../Planificacion/ProyectoITT/CargarInfoPreyTecnico?handler&idproyecto=' + $("#IdProyectoTecnico").val(),
        (data) => {
            if (data === null) {
                return;
            }
            if (data.isValid === false) {
                return;
            }


            ListaGoul = JSON.parse(data.prygoal);
            ListaGoul.forEach(function (dato, index) {
                $("#idproyectgoulname").append('<option value="'
                    + dato.Id + '">'
                    + dato.sumaryobjetives + '</option>');
            });

            var arrcombosup = JSON.parse(data.supervisor);
            arrcombosup.forEach(function (dato, index) {
                $("#idsupervisorname").append('<option value="'
                    + dato.id + '">'
                    + dato.fullname + '</option>');
            });

            var arrcombores = JSON.parse(data.responsable);
            arrcombores.forEach(function (dato, index) {
                $("#idresponsablename").append('<option value="'
                    + dato.id + '">'
                    + dato.fullname + '</option>');
            });

            var arrcombooutcome = JSON.parse(data.outcome);
            arrcombooutcome.forEach(function (dato, index) {
                $("#loframecodeoutcome").append('<option value="'
                    + dato.OutCome + '">'
                    + dato.OutCome + '--' + dato.SumaryObjetives + '</option>');
            });

            ListaResultado = JSON.parse(data.tbloutcome);
            ListaProducto = JSON.parse(data.tbloutput);
            ListaActividad = JSON.parse(data.tblactivity);

            Cargartablaspitt();
            $('#create-form').preloader('remove')

        }).done(function (data) {
            $('#create-form').preloader('remove')
            console.log("second success");
        })
        .fail(function (jqxhr, textStatus, error) {
            $('#create-form').preloader('remove')
            var err = textStatus + ", " + error;
        })
        .always(function () {
            $('#create-form').preloader('remove')
            console.log("complete");
        });


}


function Cargartablaspitt() {

    var codifooutcome = $("#loframecodeoutcome").val();


    var ListaResultadohelp = [];
    var ListaProductohelp = [];
    var ListaActividadhelp = [];

    $.each(ListaResultado, function (i, value) {
        if (codifooutcome === value.OutCome) {
            ListaResultadohelp.push(value);
        }
    });

    $.each(ListaProducto, function (i, value) {
        if (codifooutcome === value.OutCome) {
            ListaProductohelp.push(value);
        }
    });

    $.each(ListaActividad, function (i, value) {
        if (codifooutcome === value.OutCome) {
            ListaActividadhelp.push(value);
        }
    });


    $('#tblindres').DataTable({
        responsive: true,
        info: true,
        /*bAutoWidth: true,*/
        data: ListaResultadohelp,
        columns: [
            // { data: 'IdMarcoLogicoAsignado', title: 'IdMarcoLogicoAsignado' },
            //{ data: 'IdMarcoLogico', title: 'IdMarcoLogico' },
            // { data: 'IdLogFrame', title: 'IdLogFrame' },
            { data: 'OutCome', title: 'OutCome' },
            { data: 'SumaryObjetives', title: 'SumaryObjetives', className: 'acortarcolumna' },
            //{ data: 'IdNivel', title: 'IdNivel' },
            { data: 'CodigoML', title: 'Codigo Indicador' },
            { data: 'NombreML', title: 'Indicador' },
            //{ data: 'Target', title: 'Target' },
            { data: 'Unidad', title: 'Unidad' },
            { data: 'Frecuencia', title: 'Frecuencia' },
            { data: 'Participante', title: 'Participante' },
            { data: 'Vindicadores', title: 'Vinculado', className: 'acortarcolumna' },
            /*{ data: 'ModeloProyecto', title: 'Modelo Proyecto' },*/
            {
                data: 'Valorlineabase', title: 'Linea Base',
                render: function (data, type, row, rowcol) {
                    return '<input id="idReslineabase_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '"  type="number" step="0.01" onchange="CargarvaloresResultado(this)" value="' + row.Valorlineabase + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF1',
                render: function (data, type, row, rowcol) {
                    return '<input id="idResmetaa_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01"  onchange="CargarvaloresResultado(this)" value="' + row.Valormetaa + '" min="0.00" max="9999999.99" />';

                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF2',
                render: function (data, type, row, rowcol) {
                    return '<input id="idResmetab_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01"  onchange="CargarvaloresResultado(this)" value="' + row.Valormetab + '" min="0.00" max="9999999.99" />';

                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF3',
                render: function (data, type, row, rowcol) {
                    return '<input id="idResmetac_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01"  onchange="CargarvaloresResultado(this)" value="' + row.Valormetac + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF4',
                render: function (data, type, row, rowcol) {
                    return '<input id="idResmetad_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01"  onchange="CargarvaloresResultado(this)" value="' + row.Valormetad + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF5',
                render: function (data, type, row, rowcol) {
                    return '<input id="idResmetae_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01"  onchange="CargarvaloresResultado(this)" value="' + row.Valormetae + '" min="0.00" max="9999999.99" />';
                },
            },
        ],
    });


    $('#tblprod').DataTable({
        responsive: true,
        info: true,
        data: ListaProductohelp,
        columns: [
            //{ data: 'IdMarcoLogicoAsignado', title: 'IdMarcoLogicoAsignado' },
            //{ data: 'IdMarcoLogico', title: 'IdMarcoLogico' },
            //{ data: 'IdLogFrame', title: 'IdLogFrame' },
            {
                data: 'OutPut', title: 'OutPut',
                render: function (data, type, row, rowcol) {
                    return row.OutCome + '-' + row.OutPut;
                },
            },
            //{ data: 'OutPut', title: 'OutPut' },
            { data: 'SumaryObjetives', title: 'SumaryObjetives', className: 'acortarcolumna' },
            //{ data: 'IdNivel', title: 'IdNivel' },
            //{ data: 'Cobertura', title: 'Cobertura' },
            { data: 'CodigoML', title: 'Codigo Indicador' },
            { data: 'NombreML', title: 'Indicador' },
            //{ data: 'Target', title: 'Target' },
            { data: 'Unidad', title: 'Unidad' },
            { data: 'Frecuencia', title: 'Frecuencia' },
            { data: 'Participante', title: 'Participante' },
            { data: 'Vindicadores', title: 'Vinculado', className: 'acortarcolumna' },
            /*{ data: 'ModeloProyecto', title: 'Modelo Proyecto' },*/
            {
                data: 'IdLogFrame', title: 'Linea Base',
                render: function (data, type, row, rowcol) {
                    return '<input id="idProdlineabase_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01"  onchange="CargarvaloresProducto(this)" value="' + row.Valorlineabase + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF1',
                render: function (data, type, row, rowcol) {
                    return '<input id="idProdmetaa_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01"  onchange="CargarvaloresProducto(this)" value="' + row.Valormetaa + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF2',
                render: function (data, type, row, rowcol) {
                    return '<input id="idProdmetab_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01"  onchange="CargarvaloresProducto(this)" value="' + row.Valormetab + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF3',
                render: function (data, type, row, rowcol) {
                    return '<input id="idProdmetac_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01" onchange="CargarvaloresProducto(this)"  value="' + row.Valormetac + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF4',
                render: function (data, type, row, rowcol) {
                    return '<input id="idProdmetad_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01" onchange="CargarvaloresProducto(this)"  value="' + row.Valormetad + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF5',
                render: function (data, type, row, rowcol) {
                    return '<input id="idProdmetae_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01" onchange="CargarvaloresProducto(this)"  value="' + row.Valormetae + '" min="0.00" max="9999999.99" />';
                },
            }
        ],
    });

    $('#tblactrel').DataTable({
        responsive: true,
        info: false,
        data: ListaActividadhelp,
        columns: [
            //    { data: 'IdMarcoLogicoAsignado', title: 'IdMarcoLogicoAsignado' },
            //    { data: 'IdMarcoLogico', title: 'IdMarcoLogico' },
            //    { data: 'IdLogFrame', title: 'IdLogFrame' },
            //    { data: 'OutCome', title: 'OutCome' },
            //    { data: 'OutPut', title: 'OutPut' },
            {
                data: 'Activity', title: 'Activity',
                render: function (data, type, row, rowcol) {
                    return row.OutCome + '-' + row.OutPut + '-' + row.Activity;
                },
            },
            { data: 'SumaryObjetives', title: 'SumaryObjetives', className: 'acortarcolumna' },
            { data: 'IdNivel', title: 'IdNivel' },
            { data: 'Cobertura', title: 'Cobertura' },
            //{ data: 'IdTipoActividad', title: 'IdTipoActividad' },
            { data: 'TipoActividad', title: 'TipoActividad' },
            /* { data: 'ModeloProyecto', title: 'Modelo Proyecto' },*/
            {
                data: 'IdLogFrame', title: 'Linea Base', width: '15px',
                render: function (data, type, row, rowcol) {
                    return '<input id="idActlineabase_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01" onchange="CargarvaloresActividad(this)"  width="15px" value="' + row.Valorlineabase + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF1', width: '15px',
                render: function (data, type, row, rowcol) {
                    return '<input id="idActmetaa_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01" onchange="CargarvaloresActividad(this)"   width="15px" value="' + row.Valormetaa + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF2', width: '15px',
                render: function (data, type, row, rowcol) {
                    return '<input id="idActmetab_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01" onchange="CargarvaloresActividad(this)"   width="15px" value="' + row.Valormetab + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF3', width: '15px',
                render: function (data, type, row, rowcol) {
                    return '<input id="idActmetac_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01" onchange="CargarvaloresActividad(this)"  width="15px"  value="' + row.Valormetac + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF4', width: '15px',
                render: function (data, type, row, rowcol) {
                    return '<input id="idActmetad_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01" onchange="CargarvaloresActividad(this)"   width="15px" value="' + row.Valormetad + '" min="0.00" max="9999999.99" />';
                },
            },
            {
                data: 'IdLogFrame', title: 'Meta AF5', width: '15px',
                render: function (data, type, row, rowcol) {
                    return '<input id="idActmetae_' + row.IdMarcoLogicoAsignado + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML + '" type="number" step="0.01" onchange="CargarvaloresActividad(this)"   width="15px" value="' + row.Valormetae + '" min="0.00" max="9999999.99" />';
                },
            },
        ],
    });




}

function CargarvaloresResultado(input) {
    // + row.IdMarcoLogicoAsignado  + '_' + row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML +
    RegistrosResultado[input.id] = input.value;
    const myArray = input.id.split("_");
    var item = ListaResultado.find(item => item.IdMarcoLogicoAsignado === parseInt(myArray[1]) && item.IdMarcoLogico === parseInt(myArray[2]) && item.IdLogFrame === parseInt(myArray[3]) && item.CodigoML === myArray[4]);

    switch (myArray[0]) {
        case 'idReslineabase':
            item.Valorlineabase = input.value;
            break;
        case 'idResmetaa':
            item.Valormetaa = input.value;
            break;
        case 'idResmetab':
            item.Valormetab = input.value;
            break;
        case 'idResmetac':
            item.Valormetac = input.value;
            break;
        case 'idResmetad':
            item.Valormetad = input.value;
            break;
        case 'idResmetae':
            item.Valormetae = input.value;
            break;
        default:
        // code block
    }

}

function CargarvaloresProducto(input) {
    //+ row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML +
    RegistrosResultado[input.id] = input.value;
    const myArray = input.id.split("_");
    var item = ListaProducto.find(item => item.IdMarcoLogicoAsignado === parseInt(myArray[1]) && item.IdMarcoLogico === parseInt(myArray[2]) && item.IdLogFrame === parseInt(myArray[3]) && item.CodigoML === myArray[4]);

    switch (myArray[0]) {
        case 'idProdlineabase':
            item.Valorlineabase = input.value;
            break;
        case 'idProdmetaa':
            item.Valormetaa = input.value;
            break;
        case 'idProdmetab':
            item.Valormetab = input.value;
            break;
        case 'idProdmetac':
            item.Valormetac = input.value;
            break;
        case 'idProdmetad':
            item.Valormetad = input.value;
            break;
        case 'idProdmetae':
            item.Valormetae = input.value;
            break;
        default:
        // code block
    }

}

function CargarvaloresActividad(input) {
    //+ row.IdMarcoLogico + '_' + row.IdLogFrame + '_' + row.CodigoML +
    RegistrosResultado[input.id] = input.value;
    const myArray = input.id.split("_");
    var item = ListaActividad.find(item => item.IdMarcoLogicoAsignado === parseInt(myArray[1]) && item.IdMarcoLogico === parseInt(myArray[2]) && item.IdLogFrame === parseInt(myArray[3]) && item.CodigoML === myArray[4]);

    switch (myArray[0]) {
        case 'idActlineabase':
            item.Valorlineabase = input.value;
            break;
        case 'idActmetaa':
            item.Valormetaa = input.value;
            break;
        case 'idActmetab':
            item.Valormetab = input.value;
            break;
        case 'idActmetac':
            item.Valormetac = input.value;
            break;
        case 'idActmetad':
            item.Valormetad = input.value;
            break;
        case 'idActmetae':
            item.Valormetae = input.value;
            break;
        default:
        // code block
    }

}


//https://www.npmjs.com/package/sweetalert2/v/10.12.4
function GuardarPitt() {
    Swal.fire({
        title: 'Desea guardar los cambios?',
        text: 'Debe de estar seguro de cargar todos los parametros necesarios.',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'SI',
        cancelButtonText: 'NO',
    }).then((result) => {
        if (result.value) {
            
            var combopry = $("#IdProyectoTecnico option:selected").text();
            const myArraypry = combopry.split("--");
            var idfaepa = myArraypry[2];

            var array1 = ListaResultado.concat(ListaProducto);
            var array2 = ListaActividad.concat(array1);


            if (parseInt($("#Id").val()) === 0) {
                if (idfaepa === undefined) {
                    return Swal.fire(
                        'Cancelled',
                        'No ha seleccionado los parametros necesarios',
                        'info'
                    );
                }

                if (array2.length === 0) {
                    return Swal.fire(
                        'Cancelled',
                        'No hay registro de Logframe.',
                        'info'
                    );
                }
            }



            var array3 = [];

            ListaGoul.forEach(function (dato, index) {
                array3.push({ IdMarcoLogicoAsignado: dato.Id })
            });

            var pitt = {
                id: $("#Id").val(),
                idfapa: idfaepa,
                Detalle: array2,
                DetalleGoul: array3
            };

            $('#create-form').preloader();

            $.post("/Planificacion/ProyectoITT/OnPostCreateOrEdit", pitt,
                function (informacion, estado) {
                    if (estado == "success") {
                        if (informacion.isValid === true) {
                            $('#form-modalFullScreem').modal('toggle');                           
                        }
                        else {
                            return Swal.fire(
                                'Cancelled',
                                informacion.msg,
                                'info'
                            );
                        }
                    }
                }).done(function () {
                    console.log("second success");
                })
                .fail(function () {
                    console.log("error");
                })
                .always(function () {
                    $('#create-form').preloader('remove');
                });

        }
    })




}
