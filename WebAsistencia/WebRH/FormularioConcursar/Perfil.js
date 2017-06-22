var Perfil = {
    armarLista: function (perfiles, postulaciones, curriculum) {
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
            linkPDF.attr('href', 'https://rrhh.desarrollosocial.gob.ar/FormularioConcursar/bases/Conv03_2017_Perfil_' + un_perfil.Numero + '.pdf');
            linkPDF.attr('target', '_blank');
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
                        alertify.alert("", "Error");
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
                experienciasLaborales = curriculum.CvExperienciaLaboral;
                var estoy_postulado = false;
                var pertenezco_a_SINEP = false;

                for (var i = 0; i < lista_postulaciones.length; i++) {
                    if (postulaciones[i].Perfil.Id == un_perfil.Id) estoy_postulado = true;
                }
                for (var i = 0; i < experienciasLaborales.length; i++) {
                    if (experienciasLaborales[i].AmbitoLaboral == 1 && experienciasLaborales[i].Vigente == true) pertenezco_a_SINEP = true;
                }

                var hoy = _this.armarFechaDeHoy();

                if (hoy >= un_perfil.FechaDesde && hoy <= un_perfil.FechaHasta) {
                    if ((un_perfil.Tipo == 'General' && pertenezco_a_SINEP) || un_perfil.Tipo == 'Abierta') {

                        if (estoy_postulado) {
                            linkPostularse = $('<div>');
                            linkPostularse.text("Postulado");
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
                                        alertify.alert("", "Error");
                                    }
                                }); //termina el ajax
                            }); //termina el click
                        } //termina el if
                    } else if (un_perfil.Tipo == 'General' && !(pertenezco_a_SINEP)) {
                        linkPostularse = $('<div>');
                        linkPostularse.text("Usted no puede postularse por no estar trabajando actualmente bajo el marco del SINEP (ver aclaración abajo)");
                    }

                } else if (hoy < un_perfil.FechaDesde) {
                    linkPostularse = $('<div>');
                    linkPostularse.text("Aun no se abrieron las inscripciones");
                    //alert("Aun no se abrieron las inscripciones");
                } else if (hoy > un_perfil.FechaHasta) {
                    linkPostularse = $('<div>');
                    linkPostularse.text("Ya finalizó la inscripción");
                    //alert('Ya finalizó la inscripción');
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

    },
    armarFechaDeHoy: function () {
        var d = new Date();

        var month = d.getMonth() + 1;
        var day = d.getDate();
        var hour = d.getHours();
        var minute = d.getMinutes();
        var second = d.getSeconds();

        var hoy = d.getFullYear() + '-' +
                (('' + month).length < 2 ? '0' : '') + month + '-' +
                (('' + day).length < 2 ? '0' : '') + day + 'T' +
                (('' + hour).length < 2 ? '0' : '') + hour + ':' +
                (('' + minute).length < 2 ? '0' : '') + minute + ':' +
                (('' + second).length < 2 ? '0' : '') + second;

        return hoy;
    },
    traerPerfiles: function () {
        var _this = this;

        var perfiles = Backend.ejecutarSincronico("GetCvPerfiles", []);

        for (i = 0; i < perfiles.length; i++) {
            $('#combo_perfiles').append('<option value=' + perfiles[i].Id + ' data-agrupamiento=' + perfiles[i].Agrupamiento + ' data-nivel=' + perfiles[i].Nivel +
            'data-tipo=' + perfiles[i].Tipo + '>' + perfiles[i].Denominacion + '</option>');
        }

        $('#combo_perfiles').change(function () {
            var idPerfil = this.selectedOptions[0].value;
            $('#puesto_denominacion').html(this.selectedOptions[0].text);
            $('#puesto_agrupamiento').html(this.selectedOptions[0].dataset.agrupamiento);
            $('#nivel_escalafonario').html(this.selectedOptions[0].dataset.nivel);
            $('#puesto_tipo').html(this.selectedOptions[0].dataset.tipo);
            $('#jurisdiccion').html('Ministerio de Desarrollo Social');


        });


    }
}


