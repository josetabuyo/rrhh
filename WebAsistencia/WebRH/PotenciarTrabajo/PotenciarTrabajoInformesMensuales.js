$(document).ready(function () {
    Backend.start(function () {

      var seccion = new SeccionEstadoInformesParticipacion();

      $("#pt_detalle_mensual").hide();
      $("#pt_boton_informes_mensuales").click(() => {

        $(".pt_selected_section_button").removeClass("pt_selected_section_button");
        $("#pt_boton_informes_mensuales").addClass("pt_selected_section_button");

        seccion.render();
      });

    });
});

class SeccionEstadoInformesParticipacion {
  constructor() {
    this.tablaInformesParticipacion = new TablaInformesParticipacion();
  }
  render() {
    this.tablaInformesParticipacion.render(); // DEBUG: pregunta a Char: debo pasar parámetro usuario? quien es ese parámetro?
  }
}


class TablaInformesParticipacion extends TablaPT{
  constructor () {
    super();
    self = this;
    this.tablaInformesParticipacionDetalleMensual =  new TablaInformesParticipacionDetalleMensual();

    Backend.PT_Get_Estado_Informes_Participacion_Por_Periodo()
      .onSuccess((informes_participacion) => {
        _.forEach(informes_participacion, (i) => {
          var fila = $("<tr>");


          fila.attr("Anio", i.Entidad.Anio);
          fila.attr("Mes", i.Entidad.Mes);


          this.agregarCeldaTextoAFila(fila, i.Entidad.Anio);

          const celda = $("<td>")
          celda.text(i.Entidad.Mes);

          const icono_lupa = $("<img>");
          icono_lupa.attr("src", "IconoLupa.png");
          icono_lupa.addClass("pt_icono_lupa");
          icono_lupa.click(() => {

            fila = icono_lupa.parent().parent();

            self.tablaInformesParticipacionDetalleMensual.render(fila.attr("Anio"), fila.attr("Mes"));
          });
          celda.append(icono_lupa);
          fila.append(celda);


          this.agregarCeldaTextoAFila(fila, i.Ent_SinCarga);
          this.agregarCeldaTextoAFila(fila, i.Ent_EnProceso);
          this.agregarCeldaTextoAFila(fila, i.Ent_ConInforme);
          this.agregarCeldaTextoAFila(fila, i.Partic_SinCarga);
          this.agregarCeldaTextoAFila(fila, i.Partic_EnProceso);
          this.agregarCeldaTextoAFila(fila, i.Partic_ConInforme);

          fila.addClass("pt_fila_informes_mensuales");
          $("#pt_tabla_informes_mensuales").append(fila);
        });
      })
      .onError(function (e) {
        console.error("error al obtener niveles de participacion: " + e);
      });
  }
  render () {
      $(".pt_seccion").hide();
      $("#pt_seccion_informes_mensuales").show();
      $("#pt_detalle_mensual").hide();
  }
}



class TablaInformesParticipacionDetalleMensual extends TablaPT{
  constructor () {
    super();
  }
  render (anio, mes) {

      // DEBUG: quiero ver si llegan los parametros
      console.log(anio, mes);


      $("#pt_detalle_mensual").show();



      Backend.PT_Get_Estado_Informes_Participacion_Por_PeriodoyEntidad(anio, mes) // TODO: , "usuario")
        .onSuccess((informes_participacion) => {


          $("#pt_tabla_informes_participacion_detalle_mensual").find(".pt_fila_informes_participacion_detalle_mensual").remove();

          _.forEach(informes_participacion, (i) => {
            var fila = $("<tr>");

            // TODO: TBD es To Be Defined
            this.agregarCeldaTextoAFila(fila, "TBD Entidad TBD Entidad TBD");
            this.agregarCeldaTextoAFila(fila, i.Entidad.Nombre_Entidad);


            var celda = $("<td>");
            celda.text(i.Cant_Personas);
            var icono_lupa = $("<img>");
            icono_lupa.attr("src", "IconoLupa.png");
            icono_lupa.addClass("pt_icono_lupa");
            icono_lupa.click(() => {
              // TODO:
              alert("En construcción TBD")
            });
            celda.append(icono_lupa);
            fila.append(celda);

            this.agregarCeldaTextoAFila(fila, i.Entidad.Estado);


            // TODO: TBD es To Be Defined
            var celda = $("<td>");
            celda.text("TBD SI");
            var icono_lupa = $("<img>");
            icono_lupa.attr("src", "IconoLupa.png");
            icono_lupa.addClass("pt_icono_lupa");
            icono_lupa.click(() => {
              // TODO:
              alert("En construcción TBD")
            });
            celda.append(icono_lupa);
            fila.append(celda);

            this.agregarCeldaTextoAFila(fila, i.Entidad.Id_Informe);

            fila.addClass("pt_fila_informes_participacion_detalle_mensual");
            $("#pt_tabla_informes_participacion_detalle_mensual").append(fila);
          });
        })
        .onError(function (e) {
          console.error("error al obtener niveles de participacion: " + e);
        });


  }
}
