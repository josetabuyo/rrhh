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
                Id: formulario.Id,
                IdPersona: formulario.IdPersona,
                Campos: []
            }

            for (var campo_cambio in cambios) {
                if (cambios.hasOwnProperty(campo_cambio)) {
                    form_cambios.Campos.push({
                        campo: campo_cambio,
                        valor: cambios[campo_cambio]
                    });
                }
            }

            console.log(form_cambios);
            Backend.GuardarCambiosEnFormulario(form_cambios);
        });
        selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
            Backend.GetFormulario(JSON.stringify({ Documento: la_persona_seleccionada.documento })).onSuccess(function (formulario) {
                //            formulario = {
                //                Id: 1,
                //                Nombre: "Relevamiento de contrato",
                //                IdPersona: 111,
                //                Campos: [
                //                        { campo: "nombre", valor: "agustin" },
                //                        { campo: "apellido", valor: "calcagno" }
                //                    ]
                //            };

                $("[campo]").each(function () {
                    var campo = _.findWhere(formulario.Campos, { campo: $(this).attr("campo") });
                    if (campo) $(this).val(campo.valor);
                });


            });
        };
    });
});