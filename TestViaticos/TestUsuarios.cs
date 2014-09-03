using System.Collections.Generic;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using General.Sacc.Seguridad;
using General.MAU;

namespace General
{
    [TestClass]
    public class TestUsuarios
    {
        private Usuario usuario = new Usuario();

        public static void ConexionMockeada(string source, Usuario usuario)
        {
            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioUsuarios repo = new RepositorioUsuarios(conexion);

            usuario.Alias = "UsuDirGral";
            string password = "web1";
        }

        [TestMethod]
        public void dado_un_area_quiero_saber_nombre_telefono_y_mail_de_responsable()
        {

            var datos_del_responsable = new Responsable("Fabián", "Miranda", "4444-4256", "4444-1111", "fmiranda@ministerio.gov.ar"); // new Dictionary<string, string>();
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

            List<DatoDeContacto> datos_de_contacto = new List<DatoDeContacto>();

            DatoDeContacto dato_de_telefonos = new DatoDeContacto(1, "Teléfono", "4577-2222", 1);
            DatoDeContacto dato_de_faxes = new DatoDeContacto(2, "Fax", "4577-1000", 1);
            DatoDeContacto dato_de_mails = new DatoDeContacto(3, "Mail", "direccionRRHH@ministerio.gov.ar",1);

            datos_de_contacto.Add(dato_de_telefonos);
            datos_de_contacto.Add(dato_de_mails);
            datos_de_contacto.Add(dato_de_faxes);

            un_area.DatosDeContacto = datos_de_contacto;

            Assert.AreEqual("Dirección de RRHH", un_area.Nombre);
            Assert.AreEqual("9 de Julio 1925", un_area.Direccion);
            Assert.IsTrue(un_area.DatosDeContacto.Find(d =>d.Id == ConstantesDeDatosDeContacto.TELEFONO).Dato.Contains("4577-2222"));
            Assert.IsTrue(un_area.DatosDeContacto.Find(d => d.Id == ConstantesDeDatosDeContacto.FAX).Dato.Contains("4577-1000"));
            Assert.IsTrue(un_area.DatosDeContacto.Find(d => d.Id == ConstantesDeDatosDeContacto.MAIL).Dato.Contains("direccionRRHH@ministerio.gov.ar"));
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
        [Ignore] //Para que funcione el teamcity
        public void deberia_traer_una_unica_area_con_los_datos_de_contacto_de_la_misma()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	            |Id_Dato_Area    |Descripcion_Dato_Area  |Dato_Area                  |Orden         |es_firmante	|Cargo	      |Prioridad_Asistente	|Id_Funcionalidad | Nombre_Funcionalidad
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	|1               |Teléfono               |1111-0333                  |1             |0	            |Secretaria	  |1	                |1                | -
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	|3               |Mail                   |area333@ministerio.gov.ar  |1             |0	            |Secretaria	  |1	                | 1               | -";                                                                                                                                                                                                                                                                                                                                           

            ConexionMockeada(source, usuario);

            var areas_usuario = Autorizador.Instancia().AreasAdministradasPor(usuario);
            Assert.AreEqual(1, areas_usuario.Count);
            Assert.AreEqual("Claudia Silvia", areas_usuario[0].datos_del_responsable.Nombre);
            Assert.AreEqual("CAL Quilmes", areas_usuario[0].Nombre);
            Assert.AreEqual(". 0  Piso  Dto", areas_usuario[0].Direccion);
            Assert.IsTrue(areas_usuario[0].DatosDeContacto.Find(d => d.Id == ConstantesDeDatosDeContacto.TELEFONO).Dato.Contains("1111-0333"));
            Assert.IsTrue(areas_usuario[0].DatosDeContacto.Find(d => d.Id == ConstantesDeDatosDeContacto.MAIL).Dato.Contains("area333@ministerio.gov.ar"));
            Assert.AreEqual("Sabrina Vanesa", areas_usuario[0].Asistentes[0].Nombre);
            Assert.AreEqual("PIRES", areas_usuario[0].Asistentes[0].Apellido);
            Assert.AreEqual("1111-0333", areas_usuario[0].Asistentes[0].Telefono);
            // Assert.AreEqual("44444444", usuario.Areas[0].Asistentes[0].Fax);
            Assert.AreEqual("area333@ministerio.gov.ar", areas_usuario[0].Asistentes[0].Mail);

        }


        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void deberia_mostrarme_una_unica_vez_la_secretaria_que_posee_el_area_cuando_los_datos_estan_repetidos()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                   |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                |es_firmante	|Cargo	      |Prioridad_Asistente	|Id_Dato_Area |Descripcion_Dato_Area |Orden |Dato_Area                | Id_Funcionalidad | Nombre_Funcionalidad
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B   |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |1            |Teléfono              |1     |1111-0333	            |1                 | -
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B   |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333@ministerio.gov.ar	    |0	            |Secretaria	  |1	                |3            |Mail                  |1     |area333@ministerio.gov.ar|1                 | -";
                                                                                                                                                                                                                                                                                                                                                                                                

