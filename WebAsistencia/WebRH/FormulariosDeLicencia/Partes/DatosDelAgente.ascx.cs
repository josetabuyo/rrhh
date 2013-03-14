#region

using System;
using WSViaticos;

#endregion

//using WSWebRH;

public partial class FormulariosDeLicencia_Partes_DatosDelAgente : System.Web.UI.UserControl
{
    private Area _Area;

    public Area Area
    {
        set 
        { 
            _Area = value;
            if (value != null)
            {
                this.LArea.Text = value.Nombre;
            }
            
        }
    }

    private Persona _Agente;
    public Persona Agente
    {
        set 
        { 
            _Agente = value;
            if (value != null)
            {
                this.LAgente.Text = value.Apellido + ", " + value.Nombre;
                this.LDocumento.Text = value.Documento.ToString("###,###,##0");
                this.LCategoria.Text = value.Categoria + " " + value.Grado + " " + value.Nivel;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
