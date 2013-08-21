using System.Linq;
using System;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestViaticos
{

    [TestClass]
    public class TestCursos
    {

         Curso un_curso;
         List<Alumno> lista_alumnos_nuevos; 
        Alumno un_alumno_del_curso;
         Alumno un_alumno_nuevo;
         EspacioFisico espacio_fisico;
         DayOfWeek dia_de_la_semana;
         HorarioDeCursada horario_de_cursada;
        

        [TestInitialize]
        public void Setup()
        {
            un_curso = TestObjects.UnCursoConAlumnos();
            lista_alumnos_nuevos = TestObjects.AlumnosNuevos();
            un_alumno_del_curso = TestObjects.UnAlumnoDelCurso();
            un_alumno_nuevo = TestObjects.UnAlumnoNuevo();
            espacio_fisico = new EspacioFisico();
            dia_de_la_semana = new DayOfWeek();
            horario_de_cursada = new HorarioDeCursada(dia_de_la_semana, "12:00", "13:00", 2,1 );
        }


          [TestMethod]
          public void deberia_poder_obtener_los_alumnos_de_un_curso()
          { 
              Assert.AreEqual(5, un_curso.Alumnos().Count());
          }

          [TestMethod]
          public void deberia_poder_agregar_un_nuevo_alumno_a_un_curso()
          {
              Assert.AreEqual(un_curso.Alumnos().Count, 5);

              un_curso.AgregarAlumno(TestObjects.UnAlumnoNuevo());

              Assert.AreEqual(6, un_curso.Alumnos().Count());
          }

          [TestMethod]
          public void deberia_poder_agregar_varios_alumnos_a_un_curso()
          {
              un_curso.AgregarAlumnos(lista_alumnos_nuevos);

              Assert.AreEqual(8, un_curso.Alumnos().Count());
          }

          [TestMethod]
          public void deberia_poder_quitar_un_alumno_de_un_curso()
          {
              un_curso.AgregarAlumnos(lista_alumnos_nuevos);
              un_curso.QuitarAlumno(un_alumno_del_curso);
              
              Assert.AreEqual(7, un_curso.Alumnos().Count());
          }

          [TestMethod]
          public void deberia_poder_actualizar_los_alumnos_de_un_curso()
          {
              List<Alumno> alumnos_viejos = new List<Alumno>();
             
              alumnos_viejos.AddRange(un_curso.Alumnos());
              
              un_curso.ActualizarAlumnosDelCurso(lista_alumnos_nuevos);

              Assert.AreEqual(5, alumnos_viejos.Count);
              Assert.AreEqual(8, un_curso.Alumnos().Count);
              Assert.AreNotEqual(alumnos_viejos, un_curso.Alumnos());
          }


          [TestMethod]
          public void deberia_poder_obtener_el_espacio_fisico_de_un_curso()
          {       
              un_curso.AgregarEspacioFisico(espacio_fisico);

              Assert.IsNotNull(un_curso.GetEspacioFisico());
          }

          [TestMethod]
          public void deberia_poder_obtener_el_dia_de_cursada_de_un_curso()
          {
              un_curso.AgregarDiaDeCursada(dia_de_la_semana);

              Assert.IsTrue(un_curso.diasDeCursada().Exists(d => d.Equals(dia_de_la_semana)));
          }

          [TestMethod]
          public void deberia_poder_obtener_el_horario_de_cursada_de_un_curso()
          {
              un_curso.AgregarHorarioDeCursada(horario_de_cursada);

              Assert.IsTrue(un_curso.GetHorariosDeCursada().Contains(horario_de_cursada));
          }

          [TestMethod]
          public void deberia_poder_obtener_el_cuatrimestre_de_cursada_de_un_curso()
          { 
              Assert.AreEqual("1°C 2013", un_curso.Cuatrimestre());
          }
    }
}
