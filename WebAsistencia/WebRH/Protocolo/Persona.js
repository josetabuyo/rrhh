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
    return this._persona.Inasistencias[0].Desde;
};

Persona.prototype.hasta = function () {
    return this._persona.Inasistencias[0].Hasta;
};

Persona.prototype.estado = function () {
    return this._persona.Inasistencias[0].Estado;
};


