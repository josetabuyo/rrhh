var spinner;
var mes;
var idUsuario;

var Certificado = {

    Init: function () { },

    SetearEventos: function () {
        var _this = this;
        $('#btn_solic_cert').click(function () {
            _this.SolicitarCertificado();
        });
    },

    SolicitarCertificado: function() {
        alert('Evento_Click');
        //Backend.SolicitarCertificado()
        //  .onSuccess(function (XXX) {})
        //  .onError(function (e) {});
    },

    GetCarreraAdministrativa: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetExperienciaPublica()
                    .onSuccess(function (experienciaJSON) {
                        var experiencia = [];
                        if (experienciaJSON != "") {
                            experiencia = JSON.parse(experienciaJSON);
                        }

                        experiencia = _.sortBy((_.sortBy(experiencia, 'FechaDesde')), 'Folio');
                        var _this = this;
                        $("#tablaCarreraAdministrativa").empty();
                        var divGrilla = $("#tablaCarreraAdministrativa");
                        var columnas = [];

                        //columnas.push(new Columna("Id", { generar: function (una_carrera) { return una_carrera.Id } }));
                        //columnas.push(new Columna("Id_Certificado", { generar: function (una_carrera) { return una_carrera.Id_Certificado } }));
                        columnas.push(new Columna("Desde", { generar: function (una_carrera) { return una_carrera.Desde; } }));
                        columnas.push(new Columna("Hasta", { generar: function (una_carrera) { return una_carrera.Hasta_Original; } }));
                        columnas.push(new Columna("Marco", { generar: function (una_carrera) { return una_carrera.Descri_Tipo_Contrato; } }));
                        columnas.push(new Columna("Acto Aprobatorio", { generar: function (una_carrera) { return una_carrera.CadenaActo; } }));
                        columnas.push(new Columna("Área", { generar: function (una_carrera) { return una_carrera.Area; } }));
						
                        _this.Grilla = new Grilla(columnas);
                        _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.Grilla.CargarObjetos(experiencia);
                        _this.Grilla.DibujarEn(divGrilla);
                        $('.table-hover').removeClass("table-hover");

                        spinner.stop();
                    })
                    .onError(function (e) {
                        spinner.stop();
                    });
    }
};


