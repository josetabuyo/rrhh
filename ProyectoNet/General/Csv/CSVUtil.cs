using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.qrcode;
using System.Numerics;

namespace General.Csv
{
    public class CSVUtil
    {
     /**
	 * Constante con el array de dispersion de los caracteres de secuencia
	 * dentro del codigo CSV
	 */
        /*los numeros son enteros cuya representacion binaria tiene exactamente 7 unos 
         * en cualquier orden*/
        public static int[] unicityPositions = {138708040,100934728,168043592,170004552,
	                                         170005000,152109608,135397929,143196705,
	                                         143228961,18023457,18031648,85008672,
	                                         151062820,153682208,19465504,17306914,
	                                         17368356,18416676,18415716,18424864,
	                                         152634400,151594016,17312928,134776994,
	                                         138455074,138447137,138551880,17891896,
	                                         51446312,83960360,84484130,19472928,
	                                         2171939,8725537,8664100,75777092};


        /* CODIFICACION:  Total de 32 caracteres (la codificacion va a estar en Base 36):
        3 codigo SAF de la jurisdiccion (o 2 codigo jurisdiccion); lo dejo en codigo SAF del Ministerio de Desarrollo Social es el 311
        2 tipo de documento (para recibo digital que es la tabla Tabla_Tipo_Doc_Electronico, lo dejo como su id: en este caso 1)
        19 caracteres del hash, truncados del hash del contenido del documento, luego de haber sido pasados a base 36
        7 identificador de unicidad del conjunto de documentos (para cada tipo, en general para este proyecto seran 2 caracteres)
        1 codigo de dispersion, para mezclar el codigo de unicidad en el hash        
        */

        /*mascara de bits que contiene 9 unos para cadad valor*/
        /*https://es.calcuworld.com/calculadoras-matematicas/calculadora-binaria/ */
        public static int[] unicityPositions9unos = {172270664,101983305,170140746,186798152,170005320,219218473,236061225,
                                                    146342433,143228967,18023841,28517408,85057824,151063012,153682211,
                                                    19600672,17437987,17380644,20513892,18415974,20522080,152640544,
                                                    151610408,17444001,151554722,138979370,139495717,172630600,17900090,
                                                    51710504,86057513,88678946,19474978,2172075,9774129,10761508,76829764
                                                   };


        /**
		 * Constante con el valor de la Cabecera que deben llevar todos los codigos CSV
		 */
        public static String SAF_MDS = "311";

        /*Por el momento voy a setear el codigo del tipo de documento, despues se propone crear una tabla de tipos_documentos*/
        public static String TIPO_RECIBO_DIGITAL = "01";  //aca lo seteo como string pero en realidad el tipo es el de abajo convertido a sring y si tiene 
                                                          //menos de 2 caracteres se le agrega la cantidad de ceros necesaria(en este caso 1) hasta tener
                                                          //la cantidad de n digitos utilizadas para codificar le id del documento en el csv 
        public static int ID_TIPO_RECIBO_DIGITAL = 1;

        public static String CSV_SEPARATOR = "-";


       /* public String generarCodigoCSV-Viejo(byte[] datosPDF, string codificacionEntidad, long unicidad, string tipoDoc)
        {
            string text = "tomar el contenido del pdf";
            byte[] data = Encoding.UTF8.GetBytes(text);
            string r = "";
            byte[] hash;

            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(data);     //512 bits are 64 bytes.
            }
            r = BitConverter.ToString(hash).Replace("-", "");

            String s = generateCode(Encoding.UTF8.GetBytes(text), codificacionEntidad, unicidad, tipoDoc);

            return s;


        }*/

