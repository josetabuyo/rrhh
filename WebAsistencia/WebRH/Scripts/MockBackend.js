var Backend = {
    start(on_ready) {
      setTimeout(on_ready, 100);
    },
    PT_Get_Cargar_Combo (nombre_combo) {
      return this.ReturnAsync([
        {id: 1, descripcion: 'nombre entidad'}
      ]);
    },
    PT_Get_Estado_Carga_Participacion_Por_Periodo (id_periodo) {
        return this.ReturnAsync([
          { IdGrupoTrabajo: '1', NombreGrupoTrabajo: 'Los tigres de tigre',
            Activos: 115, Suspendidos: 16, Incompatibles: 16,
            SinCarga: 0, Parciales: 0, Completos: 0, ConInforme: 10},
          { IdGrupoTrabajo: '2', NombreGrupoTrabajo: 'Los caniches de Domingo',
            Activos: 25, Suspendidos: 0, Incompatibles: 0,
            SinCarga: 0, Parciales: 0, Completos: 0, ConInforme: 25},
          { IdGrupoTrabajo: '3', NombreGrupoTrabajo: 'Todos Juntos Podemos',
            Activos: 20, Suspendidos: 6, Incompatibles: 2,
            SinCarga: 0, Parciales: 0, Completos: 0, ConInforme: 20},
          { IdGrupoTrabajo: '4', NombreGrupoTrabajo: 'Esperanza',
            Activos: 20, Suspendidos: 5, Incompatibles: 5,
            SinCarga: 0, Parciales: 0, Completos: 0, ConInforme: 20},
          { IdGrupoTrabajo: '5', NombreGrupoTrabajo: 'Lealtad',
            Activos: 25, Suspendidos: 3, Incompatibles: 2,
            SinCarga: 0, Parciales: 0, Completos: 0, ConInforme: 25},
          { IdGrupoTrabajo: '6', NombreGrupoTrabajo: 'Compromiso',
            Activos: 25, Suspendidos: 2, Incompatibles: 2,
            SinCarga: 0, Parciales: 0, Completos: 0, ConInforme: 25},
        ]);
    },
    PT_Get_Participaciones_Dato() {
      return this.ReturnAsync([
        	{Id: '1', Dato_Participacion: '100 %', Permite_Observaciones: 0},
        	{Id: '2', Dato_Participacion: '50 %', Permite_Observaciones: 1},
         	{Id: '3', Dato_Participacion: '0 %', Permite_Observaciones: 1},
         	{Id: '4', Dato_Participacion: 'Justificado', Permite_Observaciones: 0},
          {Id: '5', Dato_Participacion: 'No Corresponde', Permite_Observaciones: 0},
      ]);
    },
    PT_Get_Add_Participacion_por_Entidad_Periodo (id_grupo, id_periodo) {
        return this.ReturnAsync([
          { Persona: { Id_Rol: 1, Cuil: '20-41342135-9', Nombre_Apellido: 'PEREZ, Juan Manuel'},
            Part_Semana1: 1, Part_Semana2: 1, Part_Semana3: 1, Part_Semana4: 4,
            Part_Semana5: null, Observaciones: 'bla bla'},
          { Persona: { Id_Rol: 2, Cuil: '20-41384535-7', Nombre_Apellido: 'GONZALEZ, Maria Jimena'},
            Part_Semana1: 3, Part_Semana2: 1, Part_Semana3: 2, Part_Semana4: 1,
            Part_Semana5: null, Observaciones: 'bla bla'},
          { Persona: { Id_Rol: 3, Cuil: '20-42344135-3', Nombre_Apellido: 'SCHMIDT, Marisa Paola'},
            Part_Semana1: 1, Part_Semana2: 2, Part_Semana3: 1, Part_Semana4: 1,
            Part_Semana5: null, Observaciones: 'bla bla'},
          { Persona: { Id_Rol: 4, Cuil: '20-45344115-4', Nombre_Apellido: 'VIÑATE, Fabiana Carmen'},
            Part_Semana1: 1, Part_Semana2: 1, Part_Semana3: 1, Part_Semana4: 1,
            Part_Semana5: null, Observaciones: ''},
          { Persona: { Id_Rol: 5, Cuil: '20-42124135-5', Nombre_Apellido: 'LOPEZ, Alberto Mario'},
            Part_Semana1: 1, Part_Semana2: 1, Part_Semana3: 1, Part_Semana4: 1,
            Part_Semana5: null, Observaciones: ''},
          { Persona: { Id_Rol: 6, Cuil: '20-42345135-6', Nombre_Apellido: 'MARINI, Pedro Pablo'},
            Part_Semana1: 1, Part_Semana2: 1, Part_Semana3: 1, Part_Semana4: 1,
            Part_Semana5: null, Observaciones: ''},
        ]);
    },
    PT_Get_Periodos() {
      return this.ReturnAsync([
        {Id: '1', Mes: 'Marzo', Anio: '2020', Cant_Semanas: 4},
        {Id: '2', Mes: 'Abril', Anio: '2020', Cant_Semanas: 5},
        {Id: '3', Mes: 'Mayo', Anio: '2020', Cant_Semanas: 4},
        {Id: '4', Mes: 'Junio', Anio: '2020', Cant_Semanas: 4},
      ]);
    },
    PT_Upd_Participacion_por_Entidad_Periodo(id_entidad, mes, anio, semana, id_persona_rol, id_dato_justificacion) {
      console.log('guardando', id_entidad, mes, anio, semana, id_persona_rol, id_dato_justificacion);
    },
    ReturnAsync(data) {
      var promesa = new Promesa();
      setTimeout(function() {
        promesa.success(data);
      }, 100);
      return promesa;
    }
};
