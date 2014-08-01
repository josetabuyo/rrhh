var Postulacion = {
    armarPostulacion: function (puesto) {
        var _this = this;

        //_this.divListado = $('#listado_puestos');
        //_this.divGrilla = $('#tabla_puestos');
        //_this.ui = $("#fondo_form");
        _this.Puesto = getVarsUrl();
        _this.btn_postular = $("#btn_postularse");
         //_this.idPersona = _this.ui.find("#txt_matricula_fecha_inscripcion");
        
        _this.puesto_numero = $("#puesto_numero");
        _this.puesto_numero.innerHTML = puesto.Numero;
        _this.puesto_convocante = $("#puesto_convocante");
        _this.puesto_convocante.text("Ministerio de Desarrollo Social de la Nación");
        _this.puesto_denominacion = $("#puesto_denominacion");
        _this.puesto_denominacion.text(puesto.Denominacion);
        _this.puesto_secretaria = $("#puesto_secretaria");
        _this.puesto_secretaria.text("Secretaria");
        _this.puesto_agrupamiento = $("#puesto_agrupamiento");
        _this.puesto_agrupamiento.text(puesto.Agrupamiento);
        _this.puesto_cargo = $("#puesto_cargo");
        _this.puesto_cargo.text(puesto.Denominacion);
        _this.puesto_convocatoria = $("#puesto_convocatoria");
        _this.puesto_convocatoria.text(puesto.Tipo);
        _this.puesto_destino = $("#puesto_destino");
        _this.puesto_destino.text("9 de Julio");
        _this.puesto_nivel =  $("#puesto_nivel");
        _this.puesto_nivel.text(puesto.Nivel);
        
        _this.txt_motivo = $("#txt_motivo");
        _this.txt_observaciones = $("#txt_observaciones");

        _this.btn_postular.click(function () {
        if (!($('#chk_bases').attr('checked'))) {
                alertify.alert('Debe aceptar los términos y bases del concurso');
                return;
            }
            var postulacion = {};
                postulacion.IdPuesto = parseInt(_this.Puesto.id);
                //postulacion.IdPersona = _this.txt_competencias_informaticas_establecimiento.val();
                //postulacion.FechaPostulacion = _this.txt_competencias_informaticas_fecha_obtencion.datepicker('getDate').toISOString();
                postulacion.Motivo =  _this.txt_motivo.val();
                postulacion.Observaciones = _this.txt_observaciones.val();
                
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "PostularseA",
                    data: {
                        una_postulacion: postulacion,
                    },
                    success: function (respuesta) {
                        alertify.alert("Usted se postuló correctamente. <br> Número de postulación: " + respuesta.Id );
                        //alModificar(respuesta);
                        //$(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al postularse.");
                     }
                  });

            });

    }
}// Botón para Ir Arriba


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

jQuery(document).ready(function () {
    jQuery("#IrArriba").hide();
    jQuery(function () {
        jQuery(window).scroll(function () {
            if (jQuery(this).scrollTop() > 200) {
                jQuery('#IrArriba').fadeIn();
            } else {
                jQuery('#IrArriba').fadeOut();
            }
        });
        jQuery('#IrArriba a').click(function () {
            jQuery('body,html').animate({
                scrollTop: 0
            }, 800);
            return false;
        });
    });

});


//DatePicker del formulario de DatosPersonales
//$('#txt_fechaNac').datepicker({
//    dateFormat: 'dd/mm/yy',
//    onClose: function () {

//    }
//});


//var ParsearFecha = function (fecha) {
//    var day = parseInt(fecha.split("/")[0]);
//    var month = parseInt(fecha.split("/")[1]);
//    var year = parseInt(fecha.split("/")[2]);

//    return new Date(year, month, day);
//}




//var AgregarEnTabla = function (tabla, datos) {

//    var n = $('tr:last td', tabla).length;
//    var valores = new Array();

//    //FC: el map inspecciona cada key o cada valor del objeto o array que le pase
//    jQuery.map(datos, function (value, key) {
//        valores.push(value)
//    });

//    var tds = '<tr>';
//    for (var i = 0; i < n; i++) {

//        tds += '<td>' + valores[i] + '</td>';
//    }
//    tds += '</tr>';

//    tabla.append(tds);
//}

