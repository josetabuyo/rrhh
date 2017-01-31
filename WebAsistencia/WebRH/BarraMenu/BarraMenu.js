$(document).ready(function () {
    Backend.start(function () {
        var boton_usuario = new BotonDesplegable("foto_usuario_icono", "contenedor_menu_usuarios");
    var boton_aplicaciones = new BotonDesplegable("menu_cuadrados", "contenedor_menu_cuadrados");
    var boton_mensajes = new BotonDesplegable("menu_mensajes", "contenedor_menu_mensajes");
        
        $('#boton_home').click(function () {
            window.location.href = 'Portal.aspx';
        });
   
        Backend.GetUsuarioLogueado().onSuccess(function (usuario) {

            document.getElementById('nombre_user').innerHTML = usuario.Owner.Nombre;
            document.getElementById('apellido_user').innerHTML = usuario.Owner.Apellido;
            document.getElementById('dni_user').innerHTML = usuario.Owner.Documento;
            document.getElementById('email_user').innerHTML = usuario.MailRegistro;

            $('#cambiar-constrasena_usuario').click(function () {

                alertify.confirm('Modificar contraseña', '¿Está seguro de querer reinciar la contraseña', function () {
                    Backend.ResetearPassword(usuario.Id).onSuccess(
                        function (nueva_clave) {
                            alertify.alert("Se ha modificado la contraseña.", "La nueva contraseña para el usuario: "
                                                + usuario.Alias + " es: " + nueva_clave);
                        });
                }

        , function () {
            alertify.alert("Modificación cancelada.");
        }
        );
            })
            
        });
    });
});