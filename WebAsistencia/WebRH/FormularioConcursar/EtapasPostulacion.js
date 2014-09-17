
var EtapasPostulacion = {
    BuscarEtapasConcurso: function () {
        var proveedor_ajax = new ProveedorAjax();
        proveedor_ajax.postearAUrl({
            url: "GetEtapasConcurso",
            success: function (respuesta) {
                alertify.alert(JSON.stringify(respuesta));
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert("Error.");
            }
        });
    },
    BuscarPostulacionesPorCodigo: function (codigo) {
        var proveedor_ajax = new ProveedorAjax();
        proveedor_ajax.postearAUrl({
            url: "GetPostulacionesPorCodigo",
            data: { "codigo": codigo },
            success: function (respuesta) {
                CompletarDatos(respuesta);

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert("Error.");
            }
        });

    },
    InsertarEtapa: function (id_postulacion, etapa) {
        var proveedor_ajax = new ProveedorAjax();
        proveedor_ajax.postearAUrl({
            url: "InsEtapaPostulacion",
            data: {
                id_postulacion: parseInt(id_postulacion, 10),
                etapa_postulacion: {Id: etapa.Id, Descripcion:etapa.Descripcion}
            },
            success: function (respuesta) {
                alertify.alert(JSON.stringify(respuesta));
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert("Error.");
            }
        });
    }
}



var CompletarDatos = function (datos_postulacion) {
    var div_tabla_historial = $("#div_tabla_historial");
    var span_empleado = $("#span_empleado");
    var span_codigo = $("#span_codigo");
    var span_fecha = $("#span_fecha");
    var span_perfil = $("#span_perfil");
    var postulacion = $("#postulacion");
    postulacion.val(JSON.stringify(datos_postulacion));

    var columnas = [];
    columnas.push(new Columna("Fecha", { generar: function (una_etapa) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_etapa.Fecha) } }));
    columnas.push(new Columna("Descripción", { generar: function (una_etapa) { return una_etapa.Etapa.Descripcion } }));
    columnas.push(new Columna("Usuario", { generar: function (una_etapa) { return una_etapa.IdUsuario } }));

    this.GrillaHistorial = new Grilla(columnas);
    this.GrillaHistorial.AgregarEstilo("table table-striped");
    this.GrillaHistorial.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
    this.GrillaHistorial.SetOnRowClickEventHandler(function (una_etapa) {
    });

    div_tabla_historial.html("");
    this.GrillaHistorial.CargarObjetos(datos_postulacion.Etapas);
    this.GrillaHistorial.DibujarEn(div_tabla_historial);

    span_empleado.html(datos_postulacion.IdPersona);
    span_codigo.html(datos_postulacion.Numero);
    span_fecha.html(ConversorDeFechas.deIsoAFechaEnCriollo(datos_postulacion.FechaPostulacion));
    span_perfil.html(datos_postulacion.Puesto.Familia);
}
    


