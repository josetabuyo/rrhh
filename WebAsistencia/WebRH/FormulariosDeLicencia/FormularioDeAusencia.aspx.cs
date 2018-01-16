using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class FormulariosDeLicencia_FormularioDeAusencia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Persona persona = (Persona)Session["persona"];

        this.nombrePersona.Text = persona.Apellido + ", " + persona.Nombre;

        this.documento.Text = persona.Documento.ToString();
        
    }
}