using System.Linq;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioCursos
    {

        ManagerDeCalendarios managerDeCalendarios;
        CalendarioDeFeriados unCalendarioGlobal = new CalendarioDeFeriados();

        [TestInitialize]
        public void Setup()
        {
            managerDeCalendarios = new ManagerDeCalendarios(unCalendarioGlobal);
        }




          [TestMethod]
          public void deberia_poder_obtener_un_curso_del_repositorio_de_cursos()
            {

                IConexionBD conexion = TestObjects.ConexionMockeada();

                RepositorioDeCursos repo = new RepositorioDeCursos(conexion);

                Assert.AreEqual("Historia", repo.GetCursoById(1).Nombre);
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


    }
}
