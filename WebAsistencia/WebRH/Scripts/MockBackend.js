var Backend = {
    start: function (on_ready) {
        setTimeout(on_ready, 100);
    },
    PTGetEstadoCargaParticipacionPorPeriodo (id_periodo) {
        return this.ReturnAsync([
          { idGrupoTrabajo: '1', nombreGrupoTrabajo: 'Los tigres de tigre',
            activos: 115, suspendidos: 16, incompatibles: 16,
            sinCarga: 0, parciales: 0, completos: 0, conInforme: 10},
          { idGrupoTrabajo: '2', nombreGrupoTrabajo: 'Los caniches de Domingo',
            activos: 25, suspendidos: 0, incompatibles: 0,
            sinCarga: 0, parciales: 0, completos: 0, conInforme: 25},
          { idGrupoTrabajo: '3', nombreGrupoTrabajo: 'Todos Juntos Podemos',
            activos: 20, suspendidos: 6, incompatibles: 2,
            sinCarga: 0, parciales: 0, completos: 0, conInforme: 20},
          { idGrupoTrabajo: '4', nombreGrupoTrabajo: 'Esperanza',
            activos: 20, suspendidos: 5, incompatibles: 5,
            sinCarga: 0, parciales: 0, completos: 0, conInforme: 20},
          { idGrupoTrabajo: '5', nombreGrupoTrabajo: 'Lealtad',
            activos: 25, suspendidos: 3, incompatibles: 2,
            sinCarga: 0, parciales: 0, completos: 0, conInforme: 25},
          { idGrupoTrabajo: '6', nombreGrupoTrabajo: 'Compromiso',
            activos: 25, suspendidos: 2, incompatibles: 2,
            sinCarga: 0, parciales: 0, completos: 0, conInforme: 25},
        ]);
    },
    PTGetAsistenciasPorGrupoYPeriodo (id_grupo, id_periodo) {
        return this.ReturnAsync([
          { cuil: '20-41342135-9', nombre: 'PEREZ, Juan Manuel',
             asistSemana1: '100', asistSemana2: '100', asistSemana3: '100',
             asistSemana4: 'medico', asistSemana5: null, observaciones: 'bla bla'},
          {  cuil: '20-41384535-7', nombre: 'GONZALEZ, Maria Jimena',
            asistSemana1: '0', asistSemana2: '', asistSemana3: '75',
            asistSemana4: '100', asistSemana5: null, observaciones: 'bla bla'},
          { cuil: '20-42344135-3', nombre: 'SCHMIDT, Marisa Paola',
            asistSemana1: '100', asistSemana2: '50', asistSemana3: '100',
            asistSemana4: '100', asistSemana5: null, observaciones: 'bla bla'},
          { cuil: '20-45344115-4', nombre: 'VIÑATE, Fabiana Carmen',
            asistSemana1: '', asistSemana2: '', asistSemana3: '',
            asistSemana4: '', asistSemana5: null, observaciones: ''},
          { cuil: '20-42124135-5', nombre: 'LOPEZ, Alberto Mario',
            asistSemana1: '', asistSemana2: '', asistSemana3: '',
            asistSemana4: '', asistSemana5: null, observaciones: ''},
          { cuil: '20-42345135-6', nombre: 'MARINI, Pedro Pablo',
            asistSemana1: '', asistSemana2: '', asistSemana3: '',
            asistSemana4: '', asistSemana5: null, observaciones: ''},
        ]);
    },
    PTGetPeriodos() {
      return this.ReturnAsync([
        {id: '1', descripcion: 'Abril 2020', cantSemanas: 4}
      ]);
    },
    PTGuardarAsistenciasGrupo(asistencias) {

    },
    ReturnAsync(data) {
      var promesa = new Promesa();
      setTimeout(function() {
        promesa.success(data);
      }, 100);
      return promesa;
    }
};
