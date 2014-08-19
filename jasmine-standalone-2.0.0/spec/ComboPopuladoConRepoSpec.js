describe("ComboPopuladoConRepoBuilder", function() {
	var populador_combos;
	var dom;
	
	beforeEach(function() {
		jasmine.Ajax.install();
	});
	
	afterEach(function() {
		jasmine.Ajax.uninstall();
	});
	
	
	function fakeResponse(plain_response) {
	//dado
		//'[{"Id":1,"Nombre":"NombreLocalidadBuenosAires","Descripcion":"DescripcionBuenosAires"},{"Id":6,"Descripcion":"DescripcionLocalidad6"}]'
	//yydevolver
		//return {"responseText": '{\"d\":' + plain_response.split('"').join('\\\\\\\"')};
		
		jasmine.Ajax.requests.mostRecent().response(
			{"responseText": '{\\\"d\\\":\\\"' + plain_response.split('"').join('\\\\\\\"') + "\\\"}"}
		);
		//return {"responseText": '{\\\"d\\\":\\\"' + plain_response.split('"').join('\\\\\\\"') + "\\\"}"};	
		
		//{"responseText": '{\"d\":\"[{\\\"Id\\\":1,\\\"Nombre\\\":\\\"NombreLocalidadBuenosAires\\\",\\\"Descripcion\\\":\\\"DescripcionBuenosAires\\\"},{\\\"Id\\\":6,\\\"Descripcion\\\":\\\"DescripcionLocalidad6\\\"}]\"}'}
	
	};
	describe("DADO: Un combo", function(){
	
		beforeEach(function() {
			updateable(this, function(args) {
				dom = $('<div><select id="combo_localidades"' + args.data_provider + args.label_combo + args.bindeo + '></select></div>');
			}, ['data_provider', 'label_combo', 'bindeo']);
		});	
		
		describe("Y: sin dataProvider", function() {
			beforeEach(function() {
				this.data_provider = "";
				populador_combos = new ComboPopuladoConRepoBuilder(Repositorio);
			});

			it("ENTONCES: no debe fallar", function() {
				populador_combos.construirCombosEn(dom);
			});
		});  
	
		describe("Y: con dataprovider", function() {
			beforeEach(function() {
				this.data_provider = ' dataProvider="Localidades"';
				populador_combos.construirCombosEn(dom);
			});

			it("ENTONCES: debe invocar al dataProvider indicado", function() {
				expect(jasmine.Ajax.requests.mostRecent().url).toContain('BuscarEnRepositorio');
				expect(jasmine.Ajax.requests.mostRecent().params).toContain('{"nombre_repositorio":"Localidades"');
			});
			
			describe("Y: con un label", function() {
				beforeEach(function() {
					this.label_combo = ' label="Nombre"';
					combos = populador_combos.construirCombosEn(dom);
					

					//fakeResponse('[{"Id":1,"Nombre":"NombreLocalidadBuenosAires","Descripcion":"DescripcionBuenosAires"},{"Id":6,"Descripcion":"DescripcionLocalidad6"}]');
					fakeResponse('[{"Id":1}]');
					//jasmine.Ajax.requests.mostRecent().response({
					//	"responseText": '{\"d\":\"[{\\\"Id\\\":1,\\\"Nombre\\\":\\\"NombreLocalidadBuenosAires\\\",\\\"Descripcion\\\":\\\"DescripcionBuenosAires\\\"},{\\\"Id\\\":6,\\\"Descripcion\\\":\\\"DescripcionLocalidad6\\\"}]\"}'
					//});
				});

				it("ENTONCES: deben cargarse usando el label", function() {
					expect(combos[0].ui.children(0)[0].label).toEqual('NombreLocalidadBuenosAires');
				});
			});
		  
			describe("Y: sin un label", function() {
				beforeEach(function() {
					this.label_combo = "";
					combos = populador_combos.construirCombosEn(dom);
					jasmine.Ajax.requests.mostRecent().response({
						"responseText": '{\"d\":\"[{\\\"Id\\\":1,\\\"Nombre\\\":\\\"NombreLocalidadBuenosAires\\\",\\\"Descripcion\\\":\\\"DescripcionBuenosAires\\\"},{\\\"Id\\\":6,\\\"Descripcion\\\":\\\"DescripcionLocalidad6\\\"}]\"}'
					});
				});

				it("ENTONCES: deben tomar el label 'Descripcion' por default", function() {
					expect(combos[0].ui.children(0)[0].label).toEqual('DescripcionBuenosAires');
				});
			}); 

			describe("Y: se bindea un valor del modelo", function() {
				var domicilio_empleado;

				beforeEach(function() {
					domicilio_empleado = { localidad: 6 };
					empleado = { domicilio: { domicilio_empleado: 6 } };
					this.bindeo = ' modelo="localidad"';
					
					combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades" dataProvider="Localidades" modelo="localidad"></select></div>'), domicilio_empleado);
					jasmine.Ajax.requests.mostRecent().response({
						"responseText": '{\"d\":\"[{\\\"Id\\\":1,\\\"Nombre\\\":\\\"NombreLocalidadBuenosAires\\\",\\\"Descripcion\\\":\\\"DescripcionBuenosAires\\\"},{\\\"Id\\\":6,\\\"Descripcion\\\":\\\"DescripcionLocalidad6\\\"}]\"}'
					});
				});
				
				it("ENTONCES: el valor debe estar seleccionado", function() {
					expect(combos[0].ui.attr("value")).toEqual('6');
				});
				
				describe("Y: cambia el valor del modelo", function() {
					beforeEach(function() {
						domicilio_empleado.localidad = 1;
					});
					
					it("ENTONCES: deberia reflejar el cambio", function() {
						//expect(combos[0].ui.attr("value")).toEqual('1'); //ver por que existe esta diferencia entre ui.attr("value") y idItemSeleccionado()
						expect(combos[0]["id_item_seleccionado"]).toEqual(1);
					});
				});
			});
			
			describe("Y: se bindea un valor de un modelo dentro de otro modelo", function() {
				beforeEach(function() {
					empleado = { hijo: { domicilio: { localidad: 6 } } };
					//this.bindeo = "
					this.bindeo = ' modelo="hijo.domicilio.localidad"';
					combos = populador_combos.construirCombosEn(dom, empleado);
					jasmine.Ajax.requests.mostRecent().response({
						"responseText": '{\"d\":\"[{\\\"Id\\\":1,\\\"Nombre\\\":\\\"NombreLocalidadBuenosAires\\\",\\\"Descripcion\\\":\\\"DescripcionBuenosAires\\\"},{\\\"Id\\\":6,\\\"Descripcion\\\":\\\"DescripcionLocalidad6\\\"}]\"}'
					});

				});

				it("ENTONCES: el valor debe estar seleccionado", function() {
					expect(combos[0].ui.attr("value")).toEqual('6');
				});
				
				describe("Y: cambia el valor del modelo", function() {
					beforeEach(function() {
						empleado.hijo.domicilio.localidad = 1;
					});
					
					it("ENTONCES: deberia reflejar el cambio", function() {
						//expect(combos[0].ui.attr("value")).toEqual('1'); //ver por que existe esta diferencia entre ui.attr("value") y idItemSeleccionado()
						expect(combos[0]["id_item_seleccionado"]).toEqual(1);
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
		   it ("ENTONCES: debe tener el valor seleccionado", function() {
				var domicilio_empleado = { localidad: 6 };
				var combos = populador_combos.construirCombosEn($('<div><select id="combo_localidades" dataProvider="Localidades" modelo="localidad"></select></div>'), domicilio_empleado);
				
				expect(combos[0].idItemSeleccionado()).toEqual(6);
			});
		});
	  
		describe("CUANDO: se construyen combos relacionados, y no se selecciona ningun valor", function() {
			var combo_dependiente;
			var combo_independiente;

			it("ENTONCES: no deberia pedir el valor al backend si no se completo el filtro", function() {
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

			it("ENTONCES: el dependiente debe pedir a su dataProvider los datos filtrados", function() {
				spyOn(combo_dependiente.repositorio, 'buscar');
				combo_independiente.ui.change();
				
				expect(combo_dependiente.repositorio.buscar).toHaveBeenCalled();
				expect(combo_dependiente.repositorio.buscar.calls.mostRecent().args[0]).toEqual("Localidades");
			});
		});
	});
});  

//it("si falla porque necesitaba filtro, debe mandar excepcion explicativa", function() {
//  expect(false).toBe(true);
//});

//it("si falla porque no esta en el modelo el attributo que le quise bindear, deberia lanzar excepcion explicativa", function() {
//  expect(false).toBe(true);
//});
		//describe("CUANDO: se especifica enabled false", function() {
	//it("debe estar desactivado", function() {
		//expect(true).toBe(false);
	//});
	//});
	
	//cuando hay una respuesta erronea del backend, deberia mostrarse un mensaje correcto.
//el builder devuelve los combos javascript

