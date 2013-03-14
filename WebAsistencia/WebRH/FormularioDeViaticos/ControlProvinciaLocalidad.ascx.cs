#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;

#endregion

public partial class ControlProvinciaLocalidad : System.Web.UI.UserControl
{
    
    private Provincia[] _Provicias;

    public Provincia[] Provicias
    {
        get { return _Provicias; }
        set { _Provicias = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
     
    }


    protected void DDLProvincias_SelectedIndexChanged(object sender, EventArgs e)
    {
    
    }

}
