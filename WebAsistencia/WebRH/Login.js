require(["Scripts/ConfigRequire.js"], function () {
    require(["jquery", "vex", "PantallaRegistro"], function ($, vex, PantallaRegistro) {
        $(function () {
            vex.defaultOptions.className = 'vex-theme-os';
            var lnk_registrarse = $("#lnk_registrarse");
            lnk_registrarse.click(function () {
                PantallaRegistro.abrir();
            });
        });
    });
});