using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;
using NMock2;
using System.Web.UI.WebControls;
using WebRhUITestNew;

namespace TestViaticos
{
    [TestClass]
    public class TestPostular
    {

        IConexionBD conexion = TestObjects.ConexionMockeada();

        [TestMethod]
        public void deberia_poder_guardar_un_cv()
        {
            var cv = new CurriculumVitae(DatosPersonales());
            var repoCv = this.RepoCV();

            repoCv.GuardarCVDatosPersonales(DatosPersonales(), TestObjects.UsuarioSACC());
            
            Assert.IsNotNull(repoCv.GetCV(29753914));
            Assert.IsNull(repoCv.GetCV(31046911));
        }

        [TestMethod]
        public void deberia_poder_ver_los_diferentes_elementos_de_mi_cv()
        {
            var cv = new CurriculumVitae(DatosPersonales());
            var repoCv = this.RepoCV();
            cv.AgregarEstudio(UnEstudio());
            cv.AgregarPublicacion(UnaPublicacion());
            cv.AgregarCertificadoDeCapacitacion(UnCertificadoDeCapacitacion());
            cv.AgregarCompetenciaInformatica(UnaCompetenciaInformatica());
            cv.AgregarDocencia(UnaDocencia());
            cv.AgregarEventoAcademico(UnEventoAcademico());
            cv.AgregarExperienciaLaboral(UnaExperienciaLaboral());
            cv.AgregarIdioma(UnIdioma());
            cv.AgregarInstitucionAcademica(UnaInstitucionAcademica());
            cv.AgregarMatricula(UnaMatricula());

            repoCv.GuardarCVDatosPersonales(DatosPersonales(), TestObjects.UsuarioSACC());

            Assert.AreEqual(1,repoCv.GetCV(29753914).CvEstudios.Count);
            Assert.AreEqual(1, repoCv.GetCV(29753914).CvDocencias.Count);
        }




        public RepositorioDeCurriculum RepoCV()
        {
            return new RepositorioDeCurriculum(conexion);
        }

        public CvDatosPersonales DatosPersonales()
        {
            return new CvDatosPersonales(29753914, "Julian", "Dominguez", "Masculino", "Soltero", "20-29753456-5",
                                         "Argentina", "Argentino", new DateTime(1980, 01, 25), "dni", UnDomicilio());
        }

        public CvDomicilio UnDomicilio()
        {
            return new CvDomicilio("Habana",1234,1,"B","CABA",1427,"Buenos Aires");
        }

        public CvEstudios UnEstudio()
        {
            return new CvEstudios("Lic. en Administracion", "Universidad de Buenos Aires", "", new DateTime(2003,03,01),new DateTime(2007,12,20),"CABA","Argentina");
        }

        public CvEventoAcademico UnEventoAcademico()
        {
            return new CvEventoAcademico("Conferencia de Economia","Conferencia","Oyente","UBA",new DateTime(2011,12,12),new DateTime(2011,12,13),"2 dias","CABA","Argentina");
        }

        public CvExperienciaLaboral UnaExperienciaLaboral()
        {
            return new CvExperienciaLaboral("Administrativo", "Renuncia", "Banco Macro", false, "Empresa Financiera","No se",
                                     new DateTime(2007, 09, 01), new DateTime(2010, 09, 01), "CABA", "Argentina");
        }

        public CvIdiomas UnIdioma()
        {
            return new CvIdiomas("First Certificate","Cultural Inglesa","Ingles","Avanzado","Intermedio","Basico",new DateTime(2013,12,20),new DateTime(2013,12,20),"CABA","Argentina");
        }

        public CvInstitucionesAcademicas UnaInstitucionAcademica()
        {
            return new CvInstitucionesAcademicas("UBA","Universitario","Profesor",1234,"Categoria",new DateTime(2013,12,20),new DateTime(2013,12,20), new DateTime(2013,10,12),new DateTime(2014,12,20),"CABA","Argentina");
        }

        public CvMatricula UnaMatricula()
        {
            return new CvMatricula("1234","Ministerio de Educacion","No se",new DateTime(2007,12,20));
        }

        public CvDocencia UnaDocencia()
        {
            return new CvDocencia("Ingles", "Secundario", "No se", "No se", "Nombrado", "No se", "12 a 18",
                                  new DateTime(2008, 01, 01), new DateTime(2010, 12, 20), "Colegio Coppelo", "CABA",
                                  "Argetina");

        }

        public CvCompetenciasInformaticas UnaCompetenciaInformatica()
        {
            return new CvCompetenciasInformaticas("Admnistrador de Base de Datos","UTN","Base de Datos","SQL","Avanzado","CABA","Argentina",new DateTime(2012,12,01));
        }

        public CvCertificadoDeCapacitacion UnCertificadoDeCapacitacion()
        {
            return new CvCertificadoDeCapacitacion("No se", "UBA", "Plomero", "5 años", new DateTime(2012, 10, 01), new DateTime(2012, 12, 01),"CABA","Argentina");
        }

        public CvPublicaciones UnaPublicacion()
        {
            return new CvPublicaciones("Como manejar bases", "Editarial", "5", true, new DateTime(2012, 12, 01));
        }

    }
}
