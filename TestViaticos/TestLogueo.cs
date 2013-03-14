using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using NMock2;

namespace TestViaticos
{
    [TestClass]
    public class TestLogueo
    {


        [TestMethod]
        public void deberia_devolver_los_datos_de_Contacto_de__un_area_con_su_responsable_y_datos_de_contacto()
        {
            string source = @"  |Id_Usuario    |es_firmante|Id_Area     |nombre_area      |Responsable       |Contacto_Area      |Nro_Orden   |Descripcion_Cargo   |Telefono   |Mail                            | Direccion         |
                                |1             |1          |1           |Area 1           |Fabián Miranda    |Laura Sánchez      |1           |Secretaria          |4589-5678  |FMIRANDA@desarrollosocial.gob.ar|Av. 9 de Julio 1925|";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioUsuarios repo = new RepositorioUsuarios();

            List<ContactoArea> contacto_area = repo.LoginUsuario();

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
            string source = @"  |Id_Area     |Responsable       |Contacto_Area      |Nro_Orden   |Descripcion_Cargo   |Telefono   |Mail                            | Direccion         |
                                |1           |Fabián Miranda    |Laura Sánchez      |1           |Secretaria          |4589-5678  |FMIRANDA@desarrollosocial.gob.ar|Av. 9 de Julio 1925|
                                |1           |Fabián Miranda    |Juan Pérez         |2           |Asesor              |4589-5678  |FMIRANDA@desarrollosocial.gob.ar|Av. 9 de Julio 1925|";


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
            string source = @"  |Id_Area     |Responsable       |Contacto_Area      |Nro_Orden   |Descripcion_Cargo   |Telefono   |Mail                            | Direccion         |
                                |1           |Fabián Miranda    |Laura Sánchez      |1           |Secretaria          |4589-5678  |FMIRANDA@desarrollosocial.gob.ar|Av. 9 de Julio 1925|
                                |2           |Fabián Miranda    |Ana García         |1           |Secretaria          |4200-5000  |FMIRANDA@MDS.gob.ar             |Córdoba 1900       |";


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
            string source =
                @"  |Id_Area     |Responsable       |Contacto_Area      |Nro_Orden   |Descripcion_Cargo   |Telefono   |Mail                            | Direccion         |";


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
            string source = @"  |Id_Area     |Responsable       |Contacto_Area      |Nro_Orden   |Descripcion_Cargo   |Telefono   |Mail                            | Direccion         |
                                |1           |Fabián Miranda    |Laura Sánchez      |1           |Secretaria          |4589-5678  |FMIRANDA@desarrollosocial.gob.ar|Av. 9 de Julio 1925|
                                |1           |Fabián Miranda    |Juan Pérez         |2           |Asesor              |4589-5678  |FMIRANDA@desarrollosocial.gob.ar|Av. 9 de Julio 1925|
                                |2           |Fabián Miranda    |Ana García         |1           |Secretaria          |4200-5000  |FMIRANDA@MDS.gob.ar             |Córdoba 1900       |";


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
   }
}
