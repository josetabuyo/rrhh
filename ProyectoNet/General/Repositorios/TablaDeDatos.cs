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
    public class TablaDeDatos : DataTable
    {
        public new List<RowDeDatos> Rows
        {
            get
            {
                var list = new List<RowDeDatos>();
                foreach (DataRow row in base.Rows)
                {
                    list.Add(new RowDeDatos(row));
                }
                return list;
            }
            set { }
        }

        public TablaDeDatos()
        {
        }

        private delegate void AddString(object x);

        public static TablaDeDatos From(string source)
        {
            var instance = new TablaDeDatos();
            var lines = source.Split(Environment.NewLine.ToArray()).ToList().FindAll(s => s.Trim() != string.Empty).ToArray();
            
            var tabla_valores = CrearFilas(lines);
            if (tabla_valores.Count == 0) throw new Exception("Imposible inferir el tipo de dato de la columna");
            CrearColumnas(instance, lines, tabla_valores);
            
            tabla_valores.ForEach(row => instance.LoadDataRow(row, true));

            return instance;
        }

        private static List<object[]> CrearFilas(object[] lines)
        {
            var rows = new List<object>(lines.Skip(1));
            var valores = new List<object[]>();
            PorCadaStringNoVacio(rows, str => valores.Add(ValoresDelRow(str)));
            return valores;
        }

        private static object[] ValoresDelRow(object str)
        {
            return new List<object>(str.ToString().Split('|')).FindAll(s => s.ToString().Trim() != String.Empty).Select((s) =>
                                                                                                                            {
                                                                                                                                if (s.ToString().Trim().ToLower() == "null")
                                                                                                                                    return null;
                                                                                                                                return s.ToString().Trim();
                                                                                                                            }).ToArray();
        }

        private static void CrearColumnas(TablaDeDatos instance, string[] lines, List<object[]> tabla_valores )
        {
            var nombres_columnas = new List<string>(lines[0].Split('|')).FindAll(s => s.Trim() != string.Empty).Select(s => s.Trim()).ToList();
            nombres_columnas.ForEach(nombre_columna => instance.Columns.Add(nombre_columna, TipoInferidoDe(tabla_valores, nombre_columna, nombres_columnas)));
        }

        private static Type TipoInferidoDe(List<object[]> tabla_valores, string nombre_columna, List<string> nombres_columnas)
        {
            int posicion_columna = nombres_columnas.IndexOf(nombre_columna);
            return TipoDeColumna(posicion_columna, tabla_valores);
        }

        private static Type TipoDeColumna(int posicion_columna, List<object[]> tabla_valores)
        {
            TypeSelector selector = new TypeSelector();
            var tipo = selector.TypeOf(tabla_valores[0][posicion_columna]);
            tabla_valores.ForEach(row => tipo = selector.GetType(row[posicion_columna], tipo));
            return selector.Type(tipo);
        }

        private static void PorCadaStringNoVacio(List<object> list, AddString block)
        {
            list.FindAll(s => s.ToString().Trim() != string.Empty).ForEach(s => block(s));
        }
    }
}