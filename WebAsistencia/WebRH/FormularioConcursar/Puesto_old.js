var Puesto = {
    armarLista: function (puestos, postulaciones) {
        var _this = this;


        //_this.divListado = $('#listado_puestos');
        _this.divGrilla = $('#tabla_puestos');

        var columnas = [];

        /*columnas.push(new Columna("Id", { generar: function (un_puesto) { return un_puesto.Id } }));*/
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
        columnas.push(new Columna("Comité&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", { generar: function (un_puesto) {
            var linkComite = $('<a>');
            linkComite[0].innerHTML = "Comite: " + un_puesto.Comite.Numero;

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
                        alertify.alert("", "Error");
                    }
                });
            });



            return linkComite;
        }
        }));

        var generador_de_celda_acciones = {
            generar: function (un_puesto) {
                var linkPostularse;
                lista_postulaciones = postulaciones;
                var estoy_postulado = false;

                for (var i = 0; i < lista_postulaciones.length; i++) {
                    if (postulaciones[i].Puesto.Id == un_puesto.Id) estoy_postulado = true;
                }
                if (estoy_postulado) {
                    linkPostularse = $('<div>')
                    linkPostularse.text("Postulado")
                } else {
                    linkPostularse = $('<a>')
                    linkPostularse[0].innerHTML = "Postularse";
                    linkPostularse.attr('href', '#');
                    linkPostularse.click(function (e) {
                        var proveedor_ajax = new ProveedorAjax();

                        proveedor_ajax.postearAUrl({ url: "SetObjetoEnSesion",
                            data: {
                                nombre: 'Puesto',
                                objeto: JSON.stringify(un_puesto)
                            },
                            success: function (respuesta) {
                                window.location.href = 'PreInscripcion.aspx?id=' + un_puesto.Id;
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert("", "Error");
                            }
                        });
                    });
                }
                return linkPostularse;
            }
        };

        columnas.push(new Columna('Acciones', generador_de_celda_acciones));

        this.GrillaDePuestos = new Grilla(columnas);
        this.GrillaDePuestos.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaDePuestos.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
        this.GrillaDePuestos.SetOnRowClickEventHandler(function (un_puesto) {
        });

        this.GrillaDePuestos.CargarObjetos(puestos);
        this.GrillaDePuestos.DibujarEn(_this.divGrilla);

    }
}


