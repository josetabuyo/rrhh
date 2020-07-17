$(document).ready(function () {
    console.warn('document ready');
    Backend.start(function () {
      console.warn('backend started');
      var seccion = new SeccionEstadoCargaParticipacion();
      $("#pt_boton_carga_participacion").click(() => {        
        $("#pt_boton_carga_participacion").addClass("pt_selected_section_button");
        seccion.render();
      });
    });
});

class SeccionEstadoCargaParticipacion {
  constructor() {
    this.tablaMensual = new TablaParticipacionMensual();
    $("#pt_cmb_periodo").empty();
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
    return celda;
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
        console.error("error al obtener niveles de participacion: " + e);
      });
  }
  render (id_entidad, periodo) {
    this.idEntidad = id_entidad;
    this.periodo = periodo;
    // <th>CUIL</th>
    // <th>Apellido y Nombre</th>
    // <th>Semana 1</th>
    // <th>Semana 2</th>
    // <th>Semana 3</th>
    // <th>Semana 4</th>
    // <th>observaciones a la participación</th>

    const fila_titulos = $("#pt_tabla_participacion_semanal").find("#pt_titulos_tabla_participacion_semanal");
    fila_titulos.empty();
    fila_titulos.append($("<th>CUIL</th>"));
    fila_titulos.append($("<th>Apellido y Nombre</th>"));
    fila_titulos.append($("<th>Semana 1</th>"));
    fila_titulos.append($("<th>Semana 2</th>"));
    fila_titulos.append($("<th>Semana 3</th>"));
    fila_titulos.append($("<th>Semana 4</th>"));
    if(periodo.Cant_Semanas == 5) {
      fila_titulos.append($("<th>Semana 5</th>"));
    }
    fila_titulos.append($("<th>observaciones a la participación</th>"));

    $("#pt_tabla_participacion_semanal").find(".pt_fila_participacion_semanal").remove();
    Backend.PT_Get_Add_Participacion_por_Entidad_Periodo(id_entidad, periodo.Id, periodo.Anio)
    .onSuccess((personas) => {
      _.forEach(personas, (p) => {
        var fila = $("<tr>");

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
        if(periodo.Cant_Semanas == 5) {
          this.renderComboAsistencia(fila, p.Part_Semana5, (nuevo_valor)=>{
            this.updateParticipacionSemanalPersona(p, 5, nuevo_valor);
          });
        }
        // celda observaciones, tiene un botón para editar
        const celda_obs = this.agregarCeldaTextoAFila(fila, p.Observacion);
        celda_obs.addClass("celda_observacion");
        const icono_lista = $("<img>");
        icono_lista.attr("src", "IconoLista.png");
        icono_lista.addClass("pt_icono_lista");
        icono_lista.click(() => {
          vex.defaultOptions.className = 'vex-theme-os';
          vex.dialog.prompt({
            message: 'Ingrese observaciones',
            value: p.Observacion,
            callback: (observacion) => {
              if(observacion===false) return;
              this.updateObservacionMensualPersona(p, observacion);
            }
          });
        });
        celda_obs.append(icono_lista);

        fila.addClass("pt_fila_participacion_semanal");
        $("#pt_tabla_participacion_semanal").append(fila);
      });
    })
    .onError(function (e) {
      console.error("error al obtener asistencias: " + e);
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
    //Si Id del dato es justificacion, se abre popup
    if (id_dato === '4') {
      var pt_popup_justificación = $('#pt_plantillas').find('.pt_justificacion').clone();
      var lbl_semana_desde = pt_popup_justificación.find('#pt_justificacion_semana_desde');
      lbl_semana_desde.html(`${this.periodo.Anio} ${this.periodo.Mes} semana ${semana}`);
      var cmb_motivo = pt_popup_justificación.find('#pt_justificacion_cmb_motivo');
      cmb_motivo.empty();
      Backend.PT_Get_Cargar_Combo('MotivoJustificacion')
        .onSuccess((motivos) => {
          _.forEach(motivos, (motivo) => {
            cmb_motivo.append($(`<option value=${motivo.id}> ${motivo.descripcion} </option>`));
          })
        })
        .onError(function (e) {
          console.error("error cargar motivos de justificacion: " + e);
        });
      var cmb_semana_hasta = pt_popup_justificación.find('#pt_justificacion_cmb_semana_hasta');
      cmb_semana_hasta.empty();
      Backend.PT_Get_Periodos()
        .onSuccess((periodos) => {
          console.log(periodos)
          _.forEach(periodos, (periodo) => {
            for (let i = 1; i <= periodo.Cant_Semanas; i++) {
              if(this.periodo.Id > periodo.Id) continue;
              if(this.periodo.Id == periodo.Id && semana >= i) continue;
              cmb_semana_hasta.append($(`<option value=${periodo.Anio}-${periodo.Id}-${i}> ${periodo.Anio} ${periodo.Mes} semana ${i} </option>`));
            } 
          })
        })
        .onError(function (e) {
          console.error("error al cargar periodos: " + e);
        });
      var txt_descripcion = pt_popup_justificación.find('#pt_descripcion_justificacion');
      txt_descripcion.val('');
      vex.defaultOptions.className = 'vex-theme-os';
      vex.dialog.open({
        message: 'Justificacion',
        input: pt_popup_justificación,
        buttons: [
          $.extend({}, vex.dialog.buttons.YES, { text: 'Guardar' }),
          $.extend({}, vex.dialog.buttons.NO, { text: 'Cancelar' })
        ],
        callback: (valor) => {
          if(valor===false) {
            this.render(this.idEntidad, this.periodo);
            return;
          }

          var descripcion = txt_descripcion.val();
          var motivo = cmb_motivo.val();
          var desde_anio = this.periodo.Anio;
          var desde_mes = this.periodo.Id;
          var desde_semana = semana;
          var str_semana_hasta = cmb_semana_hasta.val();
          var hasta_anio = str_semana_hasta.split('-')[0];
          var hasta_mes = str_semana_hasta.split('-')[1];
          var hasta_semana = str_semana_hasta.split('-')[2];
          var id_entidad = this.idEntidad;
          Backend.PT_Add_Justificacion(asistencia.Persona.Id_Rol, motivo, desde_anio, 
            desde_mes, desde_semana, hasta_anio, hasta_mes, hasta_semana, descripcion, id_entidad)
            .onSuccess((datos) => {
              this.render(this.idEntidad, this.periodo);
            })
            .onError(function (e) {
              this.render(this.idEntidad, this.periodo);
              console.error("error al guardar participacion: " + e);
            });
        }
      });
      return;
    }
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
        this.render(this.idEntidad, this.periodo);
        console.error("error al guardar participacion: " + e);
      });
  }

  updateObservacionMensualPersona (asistencia, observacion) {
    Backend.PT_UPD_Participacion_Observacion(
        this.idEntidad,
        this.periodo.Id,
        this.periodo.Anio,
        asistencia.Persona.Id_Rol,
        observacion)
      .onSuccess((datos) => {
          this.render(this.idEntidad, this.periodo);
      })
      .onError(function (e) {
        console.error("error al guardar comentarios: " + e);
      });
  }
}
