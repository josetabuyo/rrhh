using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace General.Repositorios
{
/// <summary>
/// Descripción breve de TablaDeDatos
/// </summary>


    public class RowDeDatos
    {
        private DataRow dataRow;
        public RowDeDatos(DataRow dataRow)
        {
            this.dataRow = dataRow;
        }

        public int GetInt(String campo)
        {
            return (int)dataRow[campo];
        }

        public int GetSmallintAsInt(String campo)
        {
            return int.Parse(dataRow[campo].ToString());
        }

        public string GetString(String campo)
        {
            return (string)dataRow[campo];
        }

        public DateTime GetDateTime(String campo)
        {
            return (DateTime)dataRow[campo];
        }

        public object GetObject(String campo)
        {
            return dataRow[campo];
        }

        public bool GetBoolean(string campo)
        {
            return (bool)dataRow[campo];
        }

        public float getFloat(string campo)
        {
            var valor_double = (double)dataRow[campo];
            return (float)valor_double;
        }
    }
}