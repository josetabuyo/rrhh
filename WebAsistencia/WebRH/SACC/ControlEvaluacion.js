// JavaScript Document
var Ev = function (ev) {
        var _this = this;
		var calificaciones = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "A"];
		
        this.id = ev.id_instancia.toString() + ev.id_alumno.toString();
        this.fecha = ev.fecha;
        this.calificacion = ev.calificacion;

        this.contenedor = $("<td>");

        this.html = function () {
            var contenedor = _this.contenedor;
            contenedor.css("width", "95px");
            contenedor.css("height", "30px");
            contenedor.append(_this.textboxCalificacion);
            contenedor.append(_this.textboxFecha);
            contenedor.append(_this.botonFecha);
            return contenedor;
        };

        this.botonfecha = function () {
            var boton = $("<input>").attr("type", "button").attr("id", "btn_" + _this.id);
            boton.click(function () {
                $(this).css("display", "none");
                $(_this.textboxFecha).css("display", "inline-block");
                $(_this.textboxFecha).css("visibility", "visible");
            });

            return boton;
        };

        this.textfecha = function () {
            var textbox = $("<input>").attr("type", "text").attr("id", "txtfecha_" + _this.id);

            textbox.val(_this.fecha);
            textbox.datepicker({
                onClose: function () {
                    if (_this.fecha != this.value) {
                        _this.contenedor.css("background-color", "red");
                    } else {
                        _this.contenedor.css("background-color", "white");
                    };
                    $(this).css("display", "none");
                    $(this).css("visibility", "hidden");
                    $(_this.botonFecha).css("display", "inline-block")
                },
                dateFormat: "dd/mm/yy"
            });

			textbox.attr("class", "datepicker");
            textbox.css("width", "70px");
            textbox.css("display", "none");
            textbox.css("visibility", "hidden");

            return textbox;
        };

        this.textcalificacion = function () {
            var textbox = $("<input>").attr("type", "text").attr("id", "txtcalificacion_" + _this.id);
			
			textbox.autocomplete({
				source: calificaciones
			});

            textbox.val(_this.calificacion);

            textbox.css("width", "20px");
            return textbox;
        };

        this.inicializar = function () {
            this.textboxFecha = _this.textfecha();
            this.botonFecha = _this.botonfecha();
            this.textboxCalificacion = _this.textcalificacion();
        }

        this.inicializar();
    };
	
var InstanciaEv = function(instancia){
		var _this = this;

		this.id = instancia.id;
		this.nombre = instancia.nombre;
		this.fecha = instancia.fecha;

		this.calificacionOtorgada = function () {
			return this.calificacion;
		};
		this.cambiarNombre = function (calificacion) {
			this.calificacion = calificacion;
		};
		this.fechaDeCalificacion = function () {
			return this.fecha;
		};
		this.cambiarFechaDeCalificacion = function (fecha) {
			this.fecha = fecha;
		};

		this.html = function () {
			var div_contenedor = $('<td>');

			div_contenedor.attr("id", "div_" + _this.id);
			div_contenedor.css('width: 50px;');
			div_contenedor.css('height: 50px;');

			div_contenedor.append(crearEtiquetaNombre());
			div_contenedor.append($("<br>"));
			div_contenedor.append(crearTextboxFecha());
			return div_contenedor;
		};

		function crearTextboxFecha() {
			var selector_de_fecha = $('<input>');
			selector_de_fecha.attr('type', 'text');
			selector_de_fecha.attr('class', 'date_picker_ie');
			selector_de_fecha.attr('id', 'txt_fecha_evaluacion_' + _this.id);
			selector_de_fecha.datepicker().datepicker("option", "dateFormat", "dd/mm/yy");
			selector_de_fecha.val(_this.fechaDeCalificacion());

			selector_de_fecha.change(function () {
				_this.cambiarFechaDeCalificacion($(this).val());
				$(".date_picker").val($(this).val());

			});

			return selector_de_fecha;
		}

		function crearEtiquetaNombre() {
			var selector_de_nombre = $('<label>');

			selector_de_nombre.attr("id", "lbl_instancia_" + _this.id);
			selector_de_nombre.text(_this.nombre);
			return selector_de_nombre;
		}
	
	}
	
	var Alumno = function(alumno){
		var _this = this;
		this.id = alumno.id;
		this.nombre = alumno.nombre;
		
		this.html = function(){
			return crearEtiquetaNombre();
		}
		
		function crearEtiquetaNombre() {
			var selector_de_nombre = $('<label>');

			selector_de_nombre.attr("id", "lbl_alumno_" + _this.id);
			selector_de_nombre.text(_this.nombre);
			return $("<div>").css("display", "inline-block").css("height", "30px").append(selector_de_nombre);
		}
	}