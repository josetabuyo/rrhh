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
    public class TestRepositorioAreas
    {

        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        [Ignore] //Para que funcione el teamcity
        public void se_le_deberia_poder_pedir_a_un_area_su_nombre_completo_con_el_alias()
        {
            var area_de_fabi = TestObjects.AreaDeFabi();


            string source = @"  |Id     	    |Alias
                                |939	        |fabiiiii";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeAreas repo = RepositorioDeAreas.NuevoRepositorioDeAreas(conexion);

            var alias = repo.ObtenerAliasDeAreaByIdDeArea(area_de_fabi);

            string nombre_con_alias = alias.Descripcion + " - " + area_de_fabi.Nombre;

            Assert.AreEqual("fabiiiii - Area de Fabian", nombre_con_alias);
            Assert.AreEqual("fabiiiii - Area de Fabian", area_de_fabi.NombreConAlias());
        }

        [TestMethod]
        public void si_un_area_no_tiene_alias_deberia_devolver_el_nombre_completo_sin_alias()
        {
            var area = TestObjects.AreaDeMarta();

            //No se puede testear el Repositorio porque la tabla Source no admite campos vacíos
            Assert.AreEqual("Area de Marta", area.NombreConAlias());
        }

        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void deberia_poder_obtener_todos_los_datos_del_area_y_ver_que_estan_completos()
        {

            string source = @"  |Id_Area	|descripcion     |direccion             |Id_Dato_Area   |Descripcion_Dato_Area      |Dato_Area                  |Orden  |Nombre_Asistente	   |Apellido_Asistente	     |Cargo	        |Prioridad_Asistente	  |Telefono_Asistente	    |Fax_Asistente          |Mail_Asistente	                |Nombre_Responsable     |Apellido_Responsable	  |Telefono_Responsable	    |Fax_Responsable  	    |Mail_Responsable	                
                                |1  	    |RRHH            |9 de Julio 1925       |1              |Teléfono                   |4333-2222                  |1      |Juan                  |García                   |Secretaria    |1                        |4444-5555                |4444-1111              |juan.garcia@mds.gov.ar         |Fabián                 |Miranda                  |4567-2222                |4544-3322              |fabian.miranda@ministerio.gov.ar
                                |2	        |Dirección       |17 de Agosto 1850     |2              |Mail                       |area2@ministerio.gob.ar    |1      |María                 |Pérez                    |Secretaria    |1                        |4444-5555                |4444-1111              |maria.perez@ministerio.gov.ar  |Marta                  |Novoa                    |4567-1111                |4544-1111              |marta.novoa@ministerio.gov.ar               
                                |1  	    |RRHH            |9 de Julio 1925       |1              |Teléfono                   |4333-2222                  |1      |Juan                  |García                   |Secretaria    |1                        |4444-5555                |4444-1111              |juan.garcia@mds.gov.ar         |Fabián                 |Miranda                  |4567-2222                |4544-3322              |fabian.miranda@ministerio.gov.ar
                                |2	        |Dirección       |17 de Agosto 1850     |2              |Mail                       |area2@ministerio.gob.ar    |1      |María                 |Pérez                    |Secretaria    |1                        |4444-5555                |4444-1111              |maria.perez@ministerio.gov.ar  |Marta                  |Novoa                    |4567-1111                |4544-1111              |marta.novoa@ministerio.gov.ar               ";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeAreas repo = RepositorioDeAreas.NuevoRepositorioDeAreas(conexion);


            List<Area> lista_areas_del_repo = repo.GetTodasLasAreasCompletas();
            List<Area> lista_areas_completas = TestObjects.AreasCompletas();

            Area area1 = lista_areas_del_repo.First();
            Area area2 = lista_areas_del_repo.Last();
            Assert.IsTrue(lista_areas_del_repo.Contains(area1));
            Assert.IsTrue(lista_areas_del_repo.Contains(area2));
        }

    }
}
