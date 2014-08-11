var Puesto = {
    armarLista: function (puestos) {
        var _this = this;

        //_this.divListado = $('#listado_puestos');
        _this.divGrilla = $('#tabla_puestos');

        var columnas = [];

        columnas.push(new Columna("Id", { generar: function (un_puesto) { return un_puesto.Id } }));
        columnas.push(new Columna("Puesto", { generar: function (un_puesto) { return un_puesto.Denominacion } }));
        columnas.push(new Columna("Nivel", { generar: function (un_puesto) { return un_puesto.Nivel } }));
        columnas.push(new Columna("Agrupamiento", { generar: function (un_puesto) { return un_puesto.Agrupamiento } }));
        columnas.push(new Columna("Vacantes", { generar: function (un_puesto) { return un_puesto.Vacantes } }));
        columnas.push(new Columna("Convocatoria", { generar: function (un_puesto) { return un_puesto.Tipo } }));
        columnas.push(new Columna('Nombre PDF', { generar: function (un_puesto) {
            var linkPDF = $('<a>');
            linkPDF.attr('href', '../Imagenes/' + un_puesto.Id + '.pdf');
            var img = $('<img>');
            img.attr('src', '../Imagenes/archivo.png');
            img.attr('width', '35px');
            img.attr('height', '35px');
            linkPDF.append(img);

            return linkPDF;
        }
        }));
        columnas.push(new Columna("Comité", { generar: function (un_puesto) {
            var linkComite = $('<a>');
            linkComite[0].innerText = "Comite: " + un_puesto.Comite.Numero;

            linkComite.click(function (e) {
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "SetObjetoEnSesion",
                    data: {
                        nombre: 'comite',
                        objeto: JSON.stringify(un_puesto.Comite)
                    },
                    success: function (respuesta) {
                        window.location.href = 'Comites.aspx?id=' + un_puesto.Comite.Numero;
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error");
                    }
                });
            });



            return linkComite;
            }}));
        columnas.push(new Columna('Acciones', { generar: function (un_puesto) {
            var linkPostularse = $('<a>');
            linkPostularse[0].innerText = "Postularse";

            linkPostularse.click(function (e) {
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "SetPuestoEnSesion",
                    data: {
                        puesto: un_puesto
                    },
                    success: function (respuesta) {
                        window.location.href = 'PreInscripcion.aspx?id=' + un_puesto.Id;
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error");
                    }
                });
            });

            return linkPostularse;
        } 
        }));

        this.GrillaDePuestos = new Grilla(columnas);
        this.GrillaDePuestos.AgregarEstilo("table table-striped");
        this.GrillaDePuestos.SetOnRowClickEventHandler(function (un_puesto) {
        });

        this.GrillaDePuestos.CargarObjetos(puestos);
        this.GrillaDePuestos.DibujarEn(_this.divGrilla);

    }
}


