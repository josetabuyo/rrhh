﻿$(document).ready(function () {
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

    Backend.PT_Get_Periodos()
      .onSuccess((periodos) => {
          console.log('periodos obtenidos:', periodos);
          periodos.forEach((periodo) => {
            $("#pt_cmb_periodo").append(new Option(
              periodo.Mes + periodo.Anio, periodo.Id));
          });
          $("#pt_cmb_periodo").change((e) => {
              this.periodoSeleccionado = _.findWhere({Id: e.target.value});
              this.render();
          });
          this.periodoSeleccionado = periodos ? periodos[0] : undefined;
          this.render();
      })
      .onError(function (e) {
          console.error("error al obtener periodos: " + e);
      });
  }

  render () {
    $("#pt_estado_semanal").hide();
    $("#pt_estado_mensual").show();
    Backend.PT_Get_Estado_Carga_Participacion_Por_Periodo(this.periodoSeleccionado.Id)
      .onSuccess((estados) => {
          console.log('estados obtenidos:', estados);
          this.tablaMensual.render(estados, this.periodoSeleccionado);
      })
      .onError(function (e) {
          console.error("error al obtener asistencias: " + e);
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

  render (estados, periodo) {
    $("#pt_tabla_participacion_mensual").find(".pt_fila_participacion_mensual").remove();
    _.forEach(estados, (e) => {
      const fila = $("<tr>")
      this.agregarCeldaTextoAFila(fila, e.NombreGrupoTrabajo);
      this.agregarCeldaTextoAFila(fila, e.Activos);
      this.agregarCeldaTextoAFila(fila, e.Suspendidos);
      this.agregarCeldaTextoAFila(fila, e.Incompatibles);
      this.agregarCeldaTextoAFila(fila, e.Activos + e.Suspendidos + e.Incompatibles);
      this.agregarCeldaTextoAFila(fila, e.SinCarga);
      this.agregarCeldaTextoAFila(fila, e.Parciales);

      const celda = $("<td>")
      celda.text(e.Completos);
      const icono_lista = $("<img>");
      icono_lista.attr("src", "IconoLista.png");
      icono_lista.addClass("pt_icono_lista");
      icono_lista.click(() => {
        Backend.PT_Get_Add_Participacion_por_Entidad_Periodo(e.IdGrupoTrabajo, periodo.Id)
          .onSuccess((personas) => {
              $("#pt_estado_mensual").hide();
              $("#pt_estado_semanal").show();
              this.tablaSemanal.render(personas, e.IdGrupoTrabajo, periodo);
          })
          .onError(function (e) {
              this.alertify.error("error al obtener asistencias: " + e);
          });
      });
      celda.append(icono_lista);
      fila.append(celda);

      this.agregarCeldaTextoAFila(fila, e.ConInforme);
      fila.addClass("pt_fila_participacion_mensual");
      $("#pt_tabla_participacion_mensual").append(fila);
    });
  }
}

class TablaParticipacionSemanal extends TablaPT{
  constructor () {
    super();
    Backend.PT_Get_Participaciones_Dato()
      .onSuccess((datos) => {
          this.nivelesDeParticipacion = datos;
      })
      .onError(function (e) {
          this.alertify.error("error al obtener niveles de participacion: " + e);
      });
  }
  render (personas, id_grupo_trabajo, periodo) {
    this.idGrupoTrabajo = id_grupo_trabajo;
    this.periodo = periodo;

    $("#pt_tabla_participacion_semanal").find(".pt_fila_participacion_semanal").remove();
    _.forEach(personas, (p) => {
      var fila = $("<tr>")

      this.agregarCeldaTextoAFila(fila, p.Persona.Cuil);
      this.agregarCeldaTextoAFila(fila, p.Persona.Nombre_Apellido);
      this.renderComboAsistencia(fila, p.Part_Semana1, (nuevo_valor)=>{
        this.updateParticipacionSemanalPersona(p, 1, nuevo_valor);
      });
      this.renderComboAsistencia(fila, p.Part_Semana2, (nuevo_valor)=>{
        this.updateParticipacionSemanalPersona(p, 2, nuevo_valor);
      });
      this.renderComboAsistencia(fila, p.Part_Semana3, (nuevo_valor)=>{
        this.updateParticipacionSemanalPersona(p, 3, nuevo_valor);
      });
      this.renderComboAsistencia(fila, p.Part_Semana4, (nuevo_valor)=>{
        this.updateParticipacionSemanalPersona(p, 4, nuevo_valor);
      });
      this.agregarCeldaTextoAFila(fila, p.Observacion, );

      fila.addClass("pt_fila_participacion_semanal");
      $("#pt_tabla_participacion_semanal").append(fila);
    });
  }

  renderComboAsistencia (fila, asistencia, change_handler) {
    var celda = $("<td>")
    var combo_semanal = $("<select>");
    combo_semanal.addClass("cmb_porcentaje_asistencia");
    this.nivelesDeParticipacion.forEach((nivel) => {
      combo_semanal.append(new Option(nivel.Dato_Participacion, nivel.Id));
    });
    combo_semanal.val(asistencia);
    combo_semanal.change((e) => {
      change_handler(e.target.value);
    });
    celda.append(combo_semanal);
    fila.append(celda);
  }

  updateParticipacionSemanalPersona (asistencia, semana, id_dato) {
    Backend.PT_Upd_Participacion_por_Entidad_Periodo(this.idGrupoTrabajo,
      this.periodo.Mes, this.periodo.Anio, asistencia.Persona.Id_Rol, semana, id_dato);
  }
}
