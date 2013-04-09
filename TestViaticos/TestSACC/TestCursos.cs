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

        ManagerDeCalendarios managerDeCalendarios;
        CalendarioDeFeriados unCalendarioGlobal = new CalendarioDeFeriados();

        [TestInitialize]
        public void Setup()
        {
            managerDeCalendarios = new ManagerDeCalendarios(unCalendarioGlobal);
        }


          [TestMethod]
          public void deberia_poder_obtener_los_alumnos_de_un_curso()
          {

              IConexionBD conexion = TestObjects.ConexionMockeada();

              RepositorioDeCursos repo = new RepositorioDeCursos(conexion);

              Curso un_curso = TestObjects.UnCursoConAlumno();
             
              Assert.AreEqual(5, un_curso.Alumnos().Count());
          }

          [TestMethod]
          public void deberia_poder_agregar_alumnos_a_un_curso()
          {

              IConexionBD conexion = TestObjects.ConexionMockeada();

              RepositorioDeCursos repo = new RepositorioDeCursos(conexion);

              Curso un_curso = TestObjects.UnCursoConAlumno();

              List<Alumno> lista_alumnos = TestObjects.Alumnos();

              un_curso.AgregarAlumnos(lista_alumnos);

              Assert.IsTrue(repo.ModificarCurso(un_curso));
              Assert.AreEqual(8, un_curso.Alumnos().Count());
          }

          [TestMethod]
          public void deberia_poder_obtener_el_espacio_fisico_de_un_curso()
          {
              Curso un_curso = TestObjects.UnCursoConAlumno();
              EspacioFisico espacio_fisico = new EspacioFisico();
              un_curso.AgregarEspacioFisico(espacio_fisico);

              Assert.IsNotNull(un_curso.GetEspacioFisico());
          }

          [TestMethod]
          public void deberia_poder_obtener_el__de_un_curso()
          {
              Curso un_curso = TestObjects.UnCursoConAlumno();
              DayOfWeek dia_de_la_semana = new DayOfWeek();
              un_curso.AgregarDiaDeCursada(dia_de_la_semana);

              Assert.IsNotNull(un_curso.GetHorariosDeCursada());
          }

          [TestMethod]
          public void deberia_poder_actualizar_los_alumnos_de_un_curso()
          {
              Curso un_curso = TestObjects.UnCursoConAlumno();
              List<Alumno> alumnos_viejos = new List<Alumno>();
                  alumnos_viejos.AddRange(un_curso.Alumnos());
              List<Alumno> alumnos_nuevos = new List<Alumno>();
              Modalidad modalidad = new Modalidad(1, "Fines");
              Alumno un_alumno_nuevo = new Alumno(100, "Andrea", "Bruzos", 13500315, "3969-8706", "belen.cevey@gmail.com", "Peron 525", TestObjects.AreaDeFabi(), modalidad);
              alumnos_nuevos.Add(un_alumno_nuevo);
              un_curso.ActualizarAlumnosDelCurso(alumnos_nuevos);

              Assert.AreNotEqual(alumnos_viejos.Count, un_curso.Alumnos().Count);
          }



    }
}
