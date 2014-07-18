var Puesto = {
    armarLista: function (puestos) {
        var _this = this;

        //_this.divListado = $('#listado_puestos');
        _this.divGrilla = $('#tabla_puestos');

        var columnas = [];

        columnas.push(new Columna("Id", { generar: function (un_puesto) { return un_puesto.Id } }));
        columnas.push(new Columna("Puesto", { generar: function (un_puesto) { return un_puesto.Denominacion } }));
        columnas.push(new Columna("Nivel", { generar: function (un_puesto) { return un_puesto.Nivel } }));
        columnas.push(new Columna("Agrupamiento", { generar: function (un_puesto) { return un_puesto.Agrupamiento } }));
        columnas.push(new Columna("Vacantes", { generar: function (un_puesto) { return un_puesto.Vacantes } }));
        columnas.push(new Columna("Convocatoria", { generar: function (un_puesto) { return un_puesto.Tipo } }));
        columnas.push(new Columna("Nombre PDF", { generar: function (un_puesto) { return un_puesto.Tipo } }));
        columnas.push(new Columna("Comité", { generar: function (un_puesto) { return 1 } }));
        
        this.GrillaDePuestos = new Grilla(columnas);
        this.GrillaDePuestos.AgregarEstilo("table table-striped");
        //this.GrillaDePuestos.SetOnRowClickEventHandler(function (una_matricula) {
        //});

        this.GrillaDePuestos.CargarObjetos(puestos);
        this.GrillaDePuestos.DibujarEn(_this.divGrilla);

    }
}


