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
        public void la_postulacion_deberia_tener_la_lista_de_doc_recibida()
        {

            Postulacion postulacion = TestObjects.UnaPostulacion();
            CurriculumVitae cv = TestObjects.UnCV();



            FoliableEstudiosUniversitario foliable_universitario = new FoliableEstudiosUniversitario();
            FoliableEstudiosSecundario foliable_secundario = new FoliableEstudiosSecundario();
            //perfil.DocumentacionRequerida = repo.GetFoliablesDelPerfil(perfil.Id);

            Assert.AreEqual(2, foliable_universitario.documentacion(cv).Count);
            Assert.AreEqual(0, foliable_secundario.documentacion(cv).Count);

        }


    }
}
