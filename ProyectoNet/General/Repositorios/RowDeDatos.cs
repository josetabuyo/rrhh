using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;

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

        public int GetInt(String campo, int default_if_null)
        {
            if (this.GetObject(campo) is DBNull || this.GetSmallintAsInt(campo) == 0) return default_if_null;
            return (int)dataRow[campo];
        }

        public int GetSmallintAsInt(String campo)
        {
            return int.Parse(dataRow[campo].ToString());
        }

        public int GetSmallintAsInt(String campo, int default_if_null)
        {
            if (this.GetObject(campo) is DBNull || this.GetSmallintAsInt(campo) == 0) return default_if_null;
            return int.Parse(dataRow[campo].ToString());
        }

        public string GetString(String campo)
        {
            return (string)dataRow[campo];
        }

        public string GetString(String campo, String default_if_null)
        {
            if (this.GetObject(campo) is DBNull) return default_if_null;
            return (string)dataRow[campo];
        }

        public string GetTodoComoString(String campo, String default_if_null)
        {
            if (this.GetObject(campo) is DBNull) return default_if_null;
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} ", dataRow[campo]);
            output.AppendLine();
            return output.ToString().Trim();
        }

        public DateTime GetDateTime(String campo)
        {
            return (DateTime)dataRow[campo];
        }

        public DateTime GetDateTime(String campo, DateTime default_if_null)
        {
            if (this.GetObject(campo) is DBNull) return default_if_null;
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

        public bool GetBoolean(string campo, bool default_if_null)
        {
            if (this.GetObject(campo) is DBNull) return default_if_null;
            return (bool)dataRow[campo];
        }

        public float GetFloat(string campo)
        {
            var valor_double = (double)dataRow[campo];
            return (float)valor_double;
        }

        public float GetFloat(string campo, float default_if_null)
        {
            if (this.GetObject(campo) is DBNull) return default_if_null;
            return this.GetFloat(campo);
        }

        public long GetLong(string campo)
        {
            var valor_long = (long)dataRow[campo];
            return (long)valor_long;
        }
        public long GetLong(string campo, long default_if_null)
        {
            if (this.GetObject(campo) is DBNull) return default_if_null;
            return this.GetLong(campo);
        }

        public decimal GetDecimal(string campo)
        {
            var valor_decimal = (decimal)dataRow[campo];
            return (decimal)valor_decimal;
        }

        public decimal GetDecimal(string campo, decimal default_if_null)
        {
            if (this.GetObject(campo) is DBNull) return default_if_null;
            return this.GetDecimal(campo);
        }

        public Image GetImage(string campo)
        {
            var bytes = (byte[])dataRow[campo];
            MemoryStream ms = new MemoryStream(bytes, 0,
                bytes.Length);

            ms.Write(bytes, 0, bytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}