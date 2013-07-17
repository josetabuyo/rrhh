var Planilla = function (planilla) {
    var _this = this;

    //this.id = planilla.id;
    this.instancias = planilla.Instancias;
    this.alumnos = planilla.Alumnos;
    this.evaluaciones = planilla.Evaluaciones;

    this.instancias.html = function (indice) {
        var contenedor = $("<div>");
        if (_this.instancias.length > 0) {
            var label = $("<label>").text("Fecha (Aplicar a todos)").append("<br>");

            var textbox = $("<input>").attr("id", "fecha_instancia_" + this[indice].id);
            textbox.datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function (val) {
                    $(".fecha_evaluacion").change(val);
                }
            });

            textbox.attr("class", "fecha_instancia");
            textbox.val(this[indice].fecha);
            contenedor.append(label);
            contenedor.append(textbox);
        }
        return contenedor;
    }

    this.evaluaciones.pertenece_a = function (alumno) {
        var res = Enumerable.From(this)
		.Where(function (x) { return x.IdAlumno == alumno.Id })
		.ToArray();
        if (res.length > 0)
            return res[0];
        return {
            id_alumno: "",
            id_instancia: "",
            valor: ""
        }
    }
    this.grilla = function () {
        var gr = [];
        for (var i = 0; i < _this.alumnos.length; i++) {
            var fila = {
                alumno: etiquetaAlumno(_this.alumnos[i]),
                calificacion: textCalificacion(_this.evaluaciones.pertenece_a(_this.alumnos[i])),
                fecha: textFecha(_this.evaluaciones.pertenece_a(_this.alumnos[i]))
            }
            gr.push(fila);
        }
        return gr;

    };

    function etiquetaAlumno(alumno) {
        var label = $("<label>");
        label.text(alumno.Nombre);
        return label;
    }

    function textCalificacion(calificacion) {
        var textbox = $("<input>");
        textbox.val(calificacion.Calificacion);
        return textbox;
    }

    function textFecha(calificacion) {
        var textbox = $("<input>");
        textbox.attr("id", "fecha_calificacion_" + calificacion.Id + "_" + calificacion.IdAlumno + "_" + calificacion.IdCurso);
        textbox.val(calificacion.Fecha);
        textbox.attr("class", "fecha_evaluacion");
        textbox.datepicker({ dateFormat: 'dd/mm/yy' });
        return textbox;
    }



    this.html = function () { };
};