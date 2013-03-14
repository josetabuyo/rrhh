using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;

namespace TestViaticos
{
    public class CreadorDeDatosFicticios
    {
        private INDbUnitTest _my_sql_database;

        public CreadorDeDatosFicticios()
        {
            Setup();
        }

        public void Setup()
        {
            string connection_string = AppConexionTest.GetObtenerStringConexionLocal();

            _my_sql_database = new SqlDbUnitTest(connection_string);
            _my_sql_database.ReadXmlSchema(@"..\..\..\..\TestViaticos\ViaticosDataSet.xsd");
        }

        public void AddData(string ArchivoXml)
        {
            _my_sql_database.AppendXml(@"..\..\..\..\TestViaticos\Data\" + ArchivoXml);
            _my_sql_database.PerformDbOperation(NDbUnit.Core.DbOperationFlag.CleanInsertIdentity);
        }


    }
}
