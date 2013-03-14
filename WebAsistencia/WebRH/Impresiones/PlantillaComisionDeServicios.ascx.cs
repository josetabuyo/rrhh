using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class Impresiones_PlantillaComisionDeServicios : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        //ComisionDeServicio[] lista_solicitudes_de_viaticos = ws_viaticos.GetComisionDeServicios();

        var lista_solicitudes_de_viaticos = (List<ComisionDeServicio>)Session["ComisionesAImprimir"];

        foreach (var listaSolicitudesDeViatico in lista_solicitudes_de_viaticos)
        {                        
            ImprimirComisionDeServicios(listaSolicitudesDeViatico);            
        }

    }


    public void ImprimirComisionDeServicios(ComisionDeServicio unaComision)
    {

        Table tabla = new Table();
        TableCell tc = new TableCell();
        TableRow tr = new TableRow();


        Impresiones_PaginaComisionDeServicios pcs = new Impresiones_PaginaComisionDeServicios();
        pcs = (Impresiones_PaginaComisionDeServicios)LoadControl("~\\Impresiones\\PaginaComisionDeServicios.ascx");
        pcs.ComisionServicio = unaComision;
        tc.Controls.Add(pcs);
        tr.Cells.Add(tc);
        tabla.Rows.Add(tr);

        Impresiones_Encabezado encabezado = new Impresiones_Encabezado();
        encabezado = (Impresiones_Encabezado)LoadControl("./Encabezado.ascx");
        //encabezado.Planilla = this.planilla;
        //encabezado.FechaSemana = this.planilla.semana;
        ////encabezado.NombreCooperativa = this.planilla.cooperativa.NombreCooperativa;

        this.miPanel.Controls.Add(encabezado);
        this.miPanel.Controls.Add(tabla);

        Impresiones_SaltoDePagina salto = new Impresiones_SaltoDePagina();
        salto = (Impresiones_SaltoDePagina)LoadControl("~//Impresiones//SaltoDePagina.ascx");
        this.miPanel.Controls.Add(salto);

    }
}