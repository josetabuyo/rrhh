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

namespace TestViaticos
{
    [TestClass]
    public class TestOrganigrama
    {
        
        string AREA_UNIDAD_MINISTRO = "Area Unidad Ministro";
        string AREA_DE_FABIB = "Area de Fabian B";
        
        private Area area_de_faby;
        private Area area_de_marta;
        private Area area_de_castagneto;
        private Area unidad_ministro;
        private Area area_de_fabyB;


        private List<Area> areas_de_faby_y_marta;
        private List<Area> areas_de_faby_y_marta_y_carlos;
        private List<Area> areas_de_faby_y_marta_y_carlos_unidad_ministro;
        private List<Area> areas_de_faby_fabyB_y_marta;
        private List<Area> areas_vacias;
        private List<Area> areas_de_faby_y_marta_y_carlos_unidad_ministro_y_fabyB;

        private List<Area> dependencia_faby_marta;
        private List<Area> dependencia_marta_carlos;
        private List<Area> dependencia_carlos_unidad_ministro;
        private List<Area> dependencia_fabyB_marta;
        private List<Area> dependencia_faby_carlos;
        private List<Area> dependencia_marta_unidad_ministro;
        private List<Area> dependencia_FabyB_Carlos;

        private List<List<Area>> lista_de_dependencias_faby_marta;
        private List<List<Area>> lista_de_dependencias_faby_marta_y_carlos;
        private List<List<Area>> lista_de_dependencias_faby_marta_carlos_y_um;
        private List<List<Area>> lista_de_dependencias_faby_fabyB_marta;
        private List<List<Area>> lista_de_dependencias_faby_marta_separado_de_carlos_y_um;
        private List<List<Area>> lista_de_dependencias_faby_con_dos_pades_marta_carlos;
        private List<List<Area>> lista_de_dependencias_vacias;
        private List<List<Area>> lista_de_dependencias_faby_marta_carlos_y_um_fabyb;

        private Organigrama organigrama_faby_marta;
        private Organigrama organigrama_faby_fabyB_marta;
        private Organigrama organigrama_fabi_marta_castagneto_um;
        private Organigrama organigrama_fabi_marta_castagneto_um_fabyB;

        [TestInitialize]
        public void Setup()
        {
            area_de_marta = TestObjects.AreaDeMarta();
            area_de_faby = TestObjects.AreaDeFabi();
            area_de_castagneto = TestObjects.AreaDeCastagneto();
            unidad_ministro = new Area(1, AREA_UNIDAD_MINISTRO, "1", true);
            area_de_fabyB = new Area(0938, AREA_DE_FABIB, "939B", true);

            areas_de_faby_y_marta = TestObjects.AreasDeFabiYMarta();
            areas_de_faby_y_marta_y_carlos = TestObjects.AreasDeFabiMartaYCarlos(); 
            areas_de_faby_y_marta_y_carlos_unidad_ministro = new List<Area>() { area_de_faby, area_de_marta, area_de_castagneto, unidad_ministro };
            areas_de_faby_fabyB_y_marta = new List<Area>() { area_de_faby, area_de_fabyB, area_de_marta };
            areas_vacias = new List<Area>();
            areas_de_faby_y_marta_y_carlos_unidad_ministro_y_fabyB = new List<Area>() { area_de_faby, area_de_marta, area_de_castagneto, unidad_ministro, area_de_fabyB };

            dependencia_faby_marta = TestObjects.DependenciaEntreFabyYMarta();
            dependencia_marta_carlos = TestObjects.DependenciaEntreMartaYCarlos();
            dependencia_faby_carlos = new List<Area>() { area_de_faby, area_de_castagneto };
            dependencia_carlos_unidad_ministro = new List<Area>() { area_de_castagneto, unidad_ministro };
            dependencia_fabyB_marta = new List<Area>() { area_de_fabyB, area_de_marta };
            dependencia_marta_unidad_ministro = new List<Area>() { area_de_marta, unidad_ministro };
            dependencia_FabyB_Carlos = new List<Area>() { area_de_fabyB, area_de_castagneto };

            lista_de_dependencias_faby_marta = TestObjects.DependenciasEntreFabyYMarta();
            lista_de_dependencias_faby_marta_y_carlos = TestObjects.DependenciasEntreFabyMartaYCarlos();
            lista_de_dependencias_faby_marta_carlos_y_um = new List<List<Area>>() { dependencia_faby_marta, dependencia_marta_carlos, dependencia_carlos_unidad_ministro };
            lista_de_dependencias_faby_fabyB_marta = new List<List<Area>>() { dependencia_faby_marta, dependencia_fabyB_marta };
            lista_de_dependencias_faby_marta_separado_de_carlos_y_um =  new List<List<Area>>() {dependencia_faby_marta, dependencia_carlos_unidad_ministro};
            lista_de_dependencias_faby_con_dos_pades_marta_carlos = new List<List<Area>>{dependencia_faby_marta, dependencia_faby_carlos, dependencia_marta_unidad_ministro, dependencia_carlos_unidad_ministro};
            lista_de_dependencias_vacias = new List<List<Area>>();
            lista_de_dependencias_faby_marta_carlos_y_um_fabyb = new List<List<Area>>() { dependencia_faby_marta, dependencia_carlos_unidad_ministro, dependencia_FabyB_Carlos, dependencia_marta_unidad_ministro };

            organigrama_faby_marta = new Organigrama(areas_de_faby_y_marta, lista_de_dependencias_faby_marta);
            organigrama_fabi_marta_castagneto_um = new Organigrama(areas_de_faby_y_marta_y_carlos_unidad_ministro, lista_de_dependencias_faby_marta_carlos_y_um);
            organigrama_faby_fabyB_marta = new Organigrama(areas_de_faby_fabyB_y_marta, lista_de_dependencias_faby_fabyB_marta);
            organigrama_fabi_marta_castagneto_um_fabyB = new Organigrama(areas_de_faby_y_marta_y_carlos_unidad_ministro_y_fabyB, lista_de_dependencias_faby_marta_carlos_y_um_fabyb);
        }


