using System.Linq;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using General.Calendario;


using NMock2;

namespace TestViaticos
{

    [TestClass]
    public class TestAlumnos
    {

        private IConexionBD conexionMock;
        [TestInitialize]
        public void SetUp()
        {
            conexionMock = TestObjects.ConexionMockeada();
        }     

        //ESTE TEST CUANDO PERSISTAMOS VA A FALLAR XQ YA TIENE ALUMNOS CARGADOS
        [TestMethod]
        public void deberia_poder_agregar_alumnos()
        {
            //SE HACE EN CURSOS

            //IConexionBD conexion = TestObjects.ConexionMockeada();

            //RepositorioDeAlumnos repo = new RepositorioDeAlumnos(conexion);

            //repo.GuardarAlumno(TestObjects.UnAlumnoFer(), new Usuario());

            //Assert.AreEqual(4, repo.GetAlumnos().Count());
        }

        [TestMethod]
        public void deberia_poder_quitar_alumnos()
        {
           //SE HACE EN CURSOS
            
            //IConexionBD conexion = TestObjects.ConexionMockeada();

            //RepositorioDeAlumnos repo = new RepositorioDeAlumnos(conexion);

            //repo.QuitarAlumno(new Alumno(), new Usuario());

            //Assert.AreEqual(2, repo.GetAlumnos().Count());
        }

        [TestMethod]
        public void cuando_un_alumno_pertenece_a_3_areas_deberia_pedirle_las_areas_y_devolverme_3()
        {

            Modalidad modalidad = TestObjects.ModalidadFinesPuro();
            Expect.AtLeastOnce.On(TestObjects.RepoModalidadesMockeado()).Method("GetModalidadById").WithAnyArguments().Will(Return.Value(modalidad));
           
            
            
            string source = @"      |Id     |Documento   |Apellido     |Nombre     |Telefono      |Mail     |Direccion  |IdModalidad  |ModalidadDescripcion |idInstancia    |DescripcionInstancia   |IdArea |NombreArea                         |IdBaja
                                    |01     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |1              |Primer Parcial         |0      |Ministerio de Desarrollo Social    |0
                                    |02     |31041236    |Caino        |Fernando   |A222          |fer@ar   |Av         |1            |fines                |1              |Primer Parcial         |1      |Unidad Ministrio                   |0
                                    |05     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |1              |Primer Parcial         |1      |Unidad Ministrio                   |0
                                    |03     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |1              |Primer Parcial         |621    |Secretaría de Deportes             |0";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeAlumnos repo = new RepositorioDeAlumnos(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoModalidadesMockeado());
            Alumno belen = new Alumno();
            List<Alumno> lista_de_alumnos = repo.GetAlumnos();
            belen = lista_de_alumnos.Find(a => a.Documento.Equals(31507315));

            Assert.AreEqual(3, belen.Areas.Count);
        }

        [TestMethod]
        public void deberia_poder_obtener_todas_las_modalidades()
        {
            string source = @"      |IdModalidad  |ModalidadDescripcion   |idEstructura  |DescripcionEstructura |idInstancia |DescripcionInstancia
                                    |1	          |Fines Puro	          |1	         |Fines	                |6	         |Calificación Final
                                    |2	          |Fines CENS	          |2	         |Cens	                |1	         |1° Evaluación";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeModalidades repo = new RepositorioDeModalidades(conexion);     
            List<Modalidad> lista_de_modalidades = repo.GetModalidades();

            Assert.AreEqual(2, lista_de_modalidades.Count());
            Assert.AreEqual(1, lista_de_modalidades.First().Id);
            Assert.AreEqual(2, lista_de_modalidades.Last().Id);
            Assert.AreEqual("Fines Puro", lista_de_modalidades.First().Descripcion);
            Assert.AreEqual("Fines CENS", lista_de_modalidades.Last().Descripcion);

        }

