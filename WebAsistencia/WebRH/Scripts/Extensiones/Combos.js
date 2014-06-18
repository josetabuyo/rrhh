$.fn.extend({
    cargarCombo: function (col, nombreVal, nombreDescripcion) {
        var _this = this;
        col.forEach(function (item) {
            var option = $("<option value='" + item[nombreVal] + "' item='" + JSON.stringify(item) + "'>" + item[nombreDescripcion] + "</option>");
            _this.append(option);
        });
    },
    itemSeleccionado: function () {
        return JSON.parse(this.find("option:selected").attr("item"));
    }
});
