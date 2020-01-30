using System;
using System.Text;
using System.Globalization;

/// <summary>
/// Convierte números en su expresión numérica a su numeral cardinal
/// </summary>
namespace General
{

public class Utils
{
    

    #region Constructores

    public Utils()
    {

    }
        #endregion

        public int SubstringAEntero(string s)
        {
            if (s.IndexOf('.') < 0)
            {
                return int.Parse(s);
            }
            else
            {
                return int.Parse(s.Remove(s.IndexOf('.'), 1));
            }
        }

        public string SubstringQuitarChar(string s,char c)
        {
            if (s.IndexOf(c) < 0)
            {
                return s;
            }
            else
            {
                return s.Remove(s.IndexOf(c), 1);
            }
        }

        /*pj:  input 112.321,01  -->  112321.01*/
        public string SubstringAFormatoFloat(string s)
        {
            string ss = "";
            string sss = "";
            
            if (s.IndexOf('.') < 0)
            {
                //return int.Parse(s);
                ss = s;
            }
            else
            {
                ss = s.Remove(s.IndexOf('.'), 1);
            }

            if (ss.IndexOf(',') < 0)
            {
                //return int.Parse(s);
                return "0";// si hay algo por lo minimo debe tener ,00  osea dos decimales
            }
            else
            {
                sss = ss.Replace(',','.');
                return sss.Trim();// Decimal.Parse(sss);
            }
            
        }

        public decimal SubstringAFormatoFloatToDecimal(string s)
        {
            NumberStyles style;
            CultureInfo provider;
            string temp = "";

            style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            provider = new CultureInfo("es-AR");
            temp = s.Trim();
            if (temp == "")
            {
                return 0;
            }else
            {
                return Decimal.Parse(s.Trim(), style, provider);
            }
            
        }
        public decimal SubstringAFormatoFloatToDecimal2(string s)
        {
            string ss = "";
            string sss = "";

            if (s.IndexOf('.') < 0)
            {
                //return int.Parse(s);
                ss = s;
            }
            else
            {
                ss = s.Remove(s.IndexOf('.'), 1);
            }

            if (ss.IndexOf(',') < 0)
            {
                //return int.Parse(s);
                return 0;// si hay algo por lo minimo debe tener ,00  osea dos decimales
            }
            else
            {
                sss = ss.Replace(',', '.');
                return Decimal.Parse(sss);
            }

        }

    }
}