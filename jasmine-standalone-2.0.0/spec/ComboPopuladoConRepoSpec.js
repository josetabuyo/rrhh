describe("ComboPopuladoConRepoBuilder", function() {
	describe("DADO: Un solo combo.", function() {
		var populador_combos;
		var combo;
		var mock_repo;
		var combos;

		//describe("CUANDO: se especifica enabled false", function() {
		//it("debe estar desactivado", function() {
			//expect(true).toBe(false);
		//});
		//});

		beforeEach(function() {
			mock_repo = { buscar: function (nombre_repositorio, criterio, onSuccess, onError) { onSuccess( [{ Id: 1, Nombre:'NombreLocalidadBuenosAires', Descripcion:'DescripcionBuenosAires'}, { Id: 6, Descripcion:'DescripcionLocalidad6'}  ]) } };
			populador_combos = new ComboPopuladoConRepoBuilder(mock_repo);
		});

		describe("CUANDO: se construye sin dataprovider", function() {
			it("no debe fallar", function() {
				combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades"></select></div>'));
			});
		});
		
		describe("CUANDO: se construye con dataprovider", function() {

			it("debe invocar al dataProvider indicado", function() {
					spyOn(mock_repo, 'buscar');
					var combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades" dataProvider="Localidades"></select></div>'));
					expect(mock_repo.buscar).toHaveBeenCalled();
					expect(mock_repo.buscar.calls.mostRecent().args[0]).toEqual("Localidades");
			});
			
			describe("Y: con un label", function() {
				beforeEach(function() {
					combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades" dataProvider="Localidades" label="Nombre"></select></div>'));
				});

				it("deben cargarse usando el label", function() {
					expect(combos[0].ui.children(0)[0].label).toEqual('NombreLocalidadBuenosAires');
				});
			});
		  
			describe("Y: sin un label", function() {
				beforeEach(function() {
					combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades" dataProvider="Localidades"></select></div>'));
				});

				it("deben tomar el label 'Descripcion' por default", function() {
					expect(combos[0].ui.children(0)[0].label).toEqual('DescripcionBuenosAires');
				});
			}); 

			describe("Y: se selecciona un valor segun el modelo", function() {
				var domicilio_empleado;

				beforeEach(function() {
					domicilio_empleado = { localidad: 6 };
					combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades" dataProvider="Localidades" bindeadoCon="localidad"></select></div>'), domicilio_empleado);
				});

				it("el valor debe estar seleccionado", function() {
					expect(combos[0].ui.attr("value")).toEqual('6');
				});
				
				describe("Y: cambia el valor del modelo", function() {
					beforeEach(function() {
						domicilio_empleado.localidad = 1;
					});
					
					it("deberia reflejar el cambio", function() {
						//expect(combos[0].ui.attr("value")).toEqual('1'); //ver por que existe esta diferencia entre ui.attr("value") y idItemSeleccionado()
						expect(combos[0].idItemSeleccionado()).toEqual(1);
					});
				});
			}); 			
		});
	});

	describe("DADO: dos combos dependientes", function() {
		var populador_combos;
		var mock_repo;
		var combo_dependiente;
		var combo_independiente;
		var combos;
		var combo;

		beforeEach(function() {
			mock_repo = { buscar: function (nombre_repositorio, criterio, onSuccess, onError) { 
												if (nombre_repositorio == "Localidades") {
													onSuccess( [{ Id: 1, Descripcion:'DescripcionLocalidadCABA'}, { Id: 6, Descripcion:'DescripcionLocalidadLaPlata'} ]) ;
												} else {
													onSuccess( [{ Id: 1, Descripcion:'DescripcionProvinciaBuenosAires'}]) ;
												}
										}
									};
			populador_combos = new ComboPopuladoConRepoBuilder(mock_repo);
		});

	   describe("CUANDO: bindeo el valor del combo al modelo", function() {
		   it ("debe tener el valor seleccionado", function() {
				var domicilio_empleado = { localidad: 6 };
				var combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades" dataProvider="Localidades" bindeadoCon="localidad"></select></div>'), domicilio_empleado);
				
				expect(combos[0].idItemSeleccionado()).toEqual(6);
			});
		});
	  
		describe("CUANDO: se construyen combos relacionados, y no se selecciona ningun valor", function() {
			var combo_dependiente;
			var combo_independiente;

			it("no deberia pedir el valor al backend si no se completo el filtro", function() {
				mock_repo = { buscar: function (nombre_repositorio, criterio, onSuccess, onError) { 
													if (nombre_repositorio == "Localidades") {
														throw "no deberia haber invocado al repo";
													} else {
														onSuccess( [{ Id: 1, Descripcion:'DescripcionProvinciaBuenosAires'}]) ;
													}
												}
											};
				populador_combos = new ComboPopuladoConRepoBuilder(mock_repo);
				var dom = $('<div><select id="combo_provincias" dataProvider="Provincias"></select><select id="combo_localidades" dependeDe="combo_provincias" dataProvider="Localidades"></select></div>');
				combos = populador_combos.construirCombosEn(dom);
			});
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

			it("el dependiente debe pedir a su dataProvider los datos filtrados", function() {
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
});  