var Grilla = function (columnas) {
    //miembros privados
    var tabla;
    var encabezado;
    var onRowClickEventHandler;
    var Objetos = new Array();

    this._progress_bar = $('<div>');
    var progress_label = $("<div>");
    progress_label.css("float", "left");
    progress_label.css("margin-left", "40%");
    progress_label.css("margin-top", "5px");
    progress_label.css("font-weight", "bold");

    progress_label.text("Cargando documentos...");

    this._progress_bar.append(progress_label);

    this._progress_bar.progressbar({
        value: false
    });
    this._progress_bar.progressbar("option", "value", false);
    this._mostrando_progress_bar = false;

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
        panel.append(tabla);
    }

    this.SetOnRowClickEventHandler = function (metodo) {
        onRowClickEventHandler = metodo;
    }

    this.setProveedorDeDatos = function (proveedor) {
        this._proveedor_de_datos = proveedor;
    }

    this.refrescar = function () {
        this.BorrarContenido();
        this.mostrarProgressBar();
        this._proveedor_de_datos.pedirDatos(this.CargarObjetos.bind(this));
    }

    this.mostrarProgressBar = function () {
        tabla.after(this._progress_bar);
        this._progress_bar.show();
        this._mostrando_progress_bar = true;
    }

    this.ocultarProgressBar = function () {
        this._progress_bar.hide();
        this._mostrando_progress_bar = false;
    }

    this.mostrandoProgressBar = function () {
        return this._mostrando_progress_bar;
    }

    this.CargarObjetos = function (objetos) {
        this.ocultarProgressBar();
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
