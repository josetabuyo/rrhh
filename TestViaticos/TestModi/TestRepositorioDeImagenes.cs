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

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioDeImagenes
    {
        IFileSystem mock_del_file_system;
        IRepositorioDeLegajosEscaneados repo_imagenes;
        Dictionary<string, List<string>> mock_filesystem_data;

        private IRepositorioDeLegajosEscaneados repo_de_imagenes()
        {
            if (repo_imagenes == null)
                return new RepositorioDeLegajosEscaneados(mockearFileSystem(mock_filesystem_data.Keys.First(), mock_filesystem_data.Values.First()), "imagenes");
            return repo_imagenes;
        }

        private IFileSystem mockearFileSystem(string path_legajo , List<string> imagenes_legajo)
        {
            if (mock_del_file_system == null)
            {
                var mocks = new Mockery();
                mock_del_file_system = mocks.NewMock<IFileSystem>();
                Expect.AtLeastOnce.On(mock_del_file_system).Method("getFiles").With(new object[] { path_legajo }).Will(Return.Value(imagenes_legajo));
                return mock_del_file_system;
            }
            return mock_del_file_system;
        }

        [TestMethod]
        public void deberia_poder_obtener_una_lista_con_3_imagenes_del_repositorio_para_el_legajo_205939()
        {
            mock_filesystem_data = new Dictionary<string, List<string>>() {{ "imagenes/205939", new List<string>() { "imagenes/205939/imagen1.jpg", 
                                                                "imagenes/205939/imagen2.jpg", 
                                                                "imagenes/205939/imagen3.jpg" }}};

            var imagenes = repo_de_imagenes().getThumbnailsParaUnLegajo(205939);

            Assert.AreEqual(3, imagenes.Count());
        }

        [TestMethod]
        public void deberia_poder_obtener_una_lista_con_2_imagenes_del_repositorio_para_el_legajo_203404()
        {
            mock_filesystem_data = new Dictionary<string, List<string>>() {{ "imagenes/203404", new List<string>() { "imagenes/205939/imagen1.jpg", 
                                                                "imagenes/205939/imagen2.jpg" }}};

            var imagenes = repo_de_imagenes().getThumbnailsParaUnLegajo(203404);
            
            Assert.AreEqual(2, imagenes.Count());
        }

        [TestMethod]
        public void las_imagenes_para_el_legajo_203404_deberian_incluir_una_que_se_llame_Koala()
        {
            mock_filesystem_data = new Dictionary<string, List<string>>() {{ "imagenes/203404", new List<string>() { "imagenes/205939/imagen1.jpg" }}};

            var imagenes = repo_de_imagenes().getThumbnailsParaUnLegajo(203404);
            
            Assert.IsTrue(imagenes.Any(imagen => imagen.nombre == "imagen1"));
        }

        //[TestMethod]
        //public void el_repositorio_deberia_devolver_una_lista_con_cero_imagenes_para_el_legajo_111111_que_no_tiene_carpeta()
        //{
        //    mock_filesystem_data = new Dictionary<string, List<string>>() { { "imagenes/203404", new List<string>() { "imagenes/205939/imagen1.jpg" } } };

        //    var imagenes = repo_de_imagenes().getImagenesParaUnLegajo(111111);

        //    Assert.AreEqual(0, imagenes.Count());
        //}
    }
}
