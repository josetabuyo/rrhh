
var CrearBotonAsistencia = function (id_alumno, dia_cursado, valor, valor_maximo) {

    var botonAsistencia = $('<input>');
    botonAsistencia.attr('id', 'btnAsistencia' + id_alumno + "_" + dia_cursado);
    botonAsistencia.attr('type', 'button');
    botonAsistencia.attr("estado", valor);
    botonAsistencia.attr("valor_maximo", valor_maximo);
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

    var colores = new Array(); // ['btn_blanco_clicked', 'btn_verde_clicked', 'btn_verde_clicked', 'btn_verde_clicked', 'btn_amarillo_clicked'];
    var etiquetas = new Array(); // ['  ', '1', '2', '3', 'n/a'];

    colores[0] = 'btn_blanco_clicked';
    etiquetas[0] = '  ';
    for (var j = 1; j <= $(boton).attr('valor_maximo'); j++) {
        colores[j] = 'btn_verde_clicked';
        etiquetas[j] = j;
    }
    //colores[colores.length] = 'btn_amarillo_clicked';
    //etiquetas[etiquetas.length] = 'n/a';

    var estado = $(boton).attr('estado');

    var i = ++estado % colores.length;

    $(boton).attr('estado', i);
    $(boton).removeClass();
    $(boton).addClass(colores[i]);
    $(boton).val(etiquetas[i]);
};

var InicializarBoton = function (boton) {
    var colores = new Array();
    var etiquetas = new Array();

    colores[0] = 'btn_blanco_clicked';
    etiquetas[0] = '  ';
   
    for (var j = 1; j <= $(boton).attr('valor_maximo'); j++) {
        colores[j] = 'btn_verde_clicked';
        etiquetas[j] = j;
    }
    //colores[colores.length] = 'btn_amarillo_clicked';
    //etiquetas[etiquetas.length] = 'n/a';
    var estado = $(boton).attr('estado');

    $(boton).attr('estado', estado);
    $(boton).removeClass();
    $(boton).addClass(colores[estado]);
    $(boton).val(etiquetas[estado]);
};