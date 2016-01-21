$(document).ready(function () {
    Backend.start(function () {
        VistaFormulario.start();        
    });
});

var VistaFormulario = {
    start: function () {
        var _this = this;
        $('#fecha_ingreso_apn').datepicker();
        $('#fecha_ingreso_apn').datepicker('option', 'dateFormat', 'dd/mm/yy');
        $('#fecha_ingreso_minis').datepicker();
        $('#fecha_ingreso_minis').datepicker('option', 'dateFormat', 'dd/mm/yy');
        $('#fecha_ingreso_oficina').datepicker();
        $('#fecha_ingreso_oficina').datepicker('option', 'dateFormat', 'dd/mm/yy');
        var selector_personas = new SelectorDePersonas({
            ui: $('#selector_usuario'),
            repositorioDePersonas: new RepositorioDePersonas(new ProveedorAjax("../")),
            placeholder: "nombre, apellido, documento o legajo"
        });

        var formulario = {};

        var cambios = {};

        $("[rh-control-type='combo']").each(function (i, e) {
            var _this = this;
            var select = $(this);
            var opt_constructor = {
                select: select,
                dataProvider: select.attr('rh-data-provider'),
                permiteAgregar: select.attr('rh-permite-agregar') || false
            };
            var prop_label = select.attr("rh-propiedad-label");
            if (prop_label) opt_constructor.propiedadLabel = prop_label;


            var filter_key = select.attr('rh-filter-key');
            var id_filter_combo = select.attr('rh-id-filter-combo');
            if (filter_key && id_filter_combo) {
                var filter_combo = $("#" + id_filter_combo);
                opt_constructor.filtro = {};
                var valor_filtro = parseInt(filter_combo.val());
                if (isNaN(valor_filtro)) valor_filtro = -1;
                opt_constructor.filtro[filter_key] = valor_filtro;
            }

            var combo = new ComboConBusquedaYAgregado(opt_constructor);

            if (filter_key && id_filter_combo) {
                var filter_combo = $("#" + id_filter_combo);
                filter_combo.change(function () {
                    var filtro = {};
                    var valor_filtro = parseInt(filter_combo.val());
                    if (isNaN(valor_filtro)) valor_filtro = -1;
                    filtro[filter_key] = valor_filtro;
                    combo.filtrarPor(filtro);
                });
            }
        });

        _this.habilitar_registro_cambios = true;
        $("[campo]").change(function () {
            if (_this.habilitar_registro_cambios) cambios[$(this).attr("campo")] = $(this).val();
        });
        $("#btn_guardar_cambios").click(function () {
            var form_cambios = {
                idFormulario: formulario.idFormulario,
                idPersona: formulario.idPersona,
                campos: []
            }

            for (var campo_cambio in cambios) {
                if (cambios.hasOwnProperty(campo_cambio)) {
                    form_cambios.campos.push({
                        clave: campo_cambio,
                        valor: cambios[campo_cambio]
                    });
                }
            }

            console.log(form_cambios);
            Backend.GuardarCambiosEnFormulario(form_cambios)
            .onSuccess(function () {
                alertify.success("Formulario guardado correctamente");
            })
            .onError(function () {
                alertify.error("Error al guardar formulario");
            });
        });
        selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
            $(".contenedor_formulario").hide()
            _this.limpiarPantalla();
            Backend.GetFormulario(JSON.stringify({ idFormulario: 1, idPersona: la_persona_seleccionada.id })).onSuccess(function (form) {
                //            formulario = {
                //                id: 1,
                //                nombre: "Relevamiento de contrato",
                //                idPersona: 111,
                //                campos: [
                //                        { campo: "nombre", valor: "agustin" },
                //                        { campo: "apellido", valor: "calcagno" }
                //                    ]
                //            };

                formulario = form;
                form.idPersona = la_persona_seleccionada.id;
                form.idFormulario = 1;
                _this.habilitar_registro_cambios = false;
                $("[campo]").each(function () {
                    var campo = _.findWhere(formulario.campos, { clave: $(this).attr("campo") });
                    if (campo) {
                        $(this).val(campo.valor);
                        $(this).attr("valor_para_carga_async", campo.valor);
                        $(this).change();
                    }
                });
                _this.habilitar_registro_cambios = true;

                $(".contenedor_formulario").show()

                _this.dibujarEstudios();
                _this.ocultarTareas();
                _this.bindearBtnAgregarConocimiento();

                $("#CodigoBarra").barcode("FRH000," + "Para Tu Mama", "code128", {
                    showHRI: true,
                    height: 30,
                    width: 100
                });

            });
        };
    },
    limpiarPantalla: function () {
        this.habilitar_registro_cambios = false;
        $("[campo]").each(function () {
            $(this).val("");
            $(this).change();
        });
        this.habilitar_registro_cambios = true;
    },
    dibujarEstudios: function () {
        var div_estudios_extras = $(".caja_extra");
        div_estudios_extras.each(function () {
            if (this.children[0].children[1].value == "") {
                this.className = this.className + " ocultarEstudio";
            }
        })

        $('.input_estudio_extra').change(function () {
            var caja = this.parentNode.parentNode;
            if (this.value != "") {
                caja.className = caja.className.replace(/(?:^|\s)ocultarEstudio(?!\S)/g, '');
            } else {
                caja.className = caja.className + ' ocultarEstudio';
            }
        })

        $('.hidden').removeClass('hidden').hide();
        $("#cargar_mas_estudios").click(function () {
            $('.ocultarEstudio').toggleClass("mostrarEstudio");
            $(this).find('span').each(function () { $(this).toggle(); });
            return;
        })
    },
    ocultarTareas: function () {
        var _this = this;
        $('#contenedor_tarea_generales').show();
        $('#contenedor_tarea_administrativa').show();
        $('#contendor_tarea_tecnica').show();
        $('#contenedor_asistencia_tecnica').show();
        $('#contenedor_servicios_profesionales').show();
        $('#contenedor_tareas_adicionales').show();

        var esA = false;
        var esB = false;
        var esC = false;
        var esD = false;
        var esE = false;
        var esF = false;
        var esProfesional = false;
        var esTecnico = false;
        var esAdministrativo = false;


        var separador1 = "(";
        var separador2 = "-";
        var cadena = $('#funcion').val();
        var arregloDeSubCadenas = cadena.split(separador1);
        if (arregloDeSubCadenas.length > 0) {
            //me fijo que letra es en el primer caracter del segundo item
            switch (arregloDeSubCadenas[1].charAt(0)) {
                case 'A':
                    console.log('A');
                    esA = true;

                    break;
                case 'B':
                    esB = true;
                    console.log('B');
                    break;
                case 'C':
                    esC = true;
                    console.log('C');
                    break;
                case 'D':
                    esD = true;
                    console.log('D');
                    break;
                case 'E':
                    esE = true;
                    console.log('E');
                    break;
                case 'F':
                    esF = true;
                    console.log('F');
                    break;
                default:
                    console.log('Sin Letra');
                    break;
            } //end switch
            //divido el segundo item por el -, para detectar si es profesional o tec
            var arregloDeSubSubCadenas = arregloDeSubCadenas[1].split(separador2);
            if (arregloDeSubSubCadenas.length > 1) {
                //si es profesional o tecnico o administrativo
                switch (arregloDeSubSubCadenas[1].charAt(0)) {
                    case 'u':
                        esProfesional = true;
                        console.log('u');
                        break;
                    case 't':
                        esTecnico = true;
                        console.log('t');
                        break;
                    default:
                        esAdministrativo = true;
                        console.log('Administrativo');
                        break;
                } //end switch
            } else {
                esAdministrativo = true;
            } //end if

            if (!(esF || esE || (esD && esAdministrativo))) {
                $('#contenedor_tarea_generales').hide();
            }
            if (!((esC && esAdministrativo) || (esD && esAdministrativo) || esE || esF)) {
                $('#contenedor_tarea_administrativa').hide();
            }
            if (!((esC && esAdministrativo) || (esD && esAdministrativo))) {
                $('#contendor_tarea_tecnica').hide();
            }
            if (!((esB && esAdministrativo) || (esB && esTecnico) || (esC && esTecnico) || (esD && esTecnico))) {
                $('#contenedor_asistencia_tecnica').hide();
            }
            if (!((esB && esProfesional) || (esC && esProfesional) || (esD && esProfesional))) {
                $('#contenedor_servicios_profesionales').hide();
            }
            if (!(esA || (esB && esProfesional) || (esC && esProfesional))) {
                $('#contenedor_tareas_adicionales').hide();
            }

        } // end if
    },
    bindearBtnAgregarConocimiento: function () {
        var btn = $('#btn_Agregar_Conocimientos');

        btn.click(function () {
            var herramienta = $('#cboHerramientas').find('option:selected').text();
            var conocimiento = $('#cboConocimiento').find('option:selected').text();
            var texto = herramienta + ' - ' + conocimiento;

            var div = $('<div>');
            div.addClass('caja_estilo_conocimiento');

            var input = $('<input>');
            input.attr('campo', 'conocimiento');
            input.attr('disabled', 'disabled');
            input.attr('size', texto.length);
            input.addClass('estilo_conocimientos');
            input.val(texto);

            var eliminar = $('<img>');
            eliminar.attr('src', '../Imagenes/iconos/icono-eliminar.png');
            eliminar.addClass('icono_eliminar');

            eliminar.click(function () {
                this.parentElement.remove();
            })

            div.append(input);
            div.append(eliminar);

            $('#listadoConocimientos').append(div);


        })

    }
}