<%@ Application Language="C#" %>

<script runat="server">
    void Session_Start(object sender, EventArgs e) 
    {
        var ws = new WSViaticos.WSViaticosSoapClient();
        Session[ConstantesDeSesion.USUARIO] = ws.GetUsuarioNulo();
    }

    void Application_AcquireRequestState(object sender, EventArgs e)        
    {
        try
        {
            var ws = new WSViaticos.WSViaticosSoapClient();
            if (!ws.ElUsuarioPuedeAccederALaURL((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO], Request.Path)) Response.Redirect("~/Login.aspx");
        }
        catch (HttpException exc)
        {
            return;
        }
    }       
</script>
