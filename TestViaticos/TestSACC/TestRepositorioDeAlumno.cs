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
    public class TestRepositorioDeAlumno
    {

        [TestMethod]
        public void MyTestMethod()
        {
            string source = @"      |Id     |Documento   |Apellido     |Nombre     |Telefono      |Mail     |Direccion  |IdModalidad  |ModalidadDescripcion |IdArea |NombreArea                         |IdBaja
                                    |01     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |0      |Ministerio de Desarrollo Social    |0
                                    |02     |31041236    |Caino        |Fernando   |A222          |fer@ar   |Av         |1            |fines                |1      |Unidad Ministrio                   |0
                                    |05     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |1      |Unidad Ministrio                   |0
                                    |03     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |621    |Secretaría de Deportes             |0";

            var mocks = new Mockery();
            var conexion = mocks.NewMock<IConexionBD>();
            var repo_alumno = new RepositorioDeAlumnos(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoModalidadesMockeado());
            var resultado = TablaDeDatos.From(source);

            Expect.Once.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado));

            repo_alumno.GetAlumnos();
            var alumnos = repo_alumno.GetAlumnos();

            mocks.VerifyAllExpectationsHaveBeenMet();
            Assert.AreEqual(2, alumnos.Count);
        }


        [TestMethod]
        public void MyTestMethod2()
        {
            string source = @"      |Id     |Documento   |Apellido     |Nombre     |Telefono      |Mail     |Direccion  |IdModalidad  |ModalidadDescripcion |IdArea |NombreArea                         |IdBaja
                                    |01     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |0      |Ministerio de Desarrollo Social    |0";

            var mocks = new Mockery();
            var conexion = mocks.NewMock<IConexionBD>();
            var repo_alumno = new RepositorioDeAlumnos(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoModalidadesMockeado());
            var resultado = TablaDeDatos.From(source);
            resultado.Clear();

            Expect.Once.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado));

            repo_alumno.GetAlumnos();
            var alumnos = repo_alumno.GetAlumnos();
            alumnos = repo_alumno.GetAlumnos();

            mocks.VerifyAllExpectationsHaveBeenMet();
            Assert.AreEqual(0, alumnos.Count);
        }
    }
}
