using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class FormularioConcursar_Inscripcion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //var puesto = HttpContext.Current.Session[ConstantesDeSesion.PUESTO];
            var perfil = HttpContext.Current.Session[ConstantesDeSesion.PERFIL];
            //var puestoSerialize = JsonConvert.SerializeObject(puesto);

            this.perfil.Value = perfil.ToString();
        }
    }
}