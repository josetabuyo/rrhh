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
using General.Postular;

namespace TestViaticos
{
    [TestClass]
    public class TestPostular
    {

        IConexionBD conexion = TestObjects.ConexionMockeada();

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
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
            var integrantes = new List<IntegranteComite>();
            integrantes.Add(new IntegranteComite() { Nombre = "Carlos Slim" });
            var comite = new Comite(1, 1,  integrantes);
            var puestos = new List<Puesto>();
            var un_puesto = new Puesto(1, "Abogacia", "Penal", "aaffa", "A", "Se busca un abogado...pero no el que tengo aca colgado", 5, "Abierto", "A-132", comite);
            var otro_puesto = new Puesto(2, "Contador", "Discreto", "", "", "Experiencia en balances", 10, "Cerrado", "A-123", comite);

            //repoCv.GuardarCVDatosPersonales(DatosPersonales(), TestObjects.UsuarioSACC());

            //Assert.IsNotNull(repoCv.GetCV(29753914));
            //Assert.IsNull(repoCv.GetCV(31046911));
        }

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
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

        /*
         *dada una postulacion en la primer etapa, deberia devolverme el usuario y la fecha de esa etapa
         *dada una postulacion en la segunda etapa, deberia devolverme que esta en esa segunda etapa a la fecha de hoy.
         *dada una postulacion con que entro a primera etapa el dia 10, a segunda etapa el dia 12, y a una tercera etapa el dia 14, si pido la etapa en la que se encontraba al dia 11, deberia devolverme la primera.
         */
        [TestMethod]
        public void dada_una_postulacion_en_la_primer_etapa_deberia_devolverme_el_usuario_y_la_fecha_de_la_etapa()
        {
            var una_postulacion = new Postulacion();
            var etapas = new List<EtapaPostulacion>();
            var fecha_etapa = DateTime.Now.AddMonths(-3);
            etapas.Add(new EtapaPostulacion() { 
                Fecha =  fecha_etapa,
                Etapa = new EtapaConcurso(1,"Etapa 1"),
                IdUsuario = 1
            });
            una_postulacion.Etapas = etapas;
            Assert.IsTrue(una_postulacion.Etapas.Count.Equals(1));
            Assert.IsNotNull(una_postulacion.Etapas.First().Fecha);
            Assert.IsNotNull(una_postulacion.Etapas.First().IdUsuario);
        }

        [TestMethod]
        public void dada_una_postulacion_con_mas_de_una_etapa_deberia_devolverme_la_etapa_en_una_fecha_dada()
        {
            var una_postulacion = new Postulacion();
            var etapas = new List<EtapaPostulacion>();
            var fecha_etapa1 = DateTime.Now.AddMonths(-9);
            var fecha_etapa2 = DateTime.Now.AddMonths(-6);
            var fecha_etapa3 = DateTime.Now.AddMonths(-3);
            etapas.Add(new EtapaPostulacion()
            {
                Fecha = fecha_etapa1,
                Etapa = new EtapaConcurso(1,"Etapa 1"),
                IdUsuario = 1
            });
            etapas.Add(new EtapaPostulacion()
            {
                Fecha = fecha_etapa2,
                Etapa = new EtapaConcurso(2, "Etapa 2"),
                IdUsuario = 2
            });
            etapas.Add(new EtapaPostulacion()
            {
                Fecha = fecha_etapa3,
                Etapa = new EtapaConcurso(3, "Etapa 3"),
                IdUsuario = 3
            });
            una_postulacion.Etapas = etapas;
            Assert.IsTrue(una_postulacion.Etapas.Count.Equals(3));
            Assert.IsTrue(una_postulacion.EtapaEn(DateTime.Now.AddMonths(-4)).Etapa.Descripcion.Equals("Etapa 2"));
        }

        public RepositorioDeCurriculum RepoCV()
        {
            return new RepositorioDeCurriculum(conexion);
        }

        public CvDatosPersonales DatosPersonales()
        {
            return new CvDatosPersonales(29753914, "Julian", "Dominguez", 1, 1, "20-29753456-5",
                                         "Argentina", 1, new DateTime(1980, 01, 25).ToShortDateString(), 1, UnDomicilio(), UnDomicilio(),"Tiene legajo", new DatosDeContacto());
        }

        public CvDomicilio UnDomicilio()
        {
            return new CvDomicilio(1,"Habana",1234,"1","B",1,1427,6);
        }

        public CvEstudios UnEstudio()
        {
            return new CvEstudios("Lic. en Administracion",1 , 1, "Universidad de Buenos Aires", "", new DateTime(2003,03,01),new DateTime(2007,12,20),"CABA",9);
        }

        public CvEventoAcademico UnEventoAcademico()
        {
            return new CvEventoAcademico(1, "Conferencia de Economia",1,1,new DateTime(2011,12,12),new DateTime(2011,12,13),"2 dias",1,"CABA",9);
        }

        public CvExperienciaLaboral UnaExperienciaLaboral()
        {
            return new CvExperienciaLaboral(1,"Administrativo", "Renuncia", "Banco Macro", 1, "Empresa Financiera","No se",
                                     new DateTime(2007, 09, 01), new DateTime(2010, 09, 01), "CABA", 9, "bla", 1);
        }

        public CvIdiomas UnIdioma()
        {
            return new CvIdiomas(1,"First Certificate","Cultural Inglesa","Ingles",3,3,3,new DateTime(2013,12,20),"CABA",9);
        }

        public CvInstitucionesAcademicas UnaInstitucionAcademica()
        {
            return new CvInstitucionesAcademicas(1,"UBA","Universitario","Profesor","1234","Categoria",new DateTime(2013,12,20),new DateTime(2013,12,20), new DateTime(2013,10,12),new DateTime(2014,12,20),"Capital federal",1);
        }

        public CvMatricula UnaMatricula()
        {
            return new CvMatricula(1,"1234","Ministerio de Educacion","No se",new DateTime(2007,12,20));
        }

        public CvDocencia UnaDocencia()
        {
            return new CvDocencia(1,"Ingles", 1, "No se", "No se", "Nombrado", "No se", "12 a 18",
                                  new DateTime(2008, 01, 01), new DateTime(2010, 12, 20), "Colegio Coppelo", "CABA",
                                  1);

        }

        public CvCompetenciasInformaticas UnaCompetenciaInformatica()
        {
            return new CvCompetenciasInformaticas(1, "Admnistrador de Base de Datos","UTN", 1 ,1,1,"CABA",9,new DateTime(2012,12,01), "");
        }

        public CvCertificadoDeCapacitacion UnCertificadoDeCapacitacion()
        {
            return new CvCertificadoDeCapacitacion(1,"No se", "UBA", "Plomero", "5 años", new DateTime(2012, 10, 01), new DateTime(2012, 12, 01),"CABA",9);
        }

        public CvPublicaciones UnaPublicacion()
        {
            return new CvPublicaciones(1,"Como manejar bases", "Editarial", "5", 1, 1, new DateTime(2012, 12, 01));
        }

    }
}
