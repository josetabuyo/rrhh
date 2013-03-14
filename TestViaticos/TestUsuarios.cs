using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using NMock2;

namespace General
{
    [TestClass]
    public class TestUsuarios
    {
            Usuario usuario = new Usuario();

            public static void ConexionMockeada(string source, Usuario usuario)
            {
                IConexionBD conexion = TestObjects.ConexionMockeada();
                var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

                Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

                RepositorioUsuarios repo = new RepositorioUsuarios(conexion);

                usuario.NombreDeUsuario = "UsuDirGral";
                string password = "web1";

                bool acceso_correcto = repo.LoginUsuario(usuario, password);
            }        
        
        [TestMethod]
        public void dado_un_area_quiero_saber_nombre_telefono_y_mail_de_responsable()
        {

            var datos_del_responsable = new Responsable("Fabián", "Miranda", "4444-4256" , "4444-1111", "fmiranda@ministerio.gov.ar"); // new Dictionary<string, string>();
            //datos_del_responsable.Add("Nombre", "Fabián Miranda");
            //datos_del_responsable.Add("Telefono", "4577-2222");
            //datos_del_responsable.Add("Mail", "fabian@ministerio.gov.ar");

             Area rrhh = new Area(1, "RRHH", datos_del_responsable);

             Assert.AreEqual("Fabián", rrhh.datos_del_responsable.Nombre);
             Assert.AreEqual("Miranda", rrhh.datos_del_responsable.Apellido);
             Assert.AreEqual("4444-4256", rrhh.datos_del_responsable.Telefono);
             Assert.AreEqual("4444-1111", rrhh.datos_del_responsable.Fax);
             Assert.AreEqual("fmiranda@ministerio.gov.ar", rrhh.datos_del_responsable.Mail);
        }


         [TestMethod]
         public void dado_un_area_quiero_saber_direccion_telefono_y_mail_del_area()
         {
             Area un_area = new Area();
             un_area.Nombre = "Dirección de RRHH";
             un_area.Direccion = "9 de Julio 1925";
             un_area.Telefono = "4577-2222";
             un_area.Fax = "4577-1000";
             un_area.Mail = "direccionRRHH@ministerio.gov.ar";

             Assert.AreEqual("Dirección de RRHH", un_area.Nombre);
             Assert.AreEqual("9 de Julio 1925", un_area.Direccion);
             Assert.AreEqual("4577-2222", un_area.Telefono);
             Assert.AreEqual("4577-1000", un_area.Fax);
             Assert.AreEqual("direccionRRHH@ministerio.gov.ar", un_area.Mail);       
         }


         [TestMethod]
         public void dado_un_area_quiero_obtener_todos_los_asistentes_y_sus_datos_de_contacto()
         {
             var lista_de_asistentes = new List<Asistente>();
             lista_de_asistentes.Add(new Asistente("Andrea", "Pérez", "Secretaria", 1, "4444-7890", "444-7891", "andrea@rrhh.gov"));
             lista_de_asistentes.Add(new Asistente("Adrián", "Gómez", "Asesor", 2, "4444-7892", "", "adrian@rrhh.gov"));
             Area un_area = new Area();
             un_area.Asistentes = lista_de_asistentes;

             Assert.AreEqual(2, un_area.Asistentes.Count);
             Assert.IsTrue(un_area.Asistentes.Contains(lista_de_asistentes[0]));
             Assert.IsTrue(un_area.Asistentes.Contains(lista_de_asistentes[1]));
             Assert.AreEqual("Andrea", un_area.Asistentes[0].Nombre);
             Assert.AreEqual("Pérez", un_area.Asistentes[0].Apellido);
             Assert.AreEqual("Secretaria", un_area.Asistentes[0].Descripcion_Cargo);
             Assert.AreEqual(1, un_area.Asistentes[0].Prioridad_Cargo);
             Assert.AreEqual("4444-7890", un_area.Asistentes[0].Telefono);
             Assert.AreEqual("444-7891", un_area.Asistentes[0].Fax);
             Assert.AreEqual("andrea@rrhh.gov", un_area.Asistentes[0].Mail);
         }

        [TestMethod]
        public void deberia_traer_una_unica_area_con_los_datos_de_contacto_de_la_misma()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                    |es_firmante	|Cargo	      |Prioridad_Asistente	|Telefono_Area	|Mail_Area                |Id_Funcionalidad |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar| 1|";


            ConexionMockeada(source, usuario);

            Assert.AreEqual(1, usuario.Areas.Count);
            Assert.AreEqual("Claudia Silvia", usuario.Areas[0].datos_del_responsable.Nombre);
            Assert.AreEqual("CAL Quilmes", usuario.Areas[0].Nombre);
            Assert.AreEqual(". 0  Piso  Dto", usuario.Areas[0].Direccion);
            Assert.AreEqual("1111-0333", usuario.Areas[0].Telefono);
            Assert.AreEqual("area333@ministerio.gov.ar", usuario.Areas[0].Mail);
            Assert.AreEqual("Sabrina Vanesa", usuario.Areas[0].Asistentes[0].Nombre);
            Assert.AreEqual("PIRES", usuario.Areas[0].Asistentes[0].Apellido);
            Assert.AreEqual("1111-0333", usuario.Areas[0].Asistentes[0].Telefono);
           // Assert.AreEqual("44444444", usuario.Areas[0].Asistentes[0].Fax);
            Assert.AreEqual("area333@ministerio.gov.ar", usuario.Areas[0].Asistentes[0].Mail);

        }


