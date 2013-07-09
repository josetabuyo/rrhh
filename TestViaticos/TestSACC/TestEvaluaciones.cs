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
         Evaluacion evaluacion_final;
         HorarioDeCursada horario_de_cursada;
         InstanciaDeEvaluacion primer_parcial;
         InstanciaDeEvaluacion segundo_parcial;
         InstanciaDeEvaluacion final;
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
            final = TestObjects.FinalNulo();
            primera_evaluacion = new Evaluacion(primer_parcial, un_alumno_del_curso, un_curso_cens, new CalificacionNumerica(10), DateTime.Today);
            segunda_evaluacion = new Evaluacion(segundo_parcial, un_alumno_del_curso, un_curso_cens, new CalificacionNumerica(8), DateTime.Today);
            evaluacion_final = new Evaluacion(final, un_alumno_del_curso, un_curso_puro, new CalificacionNull("No tiene calificación"), DateTime.Today);
            espacio_fisico = new EspacioFisico();
            dia_de_la_semana = new DayOfWeek();
            horario_de_cursada = new HorarioDeCursada(dia_de_la_semana, "12:00", "13:00", 2);
            
            planilla_evaluaciones = new PlanillaDeEvaluaciones(un_curso_cens, lista_de_instancias_de_evaluacion);
        }

    


          [TestMethod]
          public void dado_un_alumno_un_curso_y_una_nota_deberia_poder_cambiarla()
          {
              //un_curso_cens.AgregarAlumnos(lista_alumnos_nuevos);
              //un_curso_cens.AgregarEvaluacion(primera_evaluacion);

              //Assert.AreEqual(10, un_curso_cens.EvaluacionDeAlumnoEnUnaInstancia(un_alumno_del_curso, primer_parcial).Calificacion.Nota);

              //primera_evaluacion.CambiarCalificacionPor(5);
              //Assert.AreEqual(5, un_curso_cens.EvaluacionDeAlumnoEnUnaInstancia(un_alumno_del_curso, primer_parcial).Calificacion.Nota);
          }


          //[TestMethod]
          //public void no_deberia_poder_evaluar_un_alumno_que_no_pertenece_al_curso()
          //{
          //    un_curso_cens.AgregarAlumnos(lista_alumnos_nuevos);

          //    Assert.AreEqual(8, un_curso_cens.Alumnos().Count());
          //}
    }
}

