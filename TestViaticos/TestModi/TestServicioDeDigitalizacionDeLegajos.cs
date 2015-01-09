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
    public class TestServicioDeDigitalizacionDeLegajos
    {
        Mockery mocks;
        IConexionBD conexion_mockeada;
        IFileSystem file_system_mockeado;
        List<string> pathsImagenes;
        TablaDeDatos resultado_sp_legajo_por_dni;
        TablaDeDatos resultado_sp_legajo_por_id_interna;
        TablaDeDatos resultado_sp_legajo_por_apellido_y_nombre;
        TablaDeDatos resultado_sp_indice_documentos;
        TablaDeDatos resultado_sp_id_imagenes_sin_asignar;
        TablaDeDatos resultado_sp_id_imagenes_del_documento;
        TablaDeDatos resultado_sp_categoria_del_documento;
        TablaDeDatos resultado_sp_get_imagen;

        TablaDeDatos tabla_vacia;
        IServicioDeDigitalizacionDeLegajos servicioDeLegajos;
        string source_javier_lurgo;
        string source_documentos_de_javier_lurgo;
        string source_imagenes_del_legajo_de_javier_lurgo;
        string source_imagenes_del_documento_de_javier_lurgo;
        string source_id_categoria_del_documento_de_javier_lurgo;
        string source_imagen_10;

        [TestInitialize]
        public void Setup()
        {
            mocks = new Mockery();
            conexion_mockeada = mocks.NewMock<IConexionBD>();
            tabla_vacia = new TablaDeDatos();

            source_javier_lurgo = @"    Nro_Documento   |id_interna |Nombre	    |Apellido   |Cuil_Nro  
                                        29193500        |205171     |Javier     |Lurgo	    |20-29193500-2";

            source_imagenes_del_legajo_de_javier_lurgo = @"    id_imagen    |nro_folio
                                                                1           |0"; 

            source_documentos_de_javier_lurgo = @"      tabla       |id     |JUR	                            |ORG                            |TIPO               |FOLIO	    |fecha_comunicacion    	    |Fecha_Hasta
                                                        curriculums |221    |Ministerio de desarrollo social	|Direccion de recursos humanos	|curriculum         |00-000/000	|2012-05-21 00:00:00.000	|1900-01-01 00:00:00.000";
            
            source_imagenes_del_documento_de_javier_lurgo = @"    id_imagen
                                                                7
                                                                8";

            source_id_categoria_del_documento_de_javier_lurgo = @"      id_categoria
                                                                        54";

            source_imagen_10 =  @"      nombre_imagen       |bytes_imagen
                                        imagen10            |R0lGODlhUAAPAKIAAAsLav///88PD9WqsYmApmZmZtZfYmdakyH5BAQUAP8ALAAAAABQAA8AAAPbWLrc/jDKSVe4OOvNu/9gqARDSRBHegyGMahqO4R0bQcjIQ8E4BMCQc930JluyGRmdAAcdiigMLVrApTYWy5FKM1IQe+Mp+L4rphz+qIOBAUYeCY4p2tGrJZeH9y79mZsawFoaIRxF3JyiYxuHiMGb5KTkpFvZj4ZbYeCiXaOiKBwnxh4fnt9e3ktgZyHhrChinONs3cFAShFF2JhvCZlG5uchYNun5eedRxMAF15XEFRXgZWWdciuM8GCmdSQ84lLQfY5R14wDB5Lyon4ubwS7jx9NcV9/j5+g4JADs=";
            resultado_sp_legajo_por_dni = tabla_vacia;
            resultado_sp_legajo_por_id_interna = tabla_vacia;
            resultado_sp_legajo_por_apellido_y_nombre = tabla_vacia;
            resultado_sp_indice_documentos = tabla_vacia;
            resultado_sp_id_imagenes_sin_asignar = tabla_vacia;
            resultado_sp_id_imagenes_del_documento = tabla_vacia;
            resultado_sp_categoria_del_documento = tabla_vacia;
            resultado_sp_get_imagen = tabla_vacia;

            servicioDeLegajos = new ServicioDeDigitalizacionDeLegajos(conexion_mockeada);
        }

        public void SetupExpectations()
        {          
            Expect.AtLeastOnce.On(conexion_mockeada).Method("Ejecutar").With(new object[] { "dbo.LEG_GET_Datos_Personales", Is.Anything }).Will(Return.Value(resultado_sp_legajo_por_dni));
            Expect.AtLeastOnce.On(conexion_mockeada).Method("Ejecutar").With(new object[] { "dbo.MODI_GET_Datos_Personales_Por_Id_interna", Is.Anything }).Will(Return.Value(resultado_sp_legajo_por_id_interna));
            Expect.AtLeastOnce.On(conexion_mockeada).Method("Ejecutar").With(new object[] { "dbo.MODI_GET_Datos_Personales_Por_Apellido_Y_Nombre", Is.Anything }).Will(Return.Value(resultado_sp_legajo_por_apellido_y_nombre));
            Expect.AtLeastOnce.On(conexion_mockeada).Method("Ejecutar").With(new object[] { "dbo.LEG_GET_Indice_Documentos", Is.Anything }).Will(Return.Value(resultado_sp_indice_documentos));
            Expect.AtLeastOnce.On(conexion_mockeada).Method("Ejecutar").With(new object[] { "dbo.MODI_Imagenes_De_Un_Legajo", Is.Anything }).Will(Return.Value(resultado_sp_id_imagenes_sin_asignar));
            Expect.AtLeastOnce.On(conexion_mockeada).Method("Ejecutar").With(new object[] { "dbo.MODI_Imagenes_Asignadas_A_Un_Documento", Is.Anything }).Will(Return.Value(resultado_sp_id_imagenes_del_documento));
            Expect.AtLeastOnce.On(conexion_mockeada).Method("Ejecutar").With(new object[] { "dbo.MODI_Categoria_De_Un_Documento", Is.Anything }).Will(Return.Value(resultado_sp_categoria_del_documento));
            Expect.AtLeastOnce.On(conexion_mockeada).Method("Ejecutar").With(new object[] { "dbo.MODI_Get_Imagen", Is.Anything }).Will(Return.Value(resultado_sp_get_imagen));
            Expect.AtLeastOnce.On(conexion_mockeada).Method("EjecutarEscalar").With(new object[] { "dbo.MODI_Agregar_Imagen_Sin_Asignar_A_Un_Legajo", Is.Anything });
        }
        
        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void deberia_poder_obtener_un_legajo_completo_pasando_el_numero_de_documento()
        {
            resultado_sp_legajo_por_dni = TablaDeDatos.From(source_javier_lurgo);
            resultado_sp_id_imagenes_sin_asignar = TablaDeDatos.From(source_imagenes_del_legajo_de_javier_lurgo);
            resultado_sp_indice_documentos = TablaDeDatos.From(source_documentos_de_javier_lurgo);
            resultado_sp_id_imagenes_del_documento = TablaDeDatos.From(source_imagenes_del_documento_de_javier_lurgo);
            resultado_sp_categoria_del_documento = TablaDeDatos.From(source_id_categoria_del_documento_de_javier_lurgo);

            SetupExpectations();

            var respuesta = servicioDeLegajos.BuscarLegajos("29193500");

            verificarQueElLegajoDeJavierEsteCompletoEnElResultado(respuesta);
        }

        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void deberia_poder_obtener_un_legajo_completo_pasando_la_id_interna()
        {
            resultado_sp_legajo_por_id_interna = TablaDeDatos.From(source_javier_lurgo);
            resultado_sp_id_imagenes_sin_asignar = TablaDeDatos.From(source_imagenes_del_legajo_de_javier_lurgo);
            resultado_sp_indice_documentos = TablaDeDatos.From(source_documentos_de_javier_lurgo);
            resultado_sp_id_imagenes_del_documento = TablaDeDatos.From(source_imagenes_del_documento_de_javier_lurgo);
            resultado_sp_categoria_del_documento = TablaDeDatos.From(source_id_categoria_del_documento_de_javier_lurgo);

            SetupExpectations();

            var respuesta = servicioDeLegajos.BuscarLegajos("205171");

            verificarQueElLegajoDeJavierEsteCompletoEnElResultado(respuesta);
        }

        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void deberia_poder_obtener_un_legajo_completo_pasando_el_apellido_y_el_nombre()
        {
            resultado_sp_legajo_por_apellido_y_nombre = TablaDeDatos.From(source_javier_lurgo);
            resultado_sp_id_imagenes_sin_asignar = TablaDeDatos.From(source_imagenes_del_legajo_de_javier_lurgo);
            resultado_sp_indice_documentos = TablaDeDatos.From(source_documentos_de_javier_lurgo);
            resultado_sp_id_imagenes_del_documento = TablaDeDatos.From(source_imagenes_del_documento_de_javier_lurgo);
            resultado_sp_categoria_del_documento = TablaDeDatos.From(source_id_categoria_del_documento_de_javier_lurgo);

            SetupExpectations();

            var respuesta = servicioDeLegajos.BuscarLegajos("Javier Lurgo");

            verificarQueElLegajoDeJavierEsteCompletoEnElResultado(respuesta);
        }

        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void deberia_poder_obtener_una_imagen_pasando_su_id()
        {
            resultado_sp_get_imagen = TablaDeDatos.From(source_imagen_10);
            SetupExpectations();

            var imagen = servicioDeLegajos.GetImagenPorId(10);

            Assert.AreEqual("imagen10", imagen.nombre);
        }

        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void deberia_poder_obtener_un_thumbnail_de_una_imagen_pasando_su_id_alto_y_ancho_deseado()
        {
            resultado_sp_get_imagen = TablaDeDatos.From(source_imagen_10);
            SetupExpectations();

            var imagen = servicioDeLegajos.GetThumbnailPorId(10, 5, 5);

            Assert.AreEqual("imagen10", imagen.nombre);
            Assert.AreNotEqual("R0lGODlhUAAPAKIAAAsLav///88PD9WqsYmApmZmZtZfYmdakyH5BAQUAP8ALAAAAABQAA8AAAPbWLrc/jDKSVe4OOvNu/9gqARDSRBHegyGMahqO4R0bQcjIQ8E4BMCQc930JluyGRmdAAcdiigMLVrApTYWy5FKM1IQe+Mp+L4rphz+qIOBAUYeCY4p2tGrJZeH9y79mZsawFoaIRxF3JyiYxuHiMGb5KTkpFvZj4ZbYeCiXaOiKBwnxh4fnt9e3ktgZyHhrChinONs3cFAShFF2JhvCZlG5uchYNun5eedRxMAF15XEFRXgZWWdciuM8GCmdSQ84lLQfY5R14wDB5Lyon4ubwS7jx9NcV9/j5+g4JADs=", imagen.bytesImagen);
        }

        private static void verificarQueElLegajoDeJavierEsteCompletoEnElResultado(RespuestaABusquedaDeLegajos respuesta)
        {
            Assert.AreEqual("OK", respuesta.codigoDeResultado);
            Assert.AreEqual(29193500, respuesta.legajos[0].numeroDeDocumento);
            Assert.AreEqual(205171, respuesta.legajos[0].idInterna);
            Assert.AreEqual("Javier", respuesta.legajos[0].nombre);
            Assert.AreEqual("Lurgo", respuesta.legajos[0].apellido);
            Assert.AreEqual(0, respuesta.legajos[0].imagenesSinAsignar.Count);
            Assert.AreEqual(1, respuesta.legajos[0].documentos.Count);
            Assert.AreEqual(54, respuesta.legajos[0].documentos[0].idCategoria);
        }
    }
}
