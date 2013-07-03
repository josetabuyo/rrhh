using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;


using NMock2;

namespace TestViaticos
{
    [TestClass]
    public class TestRepositorioZonas
    {

        //TestZonas
        [TestMethod]
        public void TestGetZonas()
        {

            //creador_de_datos.AddData("VIA_Zonas.xml");
            //RepositorioZonas repositorio = new RepositorioZonas();
            //List<Zona> zonas = new List<Zona>();
            //zonas = repositorio.GetTodasLasZonas();

            //Assert.AreEqual(6, zonas.Count());
        }


        [TestMethod]
        public void deberia_devolver_region_METRO_con_BuenosAires_con_una_localidad()
        {
            string source = @"  |IdZona     |NombreZona         |IdProvincia        |NombreProvincia   |IdLocalidad    |NombreLocalidad|
                                |1          |Metro              |2                  |Buenos Aires      |3              |Capital        |";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioZonas repo = new RepositorioZonas(conexion);

            List<Zona> zonas = repo.GetTodasLasZonas();

            Assert.AreEqual(1, zonas.Count);
            Assert.AreEqual(1, zonas[0].Provincias.Count);
            Assert.AreEqual(1, zonas[0].Provincias[0].Localidades.Count);
            Assert.AreEqual(1, zonas[0].Id);
            Assert.AreEqual(2, zonas[0].Provincias[0].Id);
            Assert.AreEqual(3, zonas[0].Provincias[0].Localidades[0].Id);

        }

        [TestMethod]
        public void deberia_devolver_region_METRO_con_BuenosAires_con_una_localidad_con_id_4()
        {
            string source = @"  |IdZona     |NombreZona         |IdProvincia        |NombreProvincia   |IdLocalidad    |NombreLocalidad|
                                |1          |Metro              |7                  |Buenos Aires      |4              |Capital        |";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioZonas repo = new RepositorioZonas(conexion);

            List<Zona> zonas = repo.GetTodasLasZonas();

            Assert.AreEqual(7, zonas[0].Provincias[0].Id);
            Assert.AreEqual(4, zonas[0].Provincias[0].Localidades[0].Id);

        }



        [TestMethod]
        public void deberia_devolver_Buenos_Aires_con_dos_localidades()
        {
            string source = @"  |IdZona     |NombreZona         |IdProvincia     |NombreProvincia   |IdLocalidad    |NombreLocalidad|
                                |1          |Metro              |7               |Buenos Aires      |4              |Capital        |
                                |1          |Metro              |7               |Buenos Aires      |5              |Capital        |";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioZonas repo = new RepositorioZonas(conexion);

            List<Zona> zonas = repo.GetTodasLasZonas();

            Assert.AreEqual(2, zonas[0].Provincias[0].Localidades.Count);
            Assert.AreEqual(4, zonas[0].Provincias[0].Localidades[0].Id);
            Assert.AreEqual(5, zonas[0].Provincias[0].Localidades[1].Id);

        }

        [TestMethod]
        [Ignore] //("Todavía no implementamos Tablas Vacías")
        public void deberia_devolver_ninguna_zona()
        {
            string source = @"  |IdZona     |NombreZona         |IdProvincia        |NombreProvincia    |IdLocalidad    |NombreLocalidad|";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioZonas repo = new RepositorioZonas(conexion);

            List<Zona> zonas = repo.GetTodasLasZonas();

            Assert.AreEqual(0, zonas.Count);
        }



        [TestMethod]
        public void deberia_devolver_la_zona_Metro_con_una_localidad_y_la_zona_Patagonia_con_una_localidad()
        {
            string source = @"  |IdZona     |NombreZona         |IdProvincia        |NombreProvincia    |IdLocalidad |NombreLocalidad|
                                |1          |Metro              |7                  |Buenos Aires       |4           |Capital        |
                                |2          |Patagonia          |8                  |Chubut             |5           |Rawson         |";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioZonas repo = new RepositorioZonas(conexion);

            List<Zona> zonas = repo.GetTodasLasZonas();

            Assert.AreEqual(2, zonas.Count);
            Assert.AreEqual(1, zonas[0].Provincias[0].Localidades.Count);
            Assert.AreEqual(1, zonas[1].Provincias[0].Localidades.Count);
            Assert.AreEqual(4, zonas[0].Provincias[0].Localidades[0].Id);
            Assert.AreEqual(5, zonas[1].Provincias[0].Localidades[0].Id);
            Assert.AreEqual("Buenos Aires", zonas[0].Provincias[0].Nombre);
            Assert.AreEqual("Chubut", zonas[1].Provincias[0].Nombre);
            Assert.AreEqual("Capital", zonas[0].Provincias[0].Localidades[0].Nombre);
            Assert.AreEqual("Rawson", zonas[1].Provincias[0].Localidades[0].Nombre);

        }


        [TestMethod]
        public void deberia_devolver_la_zona_Metro_con_dos_provincias_diferentes()
        {
            string source = @"  |IdZona     |NombreZona         |IdProvincia        |NombreProvincia    |IdLocalidad   |NombreLocalidad|
                                |1          |Metro              |7                  |Buenos Aires       |4             |Capital        |
                                |1          |Metro              |8                  |La Pampa           |5             |Santa Rosa     |";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioZonas repo = new RepositorioZonas(conexion);

            List<Zona> zonas = repo.GetTodasLasZonas();

            Assert.AreEqual(2, zonas[0].Provincias.Count);
            Assert.AreEqual(1, zonas[0].Provincias[0].Localidades.Count);
            Assert.AreEqual(1, zonas[0].Provincias[1].Localidades.Count);
            Assert.AreEqual(4, zonas[0].Provincias[0].Localidades[0].Id);
            Assert.AreEqual(5, zonas[0].Provincias[1].Localidades[0].Id);
        }



        //private static TablaDeDatos CrearResultadoSP()
        //{
        //            var resultado_sp = new TablaDeDatos();
        //            resultado_sp.Columns.Add("IdZona", typeof(int));
        //            resultado_sp.Columns.Add("IdProvincia", typeof(int));
        //            resultado_sp.Columns.Add("IdLocalidad", typeof(int));



        //            //tabla_viatico.LoadDataRow(new object[] {
        //            //    1,1,1
        //            //});
        //return resultado_sp;
        //}




    }
}
