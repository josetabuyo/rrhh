var ListaDeFichas = function (UI) {

};

ListaDeFichas.prototype = {
    setProveedorDeDatos: function (proveedor) {
        this.proveedor_de_datos = proveedor;
    },
    refrescar: function () {
        this.BorrarContenido();
        this.mostrarProgressBar();
        var self = this;
        this.proveedor_de_datos.pedirDatos(function (obj) { self.CargarObjetos(obj); });
    },
    cargarObjetos: function (objetos) {
        this.ocultarProgressBar();
        for (var i = 0; i < objetos.length; i++) {
            var obj = objetos[i];
            this.CargarObjeto(obj);
        }
    },
    cargarObjeto: function (obj) {
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
};