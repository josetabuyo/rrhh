var Editor = {
    Inicializar: function () {
        this.SetearEventos();
    },
    SetearEventos: function () {
     var data = CKEDITOR.instances.editor1.setData('<p><span style="color:#af9a34">hola</span></p>');
        var _this = this;
        $('#boton_grabar_notificacion').click(function () {
            _this.Grabar();
        });
    },
    Grabar: function () { 
     //var data = CKEDITOR.instances.editor1.getData();
     alert('kk');
    },
}
