$(document).ready(function () {
    Backend.start(function () {
        VistaFormulario.start();        
    });
});

var VistaFormulario = {
    start: function () {
        var _this = this;
        $('#fecha_ingreso_apn').datepicker();
        $('#fecha_ingreso_apn').datepicker('option', 'dateFormat', 'dd/mm/yy');
        $('#fecha_ingreso_minis').datepicker();
        $('#fecha_ingreso_minis').datepicker('option', 'dateFormat', 'dd/mm/yy');
        $('#fecha_ingreso_oficina').datepicker();
        $('#fecha_ingreso_oficina').datepicker('option', 'dateFormat', 'dd/mm/yy');
        var selector_personas = new SelectorDePersonas({
            ui: $('#selector_usuario'),
            repositorioDePersonas: new RepositorioDePersonas(new ProveedorAjax("../")),
            placeholder: "nombre, apellido, documento o legajo"
        });

        var formulario = {};

        var cambios = {};

        $("[campo]").change(function () {
            cambios[$(this).attr("campo")] = $(this).val();
        });
        $("#btn_guardar_cambios").click(function () {
            var form_cambios = {
                idFormulario: formulario.idFormulario,
                idPersona: formulario.idPersona,
                campos: []
            }

            for (var campo_cambio in cambios) {
                if (cambios.hasOwnProperty(campo_cambio)) {
                    form_cambios.campos.push({
                        clave: campo_cambio,
                        valor: cambios[campo_cambio]
                    });
                }
            }

            console.log(form_cambios);
            Backend.GuardarCambiosEnFormulario(form_cambios)
            .onSuccess(function () {
                alertify.success("Formulario guardado correctamente");
            })
            .onError(function () {
                alertify.error("Error al guardar formulario");
            });
        });
        selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
            $(".contenedor_formulario").hide()
            _this.limpiarPantalla();
            Backend.GetFormulario(JSON.stringify({ idFormulario: 1, idPersona: la_persona_seleccionada.id })).onSuccess(function (form) {
                //            formulario = {
                //                id: 1,
                //                nombre: "Relevamiento de contrato",
                //                idPersona: 111,
                //                campos: [
                //                        { campo: "nombre", valor: "agustin" },
                //                        { campo: "apellido", valor: "calcagno" }
                //                    ]
                //            };

                formulario = form;
                form.idPersona = la_persona_seleccionada.id;
                form.idFormulario = 1;
                $("[campo]").each(function () {
                    var campo = _.findWhere(formulario.campos, { clave: $(this).attr("campo") });
                    if (campo) $(this).val(campo.valor);
                });

                $(".contenedor_formulario").show()
            });
        };
    },
    limpiarPantalla: function () {
        $("[campo]").each(function () {
            $(this).val("");
        });
    }
}