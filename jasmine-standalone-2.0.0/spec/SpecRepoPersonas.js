describe("Interactuando con el backend", function() {
	var proveedorAjax;
	var jsonJuan;
	var urlBuscarPersonas
	var urlBase;
	var urlBuscarPersonasPart;

	beforeEach(function() {
		jasmine.Ajax.install();
		proveedorAjax = new ProveedorAjax();
		jsonJuan = '{"d":"[{\\"Id\\":6944,\\"Documento\\":10659739,\\"Nombre\\":\\"Juan\\",\\"Apellido\\":\\"CALCAGNO\\",\\"Legajo\\":\\"301318\\"},{}]"}';
		urlBuscarPersonasPart = "BuscarPersonas"
		urlBase = '../../../../AjaxWS.asmx/';
		urlBuscarPersonas = urlBase + urlBuscarPersonasPart;
	});

	afterEach(function() {
	  jasmine.Ajax.uninstall();
	});

	describe("El proveedor de ajax", function() {
		
		it("deberia pasar a minusculas todas las key del diccionario json", function() {
			var successFunctionHasBeenCalled = false;
			var datosDelPost = {
								url: urlBuscarPersonasPart,
								data: { criterio: "CAL"},
								success: function(respuesta) {
											expect(respuesta[0].Id).toBeUndefined();
											expect(respuesta[0].id).toEqual(6944);
											successFunctionHasBeenCalled = true;
										}
								};
			stubRequestCon(200, jsonJuan);
			
			proveedorAjax.postearAUrl(datosDelPost);
			expect(successFunctionHasBeenCalled).toBe(true);
		});
	});

	describe("El repositorio de personas", function() {

		var repoPersonas;
		var juan;

		beforeEach(function() {
			juan = {id: 6944, documento: 10659739, nombre: "Juan", apellido: "CALCAGNO", legajo: "301318"};
			repoPersonas = new RepositorioDePersonas(proveedorAjax);
		});
		
		it("deberia llamar a un bloque con las personas que le devuelve el proveedor ajax como parametro.", function() {
			var handlearPersonas = jasmine.createSpy('handlearPersonas');
			var handlerError = jasmine.createSpy('handlerError');
			stubRequestCon(200, jsonJuan);
			
			repoPersonas.buscarPersonas("CALC", handlearPersonas, handlerError);

			var personasObtenidas = primerArgumentoRecibidoPor(handlearPersonas);
			expect(personasObtenidas[0]).toEqual(juan);
		});
		
		it("deberia llamar a la funcion de error cuando falla", function() {
			var handlearPersonas = jasmine.createSpy('handlearPersonas');
			var handlerError = jasmine.createSpy('handlerError');
			stubRequestCon(305, "Error del server");
			
			repoPersonas.buscarPersonas("CALC", handlearPersonas, handlerError);
		
			expect(handlerError).toHaveBeenCalled();
		});
	});
	
	function stubRequestCon(status, responseText) {
		jasmine.Ajax.stubRequest(urlBuscarPersonas).andReturn({
			"status": status,
			"responseText": responseText
		});
	}
	
	function primerArgumentoRecibidoPor(funcion) {
		return funcion.calls.first().args[0];
	}
});