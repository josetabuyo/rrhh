var AdministradorDeLugaresDeTrabajo = function () {
    var json_areas = Backend.ejecutarSincronico("GetAreasParaLugaresDeTrabajo", []);
    var areas = [];
    for (var i = 0; i < json_areas.length; i++) {
        areas.push(new Area(json_areas[i]));
    }
    contenedorPlanilla = $('#ContenedorPlanilla');
    var columnas = [];

    columnas.push(new Columna("Área", { generar: function (un_area) {
        return un_area.nombre();
    }
    }));
    columnas.push(new Columna("Teléfonos", { generar: function (un_area) {
        return un_area.telefonos();
    }
    }));
    columnas.push(new Columna("Correo Electrónico", { generar: function (un_area) {
        return un_area.mails();
    }
    }));
    columnas.push(new Columna("Dirección", {
        generar: function (un_area) {
            var direccion = un_area.direccion();
            var cont = $("<div>").css("width", "320px").append(direccion);
            return cont;
        }
    }));

    // Backend.sync.ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre("mau_usuarios_por_area").onSuccess(function (tiene_permisos) {

    if (Backend.sync.ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre("mau_usuarios_por_area")) {

        columnas.push(new Columna("Cant. Usuarios", {
            generar: function (un_area) {
                var div = $("<div>");
                var cantidad = un_area._area.CantidadDeUsuarios;
                var link = $('<a>');
                link.attr('style', 'margin-left:20px');
                var img = $('<img>');
                img.attr('src', '../Imagenes/Botones/lupa.png');
                img.attr('width', '30px');
                img.attr('height', '30px');
                //var world = "A string with symbols / characters that have special meaning?";
                //var uri = 'http://example.com/foo?hello=' + encodeURIComponent(world);
                link.attr('href', '../Mau/AdministradorDeUsuarios.aspx?Nombre=' + encodeURIComponent(un_area._area.Alias));
                link.append(img);
                //link.text(' (Ver detalle)');
                div.append(cantidad);
                div.append(link);
                return div;
            }
        }));
    }
    // });


    PlanillaAreas = new Grilla(columnas);

    PlanillaAreas.AgregarEstilo("tabla_macc");
    PlanillaAreas.AgregarEstilo("tabla_protocolo");

    PlanillaAreas.SetOnRowClickEventHandler(function (un_area) {
        var vista = new VistaDeArea({ area: un_area });
        vista.mostrarModal();
    });

    PlanillaAreas.CargarObjetos(areas);
    PlanillaAreas.DibujarEn(contenedorPlanilla);

    var options = {
        valueNames: ['Área', 'Teléfonos', 'Correo Electrónico', 'Dirección'],
        page: 2000
    };

    var featureList = new List('ContenedorPrincipal', options);

    // This must be a hyperlink
    $("#exportar").on('click', function (event) {

        // Temporary delimiter characters unlikely to be typed by keyboard
        // This is to avoid accidentally splitting the actual contents
        var tmpColDelim = String.fromCharCode(11); // vertical tab character
        var tmpRowDelim = String.fromCharCode(0); // null character

        // actual delimiter characters for CSV format
        var colDelim = '";"';
        var rowDelim = '"\r\n"';


        var csv = '"';

        csv += "Area" + colDelim;
        csv += "Telefonos" + colDelim;
        csv += "Correo Electronico" + colDelim;
        csv += "Direccion" + colDelim;
        csv += "CP" + colDelim;
        csv += "Localidad" + colDelim;
        csv += "Provincia" + rowDelim;

        _.forEach(areas, function (a) {
            csv += a.nombre().replace(/"/g, '""') + colDelim;
            csv += a.telefonos().replace(/"/g, '""') + colDelim;
            csv += a.mails().replace(/"/g, '""') + colDelim;

            if (a._area.DireccionSeparada != null && a._area.DireccionSeparada != "") {
                csv += a._area.DireccionSeparada.Calle.replace(/"/g, '""') + colDelim;
                csv += a._area.DireccionSeparada.CP.replace(/"/g, '""') + colDelim;
                csv += a._area.DireccionSeparada.Localidad.replace(/"/g, '""') + colDelim;
                csv += a._area.DireccionSeparada.Provincia.replace(/"/g, '""') + rowDelim;
            } else {
                csv += "";
                csv += "";
                csv += "";
                csv += "";
            }
            csv += '"\r\n"';
        });

        csv += '"';

        //        // Grab text from table into CSV formatted string
        //            csv = '"' + $rows.map(function (i, row) {
        //                var $row = $(row),
        //                    $cols = $row.find('td, th');

        //                return $cols.map(function (j, col) {
        //                    var $col = $(col),
        //                        text = $col.text();

        //                    return text.replace(/"/g, '""'); // escape double quotes

        //                }).get().join(tmpColDelim);

        //            }).get().join(tmpRowDelim)
        //                .split(tmpRowDelim).join(rowDelim)
        //                .split(tmpColDelim).join(colDelim) + '"',

        // Data URI
        var csvData = 'data:application/csv;charset=utf-8,\uFEFF' + encodeURIComponent(csv);

        $(this)
            .attr({
                'download': "LugaresDeTrabajo.csv",
                'href': csvData,
                'target': '_blank'
            });
    });
}
