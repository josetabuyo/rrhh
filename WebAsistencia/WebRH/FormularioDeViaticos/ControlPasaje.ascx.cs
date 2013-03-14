#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Collections.Generic;

#endregion

public partial class ControlPasaje : System.Web.UI.UserControl
{
    private Provincia[] _Provincias;
    //private List<Provincia> lista_provincias;
    private MedioDeTransporte[] _Medios;
    private MedioDePago[] _Pagos;

    public Provincia[] Provincias
    {
        get { return _Provincias; }
        set { _Provincias = value; }
    }
    
    public MedioDeTransporte[] Medios
    {
        get { return _Medios; }
        set { _Medios = value; }
    }

    public MedioDePago[] Pagos
    {
        get { return _Pagos; }
        set { _Pagos = value; }
    }

    //void Page_PreRender(object sender, EventArgs e)
    //{
    //    // Save provincias before the page is rendered.
    //    ViewState.Add("Provincias", this.Provincias);
        
    //}

    //private void ActualizarViewStateDeProvincias()
    //{
    //    if (ViewState["Provincias"] != null)
    //    {
    //        lista_provincias = (List<Provincia>)ViewState["Provincias"];
    //    }
    //    else
    //    {
    //        // ArrayList isn't in view state, so we need to load it from scratch.
    //        lista_provincias = this.Provincias;
    //    }

    //}


    public void LimpiarControles()
    {
        this.TBFechaViaje.Text = "";
        this.TBFechaViaje.Text = DateTime.Now.ToShortDateString();

        
        this.TBPrecio.Text = "";
        this.TBPrecio.Text = "0.00";

        //this.DDLProvinciasDesde.SelectedIndex = 0;
        //this.DDLProvinciasHasta.SelectedIndex = 0;
        this.DDLMediosDePago.SelectedIndex = 0;
        this.DDLMediosDeTransporte.SelectedIndex = 0;

        CompletarLocalidades(DDLProvinciasDesde, DDLLocalidadesDesde);
        CompletarLocalidades(DDLProvinciasHasta, DDLLocalidadesHasta);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        //ActualizarViewStateDeProvincias();
        //this.TextBox1.Text = "10/10/2001";
        //this.TBPrecio.Text = "1000";

        //this.CPLOrigen.Provicias = this.Provincias;
        //this.CPLDestino.Provicias = _Provincias;

            DDLMediosDeTransporte.Items.Clear();
            DDLMediosDePago.Items.Clear();

            for (int i = 0; i < this.Medios.Length; i++)
            {
                this.DDLMediosDeTransporte.Items.Add(new ListItem(this.Medios[i].Nombre, this.Medios[i].Id.ToString()));
            }

            for (int i = 0; i < this.Pagos.Length; i++)
            {
                this.DDLMediosDePago.Items.Add(new ListItem(this.Pagos[i].Nombre, this.Pagos[i].Id.ToString()));
            }
        
        

            //this.CPLOrigen.Provicias = this.Provincias;
            //this.CPLDestino.Provicias = this.Provincias;
        
            //Para escuchar el evento que se dispara en el subcontrol ProvinciaLocalidad
            //this.CPLOrigen.Acepto += new EventHandler(CambioCombo);
            //this.CPLDestino.Acepto += new EventHandler(CambioCombo);
       
            DDLProvinciasDesde.Items.Clear();
            DDLProvinciasHasta.Items.Clear();
         

            CompletarCombosProvincias();
            CompletarDatosDefault();
       
            this.DDLProvinciasDesde.SelectedIndexChanged += new EventHandler(DDLProvinciasDesde_SelectedIndexChanged);
            this.DDLProvinciasHasta.SelectedIndexChanged += new EventHandler(DDLProvinciasHasta_SelectedIndexChanged);

    }


    private void CompletarDatosDefault()
    {
        this.TBFechaViaje.Text = "";
        this.TBFechaViaje.Text = DateTime.Now.ToShortDateString();

        this.TBPrecio.Text = "";
        this.TBPrecio.Text = "0.00";

        this.DDLProvinciasDesde.SelectedIndex = 0;
        this.DDLProvinciasHasta.SelectedIndex = 0;
        this.DDLLocalidadesDesde.SelectedIndex = 0;
        this.DDLLocalidadesHasta.SelectedIndex = 0;

    }



    private void CompletarCombosProvincias()
    {
        ListItem unItem;

        //DDLProvinciasDesde.Items.Add("");
        //DDLProvinciasHasta.Items.Add("");

        foreach (Provincia unaProvincia in this.Provincias)
        {
            unItem = new ListItem();

            unItem.Value = unaProvincia.Id.ToString();
            unItem.Text = unaProvincia.Nombre;

            DDLProvinciasDesde.Items.Add(unItem);
            DDLProvinciasHasta.Items.Add(unItem);
            //DDLProvinciasHasta.Items.Add(unItem);
            // DDLProvincias.Items.Add(unItem);
        }
    }

