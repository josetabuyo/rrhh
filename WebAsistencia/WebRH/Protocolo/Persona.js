var Persona = function (persona) {
    this._persona = persona;
    this.start();
    //_this = this;
};

Persona.prototype.start = function () {

};

Persona.prototype.id = function () {
    return this._persona.Id;
};

Persona.prototype.documento = function () {
    return this._persona.Documento;
};

Persona.prototype.nombre = function () {
    return this._persona.Apellido + ", " + this._persona.Nombre;
};

Persona.prototype.area = function () {
    return this._persona.Area.Alias;
};

Persona.prototype.inasistencias = function () {
    return this._persona.Inasistencias[0].Descripcion;
};

Persona.prototype.desde = function () {
    return new Date(this._persona.Inasistencias[0].Desde).toLocaleDateString();
};

Persona.prototype.hasta = function () {
    return new Date(this._persona.Inasistencias[0].Hasta).toLocaleDateString();
};

Persona.prototype.estado = function () {
    return this._persona.Inasistencias[0].Estado;
};

Persona.prototype.areaDestino = function () {
    return this._persona.PasePendiente.AreaDestino.Nombre;
};

Persona.prototype.fechaPase = function () {
    return new Date(this._persona.PasePendiente.Fecha).toLocaleDateString();
};

Persona.prototype.estadoPase = function () {
    return this._persona.PasePendiente.Estado
};

