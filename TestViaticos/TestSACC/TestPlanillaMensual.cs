using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using NMock2;

namespace TestViaticos
{

    [TestClass]
    public class TestPlanillaMensual
    {
        private DateTime fecha_desde;
        private DateTime fecha_hasta;
        ManagerDeCalendarios managerDeCalendarios;
        CalendarioDeFeriados unCalendarioGlobal = new CalendarioDeFeriados();
        private DateTime fecha_cursable;
        private Alumno un_alumno;
        
        [TestInitialize]
        public void Setup()
        {
            fecha_desde = new DateTime(2012, 08, 14);
            fecha_hasta = new DateTime(2012, 08, 31);
            managerDeCalendarios = new ManagerDeCalendarios(unCalendarioGlobal);
            fecha_cursable = new DateTime(2012, 08, 14);
            un_alumno = TestObjects.UnAlumnoDelCurso();
        }


          [TestMethod]
          public void deberia_poder_generar_una_planilla_para_un_curso_y_mes()
          {
             

              Curso un_curso = TestObjects.UnCursoConAlumnos();

              GeneradorDePlanillas generador = new GeneradorDePlanillas();

              Assert.IsNotNull(generador.GenerarPlanillaMensualPara(un_curso,fecha_desde, fecha_hasta));
          }

          [TestMethod]
          public void deberia_agregar_una_inasistencia_a_un_alumno_para_una_planilla_que_esta_en_un_curso()
          {
              Curso un_curso = TestObjects.UnCursoConAlumnos();
              managerDeCalendarios.AgregarCalendarioPara(un_curso);

              GeneradorDePlanillas generador = new GeneradorDePlanillas();
             
              CalendarioDeCurso un_calendario = managerDeCalendarios.CalendarioPara(un_curso);

              PlanillaMensual una_planilla = generador.GenerarPlanillaMensualPara(un_curso, fecha_desde, fecha_hasta, un_calendario);

              una_planilla.AgregarInasistenciaPara(un_alumno, fecha_cursable);

              Assert.AreEqual(1,una_planilla.GetInasistenciaPorAlumno(un_alumno).Count());
          }

          [TestMethod]
          public void no_deberia_cargar_una_inasistencia_a_un_alumno_que_no_esta_en_un_curso()
          {
              Curso un_curso = TestObjects.UnCursoConAlumnos();
              managerDeCalendarios.AgregarCalendarioPara(un_curso);

              GeneradorDePlanillas generador = new GeneradorDePlanillas();
              CalendarioDeCurso un_calendario = managerDeCalendarios.CalendarioPara(un_curso);
              Alumno un_alumno = new Alumno(8, "Dani", "Tatay", 28753951, "", "", "", new Area(1, "Area de Faby"), new Modalidad(1, "Fines Puro"));

              PlanillaMensual una_planilla = generador.GenerarPlanillaMensualPara(un_curso, fecha_desde, fecha_hasta, un_calendario);

              try
              {
                  una_planilla.AgregarInasistenciaPara(un_alumno, DateTime.Now);
                  Assert.Fail("Deberia haber lanzado excepcion");
              }
              catch (ExcepcionDeValidacion e)
              {
                  Assert.AreEqual(0, una_planilla.GetInasistenciaPorAlumno(un_alumno).Count());
                  Assert.AreEqual("Dani, no pertenece a la coleccion de Alumnos", e.Message);
              }   
          }

          [TestMethod]
          public void deberia_traer_inasistencias_de_un_alumno_para_un_mes()
          {
              Curso un_curso = TestObjects.UnCursoConAlumnos();
              managerDeCalendarios.AgregarCalendarioPara(un_curso);

              GeneradorDePlanillas generador = new GeneradorDePlanillas();
             
              CalendarioDeCurso un_calendario = managerDeCalendarios.CalendarioPara(un_curso);

              PlanillaMensual una_planilla = generador.GenerarPlanillaMensualPara(un_curso, fecha_desde, fecha_hasta, un_calendario);

              una_planilla.AgregarInasistenciaPara(un_alumno, fecha_cursable);
              Assert.AreEqual(1, una_planilla.GetInasistenciaPorAlumno(un_alumno).Count());

              una_planilla.AgregarInasistenciaPara(un_alumno, fecha_cursable.AddDays(1));
              Assert.AreEqual(2, una_planilla.GetInasistenciaPorAlumno(un_alumno).Count());
          }

