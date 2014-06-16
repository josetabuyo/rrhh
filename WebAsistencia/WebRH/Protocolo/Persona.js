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
    var fecha = new Date(this._persona.Inasistencias[0].Desde);
    return (fecha.getDate()+1) + "/" + (fecha.getMonth()+1) + "/" + fecha.getFullYear();
};

Persona.prototype.hasta = function () {
    var fecha = new Date(this._persona.Inasistencias[0].Hasta);
    return (fecha.getDate()+1) + "/" + (fecha.getMonth()+1) + "/" + fecha.getFullYear();
};

Persona.prototype.estado = function () {
    return this._persona.Inasistencias[0].Estado;
};

Persona.prototype.areaOrigen = function () {
    return this._persona.PasePendiente.AreaOrigen.Nombre;
};

Persona.prototype.areaDestino = function () {
    return this._persona.PasePendiente.AreaDestino.Nombre;
};

Persona.prototype.fechaPase = function () {
   var fecha = new Date(this._persona.PasePendiente.Fecha);
    return (fecha.getDate()+1) + "/" + (fecha.getMonth()+1) + "/" + fecha.getFullYear();
};

Persona.prototype.estadoPase = function () {
    return this._persona.PasePendiente.Estado
};

