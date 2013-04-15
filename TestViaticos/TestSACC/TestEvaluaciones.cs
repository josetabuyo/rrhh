using System.Linq;
using System;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
         InstanciaEvaluacion primer_parcial_de_fer_en_historia;
         InstanciaEvaluacion segundo_parcial_de_fer_en_historia;
        

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
            primer_parcial_de_fer_en_historia = TestObjects.PrimerParcialDeFerEnHistoria();
            segundo_parcial_de_fer_en_historia = TestObjects.SegundoParcialDeFerEnHistoria();
        }

          [TestMethod]
          public void dado_un_curso__deberia_poder_cargar_todas_las_instancias_de_evaluacion_que_habra_en_el_mismo()
          { 
              
              

              un_curso.AgregarInstanciasEvaluaciones(instancias_evaluaciones);

              Assert.AreEqual(2, un_curso.GetInstanciasEvaluaciones().Count);
          }
          
          [TestMethod]
          public void dado_un_alumno_en_un_curso_y_una_instancia_de_evaluacion_deberia_poder_saber_que_nota_se_saco()
          {
              DateTime fecha = new DateTime(2013, 04, 11);
              InstanciaEvaluacion instancia_evaluacion1 = new InstanciaEvaluacion(1, fecha, un_alumno_del_curso, "10");
              List<InstanciaEvaluacion> instancias_evaluaciones = new List<InstanciaEvaluacion>();
              instancias_evaluaciones.Add(instancia_evaluacion1);
              un_curso.AgregarInstanciasEvaluaciones(instancias_evaluaciones);

             
              string nota_del_alumno = un_curso.ObtenerNotaDelAlumnoEnLaFecha(un_alumno_del_curso, fecha);



              Assert.AreEqual("10", nota_del_alumno);
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
    }
}
