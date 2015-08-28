var Perfil = {
    armarLista: function (perfiles, postulaciones) {
        var _this = this;


        //_this.divListado = $('#listado_puestos');
        _this.divGrilla = $('#tabla_perfiles');

        var columnas = [];

        /*columnas.push(new Columna("Id", { generar: function (un_puesto) { return un_puesto.Id } }));*/
        columnas.push(new Columna("Perfil", { generar: function (un_perfil) { return un_perfil.Denominacion } }));
        columnas.push(new Columna("Nivel", { generar: function (un_perfil) { return un_perfil.Nivel } }));
        columnas.push(new Columna("Agrupamiento", { generar: function (un_perfil) { return un_perfil.Agrupamiento } }));
        columnas.push(new Columna("Vacantes", { generar: function (un_perfil) { return un_perfil.Vacantes } }));
        columnas.push(new Columna("Convocatoria", { generar: function (un_perfil) { return un_perfil.Tipo } }));
        columnas.push(new Columna('Bases del Puesto', { generar: function (un_perfil) {
            var linkPDF = $('<a>');
            linkPDF.attr('href', '../Imagenes/' + un_perfil.Id + '.pdf');
            var img = $('<img>');
            img.attr('src', '../Imagenes/archivo.png');
            img.attr('width', '35px');
            img.attr('height', '35px');
            linkPDF.append(img);

            return linkPDF;
        }
        }));
        columnas.push(new Columna("Comité&nbsp;", { generar: function (un_perfil) {
            var linkComite = $('<a>');
            linkComite[0].innerHTML = un_perfil.Comite.Numero;

            linkComite.click(function (e) {
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "SetObjetoEnSesion",
                    data: {
                        nombre: 'comite',
                        objeto: JSON.stringify(un_perfil.Comite)
                    },
                    success: function (respuesta) {
                        window.location.href = 'Comites.aspx?id=' + un_perfil.Comite.Numero;
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error");
                    }
                });
            });



            return linkComite;
        }
        }));

        var generador_de_celda_acciones = {
            generar: function (un_perfil) {
                var linkPostularse;
                lista_postulaciones = postulaciones;
                var estoy_postulado = false;

                for (var i = 0; i < lista_postulaciones.length; i++) {
                    if (postulaciones[i].Perfil.Id == un_perfil.Id) estoy_postulado = true;
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
                                nombre: 'Perfil',
                                objeto: JSON.stringify(un_perfil)
                            },
                            success: function (respuesta) {
                                window.location.href = 'PreInscripcion.aspx?id=' + un_perfil.Id;
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert("Error");
                            }
                        });
                    });
                }
                return linkPostularse;
            }
        };

        columnas.push(new Columna('Acciones', generador_de_celda_acciones));

        this.GrillaDePerfiles = new Grilla(columnas);
        this.GrillaDePerfiles.AgregarEstilo("cuerpo_tabla_perfil tr td");
        this.GrillaDePerfiles.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
        this.GrillaDePerfiles.SetOnRowClickEventHandler(function (un_perfil) {
        });

        this.GrillaDePerfiles.CargarObjetos(perfiles);
        this.GrillaDePerfiles.DibujarEn(_this.divGrilla);

    }
}


