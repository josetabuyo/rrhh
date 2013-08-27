var BotonAsistencia = function (id_alumno, dia_cursado, valor, valor_maximo) {
    var _this = this;
    this.id_alumno = id_alumno;
    this.dia_cursado = dia_cursado;
    this.valor = valor;
	this.estado = 0;
    this.valor_maximo = valor_maximo;
    this.atributos = [];

    this.IniciarAtributos = function () {
        _this.atributos[0] = { estilo: 'btn_blanco_clicked', etiqueta: '  ', valor: 0 }
        for (var j = 1; j <= _this.valor_maximo; j++) {
            _this.atributos[j] = { estilo: 'btn_verde_clicked', etiqueta: j, valor: j }
        }
        _this.atributos[_this.atributos.length] = { estilo: 'btn_amarillo_clicked', etiqueta: 'A', valor: "-1" }
        _this.atributos[_this.atributos.length] = { estilo: 'btn_amarillo_clicked', etiqueta: '-', valor: "-2" }
		_this.CambiarEstado(0);
    }

    this.html = $('<input>')
                    .attr('id', 'btnAsistencia' + id_alumno + "_" + dia_cursado)
                    .attr('type', 'button')
                    .attr("data-valor_maximo", valor_maximo)
                    .attr("data-id_alumno", id_alumno)
                    .attr("data-dia_cursado", dia_cursado)
                    .click(function () {
                        _this.CambiarEstado(1);
                    });

    this.CambiarEstado = function (add) {
		var estado;
		for(var e = 0; e < _this.atributos.length; e++){
			if(_this.atributos[e].valor == _this.valor){
				estado = e;
				break;
			}
		}
		var boton = $(_this.html);
        
        var i = (add+estado) % _this.atributos.length;

		_this.estado = i;
		_this.valor = _this.atributos[i].valor
        boton.attr('data-estado', i);
        boton.attr('data-valor', _this.atributos[i].valor);
        boton.removeClass();
        boton.addClass(_this.atributos[i].estilo);
        boton.val(_this.atributos[i].etiqueta);
    }
	
	this.IniciarAtributos();
}