$(document).ready(function () {
    console.warn('document ready');
    Backend.start(function () {
      console.warn('backend started');
      $("#pt_boton_carga_participacion").click(() => {
        var seccion = new SeccionEstadoCargaParticipacion();
        seccion.render();
        $("#pt_boton_carga_participacion").addClass("pt_selected_section_button");
      });
    });
});

class SeccionEstadoCargaParticipacion {
  constructor() {
    this.tablaMensual = new TablaParticipacionMensual();
  }

  render () {
    $("#pt_estado_semanal").hide();
    $("#pt_estado_mensual").show();
    Backend.PTGetEstadoCargaParticipacionPorPeriodo("1")
      .onSuccess((estados) => {
          console.warn('estados obtenidos:', estados);
          this.tablaMensual.render(estados);
      })
      .onError(function (e) {
          this.alertify.error("error al obtener asistencias: " + e);
      });
  }
}

class TablaPT {
  agregarCeldaTextoAFila(fila, contenido) {
    var celda = $("<td>")
    celda.text(contenido);
    fila.append(celda);
  }
}

class TablaParticipacionMensual extends TablaPT{
  constructor () {
    super();
    this.tablaSemanal = new TablaParticipacionSemanal();
  }

  render (estados) {
    $("#pt_tabla_participacion_mensual").find(".pt_fila_participacion_mensual").remove();
    _.forEach(estados, (e) => {
      const fila = $("<tr>")
      this.agregarCeldaTextoAFila(fila, e.nombreGrupoTrabajo);
      this.agregarCeldaTextoAFila(fila, e.activos);
      this.agregarCeldaTextoAFila(fila, e.suspendidos);
      this.agregarCeldaTextoAFila(fila, e.incompatibles);
      this.agregarCeldaTextoAFila(fila, e.activos + e.suspendidos + e.incompatibles);
      this.agregarCeldaTextoAFila(fila, e.sinCarga);
      this.agregarCeldaTextoAFila(fila, e.parciales);

      const celda = $("<td>")
      celda.text(e.completos);
      const icono_lista = $("<img>");
      icono_lista.attr("src", "IconoLista.png");
      icono_lista.addClass("pt_icono_lista");
      icono_lista.click(() => {
        Backend.PTGetAsistenciasPorGrupoYPeriodo(e.idGrupoTrabajo)
          .onSuccess((personas) => {
              $("#pt_estado_mensual").hide();
              $("#pt_estado_semanal").show();
              this.tablaSemanal.render(personas);
          })
          .onError(function (e) {
              this.alertify.error("error al obtener asistencias: " + e);
          });
      });
      celda.append(icono_lista);
      fila.append(celda);

      this.agregarCeldaTextoAFila(fila, e.conInforme);
      fila.addClass("pt_fila_participacion_mensual");
      $("#pt_tabla_participacion_mensual").append(fila);
    });
  }
}

class TablaParticipacionSemanal {
  render (personas) {
    $("#pt_tabla_participacion_semanal").find(".pt_fila_participacion_semanal").remove();
    _.forEach(personas, (p) => {
      var fila = $("<tr>")

      var celda = $("<td>")
      celda.text(p.cuil);
      fila.append(celda);

      celda = $("<td>")
      celda.text(p.nombre);
      fila.append(celda);

      this.renderComboAsistencia(fila, p.asistSemana1);
      this.renderComboAsistencia(fila, p.asistSemana2);
      this.renderComboAsistencia(fila, p.asistSemana3);
      this.renderComboAsistencia(fila, p.asistSemana4);

      celda = $("<td>")
      celda.text(p.observaciones);
      fila.append(celda);
      fila.addClass("pt_fila_participacion_semanal");
      $("#pt_tabla_participacion_semanal").append(fila);
    });
  }

  renderComboAsistencia (fila, asistencia) {
    var celda = $("<td>")
    var combo_semanal = $("#pt_plantillas").find(".cmb_porcentaje_asistencia").clone();
    combo_semanal.val(asistencia === '' ? '100' : asistencia);
    celda.append(combo_semanal);
    fila.append(celda);
  }
}
