#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Collections.Generic;


#endregion

//using WSWebRH;

public partial class ControlEstadia : System.Web.UI.UserControl
{

    public DateTime Desde
    {
        get
        {
            
            DateTime fecha = DateTime.Parse(this.TBFechaDesde.Text);
            string[] hora = this.TBHoraDesde.Text.Split(':');
            DateTime desde = new DateTime(fecha.Year, fecha.Month, fecha.Day, int.Parse(hora[0]), int.Parse(hora[1]), 0);
            return desde;
        }
    }

    public DateTime Hasta
    {
        get
        {

            DateTime fecha = DateTime.Parse(this.TBFechaHasta.Text);
            string[] hora =  this.TBHoraHasta.Text.Split(':');
            DateTime desde = new DateTime(fecha.Year, fecha.Month, fecha.Day, int.Parse(hora[0]), int.Parse(hora[1]), 0);
            return desde;
        }
    }

    public decimal Eventuales
    {
        get { return decimal.Parse(this.TBEventuales.Text.Replace(".", ",")); }
    }

    public decimal AdicionalParaPasajes
    {
        get { return decimal.Parse(this.TBAdicionalPorPasajes.Text.Replace(".", ",")); }
    }

    public string Motivo
    {
        get { return this.TBMotivo.Text; }
    }

    public Provincia ProvinciaElegida
    {
        get
        {
            Provincia unaProvincia = new Provincia();
            unaProvincia.Id = int.Parse(this.DDLProvincias.SelectedItem.Value);
            unaProvincia.Nombre = this.DDLProvincias.SelectedItem.Text;
            return unaProvincia;
        }
    }

    public Provincia[] Provincias
    {
        set
        {
            this.DDLProvincias.Items.Clear();
            foreach (Provincia unaProvincia in value)
            {
                ListItem unListItem = new ListItem();
                unListItem.Value = unaProvincia.Id.ToString();
                unListItem.Text = unaProvincia.Nombre;
                this.DDLProvincias.Items.Add(unListItem);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack)
        {
            return;
        }

        LimpiarControles();
       
    }

    
    public void LimpiarControles()
    {
        this.TBFechaDesde.Text = "";
        this.TBFechaDesde.Text = DateTime.Now.ToShortDateString();


        this.TBHoraDesde.Text = "";
        this.TBHoraDesde.Text = "10:00";

        this.TBFechaHasta.Text = "";
        this.TBFechaHasta.Text = DateTime.Now.ToShortDateString();

        this.TBHoraHasta.Text = "";
        this.TBHoraHasta.Text = "10:00";


        this.TBEventuales.Text = "";
        this.TBEventuales.Text = "0.00";

        this.TBAdicionalPorPasajes.Text = "";
        this.TBAdicionalPorPasajes.Text = "0.00";

        this.TBMotivo.Text = "";
        this.DDLProvincias.SelectedIndex = 0;

    }
    
   
    protected void DDLProvincias_SelectedIndexChanged(object sender, EventArgs e)
    {
        WSViaticosSoapClient service = new WSViaticosSoapClient();
        //WSViaticos.WSViaticos service = new WSViaticos.WSViaticos();
                
        Persona persona = new Persona();
        persona.Documento = ((Persona)Session["persona"]).Documento;

        //service.CalcularViatico(new Provincia { Id = int.Parse(this.DDLProvincias.SelectedItem.Value), Nombre = this.DDLProvincias.Text, CodigoAFIP = int.Parse(DDLProvincias.SelectedItem.Value), Localidades = null }, persona);
    }


    //protected void Unnamed1_Click(object sender, EventArgs e)
    //{
    //    Estadia estadia = new Estadia();
    //    estadia.Desde = new DateTime(2012, 07, 20); //this.TBFechaDesde.Text;
    //    estadia.Hasta = new DateTime(2012, 07, 25); //this.TBFechaHasta.Text;
    //    estadia.AdicionalParaPasajes = float.Parse(this.TBAdicionalPorPasajes.Text);
    //    estadia.Eventuales = float.Parse(this.TBEventuales.Text);
    //    estadia.Motivo = this.TBMotivo.Text;

    //    var horaDesde = this.TBHoraDesde.Text;
    //    var horaHasta = this.TBHoraHasta.Text;

    //    FormularioDeViaticos_GrillaEstadias ge = new FormularioDeViaticos_GrillaEstadias();
    //    ge = (FormularioDeViaticos_GrillaEstadias)LoadControl("~\\FormularioDeViaticos\\GrillaEstadias.ascx");




    //    //ge.ID = "GrillaEstadias" + Id.ToString();

    //}                       


    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {




    }

    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {




    }
}
