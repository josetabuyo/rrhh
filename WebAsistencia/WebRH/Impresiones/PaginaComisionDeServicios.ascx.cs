using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;


public partial class Impresiones_PaginaComisionDeServicios : System.Web.UI.UserControl
{

    ComisionDeServicio comision;

    public ComisionDeServicio ComisionServicio
    {
        set
        {
            comision = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        FormularioDetalleDeViaticos_ControlDetalleDeViaticos cs = new FormularioDetalleDeViaticos_ControlDetalleDeViaticos();
        cs = (FormularioDetalleDeViaticos_ControlDetalleDeViaticos)LoadControl("~\\FormularioDetalleDeViaticos\\ControlDetalleDeViaticos.ascx");
        cs.ComisionServicio = comision;
        this.PanelPaginaComision.Controls.Add(cs);
        
    }
}