        [TestMethod]
        public void deberia_mostrarme_una_unica_vez_la_secretaria_que_posee_el_area_cuando_los_datos_estan_repetidos()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                   |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                |es_firmante	|Cargo	      |Prioridad_Asistente	|Telefono_Area	|Mail_Area                | Id_Funcionalidad |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B   |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|1                 |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B   |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|1                 |";


            ConexionMockeada(source, usuario);

            Assert.AreEqual(1, usuario.Areas.Count);
        }


        [TestMethod]
        public void dada_un_area__con_3_asistentes_deberia_obtener_en_una_unica_area_unico_registro_y_los_3_asistentes_incluido_en_el_area()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                        |es_firmante	|Cargo	      |Prioridad_Asistente	|Telefono_Area	|Mail_Area                | Id_Funcionalidad |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B 	    |PIRES	                |Sabrina Vanesa	    |1111-1111	        |44444444	    |sabrina@secretaria-area333.gov.ar	    |0	            |Secretaria	  |1	                |0000-0333	    |area333@ministerio.gov.ar|1                 |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B 	    |PEREZ	                |Gabriela Ana	    |2222-2222	        |44444444	    |gabriela@asistente-area333.gov.ar	    |0	            |Asistente	  |2	                |0000-0333	    |area333@ministerio.gov.ar|1                 |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B 	    |SANCHEZ	            |Cristian Ariel	    |3333-3333	        |44444444	    |cristian@contador-area333.gov.ar	    |0	            |Contador	  |3	                |0000-0333	    |area333@ministerio.gov.ar|1                 |";

            ConexionMockeada(source, usuario);

            Assert.AreEqual(1, usuario.Areas.Count);
            Assert.AreEqual(3, usuario.Areas[0].Asistentes.Count);
            //Assert.AreEqual("Secretaria: PIRES Sabrina Vanesa |Teléfono: 1111-1111 |Mail: sabrina@secretaria-area333.gov.ar", " ");

        }

        [TestMethod]
        public void deberia_traer_4_areas_con_los_datos_de_contacto_de_la_mismas()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                    |es_firmante	|Cargo	      |Prioridad_Asistente	|Telefono_Area	|Mail_Area                | Id_Funcionalidad |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333-1@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|1                 |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PEREZ	                |Gabriela Ana	    |1111-0334	        |44444444	    |area333-2@ministerio.gov.ar	    |0	            |Asistente	  |2	                |1111-0333	    |area333@ministerio.gov.ar|1                 |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |SANCHEZ	            |Cristian Ariel	    |1111-0335	        |44444444	    |area333-3@ministerio.gov.ar	    |0	            |Contador	  |3	                |1111-0333	    |area333@ministerio.gov.ar|1                 |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|254	    |Viáticos   	    |0	            |Santolin               |Claudia Silvia	        |9 de Julio 3424. 7  Piso  Dto A 	|PIRES	                |Juan Ariel 	    |1111-1111	        |44444444	    |juan@ministerio.gov.ar	            |0	            |Secretario	  |1	                |1111-0000	    |areaC@ministerio.gov.ar  |1                 |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|461	    |Liquidaciones	    |0	            |Santolin               |Claudia Silvia	        |Rivadavia 7645	. 10  Piso  Dto 23  |PEREZ	                |Micaela    	    |1111-0334	        |44444444	    |micaela@ministerio.gov.ar	        |0	            |Asistente	  |1	                |1111-0111	    |areaB@ministerio.gov.ar  |1                 |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|054	    |Recursos Humanos	|0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B 	    |SANCHEZ	            |Belen Soledad	    |1111-0335	        |44444444	    |belen@ministerio.gov.ar	        |0	            |Contadora	  |1	                |1111-0222	    |areaA@ministerio.gov.ar  |1                 |";


            ConexionMockeada(source, usuario);

            Assert.AreEqual(4, usuario.Areas.Count);
            Assert.AreEqual("Claudia Silvia", usuario.Areas[0].datos_del_responsable.Nombre);
            Assert.AreEqual("CAL Quilmes", usuario.Areas[0].Nombre);
            Assert.AreEqual(". 0  Piso  Dto", usuario.Areas[0].Direccion);
            Assert.AreEqual("1111-0333", usuario.Areas[0].Telefono);
            Assert.AreEqual("area333@ministerio.gov.ar", usuario.Areas[0].Mail);
            Assert.AreEqual("Sabrina Vanesa", usuario.Areas[0].Asistentes[0].Nombre);
            Assert.AreEqual("PIRES", usuario.Areas[0].Asistentes[0].Apellido);
            Assert.AreEqual("1111-0333", usuario.Areas[0].Asistentes[0].Telefono);
            // Assert.AreEqual("44444444", usuario.Areas[0].Asistentes[0].Fax);
            Assert.AreEqual("area333-1@ministerio.gov.ar", usuario.Areas[0].Asistentes[0].Mail);

        }
    }
}
