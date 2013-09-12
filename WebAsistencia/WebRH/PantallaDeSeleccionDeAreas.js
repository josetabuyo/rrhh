var PantallaDeSeleccionDeAreas = function () {
    var json_areas = JSON.parse($('#areasDelUsuarioJSON').val());
    contenedor_areas = $('#contenedor_areas_usuario');
    for (var i = 0; i < json_areas.length; i++) {
        var vista = new VistaDeArea({ area: new Area(json_areas[i]) });
        vista.dibujarEn(contenedor_areas);
    }
}
