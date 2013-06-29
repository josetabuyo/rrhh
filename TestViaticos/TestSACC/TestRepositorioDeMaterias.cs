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
    public class TestRepositorioDeMaterias
    {

        private IConexionBD conexionMock;
        [TestInitialize]
        public void SetUp()
        {
            conexionMock = TestObjects.ConexionMockeada();
        }     

          [TestMethod]
          public void deberia_poder_obtener_todas_materias()
            {

                string source = @"  |Id     |Nombre   |IdModalidad  |ModalidadDescripcion |idInstancia   |DescripcionInstancia     |idCiclo     |NombreCiclo
                                    |01     |Física   |1	        |Fines Puro	          |6	         |Calificación Final       |1           |Primer Ciclo
                                    |02     |Química  |2	        |Fines CENS	          |1	         |1° Evaluación            |1           |Primer Ciclo
                                    |03     |Historia |2	        |Fines CENS	          |2	         |2° Evaluación            |1           |Primer Ciclo";

                
              IConexionBD conexion = TestObjects.ConexionMockeada();
              var resultado_sp = TablaDeDatos.From(source);

                Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

                RepositorioDeMaterias repo = new RepositorioDeMaterias(conexion);

                Assert.AreEqual(3, repo.GetMaterias().Count);
            }
    }
}
