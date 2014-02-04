using System.Linq;
using System;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NMock2;
using TestViaticos;


namespace TestViaticos
{

    [TestClass]
    public class TestReportes
    {

        private IConexionBD conexionMock;
        [TestInitialize]
        public void SetUp()
        {
            conexionMock = TestObjects.ConexionMockeada();
        }   
            

        [TestMethod]
        public void deberia_poder_saber_cuantos_alumnos_estan_inscriptos_en_cens()
        {
            Reportes reportes = new Reportes();
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(TestObjects.CursosSACC()));

            List<Alumno> alumnos_de_la_modalidad = reportes.ObtenerAlumnosQueEstanCursandoConModalidad(TestObjects.ModalidadCens(), TestObjects.RepoCursosMockeado());

            Assert.AreEqual(3, alumnos_de_la_modalidad.Count);
            Assert.IsTrue(alumnos_de_la_modalidad.Exists(a => a.Id == TestObjects.AlumnoFer().Id));
            Assert.IsTrue(alumnos_de_la_modalidad.Exists(a => a.Id == TestObjects.AlumnoJor().Id));
            Assert.IsTrue(alumnos_de_la_modalidad.Exists(a => a.Id == TestObjects.AlumnoJavi().Id));
        }

        [TestMethod]
        public void deberia_poder_saber_cuantos_alumnos_estan_inscriptos_en_fines_puro()
        {
            Reportes reportes = new Reportes();
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(TestObjects.CursosSACC()));

            List<Alumno> alumnos_de_la_modalidad = reportes.ObtenerAlumnosQueEstanCursandoConModalidad(TestObjects.ModalidadFinesPuro(), TestObjects.RepoCursosMockeado());

