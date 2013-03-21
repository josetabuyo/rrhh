var Grilla = function (columnas) {
    //miembros privados
    var tabla;
    var encabezado;
    var onRowClickEventHandler;
    var Objetos = new Array();

    //ESTO DEBERIA SER USADO PARA TODO, YA QUE EL INDEXOF EN IE NO FUNCIONA
    if (!Array.indexOf) {
        Array.prototype.indexOf = function (obj) {
            for (var i = 0; i < this.length; i++) {
                if (this[i] == obj) {
                    return i;
                }
            }
            return -1;
        }
    }

    //métodos públicos
    this.DibujarEn = function (panel) {
        //        if (tabla.find("tr").length < 2) {
        //            var tr = $('<tr>');
        //            var td = $('<td>');
        //            td.attr("colspan", columnas.length);
        //            td.html("No hay datos para mostrar");
        //            tr.append(td);
        //            tabla.append(tr);
        //        }

        panel.append(tabla);
    }

    this.SetOnRowClickEventHandler = function (metodo) {
        onRowClickEventHandler = metodo;
    }

    this.CargarObjetos = function (objetos) {
        for (var i = 0; i < objetos.length; i++) {
            var obj = objetos[i];
            this.CargarObjeto(obj);
        }
    }

    this.CargarObjeto = function (obj) {
        var tr = $('<tr>');
        for (var i = 0; i < columnas.length; i++) {
            var col = columnas[i];
            var td = $('<td>');
            td.append(col.generadorDeContenido.generar(obj));
            tr.append(td);
        }
        //seteo el evento click para la fila
        tr.click(function () {
            desSeleccionarTodo();
            $(this).find("td").addClass('celda_seleccionada');
            onRowClickEventHandler(obj);
        });

        tabla.append(tr);
        Objetos.push(obj);
    }

    this.QuitarObjetosExistentes = function (objetos) {
        for (var i = 0; i < objetos.length; i++) {
            var obj = objetos[i];
            if (this.ContieneElemento(obj)) {
                var indice = obtenerIndice(Objetos, obj);
                Objetos.splice(indice, 1);
            }

        }
        return Objetos;
    }

    this.QuitarObjeto = function (tabla, obj) {
        tabla.find(".celda_seleccionada").remove();
        var indice = Objetos.indexOf(obj);
        Objetos.splice(indice, 1);
    }



    //    this.QuitarObjetoSeleccionada = function (obj) {
    //        //tabla.find(".celda_seleccionada").remove();
    //        var indice = Objetos.indexOf(obj);
    //        Objetos.splice(indice, 1);
    //    }

    this.ContieneElemento = function (obj) {
        return contains(Objetos, obj);
    }

    this.Objetos = function () {
        return Objetos;
    }

    this.desSeleccionarTodo = function () {
        desSeleccionarTodo();
    }

    this.BorrarContenido = function () {
        var rowCount = tabla[0].rows.length;
        for (var i = 1; i < rowCount; i++) {
            tabla[0].deleteRow(i);
            rowCount--;
            i--;
        }
        Objetos = new Array();
    }

    //métodos privados
    function contains(a, obj) {
        var i = a.length;
        while (i--) {
            if (a[i] === obj) {
                return true;
            } else if (a[i].Id === obj.Id) {
                return true;
            }
        }
        return false;
    }

    function obtenerIndice(a, obj) {
        var i = a.length;
        while (i--) {
            if (a[i].Id === obj.Id) {
                return i;
            }
        }
        return -1;
    }

    var desSeleccionarTodo = function () {
        var celdas = tabla.find("td");
        celdas.removeClass('celda_seleccionada');
        celdas.removeClass('celda_on_hover');
    }

    var inicializar = function () {
        tabla = $('<table>');
        tabla.addClass("table");
        tabla.addClass("table-striped");
        tabla.addClass("table-bordered");
        tabla.addClass("table-condensed");

        var tHead = $('<thead>');
        tHead.addClass("detalle_viatico_titulo_tabla_detalle");

        encabezado = $('<tr>');
        tHead.append(encabezado);
        tabla.append(tHead);

        for (var i = 0; i < columnas.length; i++) {
            var col = columnas[i];
            encabezado.append('<th>' + col.titulo + '</th>');
        }
    }
    //inicializo
    inicializar();
}

var Columna = function (titulo, generadorDeContenido) {
    this.titulo = titulo;
    this.generadorDeContenido = generadorDeContenido;
}
