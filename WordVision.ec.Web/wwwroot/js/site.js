$(document).ready(function () {
    $('.form-image').click(function () { $('#customFile').trigger('click'); });
    $(function () {
        $('.selectpicker').selectpicker();
    });

    $('[data-toggle="tooltip"]').tooltip()
    

    //$('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

    //    var $target = $(e.target);

    //    if ($target.parent().hasClass('disabled')) {
    //        return false;
    //    }
    //});
    //$(".next-step").click(function (e) {

    //    var $active = $('.wizard .nav-tabs li.active');
    //    $active.next().removeClass('disabled');
    //    nextTab($active);
    //});
    //$(".prev-step").click(function (e) {

    //    var $active = $('.wizard .nav-tabs li.active');
    //    prevTab($active);
    //});

    setTimeout(function () {
        $('body').addClass('loaded');
    }, 200);

   
    jQueryModalGet = (url, title) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#form-modal .modal-body').html(res.html);
                    $('#form-modal .modal-title').html(title);
                    $('#form-modal').modal('show');
                    console.log(res);
                },
                error: function (err) {
                    console.log(err)
                }
            })
            //to prevent default form submit event
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }

    jQueryModalGetHijo = (numero, url, title) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#form-modal-hijo-'+numero+' .modal-body').html(res.html);
                    $('#form-modal-hijo-' + numero +' .modal-title').html(title);
                    $('#form-modal-hijo-' + numero +'').modal('show');
                    console.log(res);
                },
                error: function (err) {
                    console.log(err)
                }
            })
            //to prevent default form submit event
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }


    jQueryModalGetHijo1 = (url, title) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#form-modal-hijo-1 .modal-body').html(res.html);
                    $('#form-modal-hijo-1 .modal-title').html(title);
                    $('#form-modal-hijo-1').modal('show');
                    console.log(res);
                },
                error: function (err) {
                    console.log(err)
                }
            })
            //to prevent default form submit event
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }

    jQueryModalPost = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {

                        if (res.solocerrar ?? false) {
                            /*$('#form-modal').modal('hide');*/
                            var hijo = res.hijo ?? 0;
                            switch (hijo) {
                                case 1:
                                    $('#form-modal-hijo').modal('hide');
                                    break;
                                case 2:
                                    $('#form-modal-hijo-1').modal('hide');
                                    break;
                                case 3:
                                    $('#form-modal-hijo-2').modal('hide');
                                    break;
                                default:
                                    $('#form-modal').modal('hide');
                                    break;
                            }
                            return;
                        }
                           
                        var opcion = res.opcion??0;
                        switch (opcion) {
                            case 1:
                                $(res.page).html(res.html);
                                break;
                            case 2:
                                $(res.page).html(res.html);
                                break;
                            case 99:
                                $(res.page).html(res.html);
                                break;
                            case 100:
                                $(res.page).html(res.html);
                                break;
                            case 101:
                                $(res.page).html(res.html);
                                break;
                            case 102:
                                $(res.page).html(res.html);
                                break;
                            case 103:
                                $(res.page).html(res.html);
                                break;
                            default:
                                $('#viewAll').html(res.html);
                                break;
                        }

                       
                        try {
                            if (opcion === 0) {
                                $('#viewAllD').html(res.html);
                            }
                        } catch (ex) { console.log(ex) }

                        var hijo = res.hijo ?? 0;
                        switch (hijo) {
                            case 1:
                                $('#form-modal-hijo').modal('hide');
                                break;
                            case 2:
                                $('#form-modal-hijo-1').modal('hide');
                                break;
                            case 3:
                                $('#form-modal-hijo-2').modal('hide');
                                break;
                            default:
                                $('#form-modal').modal('hide');
                                break;
                        }
                        //if (hijo === 0) {
                        //    $('#form-modal').modal('hide');
                        //} else {
                        //    $('#form-modal-hijo').modal('hide');
                        //}
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
    jQueryModalDelete = form => {
        if (confirm('¿Estás segura de eliminar este registro?')) {
            try {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        if (res.isValid) {

                            var opcion = res.opcion ?? 0;
                            switch (opcion) {
                                case 1:
                                    $(res.page).html(res.html);
                                    break;
                                case 2:
                                    $(res.page).html(res.html);
                                    break;
                                case 99:
                                    $(res.page).html(res.html);
                                    break;
                                case 100:
                                    $(res.page).html(res.html);
                                    break;
                                case 101:
                                    $(res.page).html(res.html);
                                    break;
                                case 102:
                                    $(res.page).html(res.html);
                                    break;
                                case 103:
                                    $(res.page).html(res.html);
                                    break;
                                default:
                                    $('#viewAll').html(res.html);
                                    break;
                            }


                            try {
                                if (opcion === 0) {
                                    $('#viewAllD').html(res.html);
                                }
                            } catch (ex) { console.log(ex) }

                            //try {
                            //    $('#viewAllD').html(res.html);
                            //} catch (ex) { console.log(ex) }
                            //try {
                            //    $('#viewAllNacional').html(res.html);
                            //} catch (ex) { console.log(ex) }

                            //$('#viewAll').html(res.html)
                        }
                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            } catch (ex) {
                console.log(ex)
            }
        }

        //prevent default form submit event
        return false;
    }

    jQueryModalController = form => {
        if (confirm('¿Estás segura de ejecutar esta acción?')) {
            try {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        
                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            } catch (ex) {
                console.log(ex)
            }
        }

        //prevent default form submit event
        return false;
    }
});