            ConexionMockeada(source, usuario);

            Assert.AreEqual(1, Autorizador.Instancia().AreasAdministradasPor(usuario).Count);
        }


        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void dada_un_area__con_3_asistentes_deberia_obtener_en_una_unica_area_unico_registro_y_los_3_asistentes_incluido_en_el_area()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                        |es_firmante	|Cargo	      |Prioridad_Asistente	|Id_Dato_Area |Descripcion_Dato_Area  |Orden   |Dato_Area                | Id_Funcionalidad | Nombre_Funcionalidad
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B 	    |PIRES	                |Sabrina Vanesa	    |1111-1111	        |44444444	    |sabrina@secretaria-area333.gov.ar	    |0	            |Secretaria	  |1	                |1            |Teléfono               |1       |0000-0333	             |1                 | -
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B 	    |PEREZ	                |Gabriela Ana	    |2222-2222	        |44444444	    |gabriela@asistente-area333.gov.ar	    |0	            |Asistente	  |2	                |1            |Teléfono               |2       |0000-0333	             |1                 | -
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B 	    |SANCHEZ	            |Cristian Ariel	    |3333-3333	        |44444444	    |cristian@contador-area333.gov.ar	    |0	            |Contador	  |3	                |3            |Mail                   |1       |area333@ministerio.gov.ar|1                 | -";

            ConexionMockeada(source, usuario);

