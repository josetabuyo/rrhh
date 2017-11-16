using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Data;
using System.Text;

public partial class FormularioConcursar_TableroControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //var usuario = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        //if (!IsPostBack)
        //{
        //    var tablero = Servicio().GetTableroDeControlDePostulaciones(usuario.Owner.Id);

        //    var tablero_serializado = JsonConvert.SerializeObject(tablero);

        //    this.tablero.Value = tablero_serializado;
        //}     
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

}