var Backend = {
    start(on_ready) {
      setTimeout(on_ready, 100);
    },
    PT_Get_Cargar_Combo (nombre_combo) {
      return this.ReturnAsync([
        {id: 1, descripcion: 'Accidente'},
        {id: 2, descripcion: 'Casamiento'},
        {id: 3, descripcion: 'Mudanza'},
        {id: 4, descripcion: 'Estudio'},
      ]);
    },
    PT_Get_Estado_Carga_Participacion_Por_Periodo (id_periodo) {
        return this.ReturnAsync([
          { Id_Entidad: '1', Nombre_Entidad: 'Los tigres de tigre',
            Activos: 115, Suspendidos: 16, Incompatibles: 16,
            Sin_Carga: 0, Activos_Parcial: 0, Completos: 0, Con_Informe: 10},
          { Id_Entidad: '2', Nombre_Entidad: 'Los caniches de Domingo',
            Activos: 25, Suspendidos: 0, Incompatibles: 0,
            Sin_Carga: 0, Activos_Parcial: 0, Completos: 0, Con_Informe: 25},
          { Id_Entidad: '3', Nombre_Entidad: 'Todos Juntos Podemos',
            Activos: 20, Suspendidos: 6, Incompatibles: 2,
            Sin_Carga: 0, Activos_Parcial: 0, Completos: 0, Con_Informe: 20},
          { Id_Entidad: '4', Nombre_Entidad: 'Esperanza',
            Activos: 20, Suspendidos: 5, Incompatibles: 5,
            Sin_Carga: 0, Activos_Parcial: 0, Completos: 0, Con_Informe: 20},
          { Id_Entidad: '5', Nombre_Entidad: 'Lealtad',
            Activos: 25, Suspendidos: 3, Incompatibles: 2,
            Sin_Carga: 0, Activos_Parcial: 0, Completos: 0, Con_Informe: 25},
          { Id_Entidad: '6', Nombre_Entidad: 'Compromiso',
            Activos: 25, Suspendidos: 2, Incompatibles: 2,
            Sin_Carga: 0, Activos_Parcial: 0, Completos: 0, Con_Informe: 25},
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
          { Persona: { Id_Rol: 1, CUIL: '20-41342135-9', Nombre_Apellido: 'PEREZ, Juan Manuel'},
            Part_Semana1: 1, Part_Semana2: 1, Part_Semana3: 1, Part_Semana4: 4,
            Part_Semana5: 1, Observacion: 'bla bla weagawrh aetrha setrhserhsaewrhg nsfa wegfaw fgoawoñef gowaegf awoe gf gawg efawgof gwa ge-fg aw ogawegfawef kgawe gfa gwef awe gfawgef agwe gfaw lef awleawergb aewbñrgasewrogasor sarog esdvfa we gfhaw egf phawe hFawfphywfe faweh-fhsegflghgf-he-fhaeñ-fh f- ñlhf -hwefñ aeñ fawr garp gr ease'},
          { Persona: { Id_Rol: 2, CUIL: '20-41384535-7', Nombre_Apellido: 'GONZALEZ, Maria Jimena'},
            Part_Semana1: 3, Part_Semana2: 1, Part_Semana3: 2, Part_Semana4: 1,
            Part_Semana5: 1, Observacion: 'bla bla'},
          { Persona: { Id_Rol: 3, CUIL: '20-42344135-3', Nombre_Apellido: 'SCHMIDT, Marisa Paola'},
            Part_Semana1: 1, Part_Semana2: 2, Part_Semana3: 1, Part_Semana4: 1,
            Part_Semana5: 1, Observacion: 'bla bla'},
          { Persona: { Id_Rol: 4, CUIL: '20-45344115-4', Nombre_Apellido: 'VIÑATE, Fabiana Carmen'},
            Part_Semana1: 1, Part_Semana2: 1, Part_Semana3: 1, Part_Semana4: 1,
            Part_Semana5: 1, Observacion: ''},
          { Persona: { Id_Rol: 5, CUIL: '20-42124135-5', Nombre_Apellido: 'LOPEZ, Alberto Mario'},
            Part_Semana1: 1, Part_Semana2: 1, Part_Semana3: 1, Part_Semana4: 1,
            Part_Semana5: 1, Observacion: ''},
          { Persona: { Id_Rol: 6, CUIL: '20-42345135-6', Nombre_Apellido: 'MARINI, Pedro Pablo'},
            Part_Semana1: 1, Part_Semana2: 1, Part_Semana3: 1, Part_Semana4: 1,
            Part_Semana5: 1, Observacion: ''},
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
      return this.ReturnAsync({});
    },
    PT_UPD_Participacion_Observacion(id_entidad, mes, anio, id_persona_rol, observacion) {
      console.log('guardando', id_entidad, mes, anio, id_persona_rol, observacion);
      return this.ReturnAsync({});
    },
    PT_Add_Justificacion(id_persona_rol, id_motivo, anio_desde, mes_desde, semana_desde, anio_hasta, mes_hasta, semana_hasta, justificacion, id_entidad) {
      console.log('creando justificacion', id_persona_rol, id_motivo, anio_desde, mes_desde, semana_desde, anio_hasta, mes_hasta, semana_hasta, justificacion, id_entidad);
      return this.ReturnAsync({});
    },    
    ReturnAsync(data) {
      var promesa = new Promesa();
      setTimeout(function() {
        promesa.success(data);
      }, 100);
      return promesa;
    }
};