function LoadTableWithAjax(config) {
    var sumColumns = [];
    var prefixColumns = [];
    $.each(config.columns, function (index, item) {
        if (item.operation === "sum") {
            sumColumns.push(index);
            if (typeof item.prefix === 'undefined')
                prefixColumns.push("$");
            else if (item.prefix === "none")
                prefixColumns.push("");
            else
                prefixColumns.push(item.prefix);
        }
    });

    if (typeof config.tableFilter === 'undefined' || config.tableFilter) {
        $(`#${config.id} thead tr`).clone(true).addClass("thead-filter").appendTo(`#${config.id} thead`);
        $(`#${config.id} thead tr:eq(1) th`).each(function (i) {
            var typeFilter = config.columns[i].filter;
            if (typeFilter === "select")
                $(this).html('<select class="form-control form-control-sm p-0 m-0 w-100 select-filter"><option value="">Todos</option></select>');
            else if (typeFilter === "none")
                $(this).html('<span><span/>');
            else if (typeFilter === "input")
                $(this).html('<input type="text" class="form-control form-control-sm p-0 m-0 w-100 input-filter"/>');

            $(".input-filter").parent().removeClass("sorting");
            $(".input-filter").parent().removeClass("sorting_asc");
            $('input', this).on('keyup change', function (e) {
                if (tableMain.column(i).search() !== this.value)
                    tableMain.column(i).search(this.value).draw();

                totalizar(tableMain, sumColumns, prefixColumns);
            });

            $('select', this).on('change', function (e) {
                if (tableMain.column(i).search() !== this.value)
                    tableMain.column(i).search(this.value).draw();
            });
        });
    }

    var e = $(`#${config.id}`);
    var t = e.DataTable({
        language: {
            url: dataTableLangPath
        },
        dom: typeof config.dom !== 'undefined' ? config.dom : 'lfrtip',
        buttons: typeof config.buttons !== 'undefined' ? config.buttons : [],
        ajax: {
            url: config.ajax.url,
            contentType: typeof config.ajax.contentType !== 'undefined' ? config.ajax.contentType : null,
            data: typeof config.ajax.data !== 'undefined' ? config.ajax.data : null,
            dataType: typeof config.ajax.dataType !== 'undefined' ? config.ajax.dataType : null,
            method: config.ajax.method,
            dataSrc: typeof config.ajax.dataSrc !== 'undefined' ? config.ajax.dataSrc : null,
        },
        data: typeof config.data !== 'undefined' ? config.data : null,
        columns: typeof config.columns !== 'undefined' ? config.columns : null,
        lengthMenu: typeof config.length_menu !== 'undefined' ? config.length_menu : [10, 50, 100],
        paging: typeof config.paging !== 'undefined' ? config.paging : null,
        info: typeof config.info !== 'undefined' ? config.info : null,
        ordering: typeof config.ordering !== 'undefined' ? config.ordering : true,
        order: typeof config.order !== 'undefined' ? config.order : [],
        paging: typeof config.paging !== 'undefined' ? config.paging : true,
        info: typeof config.info !== 'undefined' ? config.info : true,
        responsive: typeof config.responsive !== 'undefined' ? config.responsive : true,
        createdRow: typeof config.createdRow !== 'undefined' ? config.createdRow : null,
        select: {
            style: !config.checkboxes || typeof config.checkboxes !== 'undefined' ? null : 'multi'
        },
        orderCellsTop: true,
        fixedHeader: true,
        initComplete: function (settings, json) {
            $(".helpCont").parent().remove();
            $(`#${config.id}_wrapper`).append("<div class='row' id='rowInfo'></div>");
            $(`#${config.id}_info`).addClass("col-6 col-md-6 col-lg-6 col-xl-6 col-sm-12 text-left");
            $(`#${config.id}_paginate`).addClass("col-6 col-md-6 col-lg-6 col-xl-6 col-sm-12 text-right");
            $("#rowInfo").append($(`#${config.id}_info`));
            $("#rowInfo").append($(`#${config.id}_paginate`));

            $(".btn-clear-filters").on("click", function () {
                $(".thead-filter").find("select, input").each(function () {
                    if ($(this).is('select'))
                        $(this).prop("selectedIndex", 0).change();
                    else if ($(this).is('input'))
                        $(this).val("");
                });
                t.search('').columns().search('').draw();
                t.order.neutral().draw();
            });

            t.columns().iterator('column', function (ctx, idx) {
                if (config.checkboxes) {
                    if (idx != 0)
                        $(t.column(idx).header()).append('<span class="sort-icon"/>');
                } else
                    $(t.column(idx).header()).append('<span class="sort-icon"/>');
            });

            if (config.checkboxes) {
                $('body').on("change", `#${config.id} tbody input[type=checkbox]`, function () {
                    if (this.checked)
                        $(this).closest("tr").addClass("table-primary");
                    else
                        $(this).closest("tr").removeClass("table-primary");
                });

                $('body').on("change", `#${config.id} thead input[type=checkbox]`, function () {
                    var rows = t.column(0).nodes().to$();
                    $.each(rows, function (index, item) {
                        if ($(item).find("input:checkbox")[0].checked)
                            $(this).closest("tr").addClass("table-primary");
                        else
                            $(this).closest("tr").removeClass("table-primary");
                    });
                });
            }

            if (typeof config.initComplete !== 'undefined')
                config.initComplete();
        },
        drawCallback: typeof config.drawCallback !== 'undefined' ? config.drawCallback : null,
        footerCallback: function (row, data, start, end, display) {
            var api = this.api(), data;
            totalizar(api, sumColumns, prefixColumns);

            if (typeof config.footerCallback !== 'undefined')
                config.footerCallback();
        }
    });

    $('a.tool-action').on("click", function () {
        var e = $(this).data("action");
        t.button(e).trigger();
    });

    $.fn.dataTable.ext.errMode = function (settings, tn, msg) {
        if (settings && settings.jqXHR && (settings.jqXHR.status == 401 || settings.jqXHR.status == 403)) {
            location.reload(true);
        } else
            console.log(msg);
    };
    return t;
}

