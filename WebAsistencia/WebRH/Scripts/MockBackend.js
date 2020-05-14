var Backend = {
    start: function (on_ready) {
        setTimeout(on_ready, 100);
    },
    PTGetAsistenciasPorGrupoYMes (grupo, mes) {
        var data = [
          {cuil: '20-41342135-9', nombre: 'PEREZ, Juan Manuel',
           asistSemana1: '100', asistSemana2: '100', asistSemana3: '100',
           asistSemana4: '100', observaciones: 'bla bla'},
          {cuil: '20-41384535-7', nombre: 'GONZALEZ, Maria Jimena',
           asistSemana1: '0', asistSemana2: '', asistSemana3: '75',
           asistSemana4: '100', observaciones: 'bla bla'},
          {cuil: '20-42344135-3', nombre: 'SCHMIDT, Marisa Paola',
           asistSemana1: '100', asistSemana2: '50', asistSemana3: '100',
           asistSemana4: '100', observaciones: 'bla bla'},
          {cuil: '20-42344135-3', nombre: 'SCHMIDT, Marisa Paola',
           asistSemana1: '', asistSemana2: '', asistSemana3: '',
           asistSemana4: '', observaciones: ''},
        ]
        var promesa = new Promesa();
        setTimeout(function() {
          promesa.success(data);
        }, 100);
        return promesa;
    }
};
