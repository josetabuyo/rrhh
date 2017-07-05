var Comite = {
    mostrarComite: function () {
        var _this = this;

        var proveedor_ajax = new ProveedorAjax();

        proveedor_ajax.postearAUrl({ url: "GetObjetoEnSesion",
            data: {
                nombre: 'comite'
            },
            success: function (respuesta) {
                var comite = JSON.parse(respuesta);
                _this.armarTablasComite(comite);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert("", "Error al querer ver el comite.");
            }
        });

    },
    armarTablasComite: function (comite) {
        var _this = this;
        this.div_comite_titular = $('#comite_titular');
        this.div_comite_suplente = $('#comite_suplente');

        var columnas = [];
        columnas.push(new Columna("DNI", { generar: function (un_comite) { return un_comite.NroDocumento } }));
        columnas.push(new Columna("Apellido", { generar: function (un_comite) { return un_comite.Apellido } }));
        columnas.push(new Columna("Nombre", { generar: function (un_comite) { return un_comite.Nombre } }));
        columnas.push(new Columna("CV", { generar: function (un_comite) {
            if (_this.existeUrl("cv/CV_" + un_comite.NroDocumento + ".pdf")) {
                var linkPDF = $('<a>');
                linkPDF.attr('href', 'cv/CV_' + un_comite.NroDocumento + '.pdf');
                linkPDF.attr('target', '_blank');
                var img = $('<img>');
                img.attr('src', '../Imagenes/archivo.png');
                img.attr('width', '35px');
                img.attr('height', '35px');
                linkPDF.append(img);

                return linkPDF;

            } else {
                return '';
            }

        }
        }));

        var comite_titular = Enumerable.From(comite.Integrantes)
                .Select(function (x) { return x })
                .Where(function (x) { return x.EsTitular == 1 })
                .ToArray();

        var comite_suplente = Enumerable.From(comite.Integrantes)
                .Select(function (x) { return x })
                .Where(function (x) { return x.EsTitular == 0 })
                .ToArray();


        this.GrillaDeComiteTitular = new Grilla(columnas);
        this.GrillaDeComiteTitular.AgregarEstilo("table table-striped");
        this.GrillaDeComiteTitular.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
        this.GrillaDeComiteTitular.SetOnRowClickEventHandler(function (un_comite) {
        });

        this.GrillaDeComiteTitular.CargarObjetos(comite_titular);
        this.GrillaDeComiteTitular.DibujarEn(_this.div_comite_titular);

        this.GrillaDeComiteSuplente = new Grilla(columnas);
        this.GrillaDeComiteSuplente.AgregarEstilo("table table-striped");
        this.GrillaDeComiteSuplente.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
        this.GrillaDeComiteSuplente.SetOnRowClickEventHandler(function (un_comite) {
        });

        this.GrillaDeComiteSuplente.CargarObjetos(comite_suplente);
        this.GrillaDeComiteSuplente.DibujarEn(_this.div_comite_suplente);
    },
    existeUrl: function (url) {
        var http = new XMLHttpRequest();
        http.open('HEAD', url, false);
        http.send();
        return http.status != 404;
    }
}





