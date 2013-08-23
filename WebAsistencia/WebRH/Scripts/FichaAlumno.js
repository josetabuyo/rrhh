// JavaScript Document
var Ficha = function () {
    //this.datos = datos;
    this.start();
};

Grilla.prototype = {
    start: function () {
        this.nombre = $('<p>');
        this.oficina = $('<p>');
        this.imagen = $('<img>');
        //this.divContenedorFicha = $('<div>');
        //this.divContenedorTabla = $('<div>');
        //this.divContenedorFila = $('<div>');
        this.divContenedorCelda = $('<div>');
        this.spanTitulo = $('<span>');
        this.spanDato = $('<span>');


        this.nombre.addClass("nombre");
        this.oficina.addClass("oficina");
        this.imagen.addClass("imagen");
        //this.divContenedorFicha.addClass("contenedor_ficha");
        //this.divContenedorTabla.addClass("contenedor_tabla");
        //this.divContenedorFila.addClass("table-bordered");
        this.divContenedorCelda.addClass("contenedor_celda");
        this.spanTitulo.addClass("titulo");
        this.spanDato.addClass("dato");

        //this.tabla.css("cursor", "pointer");

        this.Objetos = [];

        //this.crearEncabezado();
        //this.crearCuerpo();
        //this.crearProgressBar();
        this.registrarIndexOfEnArrays();
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

    AgregarEstilo: function (clase) {
        this.tabla.addClass(clase);
    },

    SetOnRowClickEventHandler: function (metodo) {
        this.onRowClickEventHandler = metodo;
    },
    setProveedorDeDatos: function (proveedor) {
        this.proveedor_de_datos = proveedor;
    },
    refrescar: function () {
        this.BorrarContenido();
        //this.mostrarProgressBar();
        var self = this;
        this.proveedor_de_datos.pedirDatos(function (obj) { self.CargarObjetos(obj); });
    },
    CargarObjetos: function (objetos) {
        if (objetos.length > 0) {
            for (var i = 0; i < objetos.length; i++) {
                var obj = objetos[i];
                this.CargarObjeto(obj);
            }
        } 
    },
    
    CargarObjeto: function (obj) {
        var div1 = $('<div>');
        var div2 = $('<div>');
        var div3 = $('<div>');

        var tr = $('<tr>');
        for (var i = 0; i < this.obj.length; i++) {
            var registro = this.obj[i];
            var span_titulo = $('<span>');
            var span_dato = $('<span>');
            var td = $('<td>');
            td.append(col.generadorDeContenido.generar(obj));
            td.addClass(col.titulo);
            tr.append(td);
        }
        //seteo el evento click para la fila
        

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

