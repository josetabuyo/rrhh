<%@ Application Language="C#" %>

<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta al iniciarse la aplicación

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Código que se ejecuta cuando se cierra la aplicación

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Código que se ejecuta al producirse un error no controlado

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando se inicia una nueva sesión
        var ws = new WSViaticos.WSViaticosSoapClient();
        Session[ConstantesDeSesion.USUARIO] = ws.UsuarioNulo();
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: El evento Session_End se desencadena sólo con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
        // o SQLServer, el evento no se genera.

    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        var a = 1;
    }

    void Application_AcquireRequestState(object sender, EventArgs e)        
    {
        var ws = new WSViaticos.WSViaticosSoapClient();
        if(ws.ElUsuarioPuedeAccederALaURL((WSViaticos.Usuario) Session[ConstantesDeSesion.USUARIO], Request.Path)) return;
        Response.Redirect("Login.aspx");
    }
       
</script>