          [TestMethod]
          public void no_deberia_traer_inasistencias_de_un_alumno_que_no_falto()
          {
              Curso un_curso = TestObjects.UnCursoConAlumnos();

              GeneradorDePlanillas generador = new GeneradorDePlanillas();
             
              PlanillaMensual una_planilla = generador.GenerarPlanillaMensualPara(un_curso, fecha_desde, fecha_hasta);

              Assert.AreEqual(0, una_planilla.GetInasistenciaPorAlumno(un_alumno).Count());
          }

          [TestMethod]
          public void deberia_agregar_una_asistencia_a_un_alumno_para_una_planilla_que_esta_en_un_curso()
          {
              Curso un_curso = TestObjects.UnCursoConAlumnos();
              managerDeCalendarios.AgregarCalendarioPara(un_curso);

              CalendarioDeCurso un_calendario = managerDeCalendarios.CalendarioPara(un_curso);
              GeneradorDePlanillas generador = new GeneradorDePlanillas();

              Alumno un_alumno_2 = new Alumno(8, "Dani", "Tatay", 28753951, "", "", "", new Area(1, "Area de Faby"), new Modalidad(1, "Fines Puro"));

              PlanillaMensual una_planilla = generador.GenerarPlanillaMensualPara(un_curso, fecha_desde, fecha_hasta, un_calendario);

              una_planilla.AgregarAsistenciaPara(un_alumno, fecha_cursable);

              Assert.AreEqual(1, una_planilla.GetAsistenciasPorAlumno(un_alumno).Count());
              Assert.AreEqual(0, una_planilla.GetAsistenciasPorAlumno(un_alumno_2).Count());
          }

          [TestMethod]
          public void deberia_poder_conocer_los_dias_de_cursada_de_un_curso_para_un_mes()
          {
              Curso un_curso = TestObjects.UnCursoConAlumnos();
              managerDeCalendarios.AgregarCalendarioPara(un_curso);
              GeneradorDePlanillas generador = new GeneradorDePlanillas();

              CalendarioDeCurso un_calendario = managerDeCalendarios.CalendarioPara(un_curso);//new CalendarioDeCurso(un_curso, new CalendarioDeFeriados() ); //Se cambió por el Manager
              PlanillaMensual una_planilla = generador.GenerarPlanillaMensualPara(un_curso, fecha_desde, fecha_hasta, un_calendario);

              Assert.AreEqual(6, una_planilla.GetDiasDeCursadaEntre(fecha_desde, fecha_hasta).Count());
          }

          [TestMethod]
          public void no_deberia_poder_cargar_una_inasistencia_si_el_dia_no_era_cursable()
          {
              Curso un_curso = TestObjects.UnCursoConAlumnos();
              managerDeCalendarios.AgregarCalendarioPara(un_curso);

              GeneradorDePlanillas generador = new GeneradorDePlanillas();
              CalendarioDeCurso un_calendario = managerDeCalendarios.CalendarioPara(un_curso);

              PlanillaMensual una_planilla = generador.GenerarPlanillaMensualPara(un_curso, fecha_desde, fecha_hasta, un_calendario);

              DateTime fecha_no_cursable = new DateTime(2013, 01, 24);

              try
              {
                  una_planilla.AgregarInasistenciaPara(un_alumno, fecha_no_cursable);
                  Assert.Fail("Deberia haber lanzado excepcion");
              }
              catch (ExcepcionDeValidacion e)
              {
                  Assert.AreEqual( fecha_no_cursable.ToString() +  ", no pertenece a la coleccion de Dias de Cursada", e.Message);
              }
          }


    }
}
