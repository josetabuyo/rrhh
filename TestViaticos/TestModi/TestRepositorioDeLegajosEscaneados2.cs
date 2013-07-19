using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;
using NMock2;
using General.Modi;
using System.Drawing;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioDeLegajosEscaneados2
    {
        Mockery mocks;
        IFileSystem mock_del_file_system;
        IConexionBD mock_conexion; 
        IRepositorioDeLegajosEscaneados repo_legajos_escaneados;
        

        [TestInitialize]
        public void SetUp()
        {
            mocks = new Mockery();
            mock_conexion = mocks.NewMock<IConexionBD>();
            mock_del_file_system = mocks.NewMock<IFileSystem>();
            repo_legajos_escaneados = new RepositorioDeLegajosEscaneados(mock_del_file_system, mock_conexion, "imagenes");
        }

        [TestMethod]
        public void deberia_poder_obtener_una_lista_con_1_id_de_imagen_sin_asignar_del_repositorio_para_el_legajo_205939()
        {
            var pathsImagenes = new List<string>();
            pathsImagenes.Add("imagenes/205939/imagen1.jpg");
            Expect.Once.On(mock_del_file_system).Method("getPathsArchivosEnCarpeta").With("imagenes/205939").Will(Return.Value(pathsImagenes));
            Expect.AtLeastOnce.On(mock_del_file_system).Method("getImagenFromPath").With("imagenes/205939/imagen1.jpg").Will(Return.Value(new Bitmap(1, 1)));
            Expect.AtLeastOnce.On(mock_del_file_system).Method("moverArchivo");

            Expect.AtLeastOnce.On(mock_conexion).Method("EjecutarEscalar").With(new object[] { "dbo.MODI_Agregar_Imagen_Sin_Asignar_A_Un_Legajo", Is.Anything }).Will(Return.Value(12));

            string source_id_imagenes = @"  id_imagen  
                                        12";
            var resultado_sp_imagenes = TablaDeDatos.From(source_id_imagenes);

            Expect.AtLeastOnce.On(mock_conexion).Method("Ejecutar").With(new object[] { "dbo.MODI_Get_Ids_De_Imagenes_Sin_Asignar_Para_El_Legajo", Is.Anything }).Will(Return.Value(resultado_sp_imagenes));            
            
            var ids = repo_legajos_escaneados.GetIdsDeImagenesSinAsignarParaElLegajo(205939);
            Assert.AreEqual(1, ids.Count());
        }

        [TestMethod]
        public void deberia_poder_obtener_una_lista_con_2_ids_de_imagenes_sin_asignar_del_repositorio_para_el_legajo_222222()
        {
            var pathsImagenes = new List<string>();
            pathsImagenes.Add("imagenes/222222/imagen2.jpg");
            pathsImagenes.Add("imagenes/222222/imagen3.jpg");
            Expect.Once.On(mock_del_file_system).Method("getPathsArchivosEnCarpeta").With("imagenes/222222").Will(Return.Value(pathsImagenes));
            Expect.AtLeastOnce.On(mock_del_file_system).Method("getImagenFromPath").With("imagenes/222222/imagen2.jpg").Will(Return.Value(new Bitmap(1, 1)));
            Expect.AtLeastOnce.On(mock_del_file_system).Method("getImagenFromPath").With("imagenes/222222/imagen3.jpg").Will(Return.Value(new Bitmap(1, 1)));
            Expect.AtLeastOnce.On(mock_del_file_system).Method("moverArchivo");

            Expect.AtLeastOnce.On(mock_conexion).Method("EjecutarEscalar").With(new object[] { "dbo.MODI_Agregar_Imagen_Sin_Asignar_A_Un_Legajo", Is.Anything }).Will(Return.Value(12));

            string source_id_imagenes = @"  id_imagen  
                                            17
                                            23";
            var resultado_sp_imagenes = TablaDeDatos.From(source_id_imagenes);

            Expect.AtLeastOnce.On(mock_conexion).Method("Ejecutar").With(new object[] { "dbo.MODI_Get_Ids_De_Imagenes_Sin_Asignar_Para_El_Legajo", Is.Anything }).Will(Return.Value(resultado_sp_imagenes));            
            
            var imagenes = repo_legajos_escaneados.GetIdsDeImagenesSinAsignarParaElLegajo(222222);
            Assert.AreEqual(2, imagenes.Count());
        }
    }
}
