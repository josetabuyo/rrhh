var submit_value = false;
var i;
var Cursos;
var PlanillaCurso;
var GrillaHorarios;
var contenedorPlanilla;
var horarios = [];
var horario_seleccionado;

var dia = $("#cmbDia");
var horaI = $("#txtHoraInicio");
var horaF = $("#txtHoraFin");
var horasCatedra = $("#cmbHorasCatedra");



var AdministradorPlanillaCursos = function () {
    Cursos = JSON.parse($('#cursosJSON').val());
    var panelCurso = $("#panelCurso");

    contenedorPlanilla = $('#ContenedorPlanilla');
    var columnas = [];

 columnas.push(new Columna("Nombre", {
        generar: function (un_curso) {
            return un_curso.Nombre;
        }
    }));
    columnas.push(new Columna("Materia", {
        generar: function (un_curso) {
            return un_curso.Materia.Nombre;
        }
    }));
    columnas.push(new Columna("Docente", {
        generar: function (un_curso) {
            return un_curso.Docente.Nombre + " " + un_curso.Docente.Apellido;
        }
    }));
    columnas.push(new Columna("Espacio Fisico", {
        generar: function (un_curso) {
            return un_curso.EspacioFisico.Edificio.Nombre + ", Aula: " + un_curso.EspacioFisico.Aula;
        }
    }));
    columnas.push(new Columna("Horario", {
        generar: function (un_curso) {
            var horario = $.map(un_curso.Horarios, function (val, index) {
                return val.Dia.substring(0, 3) + " " + val.HoraDeInicio + " - " + val.HoraDeFin;
            }).join("<br>");
            return horario;
        }
   }));


    PlanillaCursos = new Grilla(columnas);

    PlanillaCursos.AgregarEstilo("tabla_macc");

    PlanillaCursos.SetOnRowClickEventHandler(function (un_curso) {
        panelCurso.CompletarDatosCurso(un_curso);
    });

    PlanillaCursos.CargarObjetos(Cursos);
    PlanillaCursos.DibujarEn(contenedorPlanilla);


    panelCurso.CompletarDatosCurso = function (un_curso) {

        panelCurso.find("#txtIdCurso").val(un_curso.Id);
        panelCurso.find("#txtNombre").val(un_curso.Nombre);

        panelCurso.find("#cmbMateria").val(un_curso.Materia.Id);
        panelCurso.find("#cmbDocente").val(un_curso.Docente.Id);
        panelCurso.find("#cmbEspacioFisico").val(un_curso.EspacioFisico.Id);
        panelCurso.find("#txtHorarios").val(JSON.stringify(un_curso.Horarios));
        panelCurso.find("#cmbHorasCatedra").val(un_curso.HorasCatedra);
        panelCurso.find("#txtFechaInicio").val(un_curso.FechaInicio);
        panelCurso.find("#txtFechaFin").val(un_curso.FechaFin);
        horarios = un_curso.Horarios;
        DibujarGrillaHorarios();
        $('#txtIdDocente').val(un_curso.Docente.Id);
        $('#txtIdEspacioFisico').val(un_curso.EspacioFisico.Id);
        $('#txtIdMateria').val(un_curso.Materia.Id);
        $('#horaCatedra').val($(un_curso.HoraCatedra));
        OcultarBoton($("#cambiarHorario"));
        MostrarBoton($("#agregarHorario"));
        HabilitarControl($("#btnModificarCurso"));
        HabilitarControl($("#btnQuitarCurso"));
        DeshabilitarControl($("#btnAgregarCurso"));
    };
    $('#contenedor_grilla_horario').html("")
    DeshabilitarControl($("#btnModificarCurso"));
    DeshabilitarControl($("#btnQuitarCurso"));
    HabilitarControl($("#btnAgregarCurso"));
    $("#txtHoraInicio").mask("99:99");
    $("#txtHoraFin").mask("99:99");
    $("#txtFechaInicio").datepicker($.datepicker.regional["es"]);
    $("#txtFechaFin").datepicker($.datepicker.regional["es"]);

    var options = {
        valueNames: ['Nombre', 'Materia', 'Docente', 'Espacio Fisico', 'Horario']
    };

    var featureList = new List('ContenedorPlanilla', options);

};

$('#cmbCurso').change(function () {
    var mes_inicio = un_curso.FechaInicio == null ? 1 : un_curso.FechaInicio.Month;
    var mes_fin = un_curso.FechaFin == null ? 12 : un_curso.FechaFin.Month;
    for (var mes = mes_inicio; mes <= mes_fin; mes++) {
        this.CmbCurso.Items.Add(new System.Web.UI.WebControls.ListItem(DateTimeFormatInfo.CurrentInfo.GetMonthName(mes), mes.ToString()));
    }


});


