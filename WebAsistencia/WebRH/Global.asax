<%@ Application Language="C#" %>

<script runat="server">
    void Session_Start(object sender, EventArgs e) 
    {
        var ws = new WSViaticos.WSViaticosSoapClient();
        Session[ConstantesDeSesion.USUARIO] = ws.GetUsuarioNulo();
        //Response.Redirect("~/Login.aspx");
    }

    void Application_AcquireRequestState(object sender, EventArgs e)        
    {
        //Verifico si tiene sesión activa
        try
        {
            WSViaticos.Usuario usuario = ((WSViaticos.Usuario)Session["usuario"]);
            if (usuario.Id == 0)
            {
                Response.Redirect("~\\Login.aspx");
            }
            else
            {
                try
                {
                    var ws = new WSViaticos.WSViaticosSoapClient();
                    if (!ws.ElUsuarioPuedeAccederALaURL((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO], Request.Path)) Response.Redirect("~/Forbidden.aspx");
                }
                catch (HttpException exc)
                {
                    return;
                }
            }
            
        }
        catch (Exception)
        {
            Response.Redirect("~\\Login.aspx");
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
