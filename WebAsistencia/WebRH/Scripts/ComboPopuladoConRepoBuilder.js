var ComboPopuladoConRepoBuilder = function (repositorio) {
	this.repositorio = repositorio
};

ComboPopuladoConRepoBuilder.prototype.construirCombosEn = function (dom) {
	repo = this.repositorio;
    combos = dom.find('[dataProvider]').each(function () {
        var control = this;
		
		new SuperCombo({
            ui: control,
            nombre_repositorio: $(control).attr("dataProvider"),
            repositorio: repo,
        });
		
    });
	return combos;
};