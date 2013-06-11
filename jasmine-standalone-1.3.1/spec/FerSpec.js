describe("Hello world", function() {
    it("says hello", function() {
        expect(helloWorld()).toEqual("Hello world!");
    });
});

describe('Mi matcher', function() {

    beforeEach(function() {
        this.addMatchers({
            toBeDivisibleByTwo: function() {
                return (this.actual % 2) === 0;
            }
        });
    });

    it('es divisible por 2', function() {
        expect(gimmeANumber()).toBeDivisibleByTwo();
    });

});

describe('some suite', function () {
  var valor_inicial = 1;
  afterEach(function () {
    valor_inicial = 0;
  });

  it('Deberia ser igual a 1', function () {
    expect(valor_inicial).toEqual(1);
  });

  it('Deberia ser igual a 0 despues', function () {
    expect(valor_inicial).toEqual(0);
  });
});

describe("SPY Persona", function() {
    it("ESPIO que se deberia haber llamado el metodo sayHello() dentro de Persona", function() {
        var fakePerson = new Person();
        spyOn(fakePerson, "sayHello");
        fakePerson.helloSomeone("world");
        expect(fakePerson.sayHello).toHaveBeenCalled();
    });
});

describe("SPY Persona", function() {
    it("ESPIO que se llamo al metodo helloSomeone enviando un argumento en especifico", function() {
        var fakePerson = new Person();
        spyOn(fakePerson, "helloSomeone");
        fakePerson.helloSomeone("world");
        expect(fakePerson.helloSomeone).toHaveBeenCalledWith("world");		
    });
});

describe("SPY Persona", function() {
    it("ESPIO que NO se llamo al metodo helloSomeone enviando un argumento en especifico", function() {
        var fakePerson = new Person();
        spyOn(fakePerson, "helloSomeone");
        fakePerson.helloSomeone("world");
        expect(fakePerson.helloSomeone).not.toHaveBeenCalledWith("foo");
    });
});

describe("SPY FAKE Person", function() {
    it("Llamar a un metodo dummy", function() {
        var fakePerson = new Person();
        fakePerson.sayHello = jasmine.createSpy('"Say hello" spy').andReturn("ello ello");//seteo un metodo sin importar que haga algo real, solo quiero testear que se llame y puedo agregar de esperar algo en especifico
        fakePerson.helloSomeone("world");
        expect(fakePerson.sayHello).toHaveBeenCalled();
    });
});

describe("SPY FAKE Person", function() {
    it("Llamar a un metodo dummy que a su vez llama a otro metodo", function() {
        var fakePerson = new Person();
		fakePerson.sayHello = jasmine.createSpy('"Say hello" spy').andCallFake(function() {
			//document.write("Time to say hello!");
			return "bonjour";
		});//quiero que mi funcion boba llame a otra funcion por ejemplo

        fakePerson.helloSomeone("world");
        expect(fakePerson.sayHello).toHaveBeenCalled();
    });
});

describe("ASINCRONICO", function() {
    it("run llama asincronicamente", function() {
        
		runs(function() {
			var foo = 1;
			expect(foo).toEqual(1);
		});
		runs(function() {
			var bar = 2;
			bar ++;
			expect(bar).toEqual(3);
		});

    });
});

// describe("ASINCRONISMO", function() {
	// it("le pido hora al servidor", function () {
			// runs(function () {
				// expect(reloj.horaActual()).toBeUndefined();
				// reloj.pedirLaHora();
				// expect(reloj.horaActual()).toBeUndefined();
			// });
			// waits(0);
			// waitsFor(function () {
				// return reloj.horaActual() !== undefined;
			// }, 
			// "No se recibió la hora, jue pucha", 
			// 10000);
			
			// runs(function () {
				// expect(reloj.horaActual()).toBeDefined();
			// });
	// });
// });