            Assert.AreEqual(1, Autorizador.Instancia().AreasAdministradasPor(usuario).Count);
            Assert.AreEqual(3, Autorizador.Instancia().AreasAdministradasPor(usuario)[0].Asistentes.Count);
            //Assert.AreEqual("Secretaria: PIRES Sabrina Vanesa |Teléfono: 1111-1111 |Mail: sabrina@secretaria-area333.gov.ar", " ");

        }

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void deberia_traer_4_areas_con_los_datos_de_contacto_de_la_mismas()
        {
            string source = @"  |id_usuario	|nombre	        |password	                    |id_area	|nombre_area	    |Presenta_DDJJ	|Apellido_Responsable	|Nombre_Responsable     |direccion	                        |Apellido_Asistente	    |Nombre_Asistente	|Telefono_Asistente	|Fax_Asistente	|Mail_Asistente	                   |Id_Dato_Area    |Descripcion_Dato_Area  |Dato_Area                  |Orden |es_firmante	|Cargo	      |Prioridad_Asistente	| Id_Funcionalidad | Nombre_Funcionalidad
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PIRES	                |Sabrina Vanesa	    |1111-0333	        |44444444	    |area333-1@ministerio.gov.ar	   |1               |Teléfono               |1111-0333                  |1     |0	        |Secretaria	  |1	                |1                 | -
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |PEREZ	                |Gabriela Ana	    |1111-0334	        |44444444	    |area333-2@ministerio.gov.ar	   |2               |Fax                    |44444444                   |1     |0	        |Asistente	  |2	                |1                 | -
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|333	    |CAL Quilmes	    |0	            |Santolin               |Claudia Silvia	        |. 0  Piso  Dto 	                |SANCHEZ	            |Cristian Ariel	    |1111-0335	        |44444444	    |area333-3@ministerio.gov.ar	   |3               |Mail                   |area333@ministerio.gov.ar  |1     |0	        |Contador	  |3	                |1                 | -
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|254	    |Viáticos   	    |0	            |Santolin               |Claudia Silvia	        |9 de Julio 3424. 7  Piso  Dto A 	|PIRES	                |Juan Ariel 	    |1111-1111	        |44444444	    |juan@ministerio.gov.ar	           |1               |Teléfono               |123-456                    |1     |0	        |Secretario	  |1	                |1                 | -
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|461	    |Liquidaciones	    |0	            |Santolin               |Claudia Silvia	        |Rivadavia 7645	. 10  Piso  Dto 23  |PEREZ	                |Micaela    	    |1111-0334	        |44444444	    |micaela@ministerio.gov.ar	       |1               |Teléfono               |789-456                    |1     |0	        |Asistente	  |1	                |1                 | -
                                |291	    |UsuDirGral     |l3WIqH4QWCAycWcSzPXYXRil/M8=	|054	    |Recursos Humanos	|0	            |Santolin               |Claudia Silvia	        |Peron 525	. 6  Piso  Dto B 	    |SANCHEZ	            |Belen Soledad	    |1111-0335	        |44444444	    |belen@ministerio.gov.ar	       |1               |Teléfono               |654-654                    |1     |0	        |Contadora	  |1	                |1                 | -";


            ConexionMockeada(source, usuario);

            var areas_usuario = Autorizador.Instancia().AreasAdministradasPor(usuario);

            Assert.AreEqual(4, areas_usuario.Count);
            Assert.AreEqual("Claudia Silvia", areas_usuario[0].datos_del_responsable.Nombre);
            Assert.AreEqual("CAL Quilmes", areas_usuario[0].Nombre);
            Assert.AreEqual(". 0  Piso  Dto", areas_usuario[0].Direccion);
            Assert.IsTrue(areas_usuario[0].DatosDeContacto.Find(d => d.Id == ConstantesDeDatosDeContacto.TELEFONO).Dato.Contains("1111-0333"));
            Assert.IsTrue(areas_usuario[0].DatosDeContacto.Find(d => d.Id == ConstantesDeDatosDeContacto.MAIL).Dato.Contains("area333@ministerio.gov.ar"));
            Assert.AreEqual("Sabrina Vanesa", areas_usuario[0].Asistentes[0].Nombre);
            Assert.AreEqual("PIRES", areas_usuario[0].Asistentes[0].Apellido);
            Assert.AreEqual("1111-0333", areas_usuario[0].Asistentes[0].Telefono);
            // Assert.AreEqual("44444444", usuario.Areas[0].Asistentes[0].Fax);
            Assert.AreEqual("area333-1@ministerio.gov.ar", areas_usuario[0].Asistentes[0].Mail);

        }

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void un_usuario_no_CENARD_debe_acceder_a_Materias()
        {
            //var items_de_menu = new List<ItemDeMenu>();
            //items_de_menu.Add(new ItemDeMenu(){ NombreItem = "Materias", Url ="Materias.aspx"});
            //var menu_esperado_sacc_no_cenard = new List<MenuDelSistema>() { new MenuDelSistema("MenuSaccNoCenard", items_de_menu) };

            //var autorizador = new AutorizadorSacc(menu_esperado_sacc_no_cenard);
            //Assert.AreEqual(autorizador.ItemsPermitidos("MenuSaccNoCenard").Count, 1);
            //Assert.AreEqual("Materias.aspx", autorizador.ItemsPermitidos("MenuSaccNoCenard").Find(i => i.NombreItem == "Materias").Url);
            Assert.Fail();
        }

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void un_usuario_CENARD_no_debe_acceder_a_Materias()
        {
            //var items_de_menu = new List<ItemDeMenu>();
            //items_de_menu.Add(new ItemDeMenu() { NombreItem = "Cursos", Url = "ABMCursos.aspx" });
            //var menu_esperado_sacc_cenard = new List<MenuDelSistema>() { new MenuDelSistema("MenuSaccCenard", items_de_menu) };
            //var autorizador = new AutorizadorSacc(menu_esperado_sacc_cenard);

            //Assert.AreEqual(1, autorizador.ItemsPermitidos("MenuSaccCenard").Count);
            //Assert.IsFalse(autorizador.ItemsPermitidos("MenuSaccCenard").Exists(i => i.NombreItem == "Materias"));
            Assert.Fail();
        }

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void un_usuario_SACC_no_debe_acceder_al_menu_Sicoi()
        {
            //var items_de_menu = new List<ItemDeMenu>();
            //items_de_menu.Add(new ItemDeMenu() { NombreItem = "Materias", Url = "Materias.aspx" });
            //var menu_esperado_sacc = new List<MenuDelSistema>() { new MenuDelSistema("MenuSACC", items_de_menu) };
            //var autorizador = new AutorizadorSacc(menu_esperado_sacc);

            //Assert.AreEqual(1, autorizador.ItemsPermitidos("MenuSACC").Count);
            //Assert.IsTrue(autorizador.ItemsPermitidos("MenuSACC").Exists(i => i.NombreItem == "Materias"));
            //Assert.IsFalse(autorizador.ItemsPermitidos("MenuSACC").Exists(i => i.NombreItem == "AltaDocumentos"));

            //Assert.AreEqual(0, autorizador.ItemsPermitidos("MenuSicoi").Count);
            Assert.Fail();
        }

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void un_usuario_SACC_puede_acceder_a_dos_menues_sacc()
        {
            //var items_de_menu = new List<ItemDeMenu>();
            //var otros_items = new List<ItemDeMenu>();

            //items_de_menu.Add(new ItemDeMenu() { NombreItem = "Materias", Url = "Materias.aspx" });
            //otros_items.Add(new ItemDeMenu() { NombreItem = "OtraOpcion", Url = "OtraOpcion.aspx" });
            //var menu_esperado_sacc = new MenuDelSistema("MenuSACC", items_de_menu);
            //var otro_menu_esperado = new MenuDelSistema("OtroMenu", otros_items);

            //var menues = new List<MenuDelSistema>() { menu_esperado_sacc, otro_menu_esperado };

            //var autorizador = new AutorizadorSacc(menues);

            //Assert.AreEqual(1, autorizador.ItemsPermitidos("MenuSACC").Count);
            //Assert.IsTrue(autorizador.ItemsPermitidos("MenuSACC").Exists(i => i.NombreItem == "Materias"));
            //Assert.IsFalse(autorizador.ItemsPermitidos("MenuSACC").Exists(i => i.NombreItem == "OtraOpcion"));

            //Assert.AreEqual(1, autorizador.ItemsPermitidos("OtroMenu").Count);
            //Assert.IsTrue(autorizador.ItemsPermitidos("OtroMenu").Exists(i => i.NombreItem == "OtraOpcion"));
            //Assert.IsFalse(autorizador.ItemsPermitidos("OtroMenu").Exists(i => i.NombreItem == "Materias"));
            Assert.Fail();
        }

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void el_repo_de_usuarios_construye_un_autorizador_con_un_acceso()
        {
//            string source = @"  id| menu        | nombre      |  url                    | orden | nivel | padre
//                                1 | MenuSACC	| Materias    |  Materias.aspx          | 1     | 2     | 0";

//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            RepositorioUsuarios repo = new RepositorioUsuarios(conexion);

//            var autorizador = repo.AutorizadorPara(usuario);

//            Assert.AreEqual(1, autorizador.ItemsPermitidos("MenuSACC").Count);
//            Assert.AreEqual("Materias.aspx", autorizador.ItemsPermitidos("MenuSACC").Find(i => i.NombreItem == "Materias").Url);
              Assert.Fail();
        }

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void el_repo_de_usuarios_construye_un_autorizador_con_dos_accesos_para_un_menu()
        {

//            string source = @"  id| menu        | nombre      |  url                    | orden | padre
//                                1 | MenuSACC	| Materias    |  Materias.aspx          | 1     | 0
//                                2 | MenuSACC	| Curso       |  Cursos.aspx            | 2     | 0";

//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            RepositorioUsuarios repo = new RepositorioUsuarios(conexion);

//            var autorizador = repo.AutorizadorPara(usuario);

//            Assert.AreEqual(2, autorizador.ItemsPermitidos("MenuSACC").Count);
//            Assert.AreEqual("Materias.aspx", autorizador.ItemsPermitidos("MenuSACC").Find(i => i.NombreItem == "Materias").Url);
//            Assert.AreEqual("Cursos.aspx", autorizador.ItemsPermitidos("MenuSACC").Find(i => i.NombreItem == "Curso").Url);
            Assert.Fail();
        }

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void el_repo_de_usuarios_construye_un_autorizador_con_accesos_para_dos_menues()
        {
//            string source = @"  id| menu        | nombre      |  url                    | orden | padre
//                                1 | MenuSACC	| Materias    |  Materias.aspx          | 1     | 0
//                                2 | MenuSicoi	| Documentos  |  AltaDocumento.aspx     | 2     | 0";

//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            RepositorioUsuarios repo = new RepositorioUsuarios(conexion);

//            var autorizador = repo.AutorizadorPara(usuario);

//            Assert.AreEqual(1, autorizador.ItemsPermitidos("MenuSACC").Count);
//            Assert.AreEqual(1, autorizador.ItemsPermitidos("MenuSicoi").Count);
//            Assert.AreEqual("Materias.aspx", autorizador.ItemsPermitidos("MenuSACC").Find(i => i.NombreItem == "Materias").Url);
//            Assert.AreEqual("AltaDocumento.aspx", autorizador.ItemsPermitidos("MenuSicoi").Find(i => i.NombreItem == "Documentos").Url);
            Assert.Fail();
        }
    }
}
