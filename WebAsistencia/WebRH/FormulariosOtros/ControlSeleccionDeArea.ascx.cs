#region

using System;
using System.Web;
using System.Web.UI.WebControls;
using WSViaticos;

#endregion

public partial class FormulariosOtros_ControlSeleccionDeArea : System.Web.UI.UserControl
{
    private Area[] _Areas;
    public Area[] Areas
    {
        get { return _Areas; }
        set { _Areas = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Enabled = true;
        TextBox1.AutoPostBack = true;
        ListBox1.AutoPostBack = true;
        ListBox1.Visible = false;
   
        if (IsPostBack)
            {
                TextBox1.Enabled = true;
            
             
                CargarCoincidencias();
                
                if (ListBox1.Items.Count!=0) {
                    
                    this.ListBox1.Visible = true;//ver
                    
                }
                else
                {
                    //this.ListBox1.ClearSelection();
                    this.DescargarLista();
                }
            


            }
      
        this.TextBox1.Focus();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (TextBox1.Text.Length != 0 )
        {
            
            CargarCoincidencias();    
        }
        

    }

    private void CargarCoincidencias()
    {




        if (ListBox1.SelectedItem == null)
        {
            this.DescargarLista();
        }
   
        if (this.TextBox1.Text.Length==0)
        {
            this.ListBox1.Visible = false;
            return;
        }


        bool coincideAlguna = false;
 
        foreach (Area area in Areas)
        {
            if (Coinciden(area.Nombre, this.TextBox1.Text))
            {
                //if (area.Codigo.Substring(area.Codigo.Length - 1) == "0")
                //{
                    coincideAlguna = true;
                    AgregarUnListItem(area);
                //}
            }
        }

        if (!coincideAlguna)
        {
        
            this.ListBox1.Visible = false;
          
        }
      

    }

    private void AgregarUnListItem(Area area)
    {
        
        if (!YaEstaCargada(area.Nombre))
        {
            this.ListBox1.Items.Add(new ListItem(area.Nombre, area.Id.ToString()));
        }

    }


    private void DescargarLista()
   {

       this.ListBox1.Items.Clear();

    }

    private bool YaEstaCargada(string NombreDelArea)
    {

        
        foreach (ListItem item in this.ListBox1.Items)
        {
            if (NombreDelArea == item.Text)
            {
                return true;
            }
        }
     
        return false;
    }

    private bool Coinciden(string buscada, string buscadora)
    {
       
        for (int i = 0; i < buscada.Length - buscadora.Length; i++)
        {
            if (buscada.Substring(i, buscadora.Length).ToUpper() == buscadora.ToUpper())
            {
                return true;
            }
        }
       
        return false;
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {


       
        this.ListBox1.Visible = true;
            Button1.Enabled=true;
        
    }

    protected void Button1_Command(object sender, CommandEventArgs e)
    {

        CargarCoincidencias();

    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Area areaPase = new Area();
        areaPase.Id = int.Parse(this.ListBox1.SelectedValue);
        areaPase.Nombre = this.ListBox1.Items[this.ListBox1.SelectedIndex].Text;
        Session["areaPase"] = areaPase;

        HttpContext ventana;
      

        ventana = HttpContext.Current;
        
        //Response.Write("<script> newwindows=open('FormPase.aspx','_blank')</script>");
       // Response.Write("<script> newwindows.focus()  </script>");

       ventana.Response.Redirect("~\\FormulariosOtros\\FormPase.aspx");
      
    }
    protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~\\Principal.aspx");
    }
}