        public String generarCodigoCSV(byte[] bytes_datos, string codificacionEntidad, long unicityNumber, string tipoDoc)
        {
            String result = "";

            byte[] hash = GenerarSHA512(bytes_datos); //el hash esta en base 64

            long value = BitConverter.ToInt64(hash, 0);//convierto a entero (puede ser +/-)
            //como un hash puede representar un numero +/- entonces doy vuelta el valor del entero(que antes se pasa a string)

            // Obtenemos la cadena base del codigo de seguridad 
//            string value2 = Base36.DecimalToArbitrarySystem(value, 36);//convierto a base 36
//            string reverseBase36Data = Reverse(value2.ToString());//doy vuelta el string para truncar desde atras
            string value2 = Base36.ToBase36String(hash); 

            //NOTA: como se convierta a base36, la parte de como considerar al negativo:
            /* en la version java la conversion a b36 retorna el numero en string dado vuelta (asi si hay un negativo se lo pone como ultimo caracter)
             OSEA: el truncamiento del hash viene desde atras para adelante; tambien se pudo como segunda opcion en lugar de trancar desde atras
             se podria considerar siempre el numero absoluto de la representacion entera del hash y recien ahi convertir a bse 36; de esta forma
             ya no se tiene en cuenta un signo negativo por delante del valor en base36*/
            //EJ: tomo los bytes, long (+/-), rebase 36 retorna en string,como puede haber un -, entonces reversa asi queda atras ej: "123132-"
            //String signHashBase36Data = Base36.convertDecimalToBase36(value); //considera siempre el valor absoluta del entero que representa el hash

            //Obtenemos la cadena en Base36 del codigo de unicidad
            //String unicityBase36 = Base36.convertDecimalToBase36(unicityNumber);
            string unicityBase36 = Base36.DecimalToArbitrarySystem(unicityNumber, 36);

            //rellenamos con 0 al principio hasta cubrir los 7 caracteres de unicidad
            while (unicityBase36.Length < 7)
            {
                unicityBase36 = "0" + unicityBase36;
            }

            //Seleccionamos de forma aleatoria una mascara para las posiciones de los caracteres de unicidad
            Random randomGenerator = new Random();
            int randomizer = randomGenerator.Next(36);
            int maskValue = unicityPositions[randomizer];
            String codigoAleatoriedadBase36 = Base36.DecimalToArbitrarySystem(randomizer, 36);

            String binaryMask = Convert.ToString(maskValue, 2);

            //rellenamos con 0 al principio hasta cubrir los 28 caracteres necesarios
            //que es la cantidad de caracteres del codigo de seguridad + de el de unicidad+tipo doc
            //que se va a recorrer para ir mezclando ambos codigos de base 36
            //AQUI es donde se trunca el hash del contenido/firma digital, para obtener solo los
            //primeros 19            
            while (binaryMask.Length < 28)
            {
                binaryMask = "0" + binaryMask;
            }

            string reverseBase36Data = value2;
            //puede que el hash en b36 tenga menos de 19 caracteres, relleno (tomo 20 como minimo porque asumo el - que puede venir)
            if (reverseBase36Data.Length < 20)
            {
                reverseBase36Data = reverseBase36Data.Replace("-", "0");//si es un negativo entonces quito el - final.
                while (reverseBase36Data.Length < 20)
                {
                    reverseBase36Data = reverseBase36Data + "0";
                }
            }
            else
            {
                //Console.WriteLine("Valor de hash en b36: " + reverseBase36Data);
            }

            String seguridadUnicidad = "";
            int posicionUnicidad = 0;
            int posicionSeguridad = 0;
            int posicionTipo = 0;
            for (int i = 0; i < binaryMask.Length; ++i)
            {
                if (binaryMask[i] == '1')
                {
                    if (posicionTipo < 2)
                    {
                        /*todabia falta asignar algun caracter de tipo doc*/
                        seguridadUnicidad += TIPO_RECIBO_DIGITAL[posicionTipo];
                        posicionTipo++;
                    }
                    else
                    {
                        /*ya se asignaron los dos caracteres de tipo doc*/
                        seguridadUnicidad += unicityBase36[posicionUnicidad];
                        posicionUnicidad++;
                    }

                }
                else
                {
                    seguridadUnicidad += reverseBase36Data[posicionSeguridad];
                    posicionSeguridad++;
                }
            }

            //Al final de este bucle posicionUnicidad debe ser 7
            //Al final de este bucle posicionSeguridad debe ser 19
            //y seguridadUnicidad debe tener ambos codigos mezclados segun el patron, 28 caracteres

            /*IMPORTANTE: la codificacionEntidad y el tipoDoc NO estan en base64...!  a modo de poder detectar visualmente la entidad de pertenencia y el tipo de 
             documento*/
            result = codificacionEntidad + seguridadUnicidad + codigoAleatoriedadBase36;
            result = result.ToLower();
            result = formatCSV(result, 4, "-");
            //result tiene con este header 34 caracteres, despues del header si 
            //se le pone el - son 35
            //Console.WriteLine("Codigo CSV obtenido: " + result);

            return result;
        }

