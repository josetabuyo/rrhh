using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;


using NMock2;
using General.MAU;
using General.Postular;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioDePerfiles
    {

        [TestInitialize]
        public void Setup()
        {
        }



        [TestMethod]
        public void deberia_poder_conocer_los_foliables_de_un_perfil()
        {
            IConexionBD conexion = TestObjects.ConexionMockeada();
            
            string source = @"  |DescripcionDocRequerida	                            |NombreClaseFoliable                   |  
                                |Se requiere 5 años de experiencia en ambito publico	|FoliableExperienciaLaboralPublica     |
                                |Se requiere 2 años de experiencia en ambito privado    |FoliableExperienciaLaboralPrivada     |
                                |Titulo Universitario	 	                            |FoliableEstudiosUniversitario         | 
                                |Antecedentes Penales	                                |FoliableAntecedentesPenales           |";


           var resultado_sp = TablaDeDatos.From(source);
           Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

           RepositorioDePuestos repo = new RepositorioDePuestos(conexion);

           Puesto perfil = TestObjects.UnPerfil();

           perfil.DocumentacionRequerida = repo.GetFoliablesDelPerfil(perfil.Id);
           Assert.AreEqual(4, perfil.DocumentacionRequerida.Count);

        }

        [TestMethod]
        public void deberia_traer_los_estudios_universitarios_de_un_cv_a_partir_del_foliable()
        {
           
            Puesto perfil = TestObjects.UnPerfil();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarEstudio(TestObjects.UnEstudioUniversitario());
            cv.AgregarEstudio(TestObjects.UnEstudioUniversitario());
            //cv.AgregarEstudio(TestObjects.UnEstudioSecundario());
            //tabla de niveles de estudio se llama tabla_codigo_escolaridad_nivel
            //nivel universitario = 12  nivel secundario = 04

            FoliableEstudiosUniversitario foliable_universitario = new FoliableEstudiosUniversitario();
            FoliableEstudiosSecundario foliable_secundario = new FoliableEstudiosSecundario();
            //perfil.DocumentacionRequerida = repo.GetFoliablesDelPerfil(perfil.Id);

            Assert.AreEqual(2, foliable_universitario.documentacion(cv).Count);
            Assert.AreEqual(0, foliable_secundario.documentacion(cv).Count);

        }

        [TestMethod]
        public void deberia_crear_una_pantalla_mostrando_solo_ingles()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarIdioma(Idioma("Ingles"));
            
            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, TestObjects.UnPerfil());

            Assert.AreEqual(1, pantalla.DocumentacionRequerida.Count);
            Assert.AreEqual("Idiomas", pantalla.DocumentacionRequerida[0].DescripcionRequisito);
            Assert.AreEqual(1, pantalla.DocumentacionRequerida[0].ItemsCv.Count);
            Assert.AreEqual("Ingles", pantalla.DocumentacionRequerida[0].ItemsCv[0].Descripcion);
            Assert.AreEqual(0, pantalla.CuadroPerfil.Count);
        }

        [TestMethod]
        public void deberia_crear_una_pantalla_mostrando_solo_aleman()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarIdioma(Idioma("Aleman"));
            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, TestObjects.UnPerfil());

            Assert.AreEqual(1, pantalla.DocumentacionRequerida.Count);
            Assert.AreEqual("Idiomas", pantalla.DocumentacionRequerida[0].DescripcionRequisito);
            Assert.AreEqual(1, pantalla.DocumentacionRequerida[0].ItemsCv.Count);
            Assert.AreEqual("Aleman", pantalla.DocumentacionRequerida[0].ItemsCv[0].Descripcion);

        }

        [TestMethod]
        public void deberia_crear_una_pantalla_mostrando_una_publicacion()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarPublicacion(new CvPublicaciones(1,"Informe sobre ciegos","","",1,1,new DateTime()));
            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, TestObjects.UnPerfil());

            Assert.AreEqual(1, pantalla.DocumentacionRequerida.Count);
            Assert.AreEqual("Publicaciones", pantalla.DocumentacionRequerida[0].DescripcionRequisito);
            Assert.AreEqual(1, pantalla.DocumentacionRequerida[0].ItemsCv.Count);
            Assert.AreEqual("Informe sobre ciegos", pantalla.DocumentacionRequerida[0].ItemsCv[0].Descripcion);

        }

        [TestMethod]
        public void deberia_crear_una_pantalla_mostrando_aleman_e_ingles_y_una_publicacion()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarIdioma(Idioma("Aleman"));
            cv.AgregarIdioma(Idioma("Ingles"));
            cv.AgregarPublicacion(new CvPublicaciones(1, "Informe sobre ciegos", "", "", 1, 1, new DateTime()));
            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, TestObjects.UnPerfil());

            Assert.AreEqual(2, pantalla.DocumentacionRequerida.Count);
            Assert.AreEqual("Idiomas", pantalla.DocumentacionRequerida[0].DescripcionRequisito);
            Assert.AreEqual(2, pantalla.DocumentacionRequerida[0].ItemsCv.Count);
            Assert.AreEqual("Aleman", pantalla.DocumentacionRequerida[0].ItemsCv[0].Descripcion);
            Assert.AreEqual("Ingles", pantalla.DocumentacionRequerida[0].ItemsCv[1].Descripcion);
            Assert.AreEqual("Publicaciones", pantalla.DocumentacionRequerida[1].DescripcionRequisito);
            Assert.AreEqual(1, pantalla.DocumentacionRequerida[1].ItemsCv.Count);
            Assert.AreEqual("Informe sobre ciegos", pantalla.DocumentacionRequerida[1].ItemsCv[0].Descripcion);
        }

        [TestMethod]
        public void deberia_ver_el_idioma_ingles_en_el_cuadro_del_perfil()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarIdioma(Idioma("Ingles"));

            Puesto puesto = TestObjects.UnPerfil();
            puesto.Requiere(RequisitoIdiomaIngles());

            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, puesto);

            Assert.AreEqual(1, pantalla.CuadroPerfil.Count);
            Assert.AreEqual("Idiomas", pantalla.CuadroPerfil[0].DescripcionRequisito);
            Assert.AreEqual(1, pantalla.CuadroPerfil[0].ItemsCv.Count);
            Assert.AreEqual("Ingles", pantalla.CuadroPerfil[0].ItemsCv[0].Descripcion);
            Assert.AreEqual(0, pantalla.DocumentacionRequerida.Count);
        }

        [TestMethod]
        public void deberia_ver_el_idioma_portugues_en_el_cuadro_del_perfil()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarIdioma(Idioma("Portugues"));

            Puesto puesto = TestObjects.UnPerfil();
            puesto.Requiere(RequisitoIdiomaPortugues());

            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, puesto);

            Assert.AreEqual(1, pantalla.CuadroPerfil.Count);
            Assert.AreEqual("Idiomas", pantalla.CuadroPerfil[0].DescripcionRequisito);
            Assert.AreEqual(1, pantalla.CuadroPerfil[0].ItemsCv.Count);
            Assert.AreEqual("Portugues", pantalla.CuadroPerfil[0].ItemsCv[0].Descripcion);
            Assert.AreEqual(0, pantalla.DocumentacionRequerida.Count);
        }

        [TestMethod]
        public void deberia_ver_el_idioma_ingles_en_el_cuadro_del_perfil_y_portugues_fuera_de_el()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarIdioma(Idioma("Ingles"));
            cv.AgregarIdioma(Idioma("Portugues"));

            Puesto puesto = TestObjects.UnPerfil();
            puesto.Requiere(RequisitoIdiomaIngles());

            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, puesto);

            Assert.AreEqual(1, pantalla.CuadroPerfil.Count);
            Assert.AreEqual("Idiomas", pantalla.CuadroPerfil[0].DescripcionRequisito);
            Assert.AreEqual(1, pantalla.CuadroPerfil[0].ItemsCv.Count);
            Assert.AreEqual("Ingles", pantalla.CuadroPerfil[0].ItemsCv[0].Descripcion);

            Assert.AreEqual(1, pantalla.DocumentacionRequerida[0].ItemsCv.Count);
            Assert.AreEqual("Idiomas", pantalla.DocumentacionRequerida[0].DescripcionRequisito);
            Assert.AreEqual(1, pantalla.DocumentacionRequerida[0].ItemsCv.Count);
            Assert.AreEqual("Portugues", pantalla.DocumentacionRequerida[0].ItemsCv[0].Descripcion);
        }

        [TestMethod]
        public void deberia_ver_el_idioma_ingles_y_portugues_en_el_cuadro_del_perfil()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarIdioma(Idioma("Ingles"));
            cv.AgregarIdioma(Idioma("Portugues"));

            Puesto puesto = TestObjects.UnPerfil();
            var idiomas_requeridos = new List<string>() { "Ingles", "Portugues" };
            puesto.Requiere(new RequisitoIdioma("Idiomas", idiomas_requeridos));

            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, puesto);

            Assert.AreEqual(1, pantalla.CuadroPerfil.Count);
            Assert.AreEqual("Idiomas", pantalla.CuadroPerfil[0].DescripcionRequisito);
            Assert.AreEqual(2, pantalla.CuadroPerfil[0].ItemsCv.Count);
            Assert.AreEqual("Ingles", pantalla.CuadroPerfil[0].ItemsCv[0].Descripcion);
            Assert.AreEqual("Portugues", pantalla.CuadroPerfil[0].ItemsCv[1].Descripcion);

            Assert.AreEqual(0, pantalla.DocumentacionRequerida.Count);
        }

        [TestMethod]
        public void no_deberia_ver_el_titulo_universitario_en_el_cuadro_del_perfil()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarEstudio(TestObjects.UnEstudioUniversitario());

            Puesto puesto = TestObjects.UnPerfil();

            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, puesto);

            Assert.AreEqual(0, pantalla.CuadroPerfil.Count);
            Assert.AreEqual(1, pantalla.DocumentacionRequerida.Count);
            Assert.AreEqual("Estudios", pantalla.DocumentacionRequerida[0].DescripcionRequisito);
            Assert.AreEqual(1, pantalla.DocumentacionRequerida[0].ItemsCv.Count);
            Assert.AreEqual("Lic en Adm", pantalla.DocumentacionRequerida[0].ItemsCv[0].Descripcion);
        }

        [TestMethod]
        public void no_deberia_tener_un_idioma_en_el_cuadro_perfil_cuando_el_perfil_no_lo_requiere()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarIdioma(Idioma("Ingles"));
            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, TestObjects.UnPerfil());

            Assert.AreEqual(0, pantalla.CuadroPerfil.Count);
        }


        [TestMethod]
        public void deberia_ver_el_titulo_universitario_en_el_cuadro_del_perfil()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarEstudio(TestObjects.UnEstudioUniversitario());

            Puesto puesto = TestObjects.UnPerfil();
            puesto.Requiere(new RequisitoEstudio("Un Estudio Universitario", new NivelDeEstudio(12, "Universitario")));

            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, puesto);

            Assert.AreEqual(1, pantalla.CuadroPerfil.Count);
            Assert.AreEqual("Un Estudio Universitario", pantalla.CuadroPerfil[0].DescripcionRequisito);
            Assert.AreEqual("Lic en Adm", pantalla.CuadroPerfil[0].ItemsCv[0].Descripcion);
            Assert.AreEqual(0, pantalla.DocumentacionRequerida.Count);
        }


        [TestMethod]
        public void deberia_ver_el_universitario_en_el_perfil_y_el_secundario_fuera_de_el()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarEstudio(TestObjects.UnEstudioUniversitario());
            cv.AgregarEstudio(TestObjects.UnEstudioSecundario());

            Puesto puesto = TestObjects.UnPerfil();
            puesto.Requiere(new RequisitoEstudio("Un Estudio Universitario", new NivelDeEstudio(12, "Universitario")));

            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, puesto);

            Assert.AreEqual(1, pantalla.CuadroPerfil.Count);
            Assert.AreEqual("Un Estudio Universitario", pantalla.CuadroPerfil[0].DescripcionRequisito);
            Assert.AreEqual("Lic en Adm", pantalla.CuadroPerfil[0].ItemsCv[0].Descripcion);
            Assert.AreEqual(1, pantalla.DocumentacionRequerida.Count);
            Assert.AreEqual("Estudios", pantalla.DocumentacionRequerida[0].DescripcionRequisito);
        }

        [TestMethod]
        public void deberia_ver_el_universitario_e_ingles_en_el_perfil_y_el_secundario__y_portugues_fuera_de_el()
        {
            CreadorDePantallas creador = new CreadorDePantallas();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarEstudio(TestObjects.UnEstudioUniversitario());
            cv.AgregarEstudio(TestObjects.UnEstudioSecundario());
            cv.AgregarIdioma(Idioma("Ingles"));
            cv.AgregarIdioma(Idioma("Portugues"));

            Puesto puesto = TestObjects.UnPerfil();
            var idiomas_requeridos = new List<string>() { "Ingles" };
            puesto.Requiere(new RequisitoIdioma("Idiomas", idiomas_requeridos));
            puesto.Requiere(new RequisitoEstudio("Un Estudio Universitario", new NivelDeEstudio(12, "Universitario")));

            PatallaRecepcionDocumentacion pantalla = creador.CrearPantalla(cv, puesto);

            Assert.AreEqual(2, pantalla.CuadroPerfil.Count);
            Assert.AreEqual("Idiomas", pantalla.CuadroPerfil[0].DescripcionRequisito);
            Assert.AreEqual("Ingles", pantalla.CuadroPerfil[0].ItemsCv[0].Descripcion);
            Assert.AreEqual("Un Estudio Universitario", pantalla.CuadroPerfil[1].DescripcionRequisito);
            Assert.AreEqual("Lic en Adm", pantalla.CuadroPerfil[1].ItemsCv[0].Descripcion);
            Assert.AreEqual(2, pantalla.DocumentacionRequerida.Count);
            Assert.AreEqual("Idiomas", pantalla.DocumentacionRequerida[0].DescripcionRequisito);
            Assert.AreEqual("Estudios", pantalla.DocumentacionRequerida[1].DescripcionRequisito);
        }

       

        private static CvIdiomas Idioma(string idioma)
        {
            return new CvIdiomas(1, idioma, "", idioma, 1, 1, 1, new DateTime(), "", 1);
        }

        private static RequisitoIdioma RequisitoIdiomaIngles()
        {
            return RequisitoIdiomaUnIdioma("Ingles");
        }

        private static RequisitoIdioma RequisitoIdiomaPortugues()
        {
            return RequisitoIdiomaUnIdioma("Portugues");
        }

        private static RequisitoIdioma RequisitoIdiomaUnIdioma(string idioma)
        {
            var el_idioma = new List<string>() { idioma };
            return new RequisitoIdioma("Idiomas", el_idioma);
        }

       /* [TestMethod]
        public void la_postulacion_deberia_tener_la_lista_de_doc_recibida()
        {
            IConexionBD conexion = TestObjects.ConexionMockeada();
            
            string source = @"  |DescripcionDocRequerida	                            |NombreClaseFoliable                   |  
                                |Se requiere 5 años de experiencia en ambito publico	|FoliableExperienciaLaboralPublica     |
                                |Se requiere 2 años de experiencia en ambito privado    |FoliableExperienciaLaboralPrivada     |
                                |Titulo Universitario	 	                            |FoliableEstudiosUniversitario         | 
                                |Antecedentes Penales	                                |FoliableAntecedentesPenales           |";


           var resultado_sp = TablaDeDatos.From(source);
           Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

           RepositorioDePuestos repo = new RepositorioDePuestos(conexion);

           Puesto perfil = TestObjects.UnPerfil();

           perfil.DocumentacionRequerida = repo.GetFoliablesDelPerfil(perfil.Id);

            Postulacion postulacion = TestObjects.UnaPostulacion();
            CurriculumVitae cv = TestObjects.UnCV();
            cv.AgregarExperienciaLaboral(TestObjects.UnaExpPrivada());
            cv.AgregarExperienciaLaboral(TestObjects.UnaExpPublica());
            cv.AgregarEstudio(TestObjects.UnEstudioUniversitario());

            //List<DocumentacionRecibida> doc_recibidos = new List<DocumentacionRecibida>();

            FoliableEstudiosUniversitario foliable_universitario = new FoliableEstudiosUniversitario();
            FoliableEstudiosSecundario foliable_secundario = new FoliableEstudiosSecundario();
            //perfil.DocumentacionRequerida = repo.GetFoliablesDelPerfil(perfil.Id);

            //perfil.DocumentacionRequerida.ForEach(dr => dr.documentacion(cv).ForEach(d => postulacion.AgregarDocumentacionRecibida(new DocumentacionRecibida(0,"",d,DateTime.Today))));
            postulacion.CrearDocumentacionARecibir(perfil.DocumentacionRequerida, cv);
            
            Assert.AreEqual(4, postulacion.DocumentacionARecibir.Count);
            Assert.AreEqual(1, foliable_universitario.documentacion(cv).Count);
            Assert.AreEqual(0, foliable_secundario.documentacion(cv).Count);

        }*/


    }
}
