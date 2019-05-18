using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class BarraMenu_FormPassword : System.Web.UI.UserControl
{
    public String UrlAjax { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.urlAjax.Text = UrlAjax;

    }
}