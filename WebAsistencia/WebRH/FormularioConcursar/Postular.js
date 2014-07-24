var Postulacion = {
    armarPostulacion: function () {
        var _this = this;

        //_this.divListado = $('#listado_puestos');
        //_this.divGrilla = $('#tabla_puestos');

         _this.idPuesto = getVarsUrl();
         _this.idPersona = _this.ui.find("#txt_matricula_fecha_inscripcion");
         _this.txt_motivo = _this.ui.find("#txt_matricula_situacion");
         _this.txt_observaciones = _this.ui.find("#txt_matricula_situacion");

        _this.btn_guardar.click(function () {
            var postulacion = {};
                postulacion.IdPuesto = _this.idPuesto;
                //postulacion.IdPersona = _this.txt_competencias_informaticas_establecimiento.val();
                //postulacion.FechaPostulacion = _this.txt_competencias_informaticas_fecha_obtencion.datepicker('getDate').toISOString();
                postulacion.Motivo = _this.cmb_competencias_informaticas_localidad.val();
                postulacion.Observaciones = _this.cmb_competencias_informaticas_pais.val();
               

                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "ActualizarCvCompetenciaInformatica",
                    data: {
                        competencia_informatica: competencia_informatica,
                    },
                    success: function (respuesta) {
                        alertify.alert("La competencia fue actualizada correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al actualizar la competencia informática.");
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
$('#txt_fechaNac').datepicker({
    dateFormat: 'dd/mm/yy',
    onClose: function () {

    }
});


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