    //PONGO ESTE METODO PARA QUE LO ESCUCHE PERO NO HAGO NADA
    void CambioCombo(object sender, EventArgs e)
    {
        
    }

    public DateTime FechaPasaje
    {
        get
        {
            DateTime Fecha = DateTime.Parse(this.TBFechaViaje.Text);
            return Fecha;
        }
    }

    public Localidad LocalidadOrigen
    {
        get 
        {

            Localidad oLocalidadOrigen = new Localidad();
            oLocalidadOrigen.Id = int.Parse(this.DDLLocalidadesDesde.SelectedItem.Value);
            oLocalidadOrigen.Nombre = this.DDLLocalidadesDesde.SelectedItem.Text;
            return oLocalidadOrigen;
        }
    }

    public Localidad LocalidadDestino
    {
        get
        {
            Localidad oLocalidadDestino= new Localidad();
            oLocalidadDestino.Id = int.Parse(this.DDLLocalidadesHasta.SelectedItem.Value);
            oLocalidadDestino.Nombre = this.DDLLocalidadesHasta.SelectedItem.Text;
            return oLocalidadDestino;
        }
    }

    public MedioDeTransporte MediosDeTransporte
    {
        get
        {
            MedioDeTransporte oMedios = new MedioDeTransporte();
            oMedios.Id = int.Parse(DDLMediosDeTransporte.SelectedItem.Value);
            oMedios.Nombre = DDLMediosDeTransporte.SelectedItem.Text;
            return oMedios;
        }
    }

    public MedioDePago MediosDePago
    {
        get
        {
            MedioDePago oPagos = new MedioDePago();
            oPagos.Id = int.Parse(DDLMediosDePago.SelectedItem.Value);
            oPagos.Nombre = DDLMediosDePago.SelectedItem.Text;
            return oPagos;
        }
    }

    public decimal Precio
    {
        get 
        {
            decimal oPrecio = decimal.Parse(this.TBPrecio.Text.Replace(".", ","));
            return oPrecio;
        }
    }

    //LO TRAJE DEL CONTROL PROVLOC
    public event EventHandler Acepto;
    protected void DDLProvinciasDesde_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.Acepto(sender, e);

        CompletarLocalidades(DDLProvinciasDesde, DDLLocalidadesDesde);

    }

    

    protected void DDLProvinciasHasta_SelectedIndexChanged(object sender, EventArgs e)
    {
       // this.Acepto(sender, e);

        CompletarLocalidades(DDLProvinciasHasta, DDLLocalidadesHasta);       
    }


    private void CompletarLocalidades(DropDownList DDLProvincias, DropDownList DDLLocalidades)
    {
        //if (DDLProvincias.SelectedIndex == 0)
        //{
        //    DDLLocalidades.Items.Clear();
        //    return;
        //}
        

        Provincia provinciaElegida = null;

        foreach (Provincia unaProvincia in Provincias)
        {
            if (unaProvincia.Id == int.Parse(DDLProvincias.Items[DDLProvincias.SelectedIndex].Value))
            {
                provinciaElegida = unaProvincia;
                break;
            }
        }


        if (DDLLocalidades.SelectedIndex <= 0)
        {
            DDLLocalidades.Items.Clear();

            ListItem unItem;

            if (provinciaElegida.Localidades != null)
            {
                foreach (Localidad unaLocalidad in provinciaElegida.Localidades)
                {
                    unItem = new ListItem();

                    unItem.Value = unaLocalidad.Id.ToString();
                    unItem.Text = unaLocalidad.Nombre;

                    DDLLocalidades.Items.Add(unItem);
                }
            }
        }
        

    }

    //LO TRAJE DEL CONTROL PROVLOC
    //public Localidad LocalidadDesde
    //{
    //    get
    //    {
    //        Localidad oLocalidad. = int.Parse(this.DDLLocalidadesDesde.SelectedItem.Value);
    //        return oLocalidad;
    //    }
    //}

    //public Localidad LocalidadHasta
    //{
    //    get
    //    {
    //        Localidad oLocalidad = int.Parse(this.DDLLocalidadesHasta.SelectedItem.Value);
    //        return oLocalidad;
    //    }
    //}


    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    this.Calendar1.Visible = !this.Calendar1.Visible;
    //}

    //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    //{
    //    this.TextBox1.Text = this.Calendar1.SelectedDate.ToShortDateString();
    //    this.Calendar1.Visible = false;
    //}

    protected void DDLProvinciasHasta_Load(object sender, EventArgs e)
    {
        CompletarLocalidades(DDLProvinciasHasta, DDLLocalidadesHasta);
    }
    protected void DDLProvinciasDesde_Load(object sender, EventArgs e)
    {
        CompletarLocalidades(DDLProvinciasDesde, DDLLocalidadesDesde);
    }
   


  
}
