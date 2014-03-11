    function mostrarMensaje(mensaje) {
        alertify.alert(mensaje);
    }

    $(document).ready(function () {      
        //localizar timers
        var iddleTimeoutWarning = null;
        var iddleTimeout = null;     //esta funcion automaticamente sera llamada por ASP.NET AJAX cuando la pagina cargue y un postback parcial complete   

        function pageLoad() {          //borrar antiguos timers de postbacks anteriores       
            if (iddleTimeoutWarning != null)

                clearTimeout(iddleTimeoutWarning);
            if (iddleTimeout != null)
                clearTimeout(iddleTimeout);        //leer tiempos desde web.config        
            var millisecTimeOutWarning = 600000; //<%= int.Parse(System.Configuration.ConfigurationManager.AppSettings["SessionTimeoutWarning"]) * 60 * 1000 %>; 
            var millisecTimeOut = 600000; //<%= int.Parse(System.Configuration.ConfigurationManager.AppSettings["SessionTimeout"]) * 60 * 1000 %>;          //establece tiempo para mostrar advertencia si el usuario ha estado inactivo  

            iddleTimeout = setTimeout("TimeoutPage()", millisecTimeOut);
        }
        function TimeoutPage() {        //actualizar pagina para este ejemplo, podriamos redirigir a otra pagina con codigo para eliminar variables de sesion       
            location.href = "../login.aspx";
        }
    });

