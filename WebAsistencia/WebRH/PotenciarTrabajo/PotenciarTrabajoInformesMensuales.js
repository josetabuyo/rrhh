$(document).ready(function () {
    Backend.start(function () {
      tablaInformesParticipacion = new TablaInformesParticipacion();

      $("#pt_boton_informes_mensuales").click(() => {

        $(".pt_selected_section_button").removeClass("pt_selected_section_button");
        $("#pt_boton_informes_mensuales").addClass("pt_selected_section_button");

        tablaInformesParticipacion.render();
      });

    });
});

class TablaInformesParticipacion extends TablaPT{
  constructor () {
    super();
    Backend.PT_Get_Estado_Informes_Participacion_Por_Periodo()
      .onSuccess((informes_participacion) => {
        _.forEach(informes_participacion, (i) => {
          var fila = $("<tr>");

          this.agregarCeldaTextoAFila(fila, i.Entidad.Anio);
          this.agregarCeldaTextoAFila(fila, i.Entidad.Mes);
          this.agregarCeldaTextoAFila(fila, i.Ent_SinCarga);
          this.agregarCeldaTextoAFila(fila, i.Ent_EnProceso);
          this.agregarCeldaTextoAFila(fila, i.Ent_ConInforme);
          this.agregarCeldaTextoAFila(fila, i.Partic_SinCarga);
          this.agregarCeldaTextoAFila(fila, i.Partic_EnProceso);
          this.agregarCeldaTextoAFila(fila, i.Partic_ConInforme);

          fila.addClass("pt_fila_participacion_semanal");
          $("#pt_tabla_participacion_semanal").append(fila);
        });
      })
      .onError(function (e) {
        console.error("error al obtener niveles de participacion: " + e);
      });
  }
  render () {
      $(".pt_seccion").hide();
      $("#pt_seccion_informes_mensuales").show();
  }

  // renderComboAsistencia (fila, asistencia, change_handler) {
  //   var celda = $("<td>")
  //   var combo_semanal = $("<select>");
  //   combo_semanal.addClass("cmb_porcentaje_asistencia");
  //   this.nivelesDeParticipacion.forEach((nivel) => {
  //     combo_semanal.append(new Option(nivel.Dato_Participacion, nivel.Id));
  //   });
  //   combo_semanal.val(asistencia);
  //   combo_semanal.change((e) => {
  //     change_handler(e.target.value);
  //   });
  //   celda.append(combo_semanal);
  //   fila.append(celda);
  // }

  // updateParticipacionSemanalPersona (asistencia, semana, id_dato) {
  //   //Si Id del dato es justificacion, se abre popup
  //   if (id_dato === '4') {
  //     var pt_popup_justificación = $('#pt_plantillas').find('.pt_justificacion').clone();
  //     var lbl_semana_desde = pt_popup_justificación.find('#pt_justificacion_semana_desde');
  //     lbl_semana_desde.html(`${this.periodo.Anio} ${this.periodo.Mes} semana ${semana}`);
  //     var cmb_motivo = pt_popup_justificación.find('#pt_justificacion_cmb_motivo');
  //     cmb_motivo.empty();
  //     Backend.PT_Get_Cargar_Combo('MotivoJustificacion')
  //       .onSuccess((motivos) => {
  //         _.forEach(motivos, (motivo) => {
  //           cmb_motivo.append($(`<option value=${motivo.id}> ${motivo.descripcion} </option>`));
  //         })
  //       })
  //       .onError(function (e) {
  //         console.error("error cargar motivos de justificacion: " + e);
  //       });
  //     var cmb_semana_hasta = pt_popup_justificación.find('#pt_justificacion_cmb_semana_hasta');
  //     cmb_semana_hasta.empty();
  //     Backend.PT_Get_Periodos()
  //       .onSuccess((periodos) => {
  //         console.log(periodos)
  //         _.forEach(periodos, (periodo) => {
  //           for (let i = 1; i <= periodo.Cant_Semanas; i++) {
  //             if(this.periodo.Id > periodo.Id) continue;
  //             if(this.periodo.Id == periodo.Id && semana >= i) continue;
  //             cmb_semana_hasta.append($(`<option value=${periodo.Anio}-${periodo.Id}-${i}> ${periodo.Anio} ${periodo.Mes} semana ${i} </option>`));
  //           }
  //         })
  //       })
  //       .onError(function (e) {
  //         console.error("error al cargar periodos: " + e);
  //       });
  //     var txt_descripcion = pt_popup_justificación.find('#pt_descripcion_justificacion');
  //     txt_descripcion.val('');
  //     vex.defaultOptions.className = 'vex-theme-os';
  //     vex.dialog.open({
  //       message: 'Justificacion',
  //       input: pt_popup_justificación,
  //       buttons: [
  //         $.extend({}, vex.dialog.buttons.YES, { text: 'Guardar' }),
  //         $.extend({}, vex.dialog.buttons.NO, { text: 'Cancelar' })
  //       ],
  //       callback: (valor) => {
  //         if(valor===false) {
  //           this.render(this.idEntidad, this.periodo);
  //           return;
  //         }
  //
  //         var descripcion = txt_descripcion.val();
  //         var motivo = cmb_motivo.val();
  //         var desde_anio = this.periodo.Anio;
  //         var desde_mes = this.periodo.Id;
  //         var desde_semana = semana;
  //         var str_semana_hasta = cmb_semana_hasta.val();
  //         var hasta_anio = str_semana_hasta.split('-')[0];
  //         var hasta_mes = str_semana_hasta.split('-')[1];
  //         var hasta_semana = str_semana_hasta.split('-')[2];
  //         var id_entidad = this.idEntidad;
  //         Backend.PT_Add_Justificacion(asistencia.Persona.Id_Rol, motivo, desde_anio,
  //           desde_mes, desde_semana, hasta_anio, hasta_mes, hasta_semana, descripcion, id_entidad)
  //           .onSuccess((datos) => {
  //             this.render(this.idEntidad, this.periodo);
  //           })
  //           .onError(function (e) {
  //             this.render(this.idEntidad, this.periodo);
  //             console.error("error al guardar participacion: " + e);
  //           });
  //       }
  //     });
  //     return;
  //   }
  //   Backend.PT_Upd_Participacion_por_Entidad_Periodo(
  //       this.idEntidad,
  //       this.periodo.Id,
  //       this.periodo.Anio,
  //       semana,
  //       asistencia.Persona.Id_Rol,
  //       id_dato)
  //     .onSuccess((datos) => {
  //       this.render(this.idEntidad, this.periodo);
  //     })
  //     .onError(function (e) {
  //       this.render(this.idEntidad, this.periodo);
  //       console.error("error al guardar participacion: " + e);
  //     });
  // }
  //
  // updateObservacionMensualPersona (asistencia, observacion) {
  //   Backend.PT_UPD_Participacion_Observacion(
  //       this.idEntidad,
  //       this.periodo.Id,
  //       this.periodo.Anio,
  //       asistencia.Persona.Id_Rol,
  //       observacion)
  //     .onSuccess((datos) => {
  //         this.render(this.idEntidad, this.periodo);
  //     })
  //     .onError(function (e) {
  //       console.error("error al guardar comentarios: " + e);
  //     });
  // }
}
