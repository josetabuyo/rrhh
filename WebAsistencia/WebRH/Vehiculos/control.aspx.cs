using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vehiculos_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            Vehiculos vehiculo;

            try
            {
                vehiculo = Servicio().Getvehiculo(usuario.Owner.Id);
            }
            catch (Exception excepcion)
            {
                
                throw new Exception("Acceso indebido al sitio: " + excepcion.Message);
            }
    
         
         private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
         
         
         }
}