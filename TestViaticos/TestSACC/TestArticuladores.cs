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
    public class TestArticuladores
    {
        Curso un_curso;
        List<Alumno> lista_alumnos_nuevos;
        Alumno un_alumno_del_curso;
        Alumno un_alumno_nuevo;
        List<AcumuladorAsistencia> acumulador_asistencias;

        [TestInitialize]
        public void Setup()
        {
            un_curso = TestObjects.UnCursoConAlumnos();
            lista_alumnos_nuevos = TestObjects.AlumnosNuevos();
            un_alumno_del_curso = TestObjects.UnAlumnoDelCurso();
            un_alumno_nuevo = TestObjects.UnAlumnoNuevo();
            acumulador_asistencias = TestObjects.Asistencias();

        }


        [TestMethod]
        public void deberia_poder_preguntarle_al_articulador_si_Zambri_quedo_libre_para_una_materia_del_cens_y_deberia_decirme_que_no()
        {
//            //El total de horas cátedra es de 30 y el máximo son 3 horas cátedra de ausencias. Zambri Al faltar 1 clase de 2 horas cátedra, le queda 1 restanto todavía
//            //El curso se cursa los Martes (1 hora cátedra) y los Miércoles (2 horas cátedra) y comienza el 01/01/2013 que es Martes
//            string source = @"  |Id     |idAlumno     |IdCurso      |fechaAsistencia                |descripcion     |valor
//                                |01     |4            |14           |2013-01-01 12:36:35.077        |Presencia       |1    
//                                |02     |4            |14           |2013-01-02 12:36:35.077        |Ausencia        |4    
//                                |03     |1            |14           |2013-01-01 12:36:35.077        |Presencia       |1    ";


//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            RepositorioDeAsistencias repo_asistencias = new RepositorioDeAsistencias(conexion);

//            Articulador articulador = new Articulador();
//            articulador.EvaluarRegularidadPara(TestObjects.AlumnoZambri(), TestObjects.UnCursoConAlumnos(), repo_asistencias);
//            int ausencias_restantes = articulador.AusenciasDisponibles(TestObjects.AlumnoZambri(), TestObjects.UnCursoConAlumnos(), repo_asistencias);

//            Assert.AreEqual("Regular", articulador.condicion_del_alumno);
//            Assert.AreEqual(1, ausencias_restantes);
        }


        [TestMethod]
        public void deberia_poder_preguntarle_al_articulador_si_Zambri_quedo_libre_para_una_materia_del_cens_y_deberia_decirme_que_si()
        {
//            //El total de horas cátedra es de 30 y el máximo son 3 horas cátedra de ausencias. Zambri Al faltar 3 clases que suman 4 horas cátedra, queda libre
//            //El curso se cursa los Martes (1 hora cátedra) y los Miércoles (2 horas cátedra) y comienza el 01/01/2013 que es Martes
//            string source = @"  |Id     |idAlumno     |IdCurso      |fechaAsistencia                |descripcion     |valor
//                                |01     |4            |14           |2013-01-01 12:36:35.077        |Ausencia        |4    
//                                |02     |4            |14           |2013-01-02 12:36:35.077        |Ausencia        |4 
//                                |02     |4            |14           |2013-01-08 12:36:35.077        |Ausencia        |4   
//                                |03     |1            |14           |2013-01-01 12:36:35.077        |Ausencia        |4    ";


//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            RepositorioDeAsistencias repo_asistencias = new RepositorioDeAsistencias(conexion);

//            Articulador articulador = new Articulador();
//            articulador.EvaluarRegularidadPara(TestObjects.AlumnoZambri(), TestObjects.UnCursoConAlumnos(), repo_asistencias);
//            int ausencias_restantes = articulador.AusenciasDisponibles(TestObjects.AlumnoZambri(), TestObjects.UnCursoConAlumnos(), repo_asistencias);

//            Assert.AreEqual("Libre", articulador.condicion_del_alumno);
//            Assert.AreEqual(-1, ausencias_restantes);
        }


        [TestMethod]
        public void deberia_poder_preguntarle_al_articulador_si_Zambri_quedo_libre_para_una_materia_del_cens_y_deberia_decirme_que_si_nuevamente_porque_asistio_parcialmente()
        {
//            //El total de horas cátedra es de 30 y el máximo son 3 horas cátedra de ausencias. Zambri Al faltar 1 hora cátedra en las 4 primeras clases sumó 4 y se excedió
//            //El curso se cursa los Martes (1 hora cátedra) y los Miércoles (2 horas cátedra) y comienza el 01/01/2013 que es Martes
//            string source = @"  |Id     |idAlumno     |IdCurso      |fechaAsistencia                |descripcion     |valor
//                                |01     |4            |14           |2013-01-01 12:36:35.077        |Ausencia        |4    
//                                |02     |4            |14           |2013-01-02 12:36:35.077        |Ausencia        |1 
//                                |02     |4            |14           |2013-01-08 12:36:35.077        |Ausencia        |4 
//                                |02     |4            |14           |2013-01-09 12:36:35.077        |Ausencia        |1   
//                                |03     |1            |14           |2013-01-01 12:36:35.077        |Ausencia        |4    ";


//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            RepositorioDeAsistencias repo_asistencias = new RepositorioDeAsistencias(conexion);

//            Articulador articulador = new Articulador();
//            articulador.EvaluarRegularidadPara(TestObjects.AlumnoZambri(), TestObjects.UnCursoConAlumnos(), repo_asistencias);
//            int ausencias_restantes = articulador.AusenciasDisponibles(TestObjects.AlumnoZambri(), TestObjects.UnCursoConAlumnos(), repo_asistencias);

//            Assert.AreEqual("Libre", articulador.condicion_del_alumno);
//             Assert.AreEqual(-1, ausencias_restantes);
        }

        [TestMethod]
        public void deberia_poder_preguntarle_al_articulador_si_Zambri_quedo_libre_para_una_materia_del_cens_y_deberia_decirme_que_no_porque_asistio_parcialmente_pero_le_restan_faltas()
        {
//            //El total de horas cátedra es de 30 y el máximo son 3 horas cátedra de ausencias. Zambri Al faltar 1 hora cátedra en las 4 primeras clases sumó 4 y se excedió
//            //El curso se cursa los Martes (1 hora cátedra) y los Miércoles (2 horas cátedra) y comienza el 01/01/2013 que es Martes
//            string source = @"  |Id     |idAlumno     |IdCurso      |fechaAsistencia                |descripcion     |valor
//                                |01     |4            |14           |2013-01-01 12:36:35.077        |Ausencia        |4    
//                                |02     |4            |14           |2013-01-02 12:36:35.077        |Ausencia        |1 
//                                |02     |4            |14           |2013-01-08 12:36:35.077        |Ausencia        |4 
//                                |02     |4            |14           |2013-01-09 12:36:35.077        |Ausencia        |2   
//                                |03     |1            |14           |2013-01-01 12:36:35.077        |Ausencia        |4    ";


//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            RepositorioDeAsistencias repo_asistencias = new RepositorioDeAsistencias(conexion);

//            Articulador articulador = new Articulador();
//            articulador.EvaluarRegularidadPara(TestObjects.AlumnoZambri(), TestObjects.UnCursoConAlumnos(), repo_asistencias);
//            int ausencias_restantes = articulador.AusenciasDisponibles(TestObjects.AlumnoZambri(), TestObjects.UnCursoConAlumnos(), repo_asistencias);

//            Assert.AreEqual("Regular", articulador.condicion_del_alumno);
//             Assert.AreEqual(0, ausencias_restantes);
        }

        [TestMethod]
        public void deberia_saber_que_Zambri_no_quedo_libre_porque_las_inasistencias_no_son_computables()
        {
//            //El total de horas cátedra es de 30 y el máximo son 3 horas cátedra de ausencias. Zambri Al faltar todos los dias pero con ID 5 (por fuerza mayor) no le le computa ninguna
//            //El curso se cursa los Martes (1 hora cátedra) y los Miércoles (2 horas cátedra) y comienza el 01/01/2013 que es Martes
//            string source = @"  |Id     |idAlumno     |IdCurso      |fechaAsistencia                |descripcion     |valor
//                                |01     |4            |14           |2013-01-01 12:36:35.077        |Ausencia        |5    
//                                |02     |4            |14           |2013-01-02 12:36:35.077        |Ausencia        |5 
//                                |02     |4            |14           |2013-01-08 12:36:35.077        |Ausencia        |5 
//                                |02     |4            |14           |2013-01-09 12:36:35.077        |Ausencia        |5   
//                                |03     |1            |14           |2013-01-01 12:36:35.077        |Ausencia        |5    ";


//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            RepositorioDeAsistencias repo_asistencias = new RepositorioDeAsistencias(conexion);

//            Articulador articulador = new Articulador();
//            //articulador.EvaluarRegularidadPara(TestObjects.AlumnoZambri(), TestObjects.UnCursoConAlumnos(), repo_asistencias);
//           // int ausencias_restantes = articulador.AusenciasDisponibles(TestObjects.AlumnoZambri(), TestObjects.UnCursoConAlumnos(), repo_asistencias);

//            Assert.AreEqual("Regular", articulador.condicion_del_alumno);
//            Assert.AreEqual(3, ausencias_restantes);
        }

        [TestMethod]
        public void deberia_poder_saber_si_un_alumno_aprobo_un_curso()
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
                                |4      |6                      |Calificacion Final             |281941     |14        |Aprobado        |6	            |2012-10-13 21:36:35.077      
                                |2      |14                     |Primer Parcial                 |284165     |14        |A2              |6	            |2012-10-13 21:36:35.077      
                                |3      |14                     |Primer Parcial                 |287872     |14        |A3              |7	            |2012-10-13 21:36:35.077  ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoAlumnosMockeado());

            //List<Evaluacion> evaluaciones = repo.GetEvaluacionesPorCursoYAlumno(curso, alumnos.First());

            Articulador articulador = new Articulador();

            Assert.AreEqual(true, articulador.DecimeSiAprobo(alumnos.First(), curso, repo));
            Assert.AreEqual(false, articulador.DecimeSiAprobo(alumnos[2], curso, repo));
            Assert.AreEqual(false, articulador.DecimeSiAprobo(alumnos.Last(), curso, repo));

        }

        [TestMethod]
        public void deberia_poder_saber_la_calificacion_de_un_curso()
        {
            var curso = TestObjects.CursoDeHistoriaDelCENS();
            var evaluaciones = TestObjects.EvaluacionesParaUnAlumno();

            var articulador = new Articulador();

            Assert.AreEqual("8", articulador.CalificacionDelCurso(curso, evaluaciones));

        }

        [TestMethod]
        public void deberia_poder_saber_que_el_estado_de_un_alumno_para_con_un_curso_es_que_adeuda_el_final()
        {
            var curso = TestObjects.CursoDeHistoriaDelCENS();
            var evaluaciones = TestObjects.EvaluacionesParaUnAlumno();

            evaluaciones.RemoveAt(2);

            var articulador = new Articulador();

            Assert.AreEqual("Adeuda", articulador.EstadoDelAlumnoParaElCurso(curso, evaluaciones));

        }

        [TestMethod]
        public void deberia_poder_saber_que_el_estado_de_un_alumno_para_con_un_curso_es_que_esta_en_curso()
        {
            var curso = TestObjects.CursoDeHistoriaDelCENS();
            var evaluaciones = TestObjects.EvaluacionesParaUnAlumno();

            var articulador = new Articulador();

            Assert.AreEqual("En Curso", articulador.EstadoDelAlumnoParaElCurso(curso, evaluaciones));

        }

        [TestMethod]
        public void deberia_poder_saber_que_el_estado_de_un_alumno_para_con_un_curso_es_que_esta_aprobada()
        {
            var curso = TestObjects.UnCursoConAlumnos();
            var evaluaciones = TestObjects.EvaluacionesParaUnAlumno();

            var articulador = new Articulador();

            Assert.AreEqual("Aprobada", articulador.EstadoDelAlumnoParaElCurso(curso, evaluaciones));

        }



       
        [TestMethod]
        public void deberia_saber_las_asistencias_de_un_alumno_por_curso()
        {
//            string source = @" |id   |FechaAsistencia                 |Valor    |IdCurso    |idAlumno 
//                               |1    |2013-11-10 21:36:35.077         |'2'        |14         |281941      
//                               |2    |2013-11-11 21:36:35.077         |'3'        |14         |281941      
//                               |3    |2013-11-12 21:36:35.077         |'0'        |14         |281941      
//                               |4    |2013-11-13 21:36:35.077         |'2'        |14         |281941           
//                               |5    |2013-11-10 21:36:35.077         |'4'        |14         |287872           
//                               |6    |2013-11-11 21:36:35.077         |'0'        |14         |287872           ";

            
//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);
//            var repo = new RepositorioDeAsistencias(conexion);

            var repo_mock = TestObjects.RepoAsistenciasMockeado();


            Expect.AtLeastOnce.On(repo_mock).Method("GetAsistencias").WithAnyArguments().Will(Return.Value(acumulador_asistencias));

            var articulador = new Articulador();
            Assert.AreEqual(4, articulador.AsistenciasParaUnAlumnoYCurso(TestObjects.AlumnoFer(), un_curso, repo_mock).Count); 

        }


        [TestMethod]
        public void deberia_saber_el_total_de_horas_catedra_de_un_curso()
        {
            //var repo_mock = TestObjects.RepoAsistenciasMockeado();

            //Expect.AtLeastOnce.On(repo_mock).Method("GetAsistencias").WithAnyArguments().Will(Return.Value(acumulador_asistencias));

            var articulador = new Articulador();
            Assert.AreEqual(3, articulador.TotalDeHorasCatedra(un_curso,TestObjects.DiasDeCursada())); 
        }


    }
}
