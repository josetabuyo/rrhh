function Evaluacion(id, calificacion, fecha) {
    var _this = this;

    this.id = id;
    this.calificacion = calificacion;
    this.fecha = fecha;
    
    this.calificacion_otorgada = function () {
        return this.calificacion;
    }
    this.cambiar_calificacion_otorgada = function (calificacion) {
        this.calificacion = calificacion;
    }
    this.fecha_de_calificacion = function () {
        return this.fecha;
    }
    this.cambiar_fecha_de_calificacion = function (fecha) {
        this.fecha = fecha;
    }

    this.html = function () {
        var div_contenedor = $('<div>');

        div_contenedor.attr("id","div_" + _this.id);
        div_contenedor.css('width: 50px;');
        div_contenedor.css('height: 50px;');
        div_contenedor.css('display: block;');

        div_contenedor.append(crear_textbox_fecha());
        div_contenedor.append(crear_select_calificacion());
        return div_contenedor.html();
    }

    function crear_textbox_fecha() {
        var selector_de_fecha = $('<input>');
        selector_de_fecha.attr('type', 'text');
        selector_de_fecha.attr('id', 'txt_fecha_evaluacion_' + _this.id);
        selector_de_fecha.attr('value', _this.fecha_de_calificacion());
        return selector_de_fecha;
    }

    function crear_select_calificacion() {
        var selector_de_calificacion = $('<select>');

        selector_de_calificacion.attr("id", "cmb_calificacion_" + _this.id);

        selector_de_calificacion.append($("<option>", { value: "A", text: "A" }));
        for (var i = 0; i <= 10; i++) {
            if (i == _this.calificacion_otorgada())
                selector_de_calificacion.append($("<option>", { value: i, text: i.toString(), "selected": "selected" }));
            else
                selector_de_calificacion.append($("<option>", { value: i, text: i.toString()}));
            
        }
        return selector_de_calificacion;
    }

};


describe("Test Grilla de Evaluaciones", function () {

    var una_calificacion = "8";
    var una_fecha = "20/03/2013";
    var una_evaluacion = new Evaluacion(una_calificacion, una_fecha);

    it("Mi objeto evaluaciones deberia decirme la calificación otorgada", function () {

        spyOn(una_evaluacion, 'calificacion_otorgada').andCallThrough();
        spyOn(una_evaluacion, 'fecha_de_calificacion').andCallThrough();

        expect(una_evaluacion.calificacion_otorgada()).toBe(una_calificacion);
    });

    it("Mi objeto evaluaciones deberia decirme la calificación otorgada y la fecha en que se hizo", function () {

        spyOn(una_evaluacion, 'calificacion_otorgada').andCallThrough();
        spyOn(una_evaluacion, 'fecha_de_calificacion').andCallThrough();

        expect(una_evaluacion.calificacion_otorgada()).toBe(una_calificacion);
        expect(una_evaluacion.fecha_de_calificacion()).toBe(una_fecha);
    });

    it("Debería poder cambiar la fecha de una evaluación", function () {
        var otra_fecha_de_evaluacion = "25/03/2013";

        spyOn(una_evaluacion, 'fecha_de_calificacion').andCallThrough();

        expect(una_evaluacion.fecha_de_calificacion()).toBe(una_fecha);
        una_evaluacion.cambiar_fecha_de_calificacion(otra_fecha_de_evaluacion);
        expect(una_evaluacion.fecha_de_calificacion()).toBe(otra_fecha_de_evaluacion);

    });

    it("Debería poder cambiar la calificación otorgada de una evaluación", function () {
        var otra_calificacion = 10;

        spyOn(una_evaluacion, 'calificacion_otorgada').andCallThrough();

        expect(una_evaluacion.calificacion_otorgada()).toBe(una_calificacion);
        una_evaluacion.cambiar_calificacion_otorgada(otra_calificacion);
        expect(una_evaluacion.calificacion_otorgada()).toBe(otra_calificacion);
    });

});

