using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;


using NMock2;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioUsuarios
    {

        [TestInitialize]
        public void Setup()
        {
        }


        /// <summary>
        /// Ignorado para poder iniciarl el CI
        /// </summary>
        [TestMethod]
        [Ignore]
        public void fabian_deberia_tener_solo_acceso_a_viaticos()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                |es_firmante	|Cargo	      |Prioridad_Asistente	|Telefono_Area	|Mail_Area                |Id_Funcionalidad |Nombre_Funcionalidad  |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|1                |-                     |";
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioUsuarios repo = new RepositorioUsuarios(conexion);

            var fabian = TestObjects.Fabian();
            repo.LoginUsuario(fabian, "web1");

            Assert.IsTrue(fabian.TienePermisosParaViaticos);
            Assert.IsFalse(fabian.TienePermisosParaSiCoI);
        }

        /// <summary>
        /// Ignorado para poder iniciarl el CI
        /// </summary>
        [TestMethod]
        [Ignore]
        public void usuario_mesa_entrada_deberia_tener_solo_acceso_a_documentos()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                |es_firmante	|Cargo	      |Prioridad_Asistente	|Telefono_Area	|Mail_Area                |Id_Funcionalidad |Nombre_Funcionalidad  |
                                |291	    |UsuMesa        |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|2                |-                     |";
                                                                                                                                                                                                                                                                                                                                                                                                                                                                

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioUsuarios repo = new RepositorioUsuarios(conexion);

            var usu_mesa = TestObjects.UsuarioMesaEntrada();
            repo.LoginUsuario(usu_mesa, "web1");

            Assert.IsFalse(usu_mesa.TienePermisosParaViaticos);
            Assert.IsTrue(usu_mesa.TienePermisosParaSiCoI);
        }

        /// <summary>
        /// Ignorado para poder iniciarl el CI
        /// </summary>
        [TestMethod]
        [Ignore]
        public void fabian_deberia_tener_acceso_a_viaticos_y_a_documentos()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                |es_firmante	|Cargo	      |Prioridad_Asistente	|Telefono_Area	|Mail_Area                |Id_Funcionalidad | Nombre_Funcionalidad  |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|1                | -                     |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|2                | -                     |";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioUsuarios repo = new RepositorioUsuarios(conexion);

            var fabian = TestObjects.Fabian();
            repo.LoginUsuario(fabian, "web1");

            Assert.IsTrue(fabian.TienePermisosParaViaticos);
            Assert.IsTrue(fabian.TienePermisosParaSiCoI);
        }

        /// <summary>
        /// Ignorado para poder iniciarl el CI
        /// </summary>
        [TestMethod]
        [Ignore]
        public void fabian_deberia_tener_solo_un_area_con_un_asistente()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                |es_firmante	|Cargo	      |Prioridad_Asistente	|Telefono_Area	|Mail_Area                |Id_Funcionalidad |  Nombre_Funcionalidad  |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|1                |  -                     |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|2                |  -                     |";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioUsuarios repo = new RepositorioUsuarios(conexion);

            var fabian = TestObjects.Fabian();
            repo.LoginUsuario(fabian, "web1");

            Assert.AreEqual(1, fabian.AreasAdministradas.Count);
        }

        /// <summary>
        /// Ignorado para poder iniciarl el CI
        /// </summary>
        [TestMethod]
        [Ignore]
        public void fabian_deberia_tener_un_area_con_solo_un_asistente()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                |es_firmante	|Cargo	      |Prioridad_Asistente	|Telefono_Area	|Mail_Area                |Id_Funcionalidad |Nombre_Funcionalidad  |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|1                |-                     |
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1111-0333	    |area333@ministerio.gov.ar|2                |-                     |";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioUsuarios repo = new RepositorioUsuarios(conexion);

            var fabian = TestObjects.Fabian();
            repo.LoginUsuario(fabian, "web1");

            Assert.AreEqual(1, fabian.AreasAdministradas[0].Asistentes.Count);
        }
    }
}
