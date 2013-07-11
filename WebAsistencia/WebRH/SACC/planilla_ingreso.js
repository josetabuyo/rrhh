// JavaScript Document
var planilla = {
    id: 1,
    alumnos: [{
        id: 1,
        nombre: "Jorge"
    }, {
        id: 2,
        nombre: "Belén"
    }, {
        id: 3,
        nombre: "Fernando"
    }],
    instancia: {
        id: 1,
        nombre: "Primer Parcial",
		fecha: "23/06/2013"
    },
    evaluaciones: [{
        id_alumno: 1,
        id_instancia: 1,
        valor: 6,
		fecha: ""
    }, {
        id_alumno: 2,
        id_instancia: 1,
        valor: 10,
		fecha: ""
    }, {
        id_alumno: 3,
        id_instancia: 1,
        valor: 10,
		fecha: ""
    }]
};

var Planilla = function (planilla) {
    var _this = this;
    
	this.id = planilla.id;
	this.instancia = planilla.Instancias;
    this.alumnos = planilla.Alumnos;
    this.evaluaciones = planilla.Evaluaciones;
	
	this.instancia.html = function(){
		var contenedor = $("<div>");
		var label = $("<label>").text("Fecha").append("<br>");
		
		var textbox = $("<input>").attr("id", "fecha_instancia_" + this.id);
		textbox.datepicker({
			onClose: function(val){
				$(".fecha_evaluacion").change(val);
			}
		});
		
		textbox.attr("class", "fecha_instancia");
		textbox.val(this.fecha);
		contenedor.append(label);
		contenedor.append(textbox);
		return contenedor;	
	}

    this.evaluaciones.pertenece_a = function (alumno) {
		var res = Enumerable.From(this)
		.Where(function (x) { return x.id_alumno == alumno.id })
		.ToArray();
		if(res.length > 0)
			return res[0];
		return {
			id_alumno: "",
			id_instancia: _this.instancia.id,
			valor: ""
		}
	}
    this.grilla = function () {
        var gr = [];
		for(var i=0; i<_this.alumnos.length; i++)
		{
			var fila = {
				alumno: etiquetaAlumno(_this.alumnos[i]),
				calificacion: textCalificacion(_this.evaluaciones.pertenece_a(_this.alumnos[i])),
				fecha: textFecha(_this.evaluaciones.pertenece_a(_this.alumnos[i]))
			}
			gr.push(fila);
		}
		return gr;
        
    };
	
	function etiquetaAlumno(alumno){
		var label = $("<label>");
		label.text(alumno.Nombre);
		return label;
	}
	
	function textCalificacion(calificacion){
		var textbox = $("<input>");
		textbox.val(calificacion.valor);
		return textbox;
	}
	
	function textFecha(calificacion){
		var textbox = $("<input>").datepicker();
		textbox.attr("id", "fecha_calificacion_" + calificacion.id_instancia + "_" + calificacion.id_alumno);
		textbox.val(calificacion.fecha);
		textbox.attr("class", "fecha_evaluacion");
		return textbox;
	}
	

	
    this.html = function () {};
};