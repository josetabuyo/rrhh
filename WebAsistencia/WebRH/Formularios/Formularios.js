$(document).ready(function () {
    Backend.start(function () {
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
            Backend.GuardarCambiosEnFormulario(form_cambios);
        });
        selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
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


            });
        };
    });
});