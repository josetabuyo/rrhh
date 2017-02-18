var Editor = {
    Inicializar: function () {
        this.SetearEventos();
    },
    SetearEventos: function () {
        //var data = CKEDITOR.instances.editor1.setData('');
        var _this = this;
        $('#boton_grabar_notificacion').click(function () {
            _this.Grabar();
        });
        $('#boton_vista_previa').click(function () {
            _this.VistaPrevia();
        });
        $("#input_documentos").keypress(function () {
            if ($("#input_documentos").val() != "") {
                lastChar = $("#input_documentos").val()[$("#input_documentos").val().length - 1];
                if (!/^([0-9])*$/.test(lastChar) && lastChar != ";") {
                    $("#input_documentos").val($("#input_documentos").val().slice(0, -1));
                    alert("sólo puede ingresar números separados por punto y coma");
                }
            }
        });
    },
    VistaPrevia: function () {
        var data = CKEDITOR.instances.editor1.getData();
        localStorage.setItem("notificacion_html", data);
        window.open('VistaPrevia.htm', '_blank');
    },
    Grabar: function () {
        var data = CKEDITOR.instances.editor1.getData();
        localStorage.setItem("notificacion_html", data);
        var documentos = this.ObtenerListadoDeDocumentos();
        Backend.EnviarNotificacion(data, documentos)
            .onSuccess(function () {
                alert("Notificación Guardada Correctamente")
            })
            .onError(function (e) {
                alert("Error al guardar la notificación")
            });
    },

    ObtenerListadoDeDocumentos: function () {
        var resultado = [];
        var listado = $("#input_documentos").val();
        var documentos = listado.split(";");
        for (var i = 0; i < documentos.length; i++) {
            if (/^([0-9])*$/.test(documentos[i])) {
                resultado.push(documentos[i])
            }
        }
        localStorage.setItem("notificacion_listado", resultado);
        return resultado;
    }

}

