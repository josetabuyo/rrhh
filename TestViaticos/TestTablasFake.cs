using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestViaticos
{
    [TestClass]
    public class TestTablasFake
    {
        [TestMethod]
        public void deberia_crear_una_tabla_con_id()
        {
            var source = "| id |";
            TablaDeDatos tabla = new TablaDeDatos();
            try
            {
                tabla = TablaDeDatos.From(source);
                Assert.Fail("Deberia decir que es imposible inferir los tipos de datos de columna");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Imposible inferir el tipo de dato de la columna", e.Message);
                Assert.AreEqual(0, tabla.Rows.Count);
                Assert.AreEqual(0, tabla.Columns.Count);
            }
        }

        [TestMethod]
        public void deberia_crear_una_tabla_con_id_y_descripcion()
        {
            var source = "| id      | descripcion |";
            TablaDeDatos tabla = new TablaDeDatos();
            try
            {
                tabla = TablaDeDatos.From(source);
                Assert.Fail("Deberia decir que es imposible inferir los tipos de datos de columna");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Imposible inferir el tipo de dato de la columna", e.Message);
                Assert.AreEqual(0, tabla.Rows.Count);
                Assert.AreEqual(0, tabla.Columns.Count);
            }
        }

        [TestMethod]
        public void deberia_crear_una_tabla_con_id_y_un_valor_1()
        {
            var source = @"| id |
                           | 1  |";

            TablaDeDatos tabla = TablaDeDatos.From(source);

            Assert.AreEqual(1, tabla.Columns.Count);
            Assert.AreEqual("id", tabla.Columns[0].ColumnName);
            Assert.AreEqual(1, tabla.Rows.Count);
            Assert.AreEqual(1, tabla.Rows[0].GetInt("id"));
        }

        [TestMethod]
        public void deberia_crear_una_tabla_con_id_y_un_valor_99()
        {
            var source = @"| id |
                           | 99  |";

            TablaDeDatos tabla = TablaDeDatos.From(source);

            Assert.AreEqual(1, tabla.Columns.Count);
            Assert.AreEqual("id", tabla.Columns[0].ColumnName);
            Assert.AreEqual(1, tabla.Rows.Count);
            Assert.AreEqual(99, tabla.Rows[0].GetInt("id"));
        }

        [TestMethod]
        public void deberia_crear_una_tabla_con_nombre_y_un_valor_Juan()
        {
            var source = @"| nombre |
                           | Juan   |";

            TablaDeDatos tabla = TablaDeDatos.From(source);

            Assert.AreEqual(1, tabla.Columns.Count);
            Assert.AreEqual("nombre", tabla.Columns[0].ColumnName);
            Assert.AreEqual(1, tabla.Rows.Count);
            Assert.AreEqual("Juan", tabla.Rows[0].GetString("nombre"));
        }

        [TestMethod]
        public void deberia_devolver_una_fecha()
        {
            var source = @" | id | nombre | nacimiento           |
                            | 7  | 0      | 2011-03-21 00:00:00  |
                            | 8  | pedro  | 2011-03-20 00:00:00  |";

            TablaDeDatos tabla = TablaDeDatos.From(source);

            Assert.AreEqual(3, tabla.Columns.Count);
            Assert.AreEqual("id", tabla.Columns[0].ColumnName);
            Assert.AreEqual("nombre", tabla.Columns[1].ColumnName);
            Assert.AreEqual("nacimiento", tabla.Columns[2].ColumnName);
            Assert.AreEqual(2, tabla.Rows.Count);

            Assert.AreEqual(7, tabla.Rows[0].GetInt("id"));
            Assert.AreEqual("0", tabla.Rows[0].GetString("nombre"));
            Assert.AreEqual(new DateTime(2011, 03, 21), tabla.Rows[0].GetDateTime("nacimiento"));

            Assert.AreEqual(8, tabla.Rows[1].GetInt("id"));
            Assert.AreEqual("pedro", tabla.Rows[1].GetString("nombre"));
            Assert.AreEqual(new DateTime(2011, 03, 20), tabla.Rows[1].GetDateTime("nacimiento"));
            
        }

        [TestMethod]
        public void deberia_poder_tener_un_null_como_primer_valor_de_una_columna()
        {
            string source = @"  |IdZona     |NombreZona         |IdProvincia        |NombreProvincia   |IdLocalidad    |NombreLocalidad|
                                |2          |null               |8                  |Catamarca         |5              |Capital2       |
                                |1          |Metro              |7                  |Buenos Aires      |4              |Capital        |";

            var resultado_sp = TablaDeDatos.From(source);
            Assert.AreEqual(DBNull.Value, resultado_sp.Rows[0].GetObject("NombreZona"));
        }

        [TestMethod]
        public void deberia_poder_tener_un_null_como_segundo_valor_de_una_columna()
        {
            string source = @"  |IdZona     |NombreZona         |IdProvincia        |NombreProvincia   |IdLocalidad    |NombreLocalidad|
                                |1          |Metro              |7                  |Buenos Aires      |4              |Capital        |
                                |2            |null               |8                  |Catamarca         |5              |Capital2       |";

            var resultado_sp = TablaDeDatos.From(source);
            Assert.AreEqual(DBNull.Value, resultado_sp.Rows[1].GetObject("NombreZona"));
        }

        [TestMethod]
        public void deberia_fallar_si_nada_indica_el_tipo_de_una_columna()
        {
            string source = @"  |IdZona     |NombreZona         |IdProvincia        |NombreProvincia   |IdLocalidad    |NombreLocalidad|
                                |2            |null               |8                  |Catamarca         |5              |Capital2       |";

            
            try
            {
                var resultado_sp = TablaDeDatos.From(source);
                Assert.AreEqual(DBNull.Value, resultado_sp.Rows[1].GetObject("NombreZona"));
                Assert.Fail("Debio lanzar excepcion Tipo Desconocido");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Tipo desconocido", e.Message);
            }
            
        }

//        [TestMethod]
//        public void deberia_crear_la_tabla_de_viaticos()
//        {
//            var datasource =
//                @"|Id|Baja|Fecha|IdAreaCreadora|DescripcionAreaCreadora|Persona_Nombre|Persona_Apellido|Persona_Documento|Persona_Area_Id|Persona_Area_Descripcion|Estadia_Id|Estadia_Desde|Estadia_Hasta|Estadia_Provincia_Id|Estadia_Provincia_Nombre|Estadia_Eventuales|Estadia_AdicionalParaPasajes|Estadia_CalculadoPorCategoria|Estadia_Motivo|Pasaje_Id|Pasaje_LocalidadOrigen_Id|Pasaje_LocalidadOrigen_Nombre|Pasaje_LocalidadDestino_Id|Pasaje_LocalidadDestino_Nombre|Pasaje_FechaDeViaje|Pasaje_MedioDeTransporte_Id|Pasaje_MedioDeTransporte_Nombre|Pasaje_MedioDePago_Id|Pasaje_MedioDePago_Nombre|Pasaje_Precio|Transicion_Id|Transicion_AreaOrigen_Id|Transicion_AreaOrigen_Descripcion|Transicion_AreaOrigen_Responsable_Nombre|Transicion_AreaOrigen_Responsable_Apellido|Transicion_AreaOrigen_Responsable_Documento|Transicion_AreaDestino_Id|Transicion_AreaDestino_Descripcion|Transicion_AreaDestino_Responsable_Nombre|Transicion_AreaDestino_Responsable_Apellido|Transicion_AreaDestino_Responsable_Documento|Transicion_Id_Accion|Transicion_Fecha|Transicion_Comentario|Telefono_Area|Cuil_Persona|Legajo_Persona|Nivel_Funcion|Grado_Rango|Categoria_Persona|Id_Zona|Nombre_Zona|
//                   "|1|true|12/07/12|1|Area_Creadora|pepe|lopez|12345123|1|Area_persona|1|12/07/12|15/07/12|1|Catamarca|123.5|123.5|123.5|un_motivo|1|1|Guadalajara|2|pernambuco

//                                                    |12/07/12|1|Avion|1|tarjeta|345.5|1|1|un_area|fabian|miranda|1234567|2|otra_area|marta|novoa|1234567,                                //Transicion_AreaDestino_Responsable_Documento 
//                                                    1|12/5/12"),              //Transicion_Fecha  
//                                                    "un_comentario",                        //Transicion_Comentario
//                                                    "1234567",                              //Telefono_Area
//                                                    "1234567",                              //Cuil_Persona
//                                                    1234567,                                //Legajo_Persona
//                                                    "una_funcion",                          //Nivel_Funcion
//                                                    "Un_Grado",                             //Grado_Rango
//                                                    "Una_Categoria",                        //Categoria_Persona
//                                                    1,                                      //Id_Zona
//                                                    "una_zona"},                            //Nombre_Zona
//                                                    true);
//        }
    }
}
