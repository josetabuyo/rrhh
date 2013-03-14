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
   public class TestAlias
    {

       [TestMethod]
        public void deberia_traer_2_alias_de_areas()
         {

             string source = @" |Id|Id_Area|Alias  |
                                |1 |169    |Faby   |
                                |2 |254    |Medicos|";

           IConexionBD conexion = TestObjects.ConexionMockeada();
           var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

           Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));


           RepositorioDeAreas repo = new RepositorioDeAreas(conexion);
           Assert.AreEqual(2, repo.ObtenerTodosLosAliasDeAreas().Count);
       
         }

       [TestMethod]
       public void deberia_traer_el_alias_faby_para_el_area_1024()
       {

           string source = @" |Id|Id_Area|Alias  |
                              |1 |1024   |Faby   |";

           IConexionBD conexion = TestObjects.ConexionMockeada();
           var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

           Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));


           RepositorioDeAreas repo = new RepositorioDeAreas(conexion);
           Area area = new Area(1024, "Dirección de Diseño y Desarrollo Organizacional para la Gestión de Personas");
           Alias alias = new Alias();
           alias = repo.ObtenerAliasDeAreaByIdDeArea(area);

          
           area.alias = alias;
           Assert.AreEqual(area.Id,1024);
           Assert.AreEqual(alias.Descripcion,"Faby");

       }


       [TestMethod]
       public void deberia_poder_modificar_el_alias_faby_a_Fabian_para_el_area_1024()
       {

           string source = @" |Id|Id_Area|Alias  |
                              |1 |1024   |Faby   |";

           IConexionBD conexion = TestObjects.ConexionMockeada();
           var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

           Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));


           RepositorioDeAreas repo = new RepositorioDeAreas(conexion);
           Area area = new Area(1024, "Dirección de Diseño y Desarrollo Organizacional para la Gestión de Personas");
           Alias alias = new Alias();
           alias = repo.ObtenerAliasDeAreaByIdDeArea(area);


           area.alias = alias;
           Assert.AreEqual(area.Id, 1024);
           Assert.AreEqual(alias.Descripcion, "Faby");

       }








    }
}
