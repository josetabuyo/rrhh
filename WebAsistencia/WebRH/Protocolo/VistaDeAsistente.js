var VistaDeAsistente = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeAsistente.prototype.start = function () {
    this.ui = $("#plantilla_vista_asistente").clone();
    this.div_cargo = this.ui.find("#cargo");
    this.div_resumen = this.ui.find("#resumen");
    var resumen = this.o.asistente.Apellido + ", " + this.o.asistente.Nombre;
    if(this.o.asistente.Telefono != "") resumen += " Telefono: " + this.o.asistente.Telefono; 
    if(this.o.asistente.Mail != "") resumen += " Mail: " + this.o.asistente.Mail;

    this.div_cargo.text(this.o.asistente.Descripcion_Cargo + ":");
    this.div_resumen.text(resumen);
};

VistaDeAsistente.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};