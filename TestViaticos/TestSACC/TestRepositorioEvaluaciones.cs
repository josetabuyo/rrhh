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
            Alumno alumno = TestObjects.AlumnoDelCurso();
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
            //Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            //Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));



            string source = @" |id   |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                               |1    |287872   |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |2    |287872   |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |3    |284165   |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |4    |284165   |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |5    |284165   |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(),TestObjects.RepoAlumnosMockeado());

            Assert.AreEqual(5, repo.GetEvaluaciones().Count);
        }

        [TestMethod]
        public void deberia_poder_obtener_todas_las_evaluaciones_que_un_alumno_se_saco_en_un_curso()
        {
            Alumno alumno = TestObjects.AlumnoDelCurso();
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));


            string source = @" |id  |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                               |1   |281941   |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |2   |284165   |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |3   |287872   |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |4   |4        |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |5   |5        |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            Assert.AreEqual(1, repo.GetEvaluacionesPorCursoYAlumno(curso, alumno).Count);
        }


        [TestMethod]
        public void deberia_poder_obtener_la_evaluación_que_un_alumno_se_saco_en_un_curso_para_una_instancia_de_evaluacion()
        {
            Alumno alumno = TestObjects.AlumnoDelCurso();
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));


            string source = @" |id   |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                               |1    |281941   |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |2    |284165   |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |3    |287872   |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |4    |4        |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |5    |5        |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";


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
            Alumno alumno = TestObjects.AlumnoDelCurso();
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));



            string source = @" |id   |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                               |1    |287872   |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |2    |287872   |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |3    |284165   |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |4    |284165   |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |5    |284165   |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            Assert.AreEqual(5, repo.GetEvaluacionesPorCurso(curso).Count);
        }


        [TestMethod]
        public void deberia_poder_obtener_todas_las_evaluaciones_del_primer_parcial_de_un_curso()
        {
            Alumno alumno = TestObjects.AlumnoDelCurso();
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));



            string source = @" |id   |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                               |1    |1        |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |2    |2        |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |3    |3        |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |4    |4        |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                               |5    |5        |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            Assert.AreEqual(1, repo.GetEvaluacionesPorCursoEInstancia(curso, TestObjects.PrimerParcial()).Count);
        }

        [TestMethod]
        public void la_nota_de_evaluacion_siempre_debe_ser_un_numero_comprendido_entre_1_y_10()
        {
            try
            {
                Evaluacion evaluacion_del_alumno = new Evaluacion(1, TestObjects.PrimerParcial(), TestObjects.UnAlumnoDelCurso(), TestObjects.UnCursoConAlumnos(), new CalificacionNumerica(11), DateTime.Today);
                Assert.Fail("Deberia fallar por que no se puede crear una nota mayor a 10 o menor a 1");
            }
            catch (ExcepcionDeValidacion excepcion)
            {
                Assert.AreEqual(excepcion.Message, "La nota no puede ser menor que 1 o mayor que 10");
            }
        }

        //[TestMethod]
        //public void dado_un_alumno_un_curso_y_una_nota_deberia_poder_cambiarla()
        //{

        //    //Evaluacion primera_evaluacion = new Evaluacion(TestObjects.PrimerParcial(), TestObjects.UnAlumnoDelCurso(), TestObjects.UnCursoConAlumnos(), new CalificacionNumerica(10), DateTime.Today);
        //    //Curso un_curso_cens = TestObjects.UnCursoConAlumnos();
        //    //un_curso_cens.AgregarAlumnos(TestObjects.AlumnosNuevos());
        //    //un_curso_cens.AgregarEvaluacion(primera_evaluacion);

        //    //Assert.AreEqual(10, un_curso_cens.EvaluacionDeAlumnoEnUnaInstancia(TestObjects.UnAlumnoDelCurso(), TestObjects.PrimerParcial()).Calificacion.Nota);

        //    //primera_evaluacion.CambiarCalificacionPor(5);
        //    //Assert.AreEqual(5, un_curso_cens.EvaluacionDeAlumnoEnUnaInstancia(TestObjects.UnAlumnoDelCurso(), TestObjects.PrimerParcial()).Calificacion.Nota);
        //}


        //[TestMethod]
        //public void no_deberia_poder_evaluar_un_alumno_que_no_pertenece_al_curso()
        //{
        //    //Curso un_curso_cens = TestObjects.UnCursoConAlumnos();

        //    //un_curso_cens.AgregarAlumnos(TestObjects.AlumnosNuevos());

        //    //Assert.AreEqual(8, un_curso_cens.Alumnos().Count());
        //}

        [TestMethod]
        public void deberia_poder_obtener_las_evaluaciones_a_actualizar()
        {
            Alumno alumno = TestObjects.AlumnoDelCurso();
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));

            string source = @"  |id     |idInstanciaEvaluacion  |DescripcionInstanciaEvaluacion |idAlumno   |idCurso   |Calificacion    |idUsuario     |fechaEvaluacion                              
                                |1      |14                     |Primer Parcial                 |281941     |14        |A1              |6	            |2012-10-13 21:36:35.077     
                                |2      |14                     |Primer Parcial                 |284165     |14        |A2              |6	            |2012-10-13 21:36:35.077      
                                |3      |14                     |Primer Parcial                 |287872     |14        |A3              |7	            |2012-10-13 21:36:35.077  ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            List<Evaluacion> evaluaciones_antiguas = repo.GetEvaluaciones();

            //Hice una nueva lista de Evaluaciones xq si cambiaba de la lista original tb cambiaba a la lista nueva
            List<Evaluacion> evaluaciones_nuevas = TestObjects.Evaluaciones();

            evaluaciones_nuevas.First().CambiarCalificacionPor(new CalificacionNoNumerica("A8"), new DateTime(2013, 07, 25));

            var eval_cambiadas = new ComparadorDeDiferencias().EvaluacionesParaActualizar(evaluaciones_antiguas, evaluaciones_nuevas);

            //El Except no funcionaba xq comparaba la igualdad de cada uno de los campos dentro del objeto, y por ejemplo la fecha era la misma pero no la consideraba igual
            //List<Evaluacion> diferencias = evaluaciones_antiguas.Except(evaluaciones_nuevas).ToList();

            Assert.AreEqual(3, repo.GetEvaluacionesPorCurso(curso).Count);
            Assert.AreEqual(1, eval_cambiadas.Count);

            evaluaciones_nuevas.Last().Fecha = new DateTime(2013, 08, 01);
            eval_cambiadas = new ComparadorDeDiferencias().EvaluacionesParaActualizar(evaluaciones_antiguas, evaluaciones_nuevas);

            Assert.AreEqual(2, eval_cambiadas.Count);

        }

        [TestMethod]
        public void deberia_poder_obtener_las_evaluaciones_a_guardar_en_el_historico()
        {
            Alumno alumno = TestObjects.AlumnoDelCurso();
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));

            string source = @"  |id     |idInstanciaEvaluacion  |DescripcionInstanciaEvaluacion |idAlumno   |idCurso   |Calificacion    |idUsuario     |fechaEvaluacion                              
                                |1      |14                     |Primer Parcial                 |281941     |14        |A1              |6	            |2012-10-13 21:36:35.077     
                                |2      |14                     |Primer Parcial                 |284165     |14        |A2              |6	            |2012-10-13 21:36:35.077      
                                |3      |14                     |Primer Parcial                 |287872     |14        |A3              |7	            |2012-10-13 21:36:35.077  ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            List<Evaluacion> evaluaciones_antiguas = repo.GetEvaluaciones();

            List<Evaluacion> evaluaciones_nuevas = TestObjects.Evaluaciones();

            evaluaciones_nuevas.First().CambiarCalificacionPor(new CalificacionNoNumerica("A8"), new DateTime(2013, 07, 25));

            var eval_para_historico = new ComparadorDeDiferencias().EvaluacionesParaDarDeBaja(evaluaciones_antiguas, evaluaciones_nuevas);                  
            Assert.AreEqual(1, eval_para_historico.Count);

            evaluaciones_nuevas.Last().Fecha = new DateTime(2013, 08, 01);
            eval_para_historico = new ComparadorDeDiferencias().EvaluacionesParaDarDeBaja(evaluaciones_antiguas, evaluaciones_nuevas);
            Assert.AreEqual(2, eval_para_historico.Count);
        }

        [TestMethod]
        public void deberia_poder_obtener_las_evaluaciones_que_se_van_a_guardar_por_primera_vez()
        {
            Alumno alumno = TestObjects.AlumnoDelCurso();
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));

            string source = @"  |id     |idInstanciaEvaluacion  |DescripcionInstanciaEvaluacion |idAlumno   |idCurso   |Calificacion    |idUsuario     |fechaEvaluacion                              
                                |1      |14                     |Primer Parcial                 |281941     |14        |A1              |6	            |2012-10-13 21:36:35.077     
                                |2      |14                     |Primer Parcial                 |284165     |14        |A2              |6	            |2012-10-13 21:36:35.077      
                                |3      |14                     |Primer Parcial                 |287872     |14        |A3              |7	            |2012-10-13 21:36:35.077  ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            List<Evaluacion> evaluaciones_antiguas = repo.GetEvaluaciones();

            List<Evaluacion> evaluaciones_nuevas = TestObjects.Evaluaciones();

            evaluaciones_nuevas.First().CambiarCalificacionPor(new CalificacionNoNumerica("A8"), new DateTime(2013, 07, 25));

            evaluaciones_nuevas.Add(TestObjects.Evaluacion());

            var eval_nuevas = new ComparadorDeDiferencias().EvaluacionesParaGuardar(evaluaciones_antiguas, evaluaciones_nuevas);

            Assert.AreEqual(1, eval_nuevas.Count);
        }

        [TestMethod]
        public void deberia_poder_borrar_una_evaluacion_que_ya_estaba()
        {
            Alumno alumno = TestObjects.AlumnoDelCurso();
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));

            string source = @"  |id     |idInstanciaEvaluacion  |DescripcionInstanciaEvaluacion |idAlumno   |idCurso   |Calificacion    |idUsuario     |fechaEvaluacion                              
                                |1      |14                     |Primer Parcial                 |281941     |14        |A1              |6	            |2012-10-13 21:36:35.077     
                                |2      |14                     |Primer Parcial                 |284165     |14        |A2              |6	            |2012-10-13 21:36:35.077      
                                |3      |14                     |Primer Parcial                 |287872     |14        |A3              |7	            |2012-10-13 21:36:35.077  ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            List<Evaluacion> evaluaciones_antiguas = repo.GetEvaluaciones();

            List<Evaluacion> evaluaciones_nuevas = TestObjects.Evaluaciones();

            evaluaciones_nuevas.Last().CambiarCalificacionPor(new CalificacionNoNumerica("A8"), new DateTime(2013, 07, 25));

            evaluaciones_nuevas.RemoveAt(0);

            var eval_a_borrar = new ComparadorDeDiferencias().EvaluacionesParaDarDeBajaSinInsertarOtra(evaluaciones_antiguas, evaluaciones_nuevas);
            var eval_para_historico = new ComparadorDeDiferencias().EvaluacionesParaDarDeBaja(evaluaciones_antiguas, evaluaciones_nuevas);
            
            Assert.AreEqual(1, eval_a_borrar.Count);
            Assert.AreEqual(2, eval_para_historico.Count);
        }

        [TestMethod]
        public void deberia_poder_actualizar_las_evaluaciones_modificadas_y_guardar_en_el_historico_las_anteriores()
        {
            Alumno alumno = TestObjects.AlumnoDelCurso();
            Curso curso = TestObjects.UnCursoConAlumnos();
            List<Alumno> alumnos = curso.Alumnos();
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));

            string source = @"  |id     |idInstanciaEvaluacion  |DescripcionInstanciaEvaluacion |idAlumno  |idCurso   |Calificacion    |idUsuario       |fechaEvaluacion                              
                                |1      |14                     |Primer Parcial                 |281941    |14        |A1              |6	            |2012-10-13 21:36:35.077     
                                |2      |14                     |Primer Parcial                 |284165    |14        |A2              |6	            |2012-10-13 21:36:35.077      
                                |3      |14                     |Primer Parcial                 |287872    |14        |A3              |7	            |2012-10-13 21:36:35.077  ";
                                                                                                            
            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            List<Evaluacion> evaluaciones_antiguas = repo.GetEvaluaciones();

            List<Evaluacion> evaluaciones_nuevas = TestObjects.Evaluaciones();

            evaluaciones_nuevas.First().CambiarCalificacionPor(new CalificacionNoNumerica("A8"), new DateTime(2013, 07, 25));
            evaluaciones_nuevas.Add(TestObjects.Evaluacion());

            var eval_cambiadas = new ComparadorDeDiferencias().EvaluacionesParaActualizar(evaluaciones_antiguas, evaluaciones_nuevas);
            var eval_para_historico = new ComparadorDeDiferencias().EvaluacionesParaDarDeBaja(evaluaciones_antiguas, evaluaciones_nuevas);           
            var eval_nuevas = new ComparadorDeDiferencias().EvaluacionesParaGuardar(evaluaciones_antiguas, evaluaciones_nuevas);

            //repo.GuardarEvaluaciones(evaluaciones_antiguas, evaluaciones_nuevas, new Usuario());

        }



    }
}
