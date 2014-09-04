describe("ComboPopuladoConRepoBuilder", function() {
	var populador_combos;
	var dom;
	
	beforeEach(function() {
		jasmine.Ajax.install();
		Backend.start()
	});
	
	afterEach(function() {
		jasmine.Ajax.uninstall();
	});
	
	function fakeResponse(plain_response) {
		var fake_response = {"responseText": '{\"d\":\"' + plain_response.split('"').join('\\\"') + "\"}"} 
		jasmine.Ajax.requests.mostRecent().response(fake_response);
	};
	
	describe("DADO: Un dom inválido", function() {
		describe("CUANDO: es undefined", function() {
			it("ENTONCES: debe lanzar excepcion explicativa al respecto", function() {
				expect(function() {
					RH_FORMS.bindear();
				}).toThrow("No se ha especificado un DOM al intentar bindear con RH_FORMS");
			});
		});
		
		describe("CUANDO: el dom es un objeto invalido", function() {
			it("ENTONCES: debe lanzar una excepcion explicativa al respecto", function() {
				expect(function() {
					RH_FORMS.bindear({});
				}).toThrow('El dom especificado al bindear con RH_FORMS es inválido, no entiende el mensaje "find"');
			});
		});
	});

	describe("DADO: Un combo", function(){
	
		beforeEach(function() {
			updateable(this, function(args) {
				dom = $('<div><select id="combo_localidades"' + args.data_provider + args.label_combo + args.bindeo + '></select></div>');
			}, ['data_provider', 'label_combo', 'bindeo']);
		});	
		
		describe("Y: marcaado como enabled=false", function() {
			it("deberia estar desactivado el combo", function() {
				var dom = $('<div><select id="combo_provincias" enabled="false" dataProvider="Provincias"></select>');
				repo = Repositorio;
				combos = RH_FORMS.bindear(dom, repo);
			});
		});
		
		describe("Y: sin dataProvider", function() {
			beforeEach(function() {
				this.data_provider = "";
			});

			it("ENTONCES: no debe fallar", function() {
				RH_FORMS.bindear(dom, Repositorio);
			});
		});  
	
		describe("Y: con dataprovider", function() {
			beforeEach(function() {
				this.data_provider = ' dataProvider="Localidades"';
			});
			
			it("ENTONCES: debe lanzar excepcion descriptiva si el builder se construye sin repositorio.", function() {
				expect(function() {
					RH_FORMS.bindear(dom);
				}).toThrow("No se ha especificado un repositorio al momento de construir el builder de combos");
			});		
			
			it("ENTONCES: el builder devuelve los combos", function() {
				combos = RH_FORMS.bindear(dom, Repositorio);
				expect(combos.length).toEqual(1);
				expect(combos[0].attr("id")).toEqual("combo_localidades");
			});

			it("ENTONCES: debe invocar al dataProvider indicado", function() {
				RH_FORMS.bindear(dom, Repositorio);
				expect(jasmine.Ajax.requests.mostRecent().params).toContain('{"nombre_metodo":"BuscarLocalidades"');
			});
			
			describe("Y: con un label", function() {
				beforeEach(function() {
					this.label_combo = ' label="Nombre"';
					combos = RH_FORMS.bindear(dom, Repositorio);
					fakeResponse('[{"Id":1,"Nombre":"NombreLocalidadBuenosAires","Descripcion":"DescripcionBuenosAires"},{"Id":6,"Descripcion":"DescripcionLocalidad6"}]');
				});
			
				it("ENTONCES: deben cargarse usando el label", function() {
					expect(combos[0].children(0)[0].childNodes[0].nodeValue).toEqual('NombreLocalidadBuenosAires');
				});
			});
		  
			describe("Y: sin un label", function() {
				beforeEach(function() {
					this.label_combo = "";
					combos = RH_FORMS.bindear(dom, Repositorio);
					fakeResponse('[{"Id":1,"Nombre":"NombreLocalidadBuenosAires","Descripcion":"DescripcionBuenosAires"},{"Id":6,"Descripcion":"DescripcionLocalidad6"}]');
				});

				it("ENTONCES: deben tomar el label 'Descripcion' por default", function() {
					expect(combos[0].children(0)[0].childNodes[0].nodeValue).toEqual('DescripcionBuenosAires');
				});
			}); 

			describe("Y: se bindea un valor localidad del modelo", function() {
				var domicilio_empleado;

				beforeEach(function() {
					domicilio_empleado = { localidad: 6 };
					empleado = { domicilio: { domicilio_empleado: 6 } };
					this.bindeo = ' modelo="localidad"';
					dom = $('<div><select id="combo_localidades" dataProvider="Localidades" modelo="localidad"></select></div>')
					combos = RH_FORMS.bindear(dom, Repositorio, domicilio_empleado);
					fakeResponse('[{"Id":1,"Nombre":"NombreLocalidadBuenosAires","Descripcion":"DescripcionBuenosAires"},{"Id":6,"Descripcion":"DescripcionLocalidad6"}]');
				});
				
				it("ENTONCES: el valor debe estar seleccionado", function() {
					expect(combos[0].attr("value")).toEqual('6');
				});
				
				describe("Y: cambia el valor del modelo", function() {
					beforeEach(function() {
						domicilio_empleado.localidad = 1;
					});
					
					it("ENTONCES: deberia reflejar el cambio", function() {
						expect(combos[0]["id_item_seleccionado"]).toEqual(1);
					});
				});
				
				describe("Y: cambia el valor del combo", function() {
					beforeEach(function() {
						combos[0].val('1').change();
					});
					
					it("ENTONCES: deberia cambiar el valor del modelo", function() {
						expect(domicilio_empleado.localidad).toEqual('1');
					});
				});
			});
			
			
			describe("Y: se bindea un valor hijo.domicilio.localidad de un modelo (dentro de otro)", function() {
				beforeEach(function() {
					empleado = { hijo: { domicilio: { localidad: 6 } } };
					this.bindeo = ' modelo="hijo.domicilio.localidad"';
				});
				
				describe("Y: el modelo especificado no es correcto", function() {
				
					it("ENTONCES: deberia lanzar excepcion explicando el error", function() {
						this.bindeo = ' modelo="hijo.domicilio.atributo_inexistente"';
						expect(function() {
							combos = RH_FORMS.bindear(dom, Repositorio, empleado);
						}).toThrow("Error al intentar bindear el modelo \"hijo.domicilio.atributo_inexistente\" al combo \"combo_localidades\"");
					});			
				});
				
				describe("Y: el modelo especificado es correcto", function() {
					beforeEach(function() {
						this.bindeo = ' modelo="hijo.domicilio.localidad"';
						combos = RH_FORMS.bindear(dom, Repositorio, empleado);
						fakeResponse('[{"Id":1,"Nombre":"NombreLocalidadBuenosAires","Descripcion":"DescripcionBuenosAires"},{"Id":6,"Descripcion":"DescripcionLocalidad6"}]')
					});

					it("ENTONCES: el valor debe estar seleccionado", function() {
						expect(combos[0].attr("value")).toEqual('6');
					});
					
					describe("Y: cambia el valor del modelo", function() {
						beforeEach(function() {
							empleado.hijo.domicilio.localidad = 1;
						});
						
						it("ENTONCES: deberia reflejar el cambio", function() {
							expect(combos[0]["id_item_seleccionado"]).toEqual(1);
						});
					});
					
					describe("Y: cambia el valor del combo", function() {
						beforeEach(function() {
							combos[0].val('1').change();
						});
						
						it("ENTONCES: deberia cambiar el valor del modelo", function() {
							expect(empleado.hijo.domicilio.localidad).toEqual('1');
						});
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
		});
		
		it("ENTONCES: el builder devuelve los combos", function() {
			dom = $('<div><select id="combo_provincias" dataProvider="Provincias" modelo="Provincia"></select><select id="combo_localidades" dependeDe="combo_provincias" dataProvider="Localidades"></select></div>');
			combos = RH_FORMS.bindear(dom, Repositorio);
			expect(combos.length).toEqual(2);
			expect(combos[0].attr("id")).toEqual("combo_provincias");
			expect(combos[1].attr("id")).toEqual("combo_localidades");
		});
		
		describe("CUANDO: no existe el combo del que depende", function() {
			it("ENTONCES: deberia lanzar excepcion explicativa al respecto", function() {
				var dom = $('<div><select id="combo_localidades" dependeDe="combo_inexistente" dataProvider="Localidades"></select></div>');				
				expect(function() {
					combos = RH_FORMS.bindear(dom, Repositorio);
				}).toThrow('El combo "combo_localidades" depenDe el combo "combo_inexistente" que no existe o no fué encontrado.')
			});
		});

		describe("CUANDO: se construyen combos relacionados, y no se selecciona ningun valor", function() {
			it("ENTONCES: no deberia pedir el valor al backend por no especificar el filtro", function() {
				mock_repo = { buscar: function (nombre_repositorio, criterio, onSuccess, onError) { 
													if (nombre_repositorio == "Localidades") {
														throw "no deberia haber invocado al repo";
													} else {
														onSuccess( [{ Id: 1, Descripcion:'DescripcionProvinciaBuenosAires'}]) ;
													}
												}
											};
				var dom = $('<div><select id="combo_provincias" modelo="Provincia" dataProvider="Provincias"></select><select id="combo_localidades" dependeDe="combo_provincias" dataProvider="Localidades"></select></div>');
				combos = RH_FORMS.bindear(dom, Repositorio);
			});
		});
	  
		describe("CUANDO: se construyen combos relacionados, y se selecciona un valor", function() {
			var combo_dependiente;
			var combo_independiente;
			var repo;
			beforeEach(function() {
				var dom = $('<div><select id="combo_provincias" modelo="Provincia" dataProvider="Provincias"></select><select id="combo_localidades" dependeDe="combo_provincias" dataProvider="Localidades"></select></div>');
				repo = Repositorio;
				combos = RH_FORMS.bindear(dom, repo);
				combo_independiente = combos[0];
				combo_dependiente = combos[1];
			});

			it("ENTONCES: el dependiente debe pedir a su dataProvider los datos filtrados", function() {
				spyOn(repo, 'buscar');
				combo_independiente.change();
				
				expect(repo.buscar).toHaveBeenCalled();
				expect(repo.buscar.calls.mostRecent().args[0]).toEqual("Localidades");
			});
		});
	});
});  

//describe("CUANDO: se especifica enabled false", function() {
	//it("debe estar desactivado", function() {
		//expect(true).toBe(false);
	//});
//});
	
//cuando hay una respuesta erronea del backend, deberia mostrarse un mensaje correcto.
