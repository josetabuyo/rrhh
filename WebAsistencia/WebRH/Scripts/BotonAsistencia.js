
var CrearBotonAsistencia = function (id_alumno, dia_cursado, valor, valor_maximo) {

    var botonAsistencia = $('<input>');
    botonAsistencia.attr('id', 'btnAsistencia' + id_alumno + "_" + dia_cursado);
    botonAsistencia.attr('type', 'button');
    botonAsistencia.attr("estado", valor);
    botonAsistencia.attr('valor', valor);
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
    var etiquetas = new Array(); // ['  ', '1', '2', '3', 'A', '-'];
    var valores = new Array();

    colores[0] = 'btn_blanco_clicked';
    etiquetas[0] = '  ';
    valores[0] = 0;

    for (var j = 1; j <= $(boton).attr('valor_maximo'); j++) {
        colores[j] = 'btn_verde_clicked';
        etiquetas[j] = j;
        valores[j] = j;
    }

    colores[colores.length] = 'btn_amarillo_clicked';
    etiquetas[etiquetas.length] = 'A';
    valores[valores.length] = 4;

    colores[colores.length] = 'btn_amarillo_clicked';
    etiquetas[etiquetas.length] = '-';
    valores[valores.length] = 5;

    var estado = $(boton).attr('estado');

    var i = ++estado % colores.length;

    $(boton).attr('estado', i);
    $(boton).attr('valor', valores[i]);
    $(boton).removeClass();
    $(boton).addClass(colores[i]);
    $(boton).val(etiquetas[i]);
};

var InicializarBoton = function (boton) {
    var colores = new Array();
    var etiquetas = new Array();
    var valores = new Array();
    var estado = 0;

    colores[0] = 'btn_blanco_clicked';
    etiquetas[0] = '  ';
    valores[0] = 0;

    for (var j = 1; j <= $(boton).attr('valor_maximo'); j++) {
        colores[j] = 'btn_verde_clicked';
        etiquetas[j] = j;
        valores[j] = j;
    }

    colores[colores.length] = 'btn_amarillo_clicked';
    etiquetas[etiquetas.length] = 'A';
    valores[valores.length] = 4;

    colores[colores.length] = 'btn_amarillo_clicked';
    etiquetas[etiquetas.length] = '-';
    valores[valores.length] = 5;


    for (var h = 0; h <= valores.length; h++) {
        if (valores[h] == $(boton).attr('valor')) {
            estado = h;
        }
    }

    $(boton).attr('estado', estado);
    $(boton).attr('valor', valores[estado]);
    $(boton).removeClass();
    $(boton).addClass(colores[estado]);
    $(boton).val(etiquetas[estado]);
};