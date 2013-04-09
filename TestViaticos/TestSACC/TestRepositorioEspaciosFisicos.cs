using System.Linq;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using General.Repositorios;
using General.Calendario;
using General;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using NMock2;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioEspaciosFisicos
    {

        private IConexionBD conexionMock;
        [TestInitialize]
        public void SetUp()
        {
            conexionMock = TestObjects.ConexionMockeada();
        }     

          [TestMethod]
          public void deberia_poder_obtener_todos_los_espacios_fisicos_que_no_estan_dados_de_baja_del_repositorio_de_espacios_fisicos()
            {

                string source = @"  |Id     |Aula   |idEdificio     |NombreEdificio     |DireccionEdificio      |NumeroEdificio     |Capacidad  |idusuario     |Fecha                      |idBaja
                                    |01     |03     |01             |Evita              |9 de Julio             |1020               |30         |1111          |2012-10-13 21:36:35.077    |0
                                    |02     |Magna  |10             |San Martín         |Santa Fe 504           |504                |100        |1111          |2012-10-13 21:36:35.077    |0
                                    |03     |315    |03             |Perón              |Santa Fe 504           |504                |25         |1111          |2012-10-13 21:36:35.077    |0";

                IConexionBD conexion = TestObjects.ConexionMockeada();
                var resultado_sp = TablaDeDatos.From(source);

                Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

                RepositorioDeEspaciosFisicos repo = new RepositorioDeEspaciosFisicos(conexion);

                Assert.AreEqual(3, repo.GetEspaciosFisicos().Count);
            }


          [TestMethod]
          public void deberia_poder_obtener_todos_los_edificios_que_no_estan_dados_de_baja_del_repositorio_de_espacios_fisicos()
          {

              string source = @"    |Id     |Nombre     |Calle          |Numero     |Piso      |Departamento    |idusuario     |Fecha                      |idBaja
                                    |01     |Evita      |9 de Julio     |1020       |PB        |0               |1111          |2012-10-13 21:36:35.077    |0
                                    |02     |San Martín |Santa Fe       |504        |3         |A               |1111          |2012-10-13 21:36:35.077    |0
                                    |03     |Perón      |Santa Fe       |504        |4         |B               |1111          |2012-10-13 21:36:35.077    |0";

              IConexionBD conexion = TestObjects.ConexionMockeada();
              var resultado_sp = TablaDeDatos.From(source);

              Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

              RepositorioDeEspaciosFisicos repo = new RepositorioDeEspaciosFisicos(conexion);

              Assert.AreEqual(3, repo.GetEdificios().Count);
              Assert.AreEqual(repo.GetEdificios().First().Direccion, "9 de Julio 1020 Piso: PB Dto: 0");
          }
    }
}
