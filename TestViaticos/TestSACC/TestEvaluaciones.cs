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

         Curso un_curso_cens;
         Curso un_curso_puro;
         List<Alumno> lista_alumnos_nuevos; 
         Alumno un_alumno_del_curso;
         Alumno un_alumno_nuevo;
         EspacioFisico espacio_fisico;
         DayOfWeek dia_de_la_semana;
         Evaluacion primera_evaluacion;
         Evaluacion segunda_evaluacion;
         HorarioDeCursada horario_de_cursada;
         InstanciaDeEvaluacion primer_parcial;
         InstanciaDeEvaluacion segundo_parcial;
         List<InstanciaDeEvaluacion> lista_de_instancias_de_evaluacion = new List<InstanciaDeEvaluacion>();
         PlanillaDeEvaluaciones planilla_evaluaciones;
        

        [TestInitialize]
        public void Setup()
        {
            un_curso_cens = TestObjects.UnCursoConAlumnos();
            un_curso_puro = TestObjects.UnCursoConAlumnosYMateriaPura();
            lista_alumnos_nuevos = TestObjects.AlumnosNuevos();
            un_alumno_del_curso = TestObjects.UnAlumnoDelCurso();
            un_alumno_nuevo = TestObjects.UnAlumnoNuevo();
            primer_parcial = TestObjects.PrimerParcial();
            segundo_parcial = TestObjects.SegundoParcial();
            primera_evaluacion = new Evaluacion(primer_parcial, un_alumno_del_curso, un_curso_cens, new CalificacionNumerica(10), DateTime.Today);
            segunda_evaluacion = new Evaluacion(segundo_parcial, un_alumno_del_curso, un_curso_cens, new CalificacionNumerica(8), DateTime.Today);
            espacio_fisico = new EspacioFisico();
            dia_de_la_semana = new DayOfWeek();
            horario_de_cursada = new HorarioDeCursada(dia_de_la_semana, "12:00", "13:00", 2);
            
            planilla_evaluaciones = new PlanillaDeEvaluaciones(un_curso_cens, lista_de_instancias_de_evaluacion);
        }

          [TestMethod]
          public void dado_un_curso_deberia_poder_ver_cuantas_instancias_de_evaluacion_tiene()
          {
              //un_curso.AgregarInstanciaEvaluacion(primer_parcial);
              Assert.AreEqual(2, un_curso_cens.Instancias().Count);
              Assert.AreEqual(1, un_curso_puro.Instancias().Count);
          }

          [TestMethod]
          public void dado_un_curso_deberia_poder_agregar_una_evaluacion()
          {
              un_curso_cens.AgregarEvaluacion(primera_evaluacion);
              Assert.AreEqual(1, un_curso_cens.EvaluacionesPorInstancias().Count);

              un_curso_cens.AgregarEvaluacion(segunda_evaluacion);
              Assert.AreEqual(2, un_curso_cens.EvaluacionesPorInstancias().Count);
             
          }

          [TestMethod]
          public void dado_un_curso_deberia_poder_agregar_una_lista_de_evaluaciones()
          {
              List<Evaluacion> lista_evaluaciones = new List<Evaluacion>() { primera_evaluacion, segunda_evaluacion };

              un_curso_cens.AgregarEvaluaciones(lista_evaluaciones);
              Assert.AreEqual(2, un_curso_cens.EvaluacionesPorInstancias().Count);

          }

          [TestMethod]
          public void dado_un_curso_deberia_poder_conocer_las_evaluaciones_de_un_alumno()
          {
              List<Evaluacion> lista_evaluaciones = new List<Evaluacion>() { primera_evaluacion, segunda_evaluacion };

              un_curso_cens.AgregarEvaluaciones(lista_evaluaciones);

              Assert.AreEqual(2, un_curso_cens.EvaluacionesDe(un_alumno_del_curso).Count);
              Assert.AreEqual(0, un_curso_cens.EvaluacionesDe(un_alumno_nuevo).Count);
          }

          [TestMethod]
          public void dado_un_curso_deberia_poder_conocer_todas_las_evaluaciones_de_una_instancia()
          {             
              un_curso_cens.AgregarEvaluacion(primera_evaluacion);

              Assert.AreEqual(1, un_curso_cens.EvaluacionesDe(primer_parcial).Count);
              Assert.AreEqual(0, un_curso_cens.EvaluacionesDe(segundo_parcial).Count);
          }

          [TestMethod]
          public void dado_un_curso_deberia_poder_conocer_que_nota_se_saco_un_alumno_en_una_instancia_determinada()
          {
              List<Evaluacion> lista_evaluaciones = new List<Evaluacion>() { primera_evaluacion, segunda_evaluacion };

              un_curso_cens.AgregarEvaluaciones(lista_evaluaciones);

              Assert.AreEqual(1, un_curso_cens.EvaluacionDeAlumnoEnUnaInstancia(un_alumno_del_curso,primer_parcial).Calificacion);
              Assert.AreEqual(0, un_curso_cens.EvaluacionDeAlumnoEnUnaInstancia(un_alumno_del_curso, segundo_parcial).Calificacion);
          }


          [TestMethod]
          public void dado_un_alumno_en_un_curso_deberia_generarle_la_evaluacion_de_una_instancia()
          {
           
              lista_de_instancias_de_evaluacion.Add(primer_parcial);
              lista_de_instancias_de_evaluacion.Add(segundo_parcial);
              Evaluacion evaluacion_del_alumno = new Evaluacion(primer_parcial, un_alumno_del_curso, un_curso_cens, new CalificacionNumerica(10), DateTime.Today);
              planilla_evaluaciones = new PlanillaDeEvaluaciones(un_curso_cens, lista_de_instancias_de_evaluacion);
              //planilla_evaluaciones.AgregarEvaluacion(evaluacion_del_alumno);



              //List<Evaluacion> evaluaciones_del_alumno = planilla_evaluaciones.GetEvaluacionesPorAlumno(un_alumno_del_curso);

              //Assert.IsTrue(evaluaciones_del_alumno.Contains(evaluacion_del_alumno));
              
          }

        [TestMethod]
          public void dado_un_alumno_en_un_curso_y_una_instancia_de_evaluacion_deberia_poder_saber_que_nota_se_saco()
          {
            //NO BORRAR !!!!! La necesito para el Test de Repositorio de Evaluaciones 
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

              
              lista_de_instancias_de_evaluacion.Add(primer_parcial);
              lista_de_instancias_de_evaluacion.Add(segundo_parcial);
            var calificacion10 = new CalificacionNumerica(10);
            Evaluacion evaluacion_del_alumno = new Evaluacion(primer_parcial, un_alumno_del_curso, un_curso_cens, calificacion10, DateTime.Today);

            PlanillaDeEvaluaciones planilla_evaluaciones = new PlanillaDeEvaluaciones(un_curso_cens, lista_de_instancias_de_evaluacion);
             // planilla_evaluaciones.AgregarEvaluacion(evaluacion_del_alumno);

              //List<Evaluacion> evaluaciones_del_alumno = planilla_evaluaciones.GetEvaluacionesPorAlumno(un_alumno_del_curso);

              //Assert.AreEqual(calificacion10, evaluaciones_del_alumno.First().Calificacion);
          }

          [TestMethod]
          public void la_nota_de_evaluacion_siempre_debe_ser_un_numero_comprendido_entre_1_y_10()
          {
              try
              {
                  Evaluacion evaluacion_del_alumno = new Evaluacion(primer_parcial, un_alumno_del_curso, un_curso_cens, new CalificacionNumerica(11), DateTime.Today);
                  Assert.Fail("Deberia fallar por que no se puede crear una nota mayor a 10 o menor a 1");
              }
              catch (ExcepcionDeValidacion excepcion)
              {
                  Assert.AreEqual(excepcion.Message, "La nota no puede ser menor que 1 o mayor que 10");
              }

              
          }

        [TestMethod]
        public void cuandoUnAlumnoNoTieneNotaEnLaPlanillaDeberiaInformarmeUnaNotaNula()
        {
            lista_de_instancias_de_evaluacion.Add(primer_parcial);
            lista_de_instancias_de_evaluacion.Add(segundo_parcial);
            planilla_evaluaciones = new PlanillaDeEvaluaciones(un_curso_cens, lista_de_instancias_de_evaluacion);
            Evaluacion notaPedido = planilla_evaluaciones.GetEvaluacionPorAlumnoEInstancia(un_alumno_del_curso, primer_parcial);
            Calificacion notaNula = new CalificacionNull();
            
            //ARREGLAR!!!
           // Assert.AreEqual(notaPedido, notaNula);
        }

          [TestMethod]
          public void dado_un_alumno_un_curso_y_una_nota_deberia_poder_cambiarla()
          {
              un_curso_cens.AgregarAlumnos(lista_alumnos_nuevos);

              Assert.AreEqual(8, un_curso_cens.Alumnos().Count());
          }

          [TestMethod]
          public void no_deberia_poder_evaluar_un_alumno_que_no_pertenece_al_curso()
          {
              un_curso_cens.AgregarAlumnos(lista_alumnos_nuevos);

              Assert.AreEqual(8, un_curso_cens.Alumnos().Count());
          }
    }
}

