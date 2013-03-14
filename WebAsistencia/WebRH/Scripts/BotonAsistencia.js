
var CrearBotonAsistencia = function (id_alumno, dia_cursado, valor) {

    var botonAsistencia = $('<input>');
    botonAsistencia.attr('id', 'btnAsistencia' + id_alumno + "_" + dia_cursado);
    botonAsistencia.attr('type', 'button');
    botonAsistencia.attr("estado", valor);
    botonAsistencia.attr("es_btn_asistencia", true);
    botonAsistencia.attr("id_alumno", id_alumno);
    botonAsistencia.attr("dia_cursado", dia_cursado);
    botonAsistencia.addClass('btn_blanco_clicked');
    botonAsistencia.click(function () {
        CambiarEstado(botonAsistencia);
    });
    InicializarBoton(botonAsistencia);
    return botonAsistencia;
};


var CambiarEstado = function (boton) {
    var colores = ['btn_blanco_clicked', 'btn_verde_clicked', 'btn_amarillo_clicked'];
    var etiquetas = ['  ', 'P', 'A'];

    var estado = $(boton).attr('estado');


    var i = ++estado % colores.length;

    $(boton).attr('estado', i);
    $(boton).removeClass();
    $(boton).addClass(colores[i]);
    $(boton).val(etiquetas[i]);
};

var InicializarBoton = function (boton) {
    var colores = ['btn_blanco_clicked', 'btn_verde_clicked', 'btn_amarillo_clicked'];
    var etiquetas = ['  ', 'P', 'A'];

    var estado = $(boton).attr('estado');

    $(boton).attr('estado', estado);
    $(boton).removeClass();
    $(boton).addClass(colores[estado]);
    $(boton).val(etiquetas[estado]);
};