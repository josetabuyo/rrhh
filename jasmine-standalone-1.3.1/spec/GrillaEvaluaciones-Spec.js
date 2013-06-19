
describe("Test Grilla de Evaluaciones", function () {

    var una_calificacion = "8";
    var una_fecha = "20/03/2013";
    var una_evaluacion = new Evaluacion(1,una_calificacion, una_fecha);

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

