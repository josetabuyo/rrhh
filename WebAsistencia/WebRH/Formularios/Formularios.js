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

        selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
            Backend.GetFormulario(1, la_persona_seleccionada.id).onSuccess(function (formulario) {
                


            });
        };
    });
});