$('#cmbMateria').change(function () {
    $('#txtIdMateria').val($('#cmbMateria').find('option:selected').val());
});

$('#cmbDocente').change(function () {
    $('#txtIdDocente').val($('#cmbDocente').find('option:selected').val());
});

$('#cmbEspacioFisico').change(function () {
    $('#txtIdEspacioFisico').val($('#cmbEspacioFisico').find('option:selected').val());
});

$('#cmbHorasCatedra').change(function () {
    $('#horaCatedra').val($('#cmbHorasCatedra').find('option:selected').text());
});
var HabilitarControl = function (control) {
    control.removeAttr('disabled', 'false');
}

var DeshabilitarControl = function (control) {
    control.attr('disabled', 'disabled');
}

var DibujarGrillaHorarios = function () {
    var contenedorGrillaHorario = $('#contenedor_grilla_horario');
    contenedorGrillaHorario.html("");

    var columnas = [
    new Columna("Dia", {
        generar: function (horario) {
            return horario.Dia;
        }
    }),
    new Columna("Hora Inicio", {
        generar: function (horario) {
            return horario.HoraDeInicio;
        }
    }),
    new Columna("Hora Fin", {
        generar: function (horario) {
            return horario.HoraDeFin;
        }
    }),
    new Columna("Horas", {
        generar: function (horario) {
            return horario.HorasCatedra;
        }
    }),
    new Columna('Quitar', {
        generar: function (horario) {

            var contenedorAcciones = $('<div>');
            var botonQuitar = $('<input>');
            botonQuitar.attr('name', 'btnQuitarHorario');
            botonQuitar.attr('type', 'button');
            botonQuitar.addClass('btn');
            botonQuitar.val('Quitar');
            botonQuitar.click(function () {
                QuitarHorario(horario);
            });
            contenedorAcciones.append(botonQuitar);
            return contenedorAcciones;
        }
    })];


    GrillaHorarios = new Grilla(columnas);
    GrillaHorarios.SetOnRowClickEventHandler(function (horario) {
        CompletarDatosHorario(horario);
        CompletarNombreCurso();
    });

    GrillaHorarios.CargarObjetos(horarios);
    GrillaHorarios.DibujarEn(contenedorGrillaHorario);
};

var CompletarDatosHorario = function (horario) {
    dia.val(horario.NumeroDia);
    horaI.val(horario.HoraDeInicio);
    horaF.val(horario.HoraDeFin);
    horasCatedra.val(horario.HorasCatedra);
    horario_seleccionado = horario;

    MostrarBoton($("#cambiarHorario"));
    OcultarBoton($("#agregarHorario"));
};

var OcultarBoton = function (control) {
    control.css("display", "none");
    control.css("visibility", "hidden");
}

var MostrarBoton = function (control) {
    control.css("display", "inline");
    control.css("visibility", "visible");
}
var ValidarCampoObligatorio = function (control) {

    if (control.val() == "") {
        alertify.alert(control.attr("data-name") + " es obligatorio");
        control.focus();
        return false;
    }
    return true;
};
var AgregarHorario = function () {

    if (ValidarHorario(false)) {
        $.extend(horarios.push(NuevoHorario()));

        $("#txtHorarios").val(JSON.stringify(horarios));
        DibujarGrillaHorarios();
        LimpiarHorario();
    }
};

var QuitarHorario = function (horario) {
    var indice = ObtenerIndice(horarios, horario);
    horarios.splice(indice, 1);
    $("#txtHorarios").val(JSON.stringify(horarios));
    DibujarGrillaHorarios();

}

var CambiarHorario = function () {

    if (ValidarHorario(true)) {
        horarios = horarios.map(function (item) {
            return item == horario_seleccionado ? NuevoHorario() : item;
        });

        $("#txtHorarios").val(JSON.stringify(horarios));
        DibujarGrillaHorarios();
        LimpiarHorario();
    }
};



var completarCombosDeHorasCatedra = function () {
    for (var i = 1; i < 4; i++) {
        var ciclo;
        var listItem = $('<option>');
        listItem.val(i);
        listItem.text(i);
        horasCatedra.append(listItem);
    }
}

var NuevoHorario = function () {

    return {
        NumeroDia: dia.find('option:selected').val(),
        Dia: dia.find('option:selected').text(),
        HoraDeInicio: horaI.val(),
        HoraDeFin: horaF.val(),
        HorasCatedra: horasCatedra.find('option:selected').text()
    };
}
var ValidarHorario = function (para_modificar) {
    return ValidarCampoObligatorio(dia) &&
    ValidarHora(horaI) &&
    ValidarHora(horaF) &&
    (para_modificar || ValidarSuperposicion()) &&
    ValidarRangoDeHoras(horaI.val(), horaF.val());
}

