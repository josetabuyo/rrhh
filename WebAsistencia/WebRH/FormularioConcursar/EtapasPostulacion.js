
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
                id_postulacion: id_postulacion,
                id_etapa_postulacion: etapa
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

    var usu_etapas = datos_postulacion.UsuEtapas;

    postulacion.val(JSON.stringify(datos_postulacion));

    var columnas = [];
    columnas.push(new Columna("Fecha", { generar: function (una_etapa) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_etapa.Fecha) } }));
    columnas.push(new Columna("Descripción", { generar: function (una_etapa) { return una_etapa.Etapa.Descripcion } }));
    columnas.push(new Columna("Usuario", { generar: function (una_etapa) {
        for (var i = 0; i < usu_etapas.length; i++) {
            if (usu_etapas[i].IdUsuario = una_etapa.IdUsuario) return usu_etapas[i].UsuarioEtapa;
        }
    } 
    }));

    this.GrillaHistorial = new Grilla(columnas);
    this.GrillaHistorial.AgregarEstilo("table table-striped");
    this.GrillaHistorial.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
    this.GrillaHistorial.SetOnRowClickEventHandler(function (una_etapa) {
    });

    div_tabla_historial.html("");
    this.GrillaHistorial.CargarObjetos(datos_postulacion.Postulacion.Etapas);
    this.GrillaHistorial.DibujarEn(div_tabla_historial);

    span_empleado.html(datos_postulacion.UsuarioPostulacion);
    span_codigo.html(datos_postulacion.Postulacion.Numero);
    span_fecha.html(ConversorDeFechas.deIsoAFechaEnCriollo(datos_postulacion.Postulacion.FechaPostulacion));
    span_perfil.html(datos_postulacion.Postulacion.Puesto.Familia);
}
    


