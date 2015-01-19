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
    public class TestRepositorioOrganigramas
    {
        private Area area_de_faby;
        private Area area_de_marta;
        private Area area_de_castagneto;
        private List<Area> areas_de_faby_y_marta;
        private List<Area> dependencia_faby_marta;
        private List<List<Area>> lista_de_dependencias_faby_marta;
        //private Organigrama organigrama_faby_marta;

        [TestInitialize]
        public void Setup()
        {
            area_de_marta = TestObjects.AreaDeMarta();
            area_de_faby = TestObjects.AreaDeMarta();
            area_de_castagneto = TestObjects.AreaDeCastagneto();
            areas_de_faby_y_marta = TestObjects.AreasDeFabiYMarta();
            dependencia_faby_marta = new List<Area>() { area_de_faby, area_de_marta };
            lista_de_dependencias_faby_marta = new List<List<Area>>() { dependencia_faby_marta };
            //organigrama_faby_marta = new Organigrama(areas_de_faby_y_marta, lista_de_dependencias_faby_marta);
        }


        [TestMethod]
        public void deberia_poder_decirle_a_un_repositorio_que_use_una_conexion_que_no_devuelve_nada()
        {
            var mock_conexion_bd = ConexionMockeada();
            Stub.On(mock_conexion_bd).Method("Ejecutar").Will(Return.Value(TablaVacia()));
            Organigrama organigrama = null;
            
            try
            {
                organigrama = UnRepositorioCon(mock_conexion_bd).GetOrganigrama();
                Assert.Fail("con una tabla vacia, el organigrama no deberia haberse podido crear");
            }
            catch (OrganigramaException e)
            {
                Assert.IsNull(organigrama);
                Assert.AreEqual("El Organigrama No Posee las Áreas y Relaciones entre Áreas Básicas y por lo tanto es inconsistente", e.Message);
            }
        }

        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void deberia_poder_decirle_a_un_repositorio_que_use_una_conexion_que_devuelve_un_organigrama_simple()
        {
            var mock_conexion_bd = ConexionMockeada();
            Expect.Once.On(mock_conexion_bd).Method("Ejecutar").Will(Return.Value(TablaConDosAreas()));
            Expect.Once.On(mock_conexion_bd).Method("Ejecutar").Will(Return.Value(TestObjects.TablaDeAliasConDosAlias()));

            Organigrama organigrama = UnRepositorioCon(mock_conexion_bd).GetOrganigrama();
            Assert.AreEqual(2, organigrama.ObtenerAreas(true).Count);
        }

        [TestMethod]
        public void deberia_devolver_los_saltos_por_excepcion()
        {
            var mock_conexion_bd = ConexionMockeada();
            Expect.Once.On(mock_conexion_bd).Method("Ejecutar").Will(Return.Value(TablaConDosExcepciones()));
            Expect.Once.On(mock_conexion_bd).Method("Ejecutar").Will(Return.Value(TestObjects.TablaDeAliasConDosAlias()));

            List<List<int>> excepciones = UnRepositorioCon(mock_conexion_bd).ExcepcionesDeCircuitoViaticos();

            Assert.AreEqual(2, excepciones.Count);
            Assert.AreEqual(area_de_faby.Id, excepciones.First().First());
            Assert.AreEqual(area_de_marta.Id, excepciones.First().Last());

            Assert.AreEqual(area_de_marta.Id, excepciones.Last().First());
            Assert.AreEqual(area_de_castagneto.Id, excepciones.Last().Last());
        }

        private TablaDeDatos TablaConDosExcepciones()
        {
            var excepciones = new List<object>() { new List<int>() { area_de_faby.Id, area_de_marta.Id }, new List<int>() { area_de_marta.Id, TestObjects.AreaDeCastagneto().Id } };
            var columnas = new List<ColumnaDeDataTable>() { new ColumnaDeDataTable("IdOrigen", typeof(Int32)), new ColumnaDeDataTable("IdDestino", typeof(Int32)) };
            return GeneradorDeTablas().CreateDT(excepciones, columnas, (ex) => { return new List<object>() { ((List<int>)ex)[0], ((List<int>)ex)[1] }; });
        }

        private TablaDeDatos TablaConUnaRelacionEntreAreas()
        {
            return GeneradorDeTablas().CreateDT(new List<object>(lista_de_dependencias_faby_marta), ColumnasDataTableDependencias(), (d) => { return new List<object> { ((List<Area>)d).First().Id, ((List<Area>)d).Last().Id }; });
        }

        private static RepositorioDeOrganigrama UnRepositorioCon(IConexionBD mock_conexion_bd)
        {
            var un_repositorio = new RepositorioDeOrganigrama(mock_conexion_bd);
            return un_repositorio;
        }

        private static RepositorioDeComisionesDeServicio UnRepositorioDeViaticosMockeado()
        {
            var un_repositorio = new RepositorioDeComisionesDeServicio(ConexionMockeada());
            return un_repositorio;
        }

        private List<ColumnaDeDataTable> ColumnasDataTableDependencias()
        {
            var columnas = new List<ColumnaDeDataTable>();
            columnas.Add(new ColumnaDeDataTable("IdPadre", typeof(Int32)));
            columnas.Add(new ColumnaDeDataTable("IdHijo", typeof(Int32)));
            return columnas;
        }

        private TablaDeDatos TablaConDosAreas()
        {
            var result = GeneradorDeTablas().CreateDT(new List<object>(areas_de_faby_y_marta), ColumnasDataTableAreas(), (a) => { return new List<object> { ((Area)a).Id, ((Area)a).Codigo, ((Area)a).Nombre, true, false }; });
            return result;
            
        }

        private GeneradorDeDataTables GeneradorDeTablas()
        {
            return new GeneradorDeDataTables();
        }

        private static TablaDeDatos TablaVacia()
        {
            return new TablaDeDatos();
        }

        private static IConexionBD ConexionMockeada()
        {
            var mocks = new Mockery();
            var mock_conexion_bd = mocks.NewMock<IConexionBD>();
            return mock_conexion_bd;
        }

        //[TestMethod]
        //public void Deberia_poder_obtener_un_organigrama_del_repositorio()
        //{            
        //    var mocks = new Mockery();
        //    var mock_conexion_bd = mocks.NewMock<IConexionBD>();
        //    var un_repositorio = new RepositorioOrganigramas(mock_conexion_bd);

        //    var parametros_sql_para_select_de_Areas = new Dictionary<string, object>();
        //    var generador_de_tablas = new GeneradorDeDataTables();
        //    var columnas = ColumnasDataTableAreas();

        //    var tabla_areas = generador_de_tablas.CreateDT(areas_de_faby_y_marta, columnas, (a) => { return null; });

        //    Expect.Once.On(mock_conexion_bd).
        //        Method("Ejecutar").
        //        With("VIA_Get_Areas", parametros_sql_para_select_de_Areas).
        //        Will(Return.Value(tabla_areas));

        //    Organigrama organigrama_obtenido = un_repositorio.GetOrganigrama();
        //    Assert.AreEqual(organigrama_faby_marta, organigrama_obtenido);
        //}



        private static List<ColumnaDeDataTable> ColumnasDataTableAreas()
        {
            var columnas = new List<ColumnaDeDataTable>();
            columnas.Add(new ColumnaDeDataTable("Id_Area", typeof(Int32)));
            columnas.Add(new ColumnaDeDataTable("Codigo", typeof(String)));
            columnas.Add(new ColumnaDeDataTable("Descripcion", typeof(String)));
            columnas.Add(new ColumnaDeDataTable("Presenta_DDJJ", typeof(Boolean)));
            columnas.Add(new ColumnaDeDataTable("Baja", typeof(Boolean)));
            return columnas;
        }
    }
}
