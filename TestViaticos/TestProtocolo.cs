using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;


using NMock2;

namespace General
{
    [TestClass]
    public class TestProtocolo
    {
            
        
// Test con Filtro por Nombre de Áreas
        [TestMethod]
        public void al_buscar_por_nombre_de_area_la_palabra_RRHH_deberia_traerme_el_area_cuyo_nombre_es_RRHH()
        {
            string dato_ingresado_en_filtro = "RRHH";
            
            List<Area> areas = AreasCompletas();
            
            BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
            FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorNombre, dato_ingresado_en_filtro);
            List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);

            Assert.AreEqual(1, areas_filtradas.Count);
            Assert.IsTrue(areas_filtradas.TrueForAll(area => area.Nombre.Contains(dato_ingresado_en_filtro)));
        }

//Test con Filtro por Dirección de Área
        [TestMethod]
        public void al_buscar_en_una_lista_de_áreas_una_dirección_devuelve_todos_las_áreas_cuyo_domicilio_contiene_el_texto_buscado()
        {
            string dato_ingresado_en_filtro = "9 de Julio";

            List<Area> areas = AreasCompletas();

            BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
            FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorDireccion, dato_ingresado_en_filtro);
            List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);

            Assert.AreEqual(1, areas_filtradas.Count);
            Assert.IsTrue(areas_filtradas.TrueForAll(area => area.Direccion.Contains(dato_ingresado_en_filtro)));
        }

// Test con Filtro por Responsable
         [TestMethod]
        public void al_buscar_por_reponsable_de_area_a_Fabian_deberia_traerme_el_area_cuyo_nombre_de_responsable_es_Fabian()
        {
            string dato_ingresado_en_filtro = "Fabián";
            
            List<Area> areas = AreasCompletas();

            BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
            FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorResponsable, dato_ingresado_en_filtro);
            List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);
            
            Assert.AreEqual(1, areas_filtradas.Count);
            Assert.IsTrue(areas_filtradas.TrueForAll(area => area.datos_del_responsable.Nombre.Contains(dato_ingresado_en_filtro) || area.datos_del_responsable.Apellido.Contains(dato_ingresado_en_filtro)));
        }

        [TestMethod]
        public void al_buscar_por_reponsable_de_area_a_Novoa_deberia_traerme_el_area_cuyo_apellido_de_responsable_es_Novoa()
         {
             string dato_ingresado_en_filtro = "Novoa";

             List<Area> areas = AreasCompletas();

             BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
             FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorResponsable, dato_ingresado_en_filtro);
             List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);

             Assert.AreEqual(1, areas_filtradas.Count);
             Assert.IsTrue(areas_filtradas.TrueForAll(area => area.datos_del_responsable.Nombre.Contains(dato_ingresado_en_filtro) || area.datos_del_responsable.Apellido.Contains(dato_ingresado_en_filtro)));
         }


         [TestMethod]
         public void al_buscar_por_reponsable_de_area_a_Miranda_debe_traer_dos_areas_una_con_responsable_cuyo_nombre_es_Miranda_y_otra_area_cuyo_apellido_de_responsable_es_también_Miranda()
         {
             string dato_ingresado_en_filtro = "Miranda";
             
             List<Area> areas = AreasCompletas();

             BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
             FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorResponsable, dato_ingresado_en_filtro);
             List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);

             Assert.AreEqual(2, areas_filtradas.Count);
             Assert.IsTrue(areas_filtradas.TrueForAll(area => area.datos_del_responsable.Nombre.Contains(dato_ingresado_en_filtro) || area.datos_del_responsable.Apellido.Contains(dato_ingresado_en_filtro)));
         }

