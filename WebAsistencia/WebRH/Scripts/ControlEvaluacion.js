function Evaluacion(evaluacion) {
    var _this = this;

    this.id = evaluacion.id;
    this.calificacion = evaluacion.calificacion;
    this.fecha = evaluacion.fecha;
    
    this.calificacionOtorgada = function () {
        return this.calificacion;
    }
    this.cambiarCalificacion = function (calificacion) {
        this.calificacion = calificacion;
    }
    this.fechaDeCalificacion = function () {
        return this.fecha;
    }
    this.cambiarFechaDeCalificacion = function (fecha) {
        this.fecha = fecha;
    }

    this.html = function () {
        var div_contenedor = $('<div>');

        div_contenedor.attr("id","div_" + _this.id);
        div_contenedor.css('width: 50px;');
        div_contenedor.css('height: 50px;');
        div_contenedor.css('display: block;');

        div_contenedor.append(crearSelectCalificacion());
        div_contenedor.append(crearTextboxFecha());
        return div_contenedor;
    }

    function crearTextboxFecha() {
        var selector_de_fecha = $('<input>');
        selector_de_fecha.attr('type', 'text');
        selector_de_fecha.attr('class', 'date_picker');
        selector_de_fecha.attr('id', 'txt_fecha_evaluacion_' + _this.id);
		selector_de_fecha.datepicker().datepicker("option", "dateFormat", "dd/mm/yy");
		selector_de_fecha.val(_this.fechaDeCalificacion());
		
		selector_de_fecha.change(function(){
			_this.cambiarFechaDeCalificacion($(this).val());
		});
		
        return selector_de_fecha;
    }

    function crearSelectCalificacion() {
        var selector_de_calificacion = $('<select>');

        selector_de_calificacion.attr("id", "cmb_calificacion_" + _this.id);
		selector_de_calificacion.attr("class", "cmb_calificacion");
		

        selector_de_calificacion.append($("<option>", { value: "A", text: "A" }));
        for (var i = 0; i <= 10; i++) {
            if (i == _this.calificacionOtorgada())
                selector_de_calificacion.append($("<option>", { value: i, text: i.toString(), "selected": "selected" }));
            else
                selector_de_calificacion.append($("<option>", { value: i, text: i.toString()}));
            
        }
		selector_de_calificacion.change(function(){
			_this.cambiarCalificacion($(this).val());
		});
        return selector_de_calificacion;
    }

};


function InstanciaDeEvaluacion(instancia) {
    var _this = this;

    this.id = instancia.id;
    this.nombre = instancia.nombre;
    this.fecha = instancia.fecha;
    
    this.calificacionOtorgada = function () {
        return this.calificacion;
    }
    this.cambiarNombre = function (calificacion) {
        this.calificacion = calificacion;
    }
    this.fechaDeCalificacion = function () {
        return this.fecha;
    }
    this.cambiarFechaDeCalificacion = function (fecha) {
        this.fecha = fecha;
    }

    this.html = function () {
        var div_contenedor = $('<div>');

        div_contenedor.attr("id","div_" + _this.id);
        div_contenedor.css('width: 50px;');
        div_contenedor.css('height: 50px;');
        div_contenedor.css('display: block;');

        div_contenedor.append(crearEtiquetaNombre());
		div_contenedor.append($("<br>"));
        div_contenedor.append(crearTextboxFecha());
        return div_contenedor;
    }

    function crearTextboxFecha() {
        var selector_de_fecha = $('<input>');
        selector_de_fecha.attr('type', 'text');
        selector_de_fecha.attr('class', 'date_picker');
        selector_de_fecha.attr('id', 'txt_fecha_evaluacion_' + _this.id);
		selector_de_fecha.datepicker().datepicker("option", "dateFormat", "dd/mm/yy");
		selector_de_fecha.val(_this.fechaDeCalificacion());
		
		selector_de_fecha.change(function(){
			_this.cambiarFechaDeCalificacion($(this).val());
			$(".date_picker").val($(this).val());
			
		});
		
        return selector_de_fecha;
    }

    function crearEtiquetaNombre() {
        var selector_de_calificacion = $('<label>');

        selector_de_calificacion.attr("id", "lbl_instancia_" + _this.id);
		selector_de_calificacion.text(_this.nombre);
        return selector_de_calificacion;
    }

};