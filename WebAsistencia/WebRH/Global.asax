<%@ Application Language="C#" %>
<script RunAt="server">
    void Session_Start(object sender, EventArgs e)
    {
        var ws = new WSViaticos.WSViaticosSoapClient();
        Session[ConstantesDeSesion.USUARIO] = ws.GetUsuarioNulo();
        //Response.Redirect("~/Login.aspx");
    }

    void Application_AcquireRequestState(object sender, EventArgs e)
    {
        try
        {
            var ws = new WSViaticos.WSViaticosSoapClient();
            if (!ws.ElUsuarioPuedeAccederALaURL((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO], Request.Path)) Response.Redirect("~/Forbidden.aspx");
        }
        catch (HttpException exc)
        {
            var pagina_actual = System.IO.Path.GetFileName(Request.Url.AbsolutePath);

            if (pagina_actual.Contains(".aspx"))
            {
                if (pagina_actual == "Login.aspx")
                {
                    return;
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            else
            {
                return;
            }
        }
    }

    void Application_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        // Código que se ejecuta al producirse un error no controlado
        Logger.EscribirLog("---------------------------------------------");
        Logger.EscribirLog(ex.ToString());

    } 
</script>
