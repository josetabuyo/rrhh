var spinner;
var idUsuario;

var ListadoAgentes = {
    init: function () {

    },
    getEstudios: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.EvalGetAgentesEvaluables()
        .onSuccess(function (agentesJSON) {
            spinner.stop();
            var agentes = JSON.parse(agentesJSON);
            var _this = this;
            $("#tablaAgentes").empty();
            var divGrilla = $("#tablaAgentes");

            var columnas = [];

            columnas.push(new Columna("Dni", { generar: function (un_agente) { return un_agente.nro_documento } }));
            columnas.push(new Columna("Apellido", { generar: function (un_agente) { return un_agente.apellido } }));
            columnas.push(new Columna("Nombre", { generar: function (un_agente) { return un_agente.nombre } }));
            columnas.push(new Columna("Evaluacion", { generar: function (un_agente) { return "A Evaluar" } }));
            /*columnas.push(new Columna("Nivel", { generar: function (un_estudio) { return un_estudio.nombreDeNivel } }));
            columnas.push(new Columna("Institución", { generar: function (un_estudio) { return un_estudio.nombreUniversidad } }));
            columnas.push(new Columna("F. Egreso", { generar: function (un_estudio) {
                var fecha_sin_hora = un_estudio.fechaEgreso.split("T");
                var fecha = fecha_sin_hora[0].split("-");
                return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
            }
            }));*/

            _this.Grilla = new Grilla(columnas);
            _this.Grilla.SetOnRowClickEventHandler(function (un_agente) {  });
            _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
            _this.Grilla.CargarObjetos(agentes);
            _this.Grilla.DibujarEn(divGrilla);
            $('.table-hover').removeClass("table-hover");

        })
        .onError(function (e) {
            spinner.stop();
        });
    }
}