function fillSelectFilter(config, t) {
    var selects = [];
    $.each(config.columns, function (index, item) {
        if (item.filter === "select")
            selects.push(index);
    });

    var i = 0;
    t.columns(selects).every(function (index, item) {
        var column = this;
        var options = column.nodes().to$().toArray().map(x => { return $(x).text() }).filter(onlyUnique);
        var select = $(column.header()).parent().parent().find("tr:eq(1) th > .select-filter")[i];
        $(select).empty().append('<option value="">Todos</option>');
        $.each(options, function (d, j) {
            if (j !== "")
                $(select).append('<option value="' + j + '">' + j + '</option>');
        });
        i++;
    });
}

function onlyUnique(value, index, self) {
    return self.indexOf(value) === index;
}

function totalizar(api, columns, prefixColumns) {
    var intVal = function (i) {
        return typeof i === 'string' ?
            i.replace(/[\$,]/g, '') * 1 :
            typeof i === 'number' ?
                i : 0;
    };
    var i = 0;
    api.columns(columns, { filter: 'applied' }).every(function () {
        var sum = this
            .data()
            .reduce(function (a, b) {
                return intVal(a) + intVal(b);
            }, 0);

        if (this.footer() !== null)
            this.footer().innerHTML = prefixColumns[i] + parseNumStr(sum, 2);

        i++;
    });
}