var ValidarSuperposicion = function () {
    horario_a_validar = NuevoHorario();

    var regExp = /(\d{1,2})\:(\d{1,2})/;

    var res = true;
    $.each(horarios, function (index, horario) {
        if (horario.NumeroDia == horario_a_validar.NumeroDia) {
            if (parseInt(horario_a_validar.HoraDeInicio.replace(regExp, "$1$2"), 10) >= parseInt(horario.HoraDeInicio.replace(regExp, "$1$2"), 10) && parseInt(horario_a_validar.HoraDeInicio.replace(regExp, "$1$2"), 10) < parseInt(horario.HoraDeFin.replace(regExp, "$1$2"), 10)) {
                res = false;
            }
            if (parseInt(horario_a_validar.HoraDeFin.replace(regExp, "$1$2"), 10) > parseInt(horario.HoraDeInicio.replace(regExp, "$1$2"), 10) && parseInt(horario_a_validar.HoraDeFin.replace(regExp, "$1$2"), 10) <= parseInt(horario.HoraDeFin.replace(regExp, "$1$2"), 10)) {
            res = false;
            }
            if (parseInt(horario_a_validar.HoraDeInicio.replace(regExp, "$1$2"), 10) <= parseInt(horario.HoraDeInicio.replace(regExp, "$1$2"), 10) && parseInt(horario_a_validar.HoraDeFin.replace(regExp, "$1$2"), 10) >= parseInt(horario.HoraDeFin.replace(regExp, "$1$2"), 10)) {
            res = false;
            }
        }
});
if (!res) alertify.alert("El horario que intenta agregar se superpone con otros horarios de la lista");
    return res;
}

var ValidarRangoDeHoras = function (hora_inicio, hora_fin) {
    var regExp = /(\d{1,2})\:(\d{1,2})/;
    if (parseInt(hora_inicio.replace(regExp, "$1$2"), 10) < parseInt(hora_fin.replace(regExp, "$1$2"), 10)) return true;
    else {
        alertify.alert("El horario de inicio no debe ser mayor o igual al horario de final");
        return false;
    }
}

var ValidarHora = function (hora) {
    if (!ValidarCampoObligatorio(hora))
        return false;
    else if (/^([0-1]?[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?$/.test(hora.val())) {
        return true;
    }
    else {
        alertify.alert("Valor de hora incorrecto");
    }
    hora.focus();
    return false;
};

var LimpiarHorario = function () {
    Limpiar(horaI);
    Limpiar(horaF);
    Limpiar(dia);
    
}

var Limpiar = function (control) {
    control.val("");
};

var LimpiarCampos = function () {
    LimpiarHorario();
    horarios = [];
    $('#contenedor_grilla_horario').html("");

    Limpiar($("#txtNombre"));

    Limpiar($("#cmbMateria"));
    Limpiar($("#cmbDocente"));
    Limpiar($("#cmbEspacioFisico"));
    Limpiar($("#txtFechaInicio"));
    Limpiar($("#txtFechaFin"));
    Limpiar($("#txtHorarios"));    

    Limpiar($("#txtIdCurso"));
    Limpiar($('#txtIdDocente'));
    Limpiar($('#txtIdEspacioFisico'));
    Limpiar($('#txtIdMateria'));
    DeshabilitarControl($("#btnModificarCurso"));
    DeshabilitarControl($("#btnQuitarCurso"));
    HabilitarControl($("#btnAgregarCurso"));
}

$(document).ready(function () {
    AdministradorPlanillaCursos();
    completarCombosDeHorasCatedra();
});

var ObtenerIndice = function (arreglo, obj) {
    if (arreglo.indexOf) {
        return arreglo.indexOf(obj);
    }
    else {
        for (var i = 0; i < this.length; i++) {
            if (this[i] == obj) {
                return i;
            }
        }
        return -1;
    };
};

var ValidarCamposObligatorios = function (controles) {
    if (controles.length > 0) {
        for (var i = 0; i < controles.length; i++) {
            if (!ValidarCampoObligatorio(controles[i]))
                return false;
        }
        return true;
    }
    return false;
}
var ValidarCurso = function () {
    if (ValidarCamposObligatorios([$("#cmbMateria"), $("#cmbDocente"), $("#cmbEspacioFisico")]) && horarios.length > 0) {
        submit_value = true;
    }
    else
        submit_value = false;

};