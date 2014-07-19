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
        public void deberia_traer_puestos()
        {
            var puestos = new List<Puesto>();
            var un_puesto = new Puesto(1, "Abogacia", "Penal","aaffa","A", "Se busca un abogado...pero no el que tengo aca colgado", 5, "Abierto");
            var otro_puesto = new Puesto(2, "Contador", "Discreto","","", "Experiencia en balances", 10, "Cerrado");

            //repoCv.GuardarCVDatosPersonales(DatosPersonales(), TestObjects.UsuarioSACC());

            //Assert.IsNotNull(repoCv.GetCV(29753914));
            //Assert.IsNull(repoCv.GetCV(31046911));
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
            return new CvDatosPersonales(29753914, "Julian", "Dominguez", 1, 1, "20-29753456-5",
                                         "Argentina", 1, new DateTime(1980, 01, 25).ToShortDateString(), 1, UnDomicilio(), UnDomicilio(),"Tiene legajo");
        }

        public CvDomicilio UnDomicilio()
        {
            return new CvDomicilio(1,"Habana",1234,"1","B",1,1427,6);
        }

        public CvEstudios UnEstudio()
        {
            return new CvEstudios("Lic. en Administracion",1 , "Universidad de Buenos Aires", "", new DateTime(2003,03,01),new DateTime(2007,12,20),"CABA","Argentina");
        }

        public CvEventoAcademico UnEventoAcademico()
        {
            return new CvEventoAcademico(1, "Conferencia de Economia","Conferencia","Oyente",new DateTime(2011,12,12),new DateTime(2011,12,13),"2 dias","UBA","CABA","Argentina");
        }

        public CvExperienciaLaboral UnaExperienciaLaboral()
        {
            return new CvExperienciaLaboral(1,"Administrativo", "Renuncia", "Banco Macro", false, "Empresa Financiera","No se",
                                     new DateTime(2007, 09, 01), new DateTime(2010, 09, 01), "CABA", "Argentina");
        }

        public CvIdiomas UnIdioma()
        {
            return new CvIdiomas(1,"First Certificate","Cultural Inglesa","Ingles","Avanzado","Intermedio","Basico",new DateTime(2013,12,20),"CABA","Argentina");
        }

        public CvInstitucionesAcademicas UnaInstitucionAcademica()
        {
            return new CvInstitucionesAcademicas(1,"UBA","Universitario","Profesor",1234,"Categoria",new DateTime(2013,12,20),new DateTime(2013,12,20), new DateTime(2013,10,12),new DateTime(2014,12,20),"CABA","Argentina");
        }

        public CvMatricula UnaMatricula()
        {
            return new CvMatricula(1,"1234","Ministerio de Educacion","No se",new DateTime(2007,12,20));
        }

        public CvDocencia UnaDocencia()
        {
            return new CvDocencia(1,"Ingles", new NivelDeDocencia(1, "Secundario"), "No se", "No se", "Nombrado", "No se", "12 a 18",
                                  new DateTime(2008, 01, 01), new DateTime(2010, 12, 20), "Colegio Coppelo", "CABA",
                                  "Argetina");

        }

        public CvCompetenciasInformaticas UnaCompetenciaInformatica()
        {
            return new CvCompetenciasInformaticas(1, "Admnistrador de Base de Datos","UTN","Base de Datos","SQL","Avanzado","CABA","Argentina",new DateTime(2012,12,01), "");
        }

        public CvCertificadoDeCapacitacion UnCertificadoDeCapacitacion()
        {
            return new CvCertificadoDeCapacitacion(1,"No se", "UBA", "Plomero", "5 años", new DateTime(2012, 10, 01), new DateTime(2012, 12, 01),"CABA","Argentina");
        }

        public CvPublicaciones UnaPublicacion()
        {
            return new CvPublicaciones(1,"Como manejar bases", "Editarial", "5", true, new DateTime(2012, 12, 01));
        }

    }
}