        //**********************************************
        //COMIENZO DE TEST 
        //**********************************************

        // TEST CON ORGANIGRAMAS DE ESTE FORMATO (2 NIELES LINEAL)

        //    o     (area_de_marta)         Nivel 1
        //    o     (area_de_faby)          Nivel 2

       
        [TestMethod]
        public void Un_organigrama_deberia_poder_decirme_cual_es_el_area_superior_de_un_area_dada()
        {

            Assert.AreEqual(area_de_marta, organigrama_faby_marta.AreaSuperiorDe(area_de_faby));
        }

       
        [TestMethod]
        public void cuando_se_solicita_la_lista_de_todas_las_áreas_superiores_de_un_área_debe_devolver_una_lista_vacía()
        {

            Assert.IsTrue(organigrama_faby_marta.AreasSuperioresDe(area_de_marta).Count.Equals(0));

        }


        [TestMethod]
        public void no_se_puede_solicitar_el_área_superior_del_área_maxima_sino_que_debería_dar_una_excepción()
        {

            Area area_inexistente = null;
            try
            {
                area_inexistente = organigrama_faby_marta.AreaSuperiorDe(area_de_marta);
                Assert.Fail("Deberia haber lanzado excepción de que no existe area superior");
            }
            catch (OrganigramaException e)
            {
                Assert.IsNull(area_inexistente);
                Assert.AreEqual("Se pidió el Area superior a " + area_de_marta.Nombre + ", y esta no tiene", e.Message);
            }

        }


        [TestMethod]
        public void Un_organigrama_deberia_poder_decirme_todas_las_areas_que_posee()
        {
            Assert.IsTrue(organigrama_faby_marta.ObtenerAreas(true).Contains(area_de_faby));
            Assert.IsTrue(organigrama_faby_marta.ObtenerAreas(true).Contains(area_de_marta));
        }

        [TestMethod]
        public void Un_organigrama_deberia_poder_decirme_todas_las_areas_inferiores_inmediatas_a_un_area_dada()
        {
                  Assert.IsTrue(organigrama_faby_marta.AreasInferioresInmediatasDe(area_de_marta).Contains(area_de_faby));
        }

        [TestMethod]
        public void al_solicitarle_las_areas_inferiores_de_Fabi_no_debe_traer_ninguna()
        {
            Assert.IsTrue(organigrama_faby_marta.GetAreasInferioresDelArea(area_de_faby).Count.Equals(0));
        }


