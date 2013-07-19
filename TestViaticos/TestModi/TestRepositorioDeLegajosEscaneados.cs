//using System;
//using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using General.Repositorios;
//using General.Calendario;
//using General;
//using NMock2;
//using General.Modi;
//using System.Drawing;

//namespace TestViaticos
//{

//    [TestClass]
//    public class TestRepositorioDeLegajosEscaneados
//    {
//        IFileSystem mock_del_file_system;
//        IRepositorioDeLegajosEscaneados repo_imagenes;
//        Dictionary<string, List<string>> mock_filesystem_data;

//        private IRepositorioDeLegajosEscaneados repo_de_legajos_escaneados()
//        {
//            if (repo_imagenes == null)
//            {
//                string sourceImagenes = @"      nombre_imagen       |bytes_imagen
//                                                imagen1             |R0lGODlhUAAPAKIAAAsLav///88PD9WqsYmApmZmZtZfYmdakyH5BAQUAP8ALAAAAABQAA8AAAPbWLrc/jDKSVe4OOvNu/9gqARDSRBHegyGMahqO4R0bQcjIQ8E4BMCQc930JluyGRmdAAcdiigMLVrApTYWy5FKM1IQe+Mp+L4rphz+qIOBAUYeCY4p2tGrJZeH9y79mZsawFoaIRxF3JyiYxuHiMGb5KTkpFvZj4ZbYeCiXaOiKBwnxh4fnt9e3ktgZyHhrChinONs3cFAShFF2JhvCZlG5uchYNun5eedRxMAF15XEFRXgZWWdciuM8GCmdSQ84lLQfY5R14wDB5Lyon4ubwS7jx9NcV9/j5+g4JADs=
//                                                imagen2             |R0lGODlhUAAPAKIAAAsLav///88PD9WqsYmApmZmZtZfYmdakyH5BAQUAP8ALAAAAABQAA8AAAPbWLrc/jDKSVe4OOvNu/9gqARDSRBHegyGMahqO4R0bQcjIQ8E4BMCQc930JluyGRmdAAcdiigMLVrApTYWy5FKM1IQe+Mp+L4rphz+qIOBAUYeCY4p2tGrJZeH9y79mZsawFoaIRxF3JyiYxuHiMGb5KTkpFvZj4ZbYeCiXaOiKBwnxh4fnt9e3ktgZyHhrChinONs3cFAShFF2JhvCZlG5uchYNun5eedRxMAF15XEFRXgZWWdciuM8GCmdSQ84lLQfY5R14wDB5Lyon4ubwS7jx9NcV9/j5+g4JADs=";
//                var resultado_sp_imagenes = TablaDeDatos.From(sourceImagenes);

//                IConexionBD conexion = TestObjects.ConexionMockeada();

//                Expect.AtLeastOnce.On(conexion).Method("Ejecutar").With(new object[] { "dbo.MODI_Imagenes_Asignadas_A_Documento", Is.Anything }).Will(Return.Value(resultado_sp_imagenes));
//                Expect.AtLeastOnce.On(conexion).Method("EjecutarSinResultado").With(new object[] { "dbo.MODI_Asignar_Imagen_A_Documento", Is.Anything });

//                return new RepositorioDeLegajosEscaneados(mockearFileSystem(mock_filesystem_data.Keys.First(), mock_filesystem_data.Values.First()), conexion, "imagenes");
//            }
//            return repo_imagenes;
//        }

//        private IFileSystem mockearFileSystem(string path_legajo , List<string> imagenes_legajo)
//        {
//            if (mock_del_file_system == null)
//            {
//                var mocks = new Mockery();
//                mock_del_file_system = mocks.NewMock<IFileSystem>();
//                Expect.AtLeastOnce.On(mock_del_file_system).Method("getPathsArchivosEnCarpeta").With(new object[] { path_legajo }).Will(Return.Value(imagenes_legajo));
//                Expect.AtLeastOnce.On(mock_del_file_system).Method("getImagenFromPath").WithAnyArguments().Will(Return.Value(new Bitmap(1, 1)));
//                return mock_del_file_system;
//            }
//            return mock_del_file_system;
//        }

