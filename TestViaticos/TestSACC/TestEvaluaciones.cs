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

        //[TestMethod]
        //public void xxx()
        //{

        //    //PlanillaEvaluacionesDto planilla = new PlanillaDeEvaluaciones(alumnos, instancias_de_evaluaciones, evaluaciones);

        //    //Assert.AreEqual(primer_parcial.Id, evaluacion.idInstancia);
        //    //Assert.AreEqual(un_alumno_del_curso.Id, evaluacion.idAlumno);
        //    //Assert.AreEqual(un_curso_cens.Id, evaluacion.idCurso);
        //    //Assert.AreEqual("2", evaluacion.nota);
        //    //Assert.AreEqual(new DateTime(2013, 03, 15) , evaluacion.fecha);
            
        //    //Assert.AreEqual(2, planilla.Count);
        //    //Assert.AreEqual(un_alumno_del_curso.Id, planilla.Alumnos[0].Id);
        //    //Assert.AreEqual(un_alumno_nuevo.Id, planilla.Alumnos[1].Id);
        //    //Assert.AreEqual(1, planilla.Instancias().Count);

        //}


    }
}

