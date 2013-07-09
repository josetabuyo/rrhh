using System.Linq;
using System;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using General.Calendario;
using NMock2;

namespace TestViaticos
{
   
    [TestClass]
    public class TestRepositorioEvaluaciones
    {
        private IConexionBD conexionMock;

        [TestInitialize]
        public void SetUp()
        {
           conexionMock = TestObjects.ConexionMockeada();
        }

        [TestMethod]
        public void deberia_poder_obtener_todas_las_evaluaciones()
        {
            Alumno alumno = TestObjects.AlumnoMinisterio();
            Curso curso = TestObjects.UnCursoConAlumnos();
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));
        


            string source = @"  |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                                |287872   |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |287872   |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(),TestObjects.RepoAlumnosMockeado());

            Assert.AreEqual(5, repo.GetEvaluaciones().Count);
        }

        [TestMethod]
        public void deberia_poder_obtener_todas_las_evaluaciones_que_un_alumno_se_saco_en_un_curso()
        {
            Alumno alumno = TestObjects.AlumnoMinisterio();
            Curso curso = TestObjects.UnCursoConAlumnos();
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));



            string source = @"  |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                                |287872   |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |287872   |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            Assert.AreEqual(5, repo.GetEvaluacionesPorCursoYAlumno(curso, alumno).Count);
        }


        [TestMethod]
        public void deberia_poder_obtener_la_evaluación_que_un_alumno_se_saco_en_un_curso_para_una_instancia_de_evaluacion()
        {
            Alumno alumno = TestObjects.AlumnoMinisterio();
            Curso curso = TestObjects.UnCursoConAlumnos();
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));



            string source = @"  |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                                |9        |14      |1                     |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |9        |14      |2                     |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |3                     |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |4                     |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |5                     |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            Assert.AreEqual("A1", repo.GetEvaluacionPorCursoAlumnoEInstancia(curso, alumno, TestObjects.PrimerParcial()).Calificacion.Descripcion);
        }

        [TestMethod]
        public void dado_un_curso_deberia_poder_ver_cuantas_instancias_de_evaluacion_tiene()
        {
            Curso curso = TestObjects.UnCursoConAlumnos();
            Assert.AreEqual(2, curso.GetInstanciasDeEvaluacion().Count);
        }


        [TestMethod]
        public void deberia_poder_obtener_todas_las_evaluaciones_de_un_curso()
        {
            Alumno alumno = TestObjects.AlumnoMinisterio();
            Curso curso = TestObjects.UnCursoConAlumnos();
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));



            string source = @"  |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                                |287872   |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |287872   |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            Assert.AreEqual(5, repo.GetEvaluacionesPorCurso(curso).Count);
        }


        [TestMethod]
        public void deberia_poder_obtener_todas_las_evaluaciones_del_primer_parcial_de_un_curso()
        {
            Alumno alumno = TestObjects.AlumnoMinisterio();
            Curso curso = TestObjects.UnCursoConAlumnos();
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));



            string source = @"  |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                                |1        |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |2        |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |3        |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |4        |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |5        |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            Assert.AreEqual(1, repo.GetEvaluacionesPorCursoEInstancia(curso, TestObjects.PrimerParcial()).Count);
        }

        //[TestMethod]
        //public void dado_un_curso_deberia_poder_agregar_una_calificación_para_un_alumno_en_una_determinada_instancia()
        //{
        //    Curso curso = TestObjects.UnCursoConAlumnos();
        //    Alumno alumno = TestObjects.AlumnoMinisterio();
        //    InstanciaDeEvaluacion primer_parcial = TestObjects.PrimerParcial();
        //    Calificacion calificacion = TestObjects.Calificacion10();

        //    Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
        //    Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));

        //    RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

        //    repo.GuardarEvaluacion(primer_parcial, alumno, curso, calificacion, DateTime.Today);
        //}

        [TestMethod]
        public void la_nota_de_evaluacion_siempre_debe_ser_un_numero_comprendido_entre_1_y_10()
        {
            try
            {
                Evaluacion evaluacion_del_alumno = new Evaluacion(TestObjects.PrimerParcial(), TestObjects.UnAlumnoDelCurso(), TestObjects.UnCursoConAlumnos(), new CalificacionNumerica(11), DateTime.Today);
                Assert.Fail("Deberia fallar por que no se puede crear una nota mayor a 10 o menor a 1");
            }
            catch (ExcepcionDeValidacion excepcion)
            {
                Assert.AreEqual(excepcion.Message, "La nota no puede ser menor que 1 o mayor que 10");
            }
        }

        [TestMethod]
        public void dado_un_alumno_un_curso_y_una_nota_deberia_poder_cambiarla()
        {

            //Evaluacion primera_evaluacion = new Evaluacion(TestObjects.PrimerParcial(), TestObjects.UnAlumnoDelCurso(), TestObjects.UnCursoConAlumnos(), new CalificacionNumerica(10), DateTime.Today);
            //Curso un_curso_cens = TestObjects.UnCursoConAlumnos();
            //un_curso_cens.AgregarAlumnos(TestObjects.AlumnosNuevos());
            //un_curso_cens.AgregarEvaluacion(primera_evaluacion);

            //Assert.AreEqual(10, un_curso_cens.EvaluacionDeAlumnoEnUnaInstancia(TestObjects.UnAlumnoDelCurso(), TestObjects.PrimerParcial()).Calificacion.Nota);

            //primera_evaluacion.CambiarCalificacionPor(5);
            //Assert.AreEqual(5, un_curso_cens.EvaluacionDeAlumnoEnUnaInstancia(TestObjects.UnAlumnoDelCurso(), TestObjects.PrimerParcial()).Calificacion.Nota);
        }


        [TestMethod]
        public void no_deberia_poder_evaluar_un_alumno_que_no_pertenece_al_curso()
        {
            //Curso un_curso_cens = TestObjects.UnCursoConAlumnos();

            //un_curso_cens.AgregarAlumnos(TestObjects.AlumnosNuevos());

            //Assert.AreEqual(8, un_curso_cens.Alumnos().Count());
        }

    }
}
