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

            List<Alumno> alumnos_de_la_modalidad = reportes.ObtenerAlumnosConModalidad(TestObjects.ModalidadCens(), TestObjects.RepoCursosMockeado());

            Assert.AreEqual(4, alumnos_de_la_modalidad.Count);            
        }

        [TestMethod]
        public void deberia_poder_saber_cuantos_alumnos_estan_inscriptos_en_fines_puro()
        {
            Reportes reportes = new Reportes();
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(TestObjects.CursosSACC()));

            List<Alumno> alumnos_de_la_modalidad = reportes.ObtenerAlumnosConModalidad(TestObjects.ModalidadFinesPuro(), TestObjects.RepoCursosMockeado());

            Assert.AreEqual(2, alumnos_de_la_modalidad.Count);
        }

        //[TestMethod]
        //public void deberia_poder_saber_cuantos_alumnos_estan_inscriptos_en_fines_cens_en_el_primer_ciclo()
        //{
        //    Reportes reportes = new Reportes();
        //    Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(TestObjects.CursosSACC()));

        //    List<Alumno> alumnos_de_la_modalidad = reportes.ObtenerAlumnosConModalidad(TestObjects.ModalidadFinesPuro(), TestObjects.PrimerCiclo() ,TestObjects.RepoCursosMockeado());


        //    Assert.AreEqual(2, alumnos_de_la_modalidad.Count);
        //}

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

        [TestMethod]
        public void deberia_poder_saber_cuantas_materias_le_falta_a_un_alumno_para_terminar_CENS()
        {
           // Se cargan las Asistencias;
           List<Asistencia> asistencias_fer = new List<Asistencia>();
            asistencias_fer.AddRange(TestObjects.AsistenciaPerfecta(TestObjects.cursoHistoria1Cens2012_1Cuat().FechaInicio, TestObjects.cursoHistoria1Cens2012_1Cuat().FechaFin, TestObjects.cursoHistoria1Cens2012_1Cuat().Id, TestObjects.AlumnoFer().Id));
            asistencias_fer.AddRange(TestObjects.AsistenciaPerfecta(TestObjects.cursoMatematica1Cens2012_1Cuat().FechaInicio, TestObjects.cursoMatematica1Cens2012_1Cuat().FechaFin, TestObjects.cursoMatematica1Cens2012_1Cuat().Id, TestObjects.AlumnoFer().Id));
            asistencias_fer.AddRange(TestObjects.AsistenciaPerfecta(TestObjects.cursoMatematica3Cens2013_1Cuat().FechaInicio, TestObjects.cursoMatematica3Cens2013_1Cuat().FechaFin, TestObjects.cursoMatematica3Cens2013_1Cuat().Id, TestObjects.AlumnoFer().Id));
            asistencias_fer.AddRange(TestObjects.AsistenciaPerfecta(TestObjects.cursoMatematica2Cens2012_2Cuat().FechaInicio, TestObjects.cursoMatematica2Cens2012_2Cuat().FechaFin, TestObjects.cursoMatematica2Cens2012_2Cuat().Id, TestObjects.AlumnoFer().Id));


            Reportes reportes = new Reportes();

            List<Materia> materias_que_el_alumno_no_curso = reportes.ObtenerMateriasNoCursadasDe(TestObjects.AlumnoFer(), TestObjects.materiasReportes(), TestObjects.cursosReportes(), asistencias_fer);
            Assert.AreEqual(2, materias_que_el_alumno_no_curso.Count);
        }


        //[TestMethod]
        //public void deberia_poder_saber_cuantas_personas_no_cursaron_historia_de_primer_ciclo()
        //{
        //    Reportes reportes = new Reportes();

        //    List<Materia> alumnos_que_aun_no_cursaron_la_materia = reportes.ObtenerAlumnosQueNoCursaron(TestObjects.Matematica3CENS());
        //    Assert.AreEqual(2, materias_que_el_alumno_no_curso.Count);
        //}

    }
}

