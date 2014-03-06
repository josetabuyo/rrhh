describe("El repositorio de personas", function() {

	var repoPersonas;
	var juan;

	beforeEach(function() {
		jasmine.Ajax.install();
		juan = new Persona({id: 6944, nombre: "Juan", apellido: "CALCAGNO", legajo: "301318", documento: 10659739});
		repoPersonas = new RepositorioDePersonas(new ProveedorAjax);
	});
  
	afterEach(function() {
	  jasmine.Ajax.uninstall();
	});
	
	function stubRequestCon(status, responseText) {
		jasmine.Ajax.stubRequest('../../../../AjaxWS.asmx/BuscarPersonas').andReturn({
			"status": status,
			"responseText": responseText
		});
	}

	it("deberia llamar a un bloque con las personas que le devuelve el proveedor ajax como parametro.", function() {
		var handlearPersonas = jasmine.createSpy('handlearPersonas');
		var handlerError = jasmine.createSpy('handlerError');
		
		stubRequestCon(200, '{"d":"[{\\"Id\\":6944,\\"Documento\\":10659739,\\"Nombre\\":\\"Juan\\",\\"Apellido\\":\\"CALCAGNO\\",\\"Legajo\\":\\"301318\\"}]"}');
		
		repoPersonas.buscarPersonas("CALC", handlearPersonas, handlerError);
		
		expect(handlearPersonas).toHaveBeenCalledWith([juan]);
	});
	

});