        //public String generateCode(byte[] bytes_datos, string codificacionEntidad, long unicityNumber, string tipoDoc)
        //nota: este codigo obtiene un hash corto, porque la convercion es a long--> convertir del hash de 128bits a 64bits se pierde informacion 
        public String generarCodigoCSVSinBigInt(byte[] bytes_datos, string codificacionEntidad, long unicityNumber, string tipoDoc)
        {
            String result = "";

            byte[] hash = GenerarSHA512(bytes_datos); //el hash esta en base 64

            long value = BitConverter.ToInt64(hash, 0);//convierto a entero (puede ser +/-)
            //como un hash puede representar un numero +/- entonces doy vuelta el valor del entero(que antes se pasa a string)

            // Obtenemos la cadena base del codigo de seguridad 
            string value2 = Base36.DecimalToArbitrarySystem(value, 36);//convierto a base 36
            string reverseBase36Data = Reverse(value2.ToString());//doy vuelta el string para truncar desde atras

            //NOTA: como se convierta a base36, la parte de como considerar al negativo:
            /* en la version java la conversion a b36 retorna el numero en string dado vuelta (asi si hay un negativo se lo pone como ultimo caracter)
             OSEA: el truncamiento del hash viene desde atras para adelante; tambien se pudo como segunda opcion en lugar de trancar desde atras
             se podria considerar siempre el numero absoluto de la representacion entera del hash y recien ahi convertir a bse 36; de esta forma
             ya no se tiene en cuenta un signo negativo por delante del valor en base36*/
            //EJ: tomo los bytes, long (+/-), rebase 36 retorna en string,como puede haber un -, entonces reversa asi queda atras ej: "123132-"
            //String signHashBase36Data = Base36.convertDecimalToBase36(value); //considera siempre el valor absoluta del entero que representa el hash

            //Obtenemos la cadena en Base36 del codigo de unicidad
            //String unicityBase36 = Base36.convertDecimalToBase36(unicityNumber);
            string unicityBase36 = Base36.DecimalToArbitrarySystem(unicityNumber, 36);

            //rellenamos con 0 al principio hasta cubrir los 7 caracteres de unicidad
            while (unicityBase36.Length < 7)
            {
                unicityBase36 = "0" + unicityBase36;
            }

            //Seleccionamos de forma aleatoria una mascara para las posiciones de los caracteres de unicidad
            Random randomGenerator = new Random();
            int randomizer = randomGenerator.Next(36);
            int maskValue = unicityPositions[randomizer];
            String codigoAleatoriedadBase36 = Base36.DecimalToArbitrarySystem(randomizer, 36);

            String binaryMask = Convert.ToString(maskValue, 2);

            //rellenamos con 0 al principio hasta cubrir los 26 caracteres necesarios
            //que es la cantidad de caracteres del codigo de seguridad + de el de unicidad
            //que se va a recorrer para ir mezclando ambos codigos de base 36
            //AQUI es donde se trunca el hash del contenido/firma digital, para obtener solo los
            //primeros 19            
            while (binaryMask.Length < 26)
            {
                binaryMask = "0" + binaryMask;
            }

            //puede que el hash en b36 tenga menos de 19 caracteres, relleno (tomo 20 como minimo porque asumo el - que puede venir)
            if (reverseBase36Data.Length < 20)
            {
                reverseBase36Data = reverseBase36Data.Replace("-", "0");//si es un negativo entonces quito el - final.
                while (reverseBase36Data.Length < 20)
                {
                    reverseBase36Data = reverseBase36Data + "0";
                }
            }
            else
            {
                //Console.WriteLine("Valor de hash en b36: " + reverseBase36Data);
            }

            String seguridadUnicidad = "";
            int posicionUnicidad = 0;
            int posicionSeguridad = 0;
            for (int i = 0; i < binaryMask.Length; ++i)
            {
                try
                {
                    if (binaryMask[i] == '1')
                    {
                        seguridadUnicidad += unicityBase36[posicionUnicidad];
                        posicionUnicidad++;
                    }
                    else
                    {
                        seguridadUnicidad += reverseBase36Data[posicionSeguridad];
                        posicionSeguridad++;
                    }
                }
                catch (Exception e) {
                    var indice = posicionSeguridad;
                    var ss = reverseBase36Data;
                }
            }

            //Al final de este bucle posicionUnicidad debe ser 7
            //Al final de este bucle posicionSeguridad debe ser 19
            //y seguridadUnicidad debe tener ambos codigos mezclados segun el patron, 26 caracteres

            /*IMPORTANTE: la codificacionEntidad y el tipoDoc NO estan en base64...!  a modo de poder detectar visualmente la entidad de pertenencia y el tipo de 
             documento*/
            result = codificacionEntidad + tipoDoc + seguridadUnicidad + codigoAleatoriedadBase36;
            result = result.ToLower();
            result = formatCSV(result, 4, "-");
            //result tiene con este header 34 caracteres, despues del header si 
            //se le pone el - son 35
            //Console.WriteLine("Codigo CSV obtenido: " + result);

            return result;
        }

