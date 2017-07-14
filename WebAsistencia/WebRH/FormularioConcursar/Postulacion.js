var Postulacion = {
    armarPostulacion: function (perfil) {
        var _this = this;

        //_this.divListado = $('#listado_puestos');
        //_this.divGrilla = $('#tabla_puestos');
        //_this.ui = $("#fondo_form");
        _this.perfil = perfil; // getVarsUrl();
        _this.btn_postular = $("#btn_postularse");
        //_this.idPersona = _this.ui.find("#txt_matricula_fecha_inscripcion");

        _this.perfil_numero = $("#puesto_numero");
        _this.perfil_numero.innerHTML = perfil.Numero;
        _this.perfil_convocante = $("#puesto_convocante");
        _this.perfil_convocante.text("Ministerio de Desarrollo Social de la Nación");
        _this.perfil_denominacion = $("#puesto_denominacion");
        _this.perfil_denominacion.text(perfil.Denominacion);
        _this.perfil_secretaria = $("#puesto_secretaria");
        _this.perfil_secretaria.text("Secretaria");
        _this.perfil_agrupamiento = $("#puesto_agrupamiento");
        _this.perfil_agrupamiento.text(perfil.Agrupamiento);
        _this.perfil_cargo = $("#puesto_cargo");
        _this.perfil_cargo.text(perfil.Denominacion);
        _this.perfil_convocatoria = $("#puesto_convocatoria");
        _this.perfil_convocatoria.text(perfil.Tipo);
        _this.perfil_destino = $("#puesto_destino");
        _this.perfil_destino.text("9 de Julio");
        _this.perfil_nivel = $("#puesto_nivel");
        _this.perfil_nivel.text(perfil.Nivel);

        _this.txt_motivo = $("#txt_motivo");
        _this.txt_observaciones = $("#txt_observaciones");

        _this.btn_postular.click(function () {
            if (!($('#chk_bases').attr('checked'))) {
                alertify.alert("", 'Debe aceptar los términos y bases del concurso');
                return;
            }

            if ($('#informeGrafico_00').val() == '') {
                alertify.alert("", 'Debe ingresar al menos 1 número de INFORME GRÁFICO');
                return;
            }


            var postulacion = {};
            postulacion.Perfil = _this.perfil; // parseInt(_this.Puesto.id);
            //postulacion.IdPersona = _this.txt_competencias_informaticas_establecimiento.val();
            //postulacion.FechaPostulacion = _this.txt_competencias_informaticas_fecha_obtencion.datepicker('getDate').toISOString();
            postulacion.Motivo = _this.txt_motivo.val();
            postulacion.Observaciones = _this.txt_observaciones.val();

            var inputs = $('.informesGraficos');
            var informes = [];
            var textoConcatenado = "";

            $.each(inputs, function (key, value) {
                if (value.value != '') {
                    informes.push(value.value);
                    textoConcatenado += value.value + ', ';
                }
            });

            postulacion.NumerosDeInformeGDE = informes;


            //return;
            //CAMBIAR A PARTE NUEVA?
            var proveedor_ajax = new ProveedorAjax();


            proveedor_ajax.postearAUrl({ url: "PostularseA",
                data: {
                    una_postulacion: postulacion
                },
                success: function (postulacion) {
                    alertify.alert("", "Usted se postuló correctamente al perfil " + postulacion.Perfil.Denominacion + ". <br> Número de postulación: " + postulacion.Numero + "<br> Números de Informe GDE: " + textoConcatenado, function () {
                        proveedor_ajax.postearAUrl({ url: "SetObjetoEnSesion",
                            data: {
                                nombre: 'Postulacion', //postulacion
                                objeto: JSON.stringify(postulacion)
                            },
                            success: function (respuesta) {
                                window.location.href = "PostInscripcion.aspx?id=" + postulacion.Id + "&fh=" + postulacion.FechaPostulacion + "&num=" + postulacion.Numero + "&gde=" + textoConcatenado;
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert("", "Error");
                            }
                        }); //alModificar(respuesta);
                        //$(".modal_close_concursar").click();
                        //window.location.href = 'PostInscripcion.aspx?id=' + respuesta.Id;
                        //window.location.href = 'FichaInscripcionCVDeclaJurada.aspx?id=' + respuesta.Id;
                    });
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alertify.alert("", errorThrown);
                }
            });

        });

    }
}


 function getVarsUrl() {
          var url = location.search.replace("?", "");
          var arrUrl = url.split("&");
          var urlObj = {};
          for (var i = 0; i < arrUrl.length; i++) {
              var x = arrUrl[i].split("=");
              urlObj[x[0]] = x[1]
          }
          return urlObj;
      }