        //*******************************************************************
        // TEST CON ORGANIGRAMAS DE ESTE FORMATO (4 NIVELES LINEAL)
        //   organigrama
        //
        //    o     (unidad_ministro)       Nivel 1
        //    o     (area_de_castagneto)    Nivel 2
        //    o     (area_de_marta)         Nivel 3
        //    o     (area_de_faby)          Nivel 4


        [TestMethod]
        public void deberia_poder_crear_un_organigrama_lineal_con_cuatro_areas()
        {

            Assert.IsTrue(organigrama_fabi_marta_castagneto_um.AreaSuperiorDe(area_de_castagneto).Equals(unidad_ministro));
            Assert.IsTrue(organigrama_fabi_marta_castagneto_um.AreaSuperiorDe(area_de_marta).Equals(area_de_castagneto));
        }
       

        [TestMethod]
        public void Un_organigrama_deberia_poder_decirme_todas_las_areas_que_son_superiores_a_un_area_dada()
        {

            Assert.IsTrue(organigrama_fabi_marta_castagneto_um.AreasSuperioresDe(area_de_faby).Contains(area_de_marta));
            Assert.IsTrue(organigrama_fabi_marta_castagneto_um.AreasSuperioresDe(area_de_faby).Contains(area_de_castagneto));
            Assert.IsTrue(organigrama_fabi_marta_castagneto_um.AreasSuperioresDe(area_de_faby).Contains(unidad_ministro));
        }

        [TestMethod]
        public void Un_organigrama_deberia_poder_decirme_todas_las_areas_inferiores_a_un_area_dada_con_una_estructura_lineal()
        {
            Assert.AreEqual(3, organigrama_fabi_marta_castagneto_um.GetAreasInferioresDelArea(unidad_ministro).Count);
            Assert.IsTrue(organigrama_fabi_marta_castagneto_um.ObtenerAreas(true).Contains(area_de_marta));
            Assert.IsTrue(organigrama_fabi_marta_castagneto_um.ObtenerAreas(true).Contains(area_de_castagneto));
            Assert.IsTrue(organigrama_fabi_marta_castagneto_um.ObtenerAreas(true).Contains(area_de_faby));
        }


        //*****************************************************************************************************************
        // TEST CON ORGANIGRAMAS INCORRECTOS DE ESTE FORMATO (2 PARES DE 2 NIVELES LINEAL SIN VÍNCULOS ENTRE AMBOS)
        //   organigrama
        //
        //    o Marta   o Unidad Ministro 
        //    o Faby    o Castagneto

        [TestMethod]
        public void no_se_debe_permitir_crear_un_organigrama_donde_tenga_mas_de_un_area_superior_final() //ARREGLAR!
        {
            try
                {
                    var organigrama_incorrecto = new Organigrama(areas_de_faby_y_marta_y_carlos_unidad_ministro, lista_de_dependencias_faby_marta_separado_de_carlos_y_um);
                    Assert.Fail("Falla porque debería haber lanzado la excepción de Organigrama inconsistente");
                }
                catch (Exception e)
                {
                    Assert.AreEqual("El Organigrama Posee más de un Área como Área Superior a Todas las Área y por lo tanto es inconsistente", e.Message);
                }
            }


        //*****************************************************************************************************************
        // TEST CON ORGANIGRAMAS INCORRECTOS DE ESTE FORMATO (sin NADA)
        //   organigrama
        //
        //        o ???

        [TestMethod]
        public void no_se_debe_permitir_crear_un_organigrama_donde_las_areas_y_las_dependencias_son_vacias()
        {
            try
            {
                var organigrama_incorrecto = new Organigrama(areas_vacias, lista_de_dependencias_vacias);
                Assert.Fail("Falla porque debería haber lanzado la excepción de Organigrama inconsistente");
            }
            catch (Exception e)
            {
                Assert.AreEqual("El Organigrama No Posee las Áreas y Relaciones entre Áreas Básicas y por lo tanto es inconsistente", e.Message);
            }
        }


        //*****************************************************************************************************************
        // TEST CON ORGANIGRAMAS INCORRECTOS DE ESTE FORMATO (1 HIJO CON 2 PADRES)
        //   organigrama
        //
        //      o Unidad Ministro
        //    o Marta   o Castagneto 
        //          o Faby    

