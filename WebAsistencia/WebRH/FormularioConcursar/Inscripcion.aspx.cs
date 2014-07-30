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
            var puesto = HttpContext.Current.Session[ConstantesDeSesion.PUESTO];

            var puestoSerialize = JsonConvert.SerializeObject(puesto);

            this.puesto.Value = puestoSerialize;
        }
    }
}