#region

using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Collections.Generic;

#endregion

public partial class Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.FormatearListado();
        this.CargarListado();
        //string IdArea = Request.QueryString["IdArea"];
    }

    private void CargarListado()
    {
        try
        {
            Area area = (Area)Session["areaActual"];
            WSViaticosSoapClient s = new WSViaticosSoapClient();
            //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();
            Persona[] personas = s.GetPersonas(area);
            this.LArea.Text = area.Nombre;

            foreach (Persona unaPersona in personas)
            {
                this.InsertarFila(unaPersona);
            }
        }
        catch (Exception)
        {
            Response.Redirect("~\\SeleccionDeArea.aspx");
        }
    }

    private void InsertarFila(Persona unaPersona)
    {
        TableRow row = new TableRow(); TableCell cell;
        ImageButton ibEliminarPase;
        ImageButton ibPase;
        ImageButton ibEliminarInasistencia;
        LinkButton lbAsistencia;

        //Columnas de datos
        cell = new TableCell();
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = unaPersona.Documento.ToString("###,###,##0") + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        cell.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = unaPersona.Apellido + ", " + unaPersona.Nombre;
        row.Cells.Add(cell);

        cell = new TableCell();

        lbAsistencia = new LinkButton();
        if (!unaPersona.Es1184)
        {
            lbAsistencia.Text = "Presente";
            lbAsistencia.Click += new EventHandler(lbAsistencia_Click);
            if (unaPersona.InasistenciaActual != null)
            {
                if (unaPersona.InasistenciaActual.Descripcion != null)
                {
                    if (!unaPersona.InasistenciaActual.Aprobada)
                    {
                        ibEliminarInasistencia = new ImageButton();
                        ibEliminarInasistencia.ImageUrl = "Imagenes/eliminar.PNG";
                        ibEliminarInasistencia.Click += new ImageClickEventHandler(ibEliminarInasistencia_Click);
                        ibEliminarInasistencia.Width = 15;
                        ibEliminarInasistencia.Height = 15;
                        ibEliminarInasistencia.ToolTip = "Eliminar Inasistencia";
                        cell.Controls.Add(ibEliminarInasistencia);
                    }

                    lbAsistencia.Text = unaPersona.InasistenciaActual.Descripcion;
                }
            }
        }

        cell.Controls.Add(lbAsistencia);
        row.Cells.Add(cell);

        cell = new TableCell();
        if (unaPersona.PasePendiente != null)
        {
            if (unaPersona.PasePendiente.Id != 0)
            {
                ibEliminarPase = new ImageButton();
                ibEliminarPase.ImageUrl = "Imagenes/eliminar.PNG";
                ibEliminarPase.Click += new ImageClickEventHandler(ibEliminarPase_Click);
                ibEliminarPase.Width = 15;
                ibEliminarPase.Height = 15;
                ibEliminarPase.ToolTip = "Eliminar Solicitud de Pase";
                ibEliminarPase.CommandArgument = unaPersona.PasePendiente.Id.ToString();
                cell.Controls.Add(ibEliminarPase);
            }
            else
            {
                ibPase = new ImageButton();
                ibPase.ImageUrl = "Imagenes/paseMin.PNG";
                ibPase.Width = 20;
                ibPase.Click += new ImageClickEventHandler(this.ibPase_Click);
                cell.Controls.Add(ibPase);
            }
        }
        else
        {
            ibPase = new ImageButton();
            ibPase.ImageUrl = "Imagenes/paseMin.PNG";
            ibPase.Click += new ImageClickEventHandler(this.ibPase_Click);
            cell.Controls.Add(ibPase);
        }

        row.Cells.Add(cell);

        
        ////////Columna Viáticos
        //////cell = new TableCell();

        //////ibViatico = new ImageButton();
        //////ibViatico.ImageUrl = "Imagenes/viatico.PNG";
        //////ibViatico.Width = 20;
        //////ibViatico.Click += new ImageClickEventHandler(this.ibViatico_Click);
        //////cell.Controls.Add(ibViatico);

        //////row.Cells.Add(cell);

        this.TAgentes.Rows.Add(row);
    }


    void ibEliminarInasistencia_Click(object sender, ImageClickEventArgs e)
    {

        //AgenteE agente = new AgenteE();
        Persona persona = new Persona();
        TableRow rowClickeada = (TableRow)((TableCell)((ImageButton)sender).Parent).Parent;
        string[] nombreCompleto = rowClickeada.Cells[3].Text.Split(',');

        persona.Documento = int.Parse(rowClickeada.Cells[2].Text.Replace(".", "").Replace("&nbsp;", ""));
        persona.Apellido = nombreCompleto[0];
        persona.Nombre = nombreCompleto[1];
        persona.Area = (Area)Session["areaActual"];

        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        //WSViaticos.WSViaticos ws = new WSViaticos.WSViaticos();
        ws.EliminarInasistenciaActual(persona);
        Response.Redirect("~\\Principal.aspx");
    }

    void lbAsistencia_Click(object sender, EventArgs e)
    {
        Persona persona = new Persona();
        TableRow rowClickeada = (TableRow)((TableCell)((LinkButton)sender).Parent).Parent;
        string[] nombreCompleto = rowClickeada.Cells[2].Text.Split(',');

        persona.Documento = int.Parse(rowClickeada.Cells[1].Text.Replace(".", "").Replace("&nbsp;", ""));
        persona.Apellido = nombreCompleto[0];
        persona.Nombre = nombreCompleto[1];
        Session["persona"] = persona;

        //GPR: Cargo los datos que necesita viaticos por si genera un viatico.
        CargarDatosParaViatico(sender);

        Response.Redirect("~\\ConceptosLicencia.aspx");
    }

    //GPR: Se movió el Viatico a la pantalla de presente como Grupo 5.
    private void CargarDatosParaViatico(object sender)
    {
        ComisionDeServicio comisionEnEdicion = new ComisionDeServicio();
        comisionEnEdicion.Estadias = new Estadia[0];
        comisionEnEdicion.Pasajes = new Pasaje[0];


        Persona personaViatico = new Persona();
        TableRow rowClickeada = (TableRow)((TableCell)((LinkButton)sender).Parent).Parent;
        string[] nombreCompleto = rowClickeada.Cells[2].Text.Split(',');

        personaViatico.Documento = int.Parse(rowClickeada.Cells[1].Text.Replace(".", "").Replace("&nbsp;", ""));
        personaViatico.Apellido = nombreCompleto[0];
        personaViatico.Nombre = nombreCompleto[1];
        Session["personaViatico"] = personaViatico;
        Session[ConstantesDeSesion.VIATICO_EN_EDICION] = comisionEnEdicion;
        //Session["Viatico vacio"] = comisionEnEdicion;
        Session["VieneDeModificacion"] = false;
        //se agregan estos dos session para poder en el form siguiente quitar estadias y pasajes guardandolo en las respectivas sessiones
        Session["EstadiasQuitadas"] = new List<string>();
        Session["PasajesQuitadas"] = new List<string>();

    }


    ////private void ibViatico_Click(object sender, ImageClickEventArgs e)
    ////{
    ////    ComisionDeServicio comisionEnEdicion = new ComisionDeServicio();
    ////    comisionEnEdicion.Estadias = new Estadia[0];
    ////    comisionEnEdicion.Pasajes = new Pasaje[0];

    ////    Persona personaViatico = new Persona();
    ////    TableRow rowClickeada = (TableRow)((TableCell)((ImageButton)sender).Parent).Parent;
    ////    string[] nombreCompleto = rowClickeada.Cells[2].Text.Split(',');

    ////    personaViatico.Documento = int.Parse(rowClickeada.Cells[1].Text.Replace(".", "").Replace("&nbsp;", ""));
    ////    personaViatico.Apellido = nombreCompleto[0];
    ////    personaViatico.Nombre = nombreCompleto[1];
    ////    Session["personaViatico"] = personaViatico;
    ////    Session[ConstantesDeSesion.VIATICO_EN_EDICION] = comisionEnEdicion;
    ////    //Response.Redirect("~\\FormularioDeViaticos\\FCargaComisionDeServicio.aspx");
    ////}

    void ibEliminarPase_Click(object sender, ImageClickEventArgs e)
    {
        PaseDeArea pase = new PaseDeArea();
        pase.Id = int.Parse(((ImageButton)sender).CommandArgument);
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        //WSViaticos.WSViaticos ws = new WSViaticos.WSViaticos();
        ws.EliminarPase(pase);
        Response.Redirect("~\\Principal.aspx");
    }


    private void ibPase_Click(object sender, ImageClickEventArgs e)
    {
        Persona personaPase = new Persona();
        TableRow rowClickeada = (TableRow)((TableCell)((ImageButton)sender).Parent).Parent;
        string[] nombreCompleto = rowClickeada.Cells[2].Text.Split(',');

        personaPase.Documento = int.Parse(rowClickeada.Cells[1].Text.Replace(".", "").Replace("&nbsp;", ""));
        personaPase.Apellido = nombreCompleto[0];
        personaPase.Nombre = nombreCompleto[1];
        Session["personaPase"] = personaPase;
        Response.Redirect("~\\FormulariosOtros\\Pases.aspx");
    }


    private void FormatearListado()
    {
        this.TAgentes.CellPadding = 0;
        this.TAgentes.CellSpacing = 0;
        this.TAgentes.Width = 687;
        this.TAgentes.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
        this.FormatearBordeSuperior();
    }

    private void FormatearBordeSuperior()
    {

        //Primera Fila (Borde superior)
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();

        tr = new TableRow();
        tc = new TableCell();

        tc = new TableCell();
        tc.Width = 10;
        tr.Cells.Add(tc);

        tc = new TableCell();
        Label l = new Label();
        Color color = new Color();

        color = ColorTranslator.FromHtml("#5A6573");

        string[] fuentes = { "Tahoma" };
        l.Text = "CUIT/CUIL";
        l.ForeColor = color;
        l.Font.Names = fuentes;
        l.Font.Size = 12;
        tc.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
        tc.Controls.Add(l);

        tr.Cells.Add(tc);


        tc = new TableCell();
        l = new Label();
        l.Text = "Apellido y Nombre";
        l.ForeColor = color;
        l.Font.Names = fuentes;
        l.Font.Size = 12;

        tc.Controls.Add(l);
        tr.Cells.Add(tc);

        tc = new TableCell();
        l = new Label();
        l.Text = "Asistencia";
        l.ForeColor = color;
        l.Font.Names = fuentes;
        l.Font.Size = 12;
        tc.Controls.Add(l);
        tr.Cells.Add(tc);

        tc = new TableCell();
        l = new Label();
        l.Text = "Pase";
        l.ForeColor = color;
        l.Font.Names = fuentes;
        l.Font.Size = 12;
        tc.Controls.Add(l);
        tr.Cells.Add(tc);

        //tc = new TableCell();
        //l = new Label();
        //l.Text = "Viático";
        //l.ForeColor = color;
        //l.Font.Names = fuentes;
        //l.Font.Size = 12;
        //tc.Controls.Add(l);
        //tr.Cells.Add(tc);

        tr.Height = 42;

        this.TAgentes.Rows.Add(tr);

    }

    protected void ImageButton3_Click(object sender, EventArgs e)
    {


        // Response.Write("<script> open('\\Formularios\\Planillas.aspx','name')</script>");
        Response.Redirect("~\\FormulariosOtros\\Planillas.aspx");
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

    protected void ImageButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("~\\ParteDiario.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~\\FormularioDeViaticosAprobacion\\FControlDeAprobacion.aspx");
    }
}