//        [TestMethod]
//        public void deberia_poder_obtener_una_lista_con_3_imagenes_del_repositorio_para_el_legajo_205939()
//        {
//            mock_filesystem_data = new Dictionary<string, List<string>>() {{ "imagenes/205939", new List<string>() { "imagenes/205939/imagen1.jpg", 
//                                                                "imagenes/205939/imagen2.jpg", 
//                                                                "imagenes/205939/imagen3.jpg" }}};

//            var imagenes = repo_de_legajos_escaneados().getThumbnailsDeImagenesSinAsignarParaUnLegajo(205939);

//            Assert.AreEqual(3, imagenes.Count());
//        }

//        [TestMethod]
//        public void deberia_poder_obtener_una_lista_con_2_imagenes_del_repositorio_para_el_legajo_203404()
//        {
//            mock_filesystem_data = new Dictionary<string, List<string>>() {{ "imagenes/203404", new List<string>() { "imagenes/205939/imagen1.jpg", 
//                                                                "imagenes/205939/imagen2.jpg" }}};

//            var imagenes = repo_de_legajos_escaneados().getThumbnailsDeImagenesSinAsignarParaUnLegajo(203404);
            
//            Assert.AreEqual(2, imagenes.Count());
//        }

//        [TestMethod]
//        public void deberia_poder_obtener_una_lista_con_2_imagenes_del_repositorio_para_el_documento_1_de_la_tabla_curriculums()
//        {
//            mock_filesystem_data = new Dictionary<string, List<string>>() {{ "imagenes/203404", new List<string>() { "imagenes/205939/imagen1.jpg", 
//                                                                "imagenes/205939/imagen2.jpg" }}};

//            var imagenes = repo_de_legajos_escaneados().getThumbnailsDeImagenesAsignadasAlDocumento("curriculums", 1);

//            Assert.AreEqual(2, imagenes.Count());
//        }

//        [TestMethod]
//        public void las_imagenes_para_el_legajo_203404_deberian_incluir_una_que_se_llame_Koala()
//        {
//            mock_filesystem_data = new Dictionary<string, List<string>>() { { "imagenes/203404", new List<string>() { "imagenes/203404/imagen1.jpg" } } };

//            var imagenes = repo_de_legajos_escaneados().getThumbnailsDeImagenesSinAsignarParaUnLegajo(203404);
            
//            Assert.IsTrue(imagenes.Any(imagen => imagen.nombre == "imagen1"));
//        }

//        [TestMethod]
//        public void deberia_poder_asociar_una_imagen_con_un_documento()
//        {
//            mock_filesystem_data = new Dictionary<string, List<string>>() { { "imagenes/203404", new List<string>() { "imagenes/203404/imagen1.jpg" } } };
//            repo_de_legajos_escaneados().asignarImagenADocumento("imagen1", 203404, "curriculums", 1);

//            var imagenes = repo_de_legajos_escaneados().getThumbnailsDeImagenesAsignadasAlDocumento("curriculums", 1);

//            Assert.AreEqual(3, imagenes.Count());
//        }

//        //[TestMethod]
//        //public void el_repositorio_deberia_devolver_una_lista_con_cero_imagenes_para_el_legajo_111111_que_no_tiene_carpeta()
//        //{
//        //    mock_filesystem_data = new Dictionary<string, List<string>>() { { "imagenes/203404", new List<string>() { "imagenes/205939/imagen1.jpg" } } };

//        //    var imagenes = repo_de_imagenes().getImagenesParaUnLegajo(111111);

//        //    Assert.AreEqual(0, imagenes.Count());
//        //}
//    }
//}
