String.prototype.toUnderscore = function(){
	return this.replace(/([A-Z])/g, function($1){return "_"+$1.toLowerCase();});
};

String.prototype.toUnderscoreCustom = function(){
	var primera_letra_minuscula =  this.substring(0, 1).toLowerCase();
	var el_resto = this.substring(1, this.length);
	var _this = primera_letra_minuscula + el_resto;
	return _this.replace(/([A-Z])/g, function($1){return "_"+$1.toLowerCase();});
};
