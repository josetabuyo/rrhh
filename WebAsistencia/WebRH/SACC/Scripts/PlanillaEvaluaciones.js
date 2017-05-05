var TextboxCalificacion = function (id) {
    var _this = this;
    this.html = $("<input>").attr("id", id);
}

var TextboxNota = function (id) {
    var _this = this;
    this.html = $("<input>").attr("id", id).attr("class", "text_2caracteres");
    this.validar = function () {
        var expresion_regular_calificaciones = /^(([1]0){0,1}|(([0-9]{1}))(\.[0-9]{1,2}){0,1})$/i;
        //calificaciones_validas = ['0', '1', '1.5', '2', '2.5', '3', '3.5', '4', '4.5', '5', '5.5', '6', '6.5', '7', '7.5', '8', '8.5', '9', '9.5', '10', 'A', ''];
        var calif_valida = false;
        this.html.val(this.html.val().replace(",", "."));
        if (expresion_regular_calificaciones.test(this.html.val()) || this.html.val() == "A" || this.html.val() == "" )
        {
        //expresion_regular_calificaciones.test(this.html.val());
        //if ($.inArray(this.html.val(), calificaciones_validas) < 0) {
            return true; // alertify.alert("", "La calificaci&oacute;n ingresada no es v&aacute;lida");
        } else {
            return false;
        }
    }
    this.html.blur(function () {
        _this.validar();

    });
}

var LabelNota = function (id) {
    var _this = this;
    this.html = $("<label>").attr("id", id).attr("style","padding: 10px; ");//.attr("", "");
}

var LabelFecha = function (id) {
    var _this = this;
    this.html = $("<label>").attr("id", id).css("padding", "5px");
}

var EncabezadoFecha = function (id) {
    var _this = this;
    this.html = $("<input>")
                .attr("type", "text").attr("id", id)
                .attr("class", "encabezado_fecha")               
                .attr("disabled", "disabled")
                .attr("title", "Aplicar fecha a todas las evaluaciones de la instancia")
                .val("Fecha");
    this.boton = $("<img>")
                .attr("src", "../Imagenes/calendar-icon.gif")
                .css("width", "20px")
                .css("height", "16px")
                .attr("title", "Aplicar fecha a todas las evaluaciones de la instancia")
                .click(function () { $("#" + id).datepicker("show"); return false });
    this.observadores = [];
    this.html.click(function () {
        return false;
    });
    this.html.datepicker({
        dateFormat: 'dd/mm/yy',
        onClose: function () {
            for (var i = 0; i < _this.observadores.length; i++) {
                if (this.value != "" && this.value != "Fecha")
                    _this.observadores[i].update(this.value);
            }
            this.value = "Fecha";
        }
    });
};

var TextboxFecha = function (id) {
    var _this = this;
    this.html = $("<input>").attr("type","text").attr("id", id).attr("class", "text_10caracteres");
    this.observadores = [];
    this.html.datepicker({
        dateFormat: 'dd/mm/yy',
        onClose: function () {
            for (var i = 0; i < _this.observadores.length; i++) {
                if (this.value != "" && this.value != "Fecha")
                    _this.observadores[i].update(this.value);
            }
        }
    });
};

EncabezadoFecha.prototype.addObservador = function (obs) {
    this.observadores.push(obs);
};

TextboxFecha.prototype.update = function (fecha) {
    this.Fecha = fecha;
    this.html.val(fecha);
};

TextboxFecha.prototype.dibujarEn = function (panel) {
    panel.append(this.input);
};

TextboxFecha.prototype.html = function () {
    return this.input;
}


