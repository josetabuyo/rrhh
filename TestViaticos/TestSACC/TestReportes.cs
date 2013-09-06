using System.Linq;
using System;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NMock2;


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
    }
}

