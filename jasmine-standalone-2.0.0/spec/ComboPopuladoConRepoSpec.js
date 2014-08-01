describe("DADO: Un ComboPopuladoConRepoBuilder y su repo que devuelve una localidad", function() {
  var populador_combos;
  var combo;
  var mock_repo;
  var combos;

  beforeEach(function() {
	mock_repo = { buscar: function (nombre_repositorio, criterio, onSuccess, onError) { onSuccess( [{ Id: 1, Nombre:'NombreLocalidadBuenosAires', Descripcion:'DescripcionBuenosAires'}]) } };
	populador_combos = new ComboPopuladoConRepoBuilder(mock_repo);
  });

  describe("CUANDO: se construyen combos con dataprovider y label", function() {
	beforeEach(function() {
		combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades" dataProvider="Localidades" label="Nombre"></select></div>'));
	});
	
	it("los combos deberian invocar al dataProvider indicado", function() {
		spyOn(mock_repo, 'buscar');
		var combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades" dataProvider="Localidades"></select></div>'));
		expect(mock_repo.buscar).toHaveBeenCalled();
		expect(mock_repo.buscar.calls.mostRecent().args[0]).toEqual("Localidades");
	});
  
	it("los combos deben cargarse usando el label", function() {
		expect(combos[0].ui.children(0).text()).toEqual('NombreLocalidadBuenosAires');
	});
  });

  describe("CUANDO: se construyen combos con dataprovider pero sin un label", function() {
	beforeEach(function() {
		combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades" dataProvider="Localidades"></select></div>'));
	});
	
	it("los combos deberian tomar el label 'Descripcion' por default", function() {
		expect(combos[0].ui.children(0).text()).toEqual('DescripcionBuenosAires');
	});
  });  
  
  describe("CUANDO: se construyen combos sin dataprovider", function() {
	it("no debe fallar si no existe ningun combo maracado con dataProvider", function() {
		combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades"></select></div>'));
	});
  });
});

describe("DADO: Un ComboPopuladoConRepoBuilder y su repo que devuelve una provincia y una localidad", function() {
	var populador_combos;
	var mock_repo;
	var combo_dependiente;
	var combo_independiente;
	var combos;
	var combo;

	beforeEach(function() {
		mock_repo = { buscar: function (nombre_repositorio, criterio, onSuccess, onError) { 
											if (nombre_repositorio == "Localidades") {
												onSuccess( [{ Id: 1, Descripcion:'DescripcionLocalidadCABA'}]) ;
											} else {
												onSuccess( [{ Id: 1, Descripcion:'DescripcionProvinciaBuenosAires'}]) ;
											}
									}
								};
		populador_combos = new ComboPopuladoConRepoBuilder(mock_repo);
	});

  
  describe("CUANDO: se construyen combos relacionados, y se selecciona un valor", function() {
    var combo_dependiente;
	var combo_independiente;
	beforeEach(function() {
		var dom = $('<div><select id="combo_provincias" dataProvider="Provincias"></select><select id="combo_localidades" dependeDe="combo_provincias" dataProvider="Localidades"></select></div>');
		combos = populador_combos.construirCombosEn(dom);
		combo_independiente = combos[0];
		combo_dependiente = combos[1];
	});
	
	it("el combo dependiente debe pedir a su dataProvider los datos filtrados", function() {
		spyOn(combo_dependiente.repositorio, 'buscar');
		combo_independiente.ui.change();
		
		expect(combo_dependiente.repositorio.buscar).toHaveBeenCalled();
		expect(combo_dependiente.repositorio.buscar.calls.mostRecent().args[0]).toEqual("Localidades");
	});
  });
});  
  //it("deberia seleccionar el valor que le pase", function() {
  // expect(false).toBe(true);
  //});
  
  //it("si falla porque necesitaba filtro, debe mandar excepcion explicativa", function() {
  //  expect(false).toBe(true);
  //});
