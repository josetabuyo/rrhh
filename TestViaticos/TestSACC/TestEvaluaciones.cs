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
    public class TestEvaluaciones
    {

         Curso un_curso;
         List<Alumno> lista_alumnos_nuevos; 
         Alumno un_alumno_del_curso;
         Alumno un_alumno_nuevo;
         EspacioFisico espacio_fisico;
         DayOfWeek dia_de_la_semana;
         HorarioDeCursada horario_de_cursada;
         InstanciasDeEvaluacion primer_parcial;
         InstanciasDeEvaluacion segundo_parcial;
        

        [TestInitialize]
        public void Setup()
        {
            un_curso = TestObjects.UnCursoConAlumnos();
            lista_alumnos_nuevos = TestObjects.AlumnosNuevos();
            un_alumno_del_curso = TestObjects.UnAlumnoDelCurso();
            un_alumno_nuevo = TestObjects.UnAlumnoNuevo();
            espacio_fisico = new EspacioFisico();
            dia_de_la_semana = new DayOfWeek();
            horario_de_cursada = new HorarioDeCursada(dia_de_la_semana, "12:00", "13:00", 2);
            primer_parcial = TestObjects.PrimerParcial();
            segundo_parcial = TestObjects.SegundoParcial();
        }

          [TestMethod]
          public void dado_un_curso__deberia_poder_cargar_todas_las_instancias_de_evaluacion_que_habra_en_el_mismo()
          {

//              string source = @"    |Id     |Aula   |idEdificio     |NombreEdificio     |DireccionEdificio      |NumeroEdificio     |Capacidad  |idusuario     |Fecha                      |idBaja
//                                    |01     |03     |01             |Evita              |9 de Julio             |1020               |30         |1111          |2012-10-13 21:36:35.077    |0
//                                    |02     |Magna  |10             |San Martín         |Santa Fe 504           |504                |100        |1111          |2012-10-13 21:36:35.077    |0
//                                    |03     |315    |03             |Perón              |Santa Fe 504           |504                |25         |1111          |2012-10-13 21:36:35.077    |0";

//              IConexionBD conexion = TestObjects.ConexionMockeada();
//              var resultado_sp = TablaDeDatos.From(source);

//              Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//              RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion);


//              repo.AgregarInstanciasEvaluaciones(instancias_evaluaciones);

//              Assert.AreEqual(2, un_curso.GetInstanciasEvaluaciones().Count);

              un_curso.AgregarInstanciaEvaluacion(primer_parcial);

              Assert.AreEqual(1, un_curso.InstanciasDeEvaluacion().Count);


          }
          
          [TestMethod]
          public void dado_un_alumno_en_un_curso_y_una_instancia_de_evaluacion_deberia_poder_saber_que_nota_se_saco()
          {

//              string source = @"  |Id     |idAlumno   |idCurso     |Calificacion     |fechaEvaluacion           |idUsuario     |fecha                      |idBaja 
//                                  |01     |03         |01          |10               |2013-05-13 00:00:00.000   |1111          |2012-10-13 21:36:35.077    |0
//                                  |02     |15         |10          |03               |2013-06-10 00:00:00.000   |1111          |2012-10-13 21:36:35.077    |0
//                                  |03     |315        |03          |08               |2013-05-13 00:00:00.000   |1111          |2012-10-13 21:36:35.077    |0";

//              IConexionBD conexion = TestObjects.ConexionMockeada();
//              var resultado_sp = TablaDeDatos.From(source);

//              Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//              RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion);
//              DateTime fecha = new DateTime(2013, 05, 13);

//              List<InstanciaEvaluacion> evaluaciones =repo.GetEvaluacionesPorCursoYAlumno(1, 3);
//              Evaluacion eval = evaluaciones.Find(e => e.Fecha.Equals(fecha));

//              Assert.AreEqual(10, eval.Calificacion);//repo.GetEvaluacionesPorCursoYAlumno(01, 03).Find(e => e.Fecha.Equals(fecha)).Calificacion);
              
              
              
              
              //DateTime fecha = new DateTime(2013, 04, 11);
              //InstanciaEvaluacion instancia_evaluacion1 = new InstanciaEvaluacion(1, fecha, un_alumno_del_curso, "10");
              //List<InstanciaEvaluacion> instancias_evaluaciones = new List<InstanciaEvaluacion>();
              //instancias_evaluaciones.Add(instancia_evaluacion1);
              //un_curso.AgregarInstanciasEvaluaciones(instancias_evaluaciones);

             
              //string nota_del_alumno = un_curso.ObtenerNotaDelAlumnoEnLaFecha(un_alumno_del_curso, fecha);



              //Assert.AreEqual("10", nota_del_alumno);
          }

          [TestMethod]
          public void dado_un_curso_un_alumno_del_mismo_y_una_instancia_de_evaluacion_deberia_poder_cargar_una_nota()
          {
              Assert.AreEqual(5, un_curso.Alumnos().Count());
          }

          

          [TestMethod]
          public void la_nota_de_evaluacion_siempre_debe_ser_un_numero_comprendido_entre_1_y_10_o_un_ausente_o_sin_informacion()
          {
              Assert.AreEqual(un_curso.Alumnos().Count, 5);

              un_curso.AgregarAlumno(TestObjects.UnAlumnoNuevo());

              Assert.AreEqual(6, un_curso.Alumnos().Count());
          }

          [TestMethod]
          public void dado_un_alumno_un_curso_y_una_nota_deberia_poder_cambiarla()
          {
              un_curso.AgregarAlumnos(lista_alumnos_nuevos);

              Assert.AreEqual(8, un_curso.Alumnos().Count());
          }

          [TestMethod]
          public void no_deberia_poder_evaluar_un_alumno_que_no_pertenece_al_curso()
          {
              un_curso.AgregarAlumnos(lista_alumnos_nuevos);

              Assert.AreEqual(8, un_curso.Alumnos().Count());
          }
    }
}