            Assert.AreEqual(2, alumnos_de_la_modalidad.Count);
            Assert.IsTrue(alumnos_de_la_modalidad.Exists(a => a.Id == TestObjects.AlumnoGer().Id));
            Assert.IsTrue(alumnos_de_la_modalidad.Exists(a => a.Id == TestObjects.AlumnoZambri().Id));
        }

        [TestMethod]
        public void deberia_poder_saber_cuantos_alumnos_estan_inscriptos_en_fines_cens_en_el_primer_ciclo()
        {
            Reportes reportes = new Reportes();
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(TestObjects.CursosSACC()));

            List<Alumno> alumnos_de_la_modalidad = reportes.ObtenerAlumnosQueEstanCursandoConModalidadYCiclo(TestObjects.ModalidadCens(), TestObjects.TercerCiclo(), TestObjects.RepoCursosMockeado());

            Assert.AreEqual(1, alumnos_de_la_modalidad.Count);
            Assert.IsTrue(alumnos_de_la_modalidad.Exists(a => a.Id == TestObjects.AlumnoJavi().Id));
        }


        [TestMethod]
        public void deberia_poder_saber_cuantos_alumnos_pertenecen_al_organismo_MDS()
        {
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            
            Reportes reportes = new Reportes();
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));

            List<Alumno> alumnos_del_mds = reportes.ObtenerAlumnosDelOrganismo(TestObjects.OrganismoMDS(), TestObjects.RepoAlumnosMockeado());

            Assert.AreEqual(2, alumnos_del_mds.Count);
        }

        //[TestMethod]
        //public void deberia_poder_saber_cuantas_materias_le_falta_a_un_alumno_para_terminar_CENS()
        //{
        //   // Se cargan las Asistencias;
        //   List<Asistencia> asistencias_fer = new List<Asistencia>();
        //   //asistencias_fer.AddRange(TestObjects.CargaAsistenciaPerfecta(TestObjects.cursoHistoria1Cens2012_1Cuat(), TestObjects.AlumnoFer()));
        //   //asistencias_fer.AddRange(TestObjects.CargaAsistenciaPerfecta(TestObjects.cursoMatematica1Cens2012_1Cuat(), TestObjects.AlumnoFer()));
        //   //asistencias_fer.AddRange(TestObjects.CargaAsistenciaPerfecta(TestObjects.cursoMatematica3Cens2013_1Cuat(), TestObjects.AlumnoFer()));
        //   //asistencias_fer.AddRange(TestObjects.CargaAsistenciaPerfecta(TestObjects.cursoMatematica2Cens2012_2Cuat(), TestObjects.AlumnoFer()));
           
        //    Reportes reportes = new Reportes();

        //    List<Materia> materias_que_el_alumno_no_curso = reportes.ObtenerMateriasNoCursadasDe(TestObjects.AlumnoFer(), TestObjects.materiasReportes(), TestObjects.cursosReportes(), asistencias_fer);
        //    Assert.AreEqual(2, materias_que_el_alumno_no_curso.Count);
        //}

        //[TestMethod]
        //public void deberia_poder_saber_cuantas_materias_le_falta_a_un_alumno_para_terminar_CENS_con_una_abandonada()
        //{
        //    // Se cargan las Asistencias;
        //    List<Asistencia> asistencias_fer = new List<Asistencia>();
        //    //asistencias_fer.AddRange(TestObjects.CargaAsistenciaPerfecta(TestObjects.cursoHistoria1Cens2012_1Cuat(), TestObjects.AlumnoFer()));
        //    //asistencias_fer.AddRange(TestObjects.CargaAsistenciaPerfecta(TestObjects.cursoMatematica1Cens2012_1Cuat(), TestObjects.AlumnoFer()));
        //    //asistencias_fer.AddRange(TestObjects.CargaAsistenciaPerfecta(TestObjects.cursoMatematica2Cens2012_2Cuat(), TestObjects.AlumnoFer()));
        //    ////asistencias_fer.AddRange(TestObjects.CargaAsistenciaImperfecta(TestObjects.cursoMatematica3Cens2013_1Cuat(), TestObjects.AlumnoFer()));

        //    Reportes reportes = new Reportes();

        //    List<Materia> materias_que_el_alumno_no_curso = reportes.ObtenerMateriasNoCursadasDe(TestObjects.AlumnoFer(), TestObjects.materiasReportes(), TestObjects.cursosReportes(), asistencias_fer);
        //    Assert.AreEqual(3, materias_que_el_alumno_no_curso.Count);
        //}

        //[TestMethod]
        //public void deberia_poder_saber_cuantos_alumnos_no_cursaron_una_materia()
        //{
        //    List<Asistencia> asistencias_de_todos = new List<Asistencia>();
        //    // Se cargan las Asistencias;
        //    //asistencias_de_todos.AddRange(TestObjects.CargaAsistenciaPerfecta(TestObjects.cursoMatematica3Cens2013_1Cuat(), TestObjects.AlumnoFer()));
        //    //asistencias_de_todos.AddRange(TestObjects.CargaAsistenciaImperfecta(TestObjects.cursoMatematica3Cens2012_2Cuat(), TestObjects.AlumnoJor()));
                       
        //    Reportes reportes = new Reportes();

        //    List<Alumno> alumnos_que_no_cursaron_la_materia = reportes.ObtenerAlumnosQueNoCursaron(TestObjects.Matematica3CENS(), TestObjects.UnCursoConAlumnos().Alumnos(), TestObjects.cursosReportes(), asistencias_de_todos);

        //    Assert.AreEqual(2, alumnos_que_no_cursaron_la_materia.Count);
        //    Assert.IsTrue(!alumnos_que_no_cursaron_la_materia.Exists(a => a.Id == TestObjects.AlumnoFer().Id)); //Fer la Aprobó
        //    Assert.IsTrue(alumnos_que_no_cursaron_la_materia.Exists(a => a.Id == TestObjects.AlumnoJor().Id)); // Jorge se quedó Libre
        //    Assert.IsTrue(alumnos_que_no_cursaron_la_materia.Exists(a => a.Id == TestObjects.AlumnoJavi().Id)); // Javi nunca la cursó
        //}

        
    }
}

