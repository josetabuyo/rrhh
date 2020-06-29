$(document).ready(function () {
    console.warn('document ready');
    Backend.start(function () {
      console.warn('backend started');
      $("#pt_boton_carga_participacion").click(() => {
        var seccion = new SeccionEstadoCargaParticipacion();
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
              periodo.Mes +' '+ periodo.Anio, JSON.stringify(periodo)));
          });
          $("#pt_cmb_periodo").change((e) => {
              this.periodoSeleccionado = e.target.value;
              this.render();
          });
          this.periodoSeleccionado = JSON.stringify(periodos ? periodos[0] : undefined);
          this.render();
      })
      .onError(function (e) {
          console.error("error al obtener periodos: " + e);
      });
  }

  render () {
    $("#pt_estado_semanal").hide();
    $("#pt_estado_mensual").show();
    this.tablaMensual.render(JSON.parse(this.periodoSeleccionado));
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

  render (periodo) {
    $("#pt_tabla_participacion_mensual").find(".pt_fila_participacion_mensual").remove();
      console.log("periodo:", JSON.stringify(periodo));
      Backend.PT_Get_Estado_Carga_Participacion_Por_Periodo(
        periodo.Anio, periodo.Id)
      .onSuccess((estados) => {
          console.log('estados obtenidos:', estados);
          _.forEach(estados, (e) => {
            const fila = $("<tr>")
            this.agregarCeldaTextoAFila(fila, e.Nombre_Entidad);
            this.agregarCeldaTextoAFila(fila, e.Activos);
            this.agregarCeldaTextoAFila(fila, e.Activos_Parcial);
            this.agregarCeldaTextoAFila(fila, e.Suspendidos);
            this.agregarCeldaTextoAFila(fila, e.Inactivos);
            this.agregarCeldaTextoAFila(fila, e.Activos + e.Activos_Parcial + e.Suspendidos + e.Inactivos);
            this.agregarCeldaTextoAFila(fila, e.Sin_Carga);

            const celda = $("<td>")
            celda.text(e.En_Proceso);
            const icono_lista = $("<img>");
            icono_lista.attr("src", "IconoLista.png");
            icono_lista.addClass("pt_icono_lista");
            icono_lista.click(() => {
              $("#pt_estado_mensual").hide();
              this.tablaSemanal.render(e.Id_Entidad, periodo);
              $("#pt_estado_semanal").show();
            });
            celda.append(icono_lista);
            fila.append(celda);

            this.agregarCeldaTextoAFila(fila, e.Con_Informe);
            fila.addClass("pt_fila_participacion_mensual");
            $("#pt_tabla_participacion_mensual").append(fila);
          });
      })
      .onError(function (e) {
          console.error("error al obtener asistencias: " + e);
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
  render (id_entidad, periodo) {
    this.idEntidad = id_entidad;
    this.periodo = periodo;

    $("#pt_tabla_participacion_semanal").find(".pt_fila_participacion_semanal").remove();
      Backend.PT_Get_Add_Participacion_por_Entidad_Periodo(id_entidad, periodo.Id, periodo.Anio)
      .onSuccess((personas) => {
        _.forEach(personas, (p) => {
          var fila = $("<tr>")

            this.agregarCeldaTextoAFila(fila, p.Persona.CUIL);
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
      })
      .onError(function (e) {
          this.alertify.error("error al obtener asistencias: " + e);
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
    Backend.PT_Upd_Participacion_por_Entidad_Periodo(
        this.idEntidad,
        this.periodo.Id, 
        this.periodo.Anio, 
        semana,
        asistencia.Persona.Id_Rol,
        id_dato)
      .onSuccess((datos) => {
          this.render(this.idEntidad, this.periodo);
      })
      .onError(function (e) {
          this.alertify.error("error al obtener niveles de participacion: " + e);
      });
  }
}
