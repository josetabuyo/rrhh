#region

using System;
using WSViaticos;
using System.Web;

#endregion

public partial class FormulariosOtros_Pases : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnGenerarPase_Click(object sender, EventArgs e)
    {
        Area areaPase = new Area();
        
        areaPase.Id = int.Parse(this.selected_area_id.Value);
        areaPase.Nombre = this.selected_area_name.Value; ;

        Session["areaPase"] = areaPase;

        HttpContext ventana;

        ventana = HttpContext.Current;

        //Response.Write("<script> newwindows=open('FormPase.aspx','_blank')</script>");
        // Response.Write("<script> newwindows.focus()  </script>");

        ventana.Response.Redirect("~\\FormulariosOtros\\FormPase.aspx");
    }
}
