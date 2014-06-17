$.fn.extend({
    cargarCombo: function (col, nombreVal, nombreDescripcion) {
        var _this = this;
        col.forEach(function (item) {
            var option = $("<option value='" + item[nombreVal] + "'>" + item[nombreDescripcion] + "</option>");
            _this.append(option);
        });
    }
});
