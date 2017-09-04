using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;


public partial class MoBi_ImportacionDeTransacciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        

    }



    protected void btnLeerArchivo_Click(object sender, EventArgs e)
    {

        //abrimos el dialogo para poder obtener el nombre la ubicacion del archivo
        //ofdAbrirArchivo.ShowDialog();
        string sArchivo = FileUpload1.PostedFile.FileName; 

        //declaramos las variables que necesitamos para poder abrir un archivo excel
        _Application exlApp;
        Workbook exlWbook;
        Worksheet exlWsheet;

        exlApp = new ApplicationClass();

        //Asignamos el libro que sera abierot
        exlWbook = exlApp.Workbooks.Open(sArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        exlWsheet = (Worksheet)exlWbook.Worksheets.get_Item(1);
        Range exlRange;
        string sValor;
        string sDetalle = "";

        //Definimos el el rango de celdas que seran leidas
        exlRange = exlWsheet.UsedRange;

        //Recorremos el archivo excel como si fuera una matriz
        for (int i = 1; i <= exlRange.Rows.Count; i++)
        {
            sValor = "";
            for (int j = 1; j <= exlRange.Columns.Count; j++)
            {
                sValor += " " + (exlRange.Cells[i, j] as Range).Value + "|";
            }
            ListBox1.Items.Add(sValor);
            sDetalle = sDetalle + "*" + sValor;
        }

        hNombreArchivo.Value = FileUpload1.FileName;
        hDetalleExcel.Value = sDetalle;

        //cerramos el libro y la aplicacion
        exlWbook.Close();
        exlApp.Quit();


    }



}