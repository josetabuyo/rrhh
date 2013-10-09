var Area = function (area) {
    this._area = area;
    this.start();
};

Area.prototype.start = function () {

};

Area.prototype.id = function () {
    return this._area.Id;
};

Area.prototype.nombre = function () {
    return this._area.Nombre;
};

Area.prototype.responsable = function () {
    return this._area.datos_del_responsable.Apellido + ", " + this._area.datos_del_responsable.Nombre;
};

Area.prototype.telefonos = function () {
    return this.getDatosDeContacto(1);
};

Area.prototype.faxes = function () {
    return this.getDatosDeContacto(2);
};

Area.prototype.mails = function () {
    return this.getDatosDeContacto(3);
};

Area.prototype.direccion = function () {
    return this._area.Direccion;
};

Area.prototype.asistentes = function () {
    return this._area.Asistentes; 
};

Area.prototype.getDatosDeContacto = function (tipoDato) {
    var datos = "";
    for (var i = 0; i < this._area.DatosDeContacto.length; i++) {
        if (this._area.DatosDeContacto[i].Id == tipoDato) {
            datos += this._area.DatosDeContacto[i].Dato + ", ";
        }
    }
    if (datos.length > 0) datos = datos.substring(0, datos.length - 2);
    return datos;
};