// Test con Filtro por Asistentes
         [TestMethod]
         public void al_buscar_en_una_lista_de_áreas_por_Asistentes_de_área_a_María_debe_traer_el_area_de_RRHH_donde_María_es_secretaria()
         {
             string dato_ingresado_en_filtro = "María";

             List<Area> areas = AreasCompletas();

             BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
             FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorAsistente, dato_ingresado_en_filtro);
             List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);

             Assert.AreEqual(1, areas_filtradas.Count);
             Assert.IsTrue(areas_filtradas.TrueForAll(area => area.Asistentes.Exists(asistente => asistente.Nombre.Contains(dato_ingresado_en_filtro)) || area.Asistentes.Exists(asistente => asistente.Apellido.Contains(dato_ingresado_en_filtro))));
         }

         [TestMethod]
         public void al_buscar_en_una_lista_de_áreas_por_Asistentes_de_área_a_Ana_debe_traer_dos_areas_donde_existen_dos_personas_llamadas_Ana_que_son_secreatarias_en_cada_area()
         {
             string dato_ingresado_en_filtro = "Ana";
                        
             List<Area> areas = AreasCompletas();

             BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
             FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorAsistente, dato_ingresado_en_filtro);
             List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);

             Assert.AreEqual(2, areas_filtradas.Count);
             Assert.IsTrue(areas_filtradas.TrueForAll(area => area.Asistentes.Exists(asistente => asistente.Nombre.Contains(dato_ingresado_en_filtro)) || area.Asistentes.Exists(asistente => asistente.Apellido.Contains(dato_ingresado_en_filtro))));
         }


         //[TestMethod]
         //public void al_buscar_en_una_lista_de_áreas_una_parte_de_telefono_devuelve_todos_las_áreas_cuyo_telefono_de_asistente_o_responsable_o_area_contiene_el_texto_buscado()
         //{
         //    string dato_ingresado_en_filtro = "2222";

         //    List<Area> areas = AreasCompletas();

         //    BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
         //    FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorTelefono, dato_ingresado_en_filtro);
         //    List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);

         //    Assert.AreEqual(2, areas_filtradas.Count);
         //    Assert.IsTrue(areas_filtradas.TrueForAll(area => area.Asistentes.Exists(asistente => asistente.Telefono.Contains(dato_ingresado_en_filtro)) || area.datos_del_responsable.Telefono.Contains(dato_ingresado_en_filtro) || area.Telefono.Contains(dato_ingresado_en_filtro)));
         //}

         //[TestMethod]
         //public void al_buscar_en_una_lista_de_áreas_un_email_devuelve_todos_las_áreas_cuyo_email_de_asistente_o_responsable_o_area_contiene_el_texto_buscado()
         //{
         //    string dato_ingresado_en_filtro = "fabian";

         //    List<Area> areas = AreasCompletas();

         //    BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
         //    FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorMail, dato_ingresado_en_filtro);
         //    List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);

         //    Assert.AreEqual(1, areas_filtradas.Count);
         //    Assert.IsTrue(areas_filtradas.TrueForAll(area => area.Asistentes.Exists(asistente => asistente.Mail.Contains(dato_ingresado_en_filtro)) || area.datos_del_responsable.Mail.Contains(dato_ingresado_en_filtro) || area.Mail.Contains(dato_ingresado_en_filtro)));
         //}

         //[TestMethod]
         //public void al_buscar_en_una_lista_de_áreas_un_email_devuelve_dos_emails__uno_de_asistente_y_otro_de_area__que_contienen_el_texto_buscado()
         //{
         //    string dato_ingresado_en_filtro = "@mds";

         //    List<Area> areas = AreasCompletas();

         //    BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
         //    FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorMail, dato_ingresado_en_filtro);
         //    List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);

         //    Assert.AreEqual(2, areas_filtradas.Count);
         //    Assert.IsTrue(areas_filtradas.TrueForAll(area => area.Asistentes.Exists(asistente => asistente.Mail.Contains(dato_ingresado_en_filtro)) || area.datos_del_responsable.Mail.Contains(dato_ingresado_en_filtro) || area.Mail.Contains(dato_ingresado_en_filtro)));
         //}



         //[TestMethod]
         //public void al_buscar_en_una_lista_de_áreas_un_fax_devuelve_todos_las_áreas_cuyo_fax_de_asistente_o_responsable_o_area_contiene_el_texto_buscado()
         //{
         //    string dato_ingresado_en_filtro = "888";

         //    List<Area> areas = AreasCompletas();

         //    BuscadorDeAreas buscador_de_areas = new BuscadorDeAreas(areas);
         //    FiltroDeAreas filtro = new FiltroDeAreas(FiltroDeAreas.PredicadoPorFax, dato_ingresado_en_filtro);
         //    List<Area> areas_filtradas = buscador_de_areas.Buscar(filtro);

         //    Assert.AreEqual(1, areas_filtradas.Count);
         //    Assert.IsTrue(areas_filtradas.TrueForAll(area => area.Asistentes.Exists(asistente => asistente.Fax.Contains(dato_ingresado_en_filtro)) || area.datos_del_responsable.Fax.Contains(dato_ingresado_en_filtro) || area.Fax.Contains(dato_ingresado_en_filtro)));
         //}

        
         private List<Area> AreasCompletas()
         {
             return TestObjects.AreasCompletas();
         }
    }
}
