using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestViaticos
{
    public static class AppConexionTest
    {
        public static string GetObtenerStringConexionLocal()
        {
            //return "Data Source=MDS-RH-0002\\SQLExpress;Initial Catalog=Acreditaciones2011;Integrated Security=True";
            //return "Data Source=MDS-1164;Initial Catalog=Viaticos_Jorge;Integrated Security=True";
            //return "Data Source=MDS-RH-0002\\SQLExpress;Initial Catalog=Acreditaciones2011_Ferca;Integrated Security=True";
            return "Data Source=MDS-RH-0003;Initial Catalog=Agustin_RRHH;Integrated Security=True";
            //return "Data Source=HP19955921631\\sqlexpress2005;Initial Catalog=Acreditaciones;Integrated Security=True";
            //return "Data Source=EXPEUEW7\\SQLEXPRESS;Initial Catalog=Acreditaciones;Integrated Security=True";
            //return "Data Source=MDS-RH-0003;Initial Catalog=Acreditaciones2011;Integrated Security=True";
        }
    }
}
