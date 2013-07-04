using System.Linq;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using General.Calendario;


using NMock2;

namespace TestViaticos
{

    [TestClass]
    public class TestAlumnos
    {

        private IConexionBD conexionMock;
        [TestInitialize]
        public void SetUp()
        {
            conexionMock = TestObjects.ConexionMockeada();
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

        [TestMethod]
        public void cuando_un_alumno_pertenece_a_3_areas_deberia_pedirle_las_areas_y_devolverme_3()
        {
            string source = @"      |Id     |Documento   |Apellido     |Nombre     |Telefono      |Mail     |Direccion  |IdModalidad  |ModalidadDescripcion |IdArea |NombreArea                         |IdBaja
                                    |01     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |0      |Ministerio de Desarrollo Social    |0
                                    |02     |31041236    |Caino        |Fernando   |A222          |fer@ar   |Av         |1            |fines                |1      |Unidad Ministrio                   |0
                                    |05     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |1      |Unidad Ministrio                   |0
                                    |03     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |621    |Secretaría de Deportes             |0";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeAlumnos repo = new RepositorioDeAlumnos(conexion);
            Alumno belen = new Alumno();
            List<Alumno> lista_de_alumnos = repo.GetAlumnos();
            belen = lista_de_alumnos.Find(a => a.Documento.Equals(31507315));

            Assert.AreEqual(3, belen.Areas.Count);
        }

    }
}