        [TestMethod]
        public void deberia_poder_obtener_todas_las_instancias_de_evaluacion_de_una_modalidad()
        {
            string source = @"      |IdModalidad  |ModalidadDescripcion   |idEstructura  |DescripcionEstructura |idInstancia |DescripcionInstancia
                                    |1	          |Fines Puro	          |1	         |Fines	                |6	         |Calificación Final
                                    |2	          |Fines CENS	          |2	         |Cens	                |1	         |1° Evaluación
                                    |2	          |Fines CENS	          |2	         |Cens	                |2	         |2° Evaluación
                                    |2	          |Fines CENS	          |2	         |Cens	                |3	         |Paepa 1
                                    |2	          |Fines CENS	          |2	         |Cens	                |4	         |Paepa 2
                                    |2	          |Fines CENS	          |2	         |Cens	                |5	         |Mesa
                                    |2	          |Fines CENS	          |2	         |Cens	                |6	         |Calificación Final";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeModalidades repo = new RepositorioDeModalidades(conexion);
            Modalidad modalidad_cens = repo.GetModalidadById(2);

            Assert.AreEqual(2, modalidad_cens.Id);
            Assert.AreEqual(6, modalidad_cens.InstanciasDeEvaluacion.Count());
            Assert.AreEqual("1° Evaluación", modalidad_cens.InstanciasDeEvaluacion.Find(i => i.Id == 1).Descripcion);

            Modalidad modalidad_puro = repo.GetModalidadById(1);

            Assert.AreEqual(1, modalidad_puro.Id);
            Assert.AreEqual(1, modalidad_puro.InstanciasDeEvaluacion.Count());
            Assert.AreEqual("Calificación Final", modalidad_puro.InstanciasDeEvaluacion.First().Descripcion);
        }


        [TestMethod]
        public void deberia_poder_obtener_todas_las_modalidades_que_existen()
        {
            string source = @"      |IdModalidad  |ModalidadDescripcion   |idEstructura  |DescripcionEstructura |idInstancia |DescripcionInstancia
                                    |1	          |Fines Puro	          |1	         |Fines	                |6	         |Calificación Final
                                    |2	          |Fines CENS	          |2	         |Cens	                |1	         |1° Evaluación
                                    |2	          |Fines CENS	          |2	         |Cens	                |2	         |2° Evaluación
                                    |2	          |Fines CENS	          |2	         |Cens	                |3	         |Paepa 1
                                    |2	          |Fines CENS	          |2	         |Cens	                |4	         |Paepa 2
                                    |2	          |Fines CENS	          |2	         |Cens	                |5	         |Mesa
                                    |2	          |Fines CENS	          |2	         |Cens	                |6	         |Calificación Final";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeModalidades repo = new RepositorioDeModalidades(conexion);
            List<Modalidad> modalidades = repo.GetModalidades();

            Assert.AreEqual(2, modalidades.Count);
            Assert.IsTrue(modalidades.Exists(m => m.Id == 1));
            Assert.IsTrue(modalidades.Exists(m => m.Id == 2));
        }

        [TestMethod]
        public void deberia_poder_obtener_todas_las_modalidades_que_existen_2()
        {
            string source = @"      |IdModalidad  |ModalidadDescripcion   |idEstructura  |DescripcionEstructura |idInstancia |DescripcionInstancia
                                    |1	          |Fines Puro	          |1	         |Fines	                |6	         |Calificación Final
                                    |1	          |Fines Puro	          |2	         |Cens	                |1	         |1° Evaluación
                                    |2	          |Fines CENS	          |2	         |Cens	                |2	         |2° Evaluación
                                    |1	          |Fines Puro	          |2	         |Cens	                |3	         |Paepa 1
                                    |2	          |Fines CENS	          |2	         |Cens	                |4	         |Paepa 2
                                    |2	          |Fines CENS	          |2	         |Cens	                |5	         |Mesa
                                    |1	          |Fines Puro	          |2	         |Cens	                |6	         |Calificación Final";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeModalidades repo = new RepositorioDeModalidades(conexion);
            List<Modalidad> modalidades = repo.GetModalidades();

            Assert.AreEqual(2, modalidades.Count);
            Assert.IsTrue(modalidades.Exists(m => m.Id == 1));
            Assert.IsTrue(modalidades.Exists(m => m.Id == 2));
        }
    }
}