function parseNumStr(num, scale, prefix) {
    if (typeof (prefix) !== 'undefined')
        return prefix + " " + parseFloat(num).toFixed(scale);
    else
        return parseFloat(num).toFixed(scale);
}

function formatDate(d = new Date()) {
    return ('0' + (d.getDate())).slice(-2) + "/" + ('0' + (d.getMonth() + 1)).slice(-2) + "/" + d.getFullYear();
}

function startLoading(componente = "body") {
    $(componente).preloader({
        text: 'Cargando...',
        //percent: '100',
        zIndex: '9999',
        setRelative: false
    });
}

function finishLoading(componente = "body") {
    $(componente).preloader('remove');
}

//function nextTab(elem) {
//    $data = $(elem).next().find('a[data-toggle="tab"]').click();
//}
//function prevTab(elem) {
//    $(elem).prev().find('a[data-toggle="tab"]').click();
//}

    // Vigila la actividad del sistema.
    // --------------------------------
function VigilaActividad() {

    // Contador de tiempo en el que el usuario está inactivo.
    // ------------------------------------------------------
    var segundosDesdeUltimaActividad = 0;

    // Recuperamos del Controlador el valor timeOut definido en sessionState del Web.config
    // -----------------------------------------------------------------------------------
    var timeOut = 1;//'@Convert.ToInt32(((System.Web.Configuration.SessionStateSection)System.Configuration.ConfigurationManager.GetSection("system.web/sessionState")).Timeout.TotalMinutes)';

    var maximaInactividad = timeOut * 60;

    // A intervalos de 1 segundo (1000) revisa el estado del contador.
    // ---------------------------------------------------------------
    setInterval(function () {
        segundoDesdeUltimaActividad++;

        if (segundosDesdeUltimaActividad > maximaInactividad) {
            alert("aaa");
        location.href = '../Account/login';
        }
    }, 1000);

    // Esta funcion inicializa el contador de inactividad, sucede cuando se detecta que el usuario está trabajando...
    // -------------------------------------------------------------------------------------------------------------
    function reseteaActividad() {
        segundosDesdeUltimaActividad = 0;
    }

    // Vector con los eventos que vigila.
    // ----------------------------------
    var EventosActividad = [
        'keydown', 'keypress', 'scroll', 'mousedown', 'mousemove', 'touchstart', 'resize'
    ];

    // Creamos "Escuchadores" de eventos al documento...
    // -------------------------------------------------
    EventosActividad.forEach(function (eventName) {
        document.addEventListener(eventName, reseteaActividad, true);
    });
}