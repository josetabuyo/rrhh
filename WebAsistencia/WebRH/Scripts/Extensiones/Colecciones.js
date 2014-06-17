Array.prototype.forEach = function (iterador) {
    var _this = this;
    for (var i = 0; i < this.length; i++) {
        iterador(_this[i]);
    }
};