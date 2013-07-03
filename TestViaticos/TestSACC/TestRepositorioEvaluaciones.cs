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
    public class TestRepositorioEvaluaciones
    {

        private IConexionBD conexionMock;
        [TestInitialize]
        public void SetUp()
        {
           conexionMock = TestObjects.ConexionMockeada();
        }

        [TestMethod]
        public void deberia_poder_obtener_todas_las_evaluaciones()
        {

            string source = @"  |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      |IdModalidad  |BajaAlumno |BajaDocente |IdArea    |NombreArea |Id |Documento  |Apellido     |Nombre     |Telefono      |Mail     |Direccion |idBaja
                                |287872   |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    |01           |0          |0           |01        |RRHH       |1  |31507315   |Cevey        |Belén      |A111          |belen@ar |Calle     |0
                                |287872   |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    |01           |0          |0           |01        |RRHH       |1  |31041236   |Caino        |Fernando   |A222          |fer@ar   |Av        |0
                                |284165   |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    |01           |0          |0           |01        |RRHH       |1  |31507315   |Cevey        |Belén      |A111          |belen@ar |Calle     |0
                                |284165   |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    |01           |0          |0           |01        |RRHH       |1  |31507315   |Cevey        |Belén      |A111          |belen@ar |Calle     |0
                                |284165   |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    |01           |0          |0           |01        |RRHH       |1  31507315|   |Cevey        |Belén      |A111          |belen@ar |Calle     |0";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion);

            Assert.AreEqual(5, repo.GetEvaluaciones().Count);
        }
           
    }
}
