#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Data;

#endregion

public partial class FormulariosDatosDeContacto_FModificacionDatosDeContacto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CargarListado();
    }

    private void CargarListado()
    {
        try
        {
            Area area = (Area)Session["areaActual"];
            WSViaticosSoapClient s = new WSViaticosSoapClient();
            area = s.RecargarArea(area);
            this.LArea.Text = area.Nombre;
            this.LDireccion.Text = area.Direccion;
            LoadTelefonos(area);
        }
        catch (Exception)
        {
            Response.Redirect("~\\SeleccionDeArea.aspx");
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session != null)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~\\Login.aspx");
        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~\\SeleccionDeArea.aspx");
    }

    private void LoadTelefonos(Area area)
    {
        DataTable dt = new DataTable("Telefonos");
        dt.Columns.Add("Id");
        dt.Columns.Add("Contacto");
       //Comentado mo´mentáneamente para que funcionen los nuevos cambios en Contacto de Área (revisar)
        //foreach (Area  ca in area )
        //{
        //    string[] rowContacto = new string[2];
        //    rowContacto[0] = ca.Id.ToString();
        //    rowContacto[1] = ca.Contacto;
        //    dt.Rows.Add(rowContacto);
        //}
        string[] dkNames = { "Id" };
        GridView_Telefonos .DataKeyNames = dkNames;
        GridView_Telefonos.DataSource = dt;
        GridView_Telefonos.DataBind();
    }

    private void LoadFax(Area area)
    {

    }

    private void LoadEMail(Area area)
    {

    }



}