        public byte[] GenerarSHA512(byte[] s)
        {
            byte[] hash;

            using (SHA512 shaM = new SHA512Managed())
            {
                //hash = shaM.ComputeHash(Encoding.UTF8.GetBytes("ddd"));     //512 bits are 64 bytes.
                hash = shaM.ComputeHash(s);     //512 bits are 64 bytes.
            }

            return hash;
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        /**
	 * Formatea el csv: Cada "num" elementos escribe el String "ss"
	 * Ejemplo: csv="123456789", num=4, ss="-" devolvería 1234-6789
	 * @param csv csv a formatear
	 * @param num cada cuantos elementos se desea escribir el String "ss"
	 * @param ss cadena que se desea introducir
	 * @return el csv formateado.
	 */
        public static String formatCSV(String csv, int num, String ss)
        {
            StringBuilder result = new StringBuilder("");
            if (csv.Length < num)
            {
                result.Append(csv);
                return result.ToString();
            }
            else
            {
                int i = 0;
                while (i + num <= csv.Length)
                {
                    String aux = csv.Substring(i, num);
                    result.Append(ss);
                    result.Append(aux);
                    i += num;
                }
                if (i < csv.Length)
                {
                    String aux = csv.Substring(i, csv.Length - i);
                    result.Append(ss);
                    result.Append(aux);

                }
                return result.ToString().Substring(1);
            }

        }


        //para la generacion de codigos de los tarjetones
        public string GenerarCodigo()
        {
            System.Random rnd = new Random(DateTime.Now.Millisecond);

            char[] Letras ={'0','1','2','3','4','5','6','7','8','9',
                    'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
                    'O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            string strAlfanumericos = "";

            for (int i = 0; i < 8; i++)
            {
                strAlfanumericos += Letras[rnd.Next(0, Letras.Length - 1)].ToString();
            }
            return strAlfanumericos.ToUpper();
        }



    }
}
