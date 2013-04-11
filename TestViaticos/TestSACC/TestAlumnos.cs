using System.Linq;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestViaticos
{

    [TestClass]
    public class TestAlumnos
    {

        [TestInitialize]
        public void Setup()
        {
            
        }

        //ESTE TEST CUANDO PERSISTAMOS VA A FALLAR XQ YA TIENE ALUMNOS CARGADOS
        [TestMethod]
        public void deberia_poder_agregar_alumnos()
        {
            //SE HACE EN CURSOS

            //IConexionBD conexion = TestObjects.ConexionMockeada();

            //RepositorioDeAlumnos repo = new RepositorioDeAlumnos(conexion);

            //repo.GuardarAlumno(TestObjects.UnAlumnoFer(), new Usuario());

            //Assert.AreEqual(4, repo.GetAlumnos().Count());
        }

        [TestMethod]
        public void deberia_poder_quitar_alumnos()
        {
           //SE HACE EN CURSOS
            
            //IConexionBD conexion = TestObjects.ConexionMockeada();

            //RepositorioDeAlumnos repo = new RepositorioDeAlumnos(conexion);

            //repo.QuitarAlumno(new Alumno(), new Usuario());

            //Assert.AreEqual(2, repo.GetAlumnos().Count());
        }



    }
}
