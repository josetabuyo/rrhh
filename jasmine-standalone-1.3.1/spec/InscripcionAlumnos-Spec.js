describe("Inscripcion Alumnos", function () {   
    var options;
	var alumno_fake;
	beforeEach(function () {
		var btnAsignarAlumno = $("<input>");
		btnAsignarAlumno.attr("type", "button");
		var btnDesAsignarAlumno = $("<input>");
		btnDesAsignarAlumno.attr("type", "button");	
		//btnDesAsignarAlumno.attr("onclick", "DesasignarAlumno()");			
		var btnGaurdarInscriptos = $("<input>");
		btnGaurdarInscriptos.attr("type", "button");
		//btnGaurdarInscriptos.attr("onclick", "InscribirAlumnos()");
        var columnas = [];
        columnas.push(new Columna("Nombre", { generar: function (un_alumno) { return un_alumno.Nombre; } }));
        columnas.push(new Columna("Apellido", { generar: function (un_alumno) { return un_alumno.Apellido; } }));
		alumno_fake = {	Id: 284165,Nombre: "Veronica",Apellido: "AYAN",Documento: 32267529,Modalidad: {Id: 2,Descripcion: "Fines CENS"},Baja: 0	};
	
		options = {
            planillaAlumnosDisponibles : $("<div>"),
			planillaAlumnosAsignados : $("<div>"),
			contenedorAlumnosDisponibles : $("<div>"),
			contenedorAlumnosAsignados : $("<div>"),
			alumnosEnGrillaParaInscribir: $("<div>"),
			mensaje: $("<div>"),
			alumnoGlobal : $("<div>"),
			alumnos : JSON.parse('[{"Id": "284165","Nombre": "Veronica","Apellido": "AYAN","Documento": 32267529,"Telefono": "4281-2685/1550595930","Mail": "ayanveronica@hotmail.com","Direccion": "Sarandí 740 Piso 3 Dto C","Modalidad": {"Id": 2,"Descripcion": "Fines CENS"},"Baja": 0},{"Id": 281941,"Nombre": "Fernando","Apellido": "CAINO","Documento": 31046911,"Telefono": "1556377257","Mail": "fernandocaino84@gmail.com","Direccion": "Avalos 1301 Piso 1 Dto C","Modalidad": {"Id": 2,"Descripcion": "Fines CENS"},"Baja": 0}]'),
			columnas : columnas,
			cmbCursos : $("#cmbCursos"),
			cmbCiclo : $("#cmbCiclo"),
			cursosJSON : JSON.parse('[{"Id":14,"Nombre":"Algoritmos (Fines CENS)","Docente":{"Telefono":"4231-7346 / 1567896003","Mail":"marce-guzman11@hotmail.com.ar","Direccion":"Agrelo 76 Piso  Dto ","Baja":0,"Id":278739,"Dni":18143503,"Nombre":"Marcela Edith","Apellido":"GUZMAN"},"Materia":{"Id":4,"Nombre":"Algoritmos","Modalidad":{"Id":2,"Descripcion":"Fines CENS","EstructuraDeEvaluacion":null},"Ciclo":{"Id":3,"Nombre":"2do ciclo"}},"Horarios":[{"NumeroDia":3,"Dia":"miércoles","HoraDeInicio":"12:00","HoraDeFin":"13:00","HorasCatedra":3},{"NumeroDia":4,"Dia":"jueves","HoraDeInicio":"11:00","HoraDeFin":"12:00","HorasCatedra":1}],"Alumnos":[{"Id":284165,"Nombre":"Veronica","Apellido":"AYAN","Documento":32267529,"Modalidad":{"Id":2,"Descripcion":"Fines CENS","EstructuraDeEvaluacion":null},"Telefono":"4281-2685/1550595930","Mail":"ayanveronica@hotmail.com","Direccion":"Sarandí 740 Piso 3 Dto C","Baja":0}],"HorasCatedra":0,"EspacioFisico":{"Id":21,"Aula":"21","Capacidad":30,"Edificio":{"Id":5,"Nombre":"Torre San Martín","Direccion":"Perón 525"}}}]'),
			idCursoSeleccionado : $("#idCursoSeleccionado"),
			botonAsignarAlumno: btnAsignarAlumno,
			botonDesAsignarAlumno:btnDesAsignarAlumno,
			botonGuardarInscriptos:btnGaurdarInscriptos
        };
	});
	
	it("deberia estar seteado las grillas", function () {
	    var componenteInscripcionAlumnos = new PaginaInscripcionAlumnos(options);
		
		expect(componenteInscripcionAlumnos.o.planillaAlumnosDisponibles).toBeDefined();
        expect(componenteInscripcionAlumnos.o.planillaAlumnosAsignados).toBeDefined();
		
    });	
	
	it("deberia pasar 1 alumno de disponible a asignado", function () {
	    var componenteInscripcionAlumnos = new PaginaInscripcionAlumnos(options);

        spyOn(componenteInscripcionAlumnos, "AsignarAlumno").andCallThrough();
		componenteInscripcionAlumnos.o.alumnoGlobal = alumno_fake;		
		componenteInscripcionAlumnos.btnAsignar.click();
		expect(componenteInscripcionAlumnos.AsignarAlumno).toHaveBeenCalled();			
    });	
	
	it("deberia pasar 1 alumno de asignado a desasignado", function () {
	    var componenteInscripcionAlumnos = new PaginaInscripcionAlumnos(options);

        spyOn(componenteInscripcionAlumnos, "DesasignarAlumno").andCallThrough();	
		componenteInscripcionAlumnos.o.alumnoGlobal = alumno_fake;		
		componenteInscripcionAlumnos.btnDesAsignar.click();
		expect(componenteInscripcionAlumnos.DesasignarAlumno).toHaveBeenCalled();			
    });	
	
	it("deberia inscribir alumnos", function () {
		var btnGuardarInscriptos = $("<input>");
			btnGuardarInscriptos.attr("type", "button");
		
		var fakeComponenteInscripcionAlumnos = function () {
			var _this = this;	
			_this.btnInscribir = btnGuardarInscriptos;
			_this.btnInscribir.click(function(){
				_this.InscribirAlumnos();
			});			
			cursosJSON = 2;		
		}
		
		fakeComponenteInscripcionAlumnos.prototype = {
		
			InscribirAlumnos: function() { 
				var _this = this;	
				_this.GetCursosDTO(); 	
			},
			GetCursosDTO: function () {
				_this = this;
				_this.cursosJSON = 3;
			}
		}
		
		var objeto_fake = new fakeComponenteInscripcionAlumnos();
		spyOn(objeto_fake, "InscribirAlumnos").andCallThrough();
	
		objeto_fake.btnInscribir.click();
		expect(objeto_fake.InscribirAlumnos).toHaveBeenCalled();		
							
	});
});	