var Planilla = function (planilla, readonly) {
    var _this = this;

    this.readonly = readonly;
    this.instancias = planilla.Instancias;
    this.alumnos = planilla.Alumnos;
    this.evaluaciones = planilla.Evaluaciones;

    function iniciar_instancias() {
        for (var i = 0; i < _this.instancias.length; i++) {
            var inst = _this.instancias[i];
            inst.etiqueta = $("<h4>").text(inst.Descripcion);
            if (_this.readonly) {
                inst.fecha = new LabelFecha("instancia_fecha_" + i);
                $(inst.fecha.html).text("Fecha");
            } else {
                inst.fecha = new EncabezadoFecha("instancia_fecha_" + i);
            }

        }
    }
    function iniciar_evaluaciones() {
        for (var i = 0; i < _this.evaluaciones.length; i++) {
            var ev = _this.evaluaciones[i];

            if (_this.readonly) {
                ev.nota = new LabelNota("nota_" + ev.DNIAlumno + "_" + ev.IdInstancia + "_" + i);
                ev.fecha = new LabelFecha("fecha_" + ev.DNIAlumno + "_" + ev.IdInstancia + "_" + i);
                $(ev.nota.html).text(ev.Calificacion);
                $(ev.fecha.html).text(ev.Fecha);
            } else {
                ev.nota = new TextboxNota("nota_" + ev.DNIAlumno + "_" + ev.IdInstancia + "_" + i);
                ev.fecha = new TextboxFecha("fecha_" + ev.DNIAlumno + "_" + ev.IdInstancia + "_" + i);
                ev.nota.html.val(ev.Calificacion);
                ev.fecha.html.val(ev.Fecha);
                ev.nota.html.change(function () {
                    if (this.value != "")
                        $(this).removeClass("nota_no_valida");
                });
                ev.fecha.html.change(function () {
                    if (this.value != "")
                        $(this).removeClass("fecha_no_valida");
                });
                ev.es_valida = function () {
                    var fecha = this.fecha.html;
                    var nota = this.nota.html;
                    var fecha_no_valida = nota.val() != "" && fecha.val() == "";
                    var nota_no_valida = (nota.val() == "" || !this.nota.validar()) && fecha.val() != "";
                    if (fecha_no_valida) {
                        fecha.addClass("fecha_no_valida");
                    } else {
                        fecha.removeClass("fecha_no_valida");
                    }
                    if (nota_no_valida) {
                        nota.addClass("nota_no_valida");
                    } else {
                        nota.removeClass("nota_no_valida");
                    }
                    return !(fecha_no_valida || nota_no_valida);
                }

            }
        }
        if (!_this.readonly) {
            for (var j = 0; j < _this.instancias.length; j++) {
                var inst = _this.instancias[j];
                for (var i = 0; i < _this.evaluaciones.length; i++) {
                    var ev = _this.evaluaciones[i];
                    if (ev.IdInstancia == inst.Id)
                        inst.fecha.addObservador(ev.fecha);
                }
            }
        }
    }

    this.instancias.html = function (indice) {
        var contenedor = $("<div>");
        var inst = _this.instancias[indice];
        if (_this.instancias.length > 0) {
            var etiqueta_titulo = $("<div>").css("text-align", "center").html(inst.etiqueta);
            var etiqueta_calificacion = $("<div>").css("display", "inline-block").css("margin-right", "4px").html("Calif.");

            var contenedor_fecha = $("<div>")
                                    .css("display", "inline-block")
                                    .css("z-index", "1")
                                    .append(inst.fecha.html)
                                    .append(inst.fecha.boton);

            contenedor.append(etiqueta_titulo);
            contenedor.append(etiqueta_calificacion);
            contenedor.append(contenedor_fecha);
            contenedor.append(inst.btn);
        }
        return contenedor;
    }

    this.grilla = function () {
        var gr = [];
        for (var i = 0; i < _this.alumnos.length; i++) {
            var fila = {
                alumno: etiquetaAlumno(_this.alumnos[i]),
                evaluaciones: evaluaciones_para(_this.alumnos[i])
            }
            gr.push(fila);
        }
        return gr;

    };

    function evaluaciones_para(alumno) {
        var res = Enumerable.From(_this.evaluaciones)
		.Where(function (x) { return x.DNIAlumno == alumno.Documento })
		.ToArray();
        if (res.length > 0)
            return res;
        return {
            input: new TextboxFecha(""),
            DNIAlumno: alumno.Documento,
            IdInstancia: "",
            Calificacion: ""
        }
    }

    function etiquetaAlumno(alumno) {
        var label = $("<label>");
        label.text(alumno.Nombre + " " + alumno.Apellido);
        return label;
    };

    iniciar_instancias();
    iniciar_evaluaciones();
};

var GeneradorCalificacionEvaluacion = function (instancia) {
    var self = this;
    self.instancia = instancia;
    self.generar = function (evaluaciones) {
        var queryResult = Enumerable.From(evaluaciones.evaluaciones)
			.Where(function (x) { return x.IdInstancia == instancia.Id });

        if (queryResult.Count() > 0) {
            var res = queryResult.First();
            var contenedor = $("<div>");
            contenedor.append(res.nota.html);
            contenedor.append(res.fecha.html);
            return contenedor;

        }
        else {
            var contenedor = $("<div>");
            return contenedor;
        }
    };
};