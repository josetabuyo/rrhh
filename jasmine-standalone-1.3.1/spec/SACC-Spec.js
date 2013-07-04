describe("----------------------------------------------------------------COMIENZO TEST SACC----------------------------------------------------------------", function () {
    it("EJECUCIÓN DE PRUEBAS", function () {
    });
});


/*
describe("Se inicializa el Botón de Asistencias", function () {
    it("El botón debería ser un cuadrado Blanco y estar en Status Asistencia No Cargada", function () {

        var botonAsistencia = new CrearBotonAsistencia("Agus10022013", "0");

        expect(botonAsistencia).toBeDefined();
        expect(botonAsistencia.attr('class')).toEqual("btn_blanco_clicked");
        expect(botonAsistencia.val()).toEqual("  ");

    });

});*/

/*
describe("El botón de Asistencia está Cuadrado Blanco y se clickea", function () {
    it("El botón cambia a color Verde P y su Status es Presente", function () {

        var botonAsistencia = new CrearBotonAsistencia("Agus10022013", "0");
        //Clickea 1 vez
        botonAsistencia.click();

        expect(botonAsistencia).toBeDefined();
        expect(botonAsistencia.attr('class')).toEqual("btn_verde_clicked");
        expect(botonAsistencia.val()).toEqual("P");

    });
    
});*/

/*
describe("El botón de Asistencia está Cuadrado Verde y se clickea", function () {
    it("El botón cambia a color Amarillo A y su Status es Ausente", function () {

        var botonAsistencia = new CrearBotonAsistencia("Agus10022013", "0");
        //Clickea 2 veces
        botonAsistencia.click();
        botonAsistencia.click();

        expect(botonAsistencia).toBeDefined();
        expect(botonAsistencia.attr('class')).toEqual("btn_amarillo_clicked");
        expect(botonAsistencia.val()).toEqual("A");

    });*/
	
describe("Boton Quitar Horario", function () {
		var componenteABMCursos;
		var horarios;
		var horario;
		var botonQuitar;

    	beforeEach(function () {
			horarios = [];
			horarios.push({NumeroDia: 1,Dia: "lunes"});
			horarios.push({NumeroDia: 2,Dia: "martes"});
		
			horario = {NumeroDia: 1,Dia: "lunes"};

			botonQuitar = $('<input>');
            botonQuitar.attr('name', 'btnQuitarHorario');
            botonQuitar.attr('type', 'button');
            
		options = {
			_horario: horario,
			_horarios: horarios,
			_botonQuitarHorario: botonQuitar	
        };
			
		var PaginaABMCurso = function (options) {
			this.o = options;
			var _this = this;	
			
			this.btnQuitar = options._botonQuitarHorario;	
			
			this.btnQuitar.click(function(){
				_this.QuitarHorario(_this.o._horario);
			});
		};
		
		PaginaABMCurso.prototype.ObtenerIndice = function (arreglo, obj) {

		_this = this;
        if (arreglo.indexOf) {
				return arreglo.indexOf(obj);
			}
			else {
				for (var i = 0; i < _this.length; i++) {
					if (_this[i] == obj) {
						return i;
					}
				}
				return -1;
			};
		};

		PaginaABMCurso.prototype.QuitarHorario = function (horario) {

		_this = this;
		var indice = _this.ObtenerIndice(_this.o._horarios, horario);
			_this.o._horarios.splice(indice, 1);
		};

		componenteABMCursos = new PaginaABMCurso(options);		
		
	});
	it("El botón debería quitar el horario que esta agregado a la grilla de horarios", function () {
		spyOn(componenteABMCursos, "QuitarHorario").andCallThrough();	
		componenteABMCursos.btnQuitar.click();
		expect(componenteABMCursos.QuitarHorario).toHaveBeenCalled();
		expect(componenteABMCursos.o._horarios.length).toEqual(1);		

    });

});