        [TestMethod]
        public void no_se_debe_permitir_crear_un_organigrama_donde_un_hijo_tenga_dos_areas_padres()
        {
            try
            {
                var organigrama_faby_con_dos_padres_marta_carlos = new Organigrama(areas_de_faby_y_marta_y_carlos_unidad_ministro, lista_de_dependencias_faby_con_dos_pades_marta_carlos);
                Assert.Fail("Falla porque debería haber lanzado la excepción de Organigrama inconsistente");
            }
            catch (Exception e)
            {
                Assert.AreEqual("El Organigrama Posee Áreas con más de un Área Superior Directa Asignada y por lo tanto es Incosistente", e.Message);
            }
        }


        //*******************************************************************************
        // TEST CON ORGANIGRAMAS DE ESTE FORMATO (2 NIVELES CON 1 ROOT Y 2 HIJOS)
        //   organigrama
        //
        //    o Marta    
        // o Faby    oFabyB  


        [TestMethod]
        public void se_puede_crear_un_organigrama_con_forma_de_arbol_de_dos_pisos()
        {
 

             Assert.AreEqual(area_de_marta, organigrama_faby_fabyB_marta.AreaSuperiorDe(area_de_faby));
             Assert.AreEqual(area_de_marta, organigrama_faby_fabyB_marta.AreaSuperiorDe(area_de_fabyB));

             Assert.IsTrue(organigrama_faby_fabyB_marta.AreasSuperioresDe(area_de_marta).Count.Equals(0));

             Assert.IsTrue(organigrama_faby_fabyB_marta.ObtenerAreas(true).Contains(area_de_faby));
             Assert.IsTrue(organigrama_faby_fabyB_marta.ObtenerAreas(true).Contains(area_de_fabyB));
             Assert.IsTrue(organigrama_faby_fabyB_marta.ObtenerAreas(true).Contains(area_de_marta));

             Assert.IsTrue(organigrama_faby_fabyB_marta.AreasSuperioresDe(area_de_faby).Contains(area_de_marta));
             Assert.IsTrue(organigrama_faby_fabyB_marta.AreasSuperioresDe(area_de_fabyB).Contains(area_de_marta));
            
        }


        [TestMethod]
        public void Un_organigrama_deberia_poder_decirme_todas_las_areas_inferiores_inmediatas_a_un_area_dada_con_muchas_areas()
        {

            Assert.IsTrue(organigrama_faby_fabyB_marta.AreasInferioresInmediatasDe(area_de_marta).Contains(area_de_faby));
            Assert.IsTrue(organigrama_faby_fabyB_marta.AreasInferioresInmediatasDe(area_de_marta).Contains(area_de_fabyB));
        }

        [TestMethod]
        public void al_solicitarle_todas_las_areas_inferiores_de_marta_deberia_traerme_faby_yfabyB()
        {
            Assert.AreEqual(2, organigrama_faby_fabyB_marta.GetAreasInferioresDelArea(area_de_marta).Count);
            Assert.IsTrue(organigrama_faby_fabyB_marta.GetAreasInferioresDelArea(area_de_marta).Contains(area_de_faby));
            Assert.IsTrue(organigrama_faby_fabyB_marta.GetAreasInferioresDelArea(area_de_marta).Contains(area_de_fabyB));
        }


        //*******************************************************************************
        // TEST CON ORGANIGRAMAS DE ESTE FORMATO (3 NIVELES CON 1 ROOT Y 2 HIJOS CAAD UNO)
        //   organigrama
        //
        //            o Unidad Ministro    
        //      o Marta             o Castagneto
        //o Fabi                        o FabyB   

        [TestMethod]
        public void al_solicitarle_las_areas_inferiores_al_area_de_Marta_debe_traer_solo_la_de_Faby()
        {
            Assert.AreEqual(1, organigrama_fabi_marta_castagneto_um_fabyB.GetAreasInferioresDelArea(area_de_marta).Count);
            Assert.IsTrue(organigrama_fabi_marta_castagneto_um_fabyB.GetAreasInferioresDelArea(area_de_marta).Contains(area_de_faby));
        }

        [TestMethod]
        public void al_solicitarle_las_areas_inferiores_a_un_listado_de_areas_debe_traer_todas_sus_inferiores()
        {
            List<Area> areas = new List<Area>();
            areas.Add(area_de_marta);
            areas.Add(area_de_castagneto);

            Assert.AreEqual(2, organigrama_fabi_marta_castagneto_um_fabyB.GetAreasInferioresDeLasAreas(areas).Count);
            
        }
        
    }
}
