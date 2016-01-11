$(document).ready(function () {
    Backend.start(function () {
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