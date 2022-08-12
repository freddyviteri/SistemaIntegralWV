//$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
//  e.target // newly activated tab
//  e.relatedTarget // previous active tab
//})

var datageneralfa = null;

var datapadisthelp = [];
var datapydisthelp = [];

var datapydisthelpnewup = [];

$(document).ready(function () {


    $('#form-add').on('hidden.bs.modal', function (e) {
        $("body").addClass("modal-open")
    });
    $("#idSelectpa").append('<option value="0">Seleccionar</option>');
    $("#idSelectpt").append('<option value="0">Seleccionar</option>');
    $("#IdProgramaArea").append('<option value="0">Seleccionar</option>');
    $("#IdProyectoTecnico").append('<option value="0">Seleccionar</option>');

    $.getJSON('../Planificacion/ProyectoITT/Cargarcombos?handler',
        (data) => {

            if (data === null) {
                return;
            }
            datageneralfa = data;

            $.each(data, function (i, value) {
                datapadisthelp.push({ idpa: value.idpa, nombreprograma: value.nombreprograma });
            });

            var uniqueSites = unique(datapadisthelp);

            $.each($.unique(uniqueSites), function (i, value) {
                $("#idSelectpa").append('<option value="'
                    + value.idpa + '">'
                    + value.nombreprograma + '</option>');
            });
            loadData();
        }).done(function (data) {
            console.log("second success");
        })
        .fail(function (jqxhr, textStatus, error) {
            var err = textStatus + ", " + error;
        })
        .always(function () {
            console.log("complete");
        });
});


function unique(array) {
    return array.reduce(function (memo, e1) {
        var matches = memo.filter(function (e2) {
            return e1.idpa == e2.idpa //&& e1.start == e2.start
        })
        if (matches.length == 0)
            memo.push(e1)
        return memo;
    }, [])

}


function CargarEditarPoppup(id) {
    $('#divContent').preloader();

    //setTimeout(function () {
        jQueryModalFullScreemGet('/Planificacion/ProyectoITT/OnGetCreateOrEdit?id=' + id, 'Editar Proyecto ITT');
        
    //}, 7000);


}


function Changepa() {
    //$('#viewAll').load('/Planificacion/ProyectoITT/LoadAll');
    $('#idSelectpt').empty();
    $("#idSelectpt").append('<option value="0">Seleccionar</option>');
    if (datageneralfa === null) {
        return;
    }
    datapydisthelp = [];
    $.each(datageneralfa, function (i, value) {
        if ($("#idSelectpa").val() === value.idpa.toString()) {
            datapydisthelp.push({ idfa: value.id, idpt: value.idpt, nombreproyecto: value.nombreproyecto, idfase: value.idfase, fase: value.fase });
        }
    });

    $.each($.unique(datapydisthelp), function (i, value) {
        $("#idSelectpt").append('<option value="'
            + value.idpt + '">'
            + value.nombreproyecto + ' -- ' + value.fase + '--' + value.idfa + '</option>');
    });

}


function Changepanewup() {
    $('#IdProyectoTecnico').empty();
    $("#IdProyectoTecnico").append('<option value="0">Seleccionar</option>');
    if (datageneralfa === null) {
        return;
    }
    datapydisthelpnewup = [];
    $.each(datageneralfa, function (i, value) {
        if ($("#IdProgramaArea").val() === value.idpa.toString()) {
            datapydisthelpnewup.push({ idfa: value.id, idpt: value.idpt, nombreproyecto: value.nombreproyecto, idfase: value.idfase, fase: value.fase });
        }
    });

    $.each($.unique(datapydisthelpnewup), function (i, value) {
        $("#IdProyectoTecnico").append('<option value="'
            + value.idpt + '" tag-valor=' + value.idfa + ' >'
            + value.nombreproyecto + ' -- ' + value.fase + '--' + value.idfa + '</option>');
    });
}



function loadData() {
    $('#viewAll').load('/Planificacion/ProyectoITT/LoadAll?idpt=' + $("#idSelectpt").val());
}



