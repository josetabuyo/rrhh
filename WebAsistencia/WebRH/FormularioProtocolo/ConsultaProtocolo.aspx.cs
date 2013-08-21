using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;

public partial class FormularioProtocolo_ConsultaProtocolo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Grilla Vieja
        //this.GrillaProtocolo.AgregarEncabezado();
        //this.GrillaProtocolo.MostrarTablaDeAreas();

        var servicio = new WSViaticos.WSViaticosSoapClient();
        MostrarAreaEnLaGrilla(servicio);

    }
    //protected void Buscar_Click(object sender, EventArgs e)
    //{
    //    //ObtenerBusqueda(this.DDLIdBusqueda.SelectedValue);
    //}

    //private void ObtenerBusqueda(string id_busqueda)
    //{
        
    //}

    private void MostrarAreaEnLaGrilla(WSViaticosSoapClient servicio)
    {
        var area = JsonConvert.DeserializeObject(servicio.GetAreasCompletas((Usuario)Session[ConstantesDeSesion.USUARIO]));
        this.areasJSON.Value = area.ToString();
    }
}