using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormularioProtocolo_ConsultaProtocolo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.GrillaProtocolo.AgregarEncabezado();
        this.GrillaProtocolo.MostrarTablaDeAreas();
    }
    protected void Buscar_Click(object sender, EventArgs e)
    {
        //ObtenerBusqueda(this.DDLIdBusqueda.SelectedValue);
    }

    private void ObtenerBusqueda(string id_busqueda)
    {
        
    }
}