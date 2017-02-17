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

            columnas.push(new Columna("Nombre", { generar: function (un_agente) { return un_agente.nombre } }));
            /*columnas.push(new Columna("Nivel", { generar: function (un_estudio) { return un_estudio.nombreDeNivel } }));
            columnas.push(new Columna("Institución", { generar: function (un_estudio) { return un_estudio.nombreUniversidad } }));
            columnas.push(new Columna("F. Egreso", { generar: function (un_estudio) {
                var fecha_sin_hora = un_estudio.fechaEgreso.split("T");
                var fecha = fecha_sin_hora[0].split("-");
                return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
            }
            }));*/

        })
        .onError(function (e) {
            spinner.stop();
        });
    }
}
