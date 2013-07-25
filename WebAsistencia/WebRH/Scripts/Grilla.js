// JavaScript Document
var Grilla = function (columnas) {
    this.columnas = columnas;
    this.start();
};

Grilla.prototype = {
    start: function () {
        this.tabla = $('<table>');
        this.tabla.addClass("table");
        this.tabla.addClass("table-striped");
        this.tabla.addClass("table-bordered");
        this.tabla.addClass("table-condensed");
        this.tabla.addClass("table-hover");
        this.tabla.css("cursor", "pointer");

        this.Objetos = [];

        this.crearEncabezado();
        this.crearProgressBar();
        this.registrarIndexOfEnArrays();
    },
    crearEncabezado: function () {
        var tHead = $('<thead>');
        tHead.addClass("detalle_viatico_titulo_tabla_detalle");

        var encabezado = $('<tr>');
        tHead.append(encabezado);
        this.tabla.append(tHead);

        for (var i = 0; i < this.columnas.length; i++) {
            var col = this.columnas[i];
            var th = $("<th>").append(col.titulo);
            encabezado.append(th);
        }
    },
    crearProgressBar: function () {
        this.progress_bar = $('<div>');
        var progress_label = $("<div>");
        progress_label.css("float", "left");
        progress_label.css("margin-left", "40%");
        progress_label.css("margin-top", "5px");
        progress_label.css("font-weight", "bold");

        progress_label.text("Cargando documentos...");

        this.progress_bar.append(progress_label);

        this.progress_bar.progressbar({
            value: false
        });
        this.progress_bar.progressbar("option", "value", false);
        this.mostrando_progress_bar = false;
    },
    registrarIndexOfEnArrays: function () {
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
    },
    DibujarEn: function (panel) {
        panel.append(this.tabla);
    },
    SetOnRowClickEventHandler: function (metodo) {
        this.onRowClickEventHandler = metodo;
    },
    setProveedorDeDatos: function (proveedor) {
        this.proveedor_de_datos = proveedor;
    },
    refrescar: function () {
        this.BorrarContenido();
        this.mostrarProgressBar();
        var self = this;
        this.proveedor_de_datos.pedirDatos(function (obj) { self.CargarObjetos(obj); });
    },
    mostrarProgressBar: function () {
        this.tabla.after(this.progress_bar);
        this.progress_bar.show();
        this.mostrando_progress_bar = true;
    },
    ocultarProgressBar: function () {
        this.progress_bar.hide();
        this.mostrando_progress_bar = false;
    },
    mostrandoProgressBar: function () {
        return this.mostrando_progress_bar;
    },
    CargarObjetos: function (objetos) {
        this.ocultarProgressBar();
        if (objetos.length > 0) {
            for (var i = 0; i < objetos.length; i++) {
                var obj = objetos[i];
                this.CargarObjeto(obj);
            }
        } else {
            this.CargarFilaSinDatos();
        }
    },
    CargarFilaSinDatos: function () {
        var tr = $('<tr>');
        var td = $('<td>');
        td.attr('colspan', this.columnas.length).text("No hay datos para mostrar");
        tr.append(td);
        this.tabla.append(tr);
    },
    CargarObjeto: function (obj) {
        var tr = $('<tr>');
        for (var i = 0; i < this.columnas.length; i++) {
            var col = this.columnas[i];
            var td = $('<td>');
            td.append(col.generadorDeContenido.generar(obj));
            tr.append(td);
        }
        //seteo el evento click para la fila
        var self = this;
        tr.click(function () {
            self.desSeleccionarTodo();
            $(this).find("td").addClass('celda_seleccionada');
            self.onRowClickEventHandler(obj);
        });

        this.tabla.append(tr);
        this.Objetos.push(obj);
    },
    QuitarObjetosExistentes: function (objetos) {
        for (var i = 0; i < objetos.length; i++) {
            var obj = objetos[i];
            if (this.ContieneElemento(obj)) {
                var indice = this.obtenerIndice(this.Objetos, obj);
                this.Objetos.splice(indice, 1);
            }

        }
        return this.Objetos;
    },
    QuitarObjeto: function (tabla, obj) {
        this.tabla.find(".celda_seleccionada").remove();
        var indice = this.Objetos.indexOf(obj);
        this.Objetos.splice(indice, 1);
    },
    ContieneElemento: function (obj) {
        return this.contains(this.Objetos, obj);
    },

    BorrarContenido: function () {
        var rowCount = this.tabla[0].rows.length;
        for (var i = 1; i < rowCount; i++) {
            this.tabla[0].deleteRow(i);
            rowCount--;
            i--;
        }
        this.Objetos = new Array();
    },
    contains: function (a, obj) {
        var i = a.length;
        while (i--) {
            if (a[i] === obj) {
                return true;
            } else if (a[i].Id === obj.Id) {
                return true;
            }
        }
        return false;
    },
    obtenerIndice: function (a, obj) {
        var i = a.length;
        while (i--) {
            if (a[i].Id === obj.Id) {
                return i;
            }
        }
        return -1;
    },
    desSeleccionarTodo: function () {
        var celdas = this.tabla.find("td");
        celdas.removeClass('celda_seleccionada');
        celdas.removeClass('celda_on_hover');
    }
};


var Columna = function (titulo, generadorDeContenido, resumida) {
    this.titulo = titulo;
    this.generadorDeContenido = generadorDeContenido;
}

