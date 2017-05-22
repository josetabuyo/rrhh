using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using NMock2;
using General;
using General.MAU;
using Newtonsoft.Json;
using System.Reflection;

namespace TestViaticos
{
    [TestClass]
    public class TestEvaluacionDesempenio
    {
        Usuario fer;

        [TestInitialize]
        public void SetUp()
        {
            RepositorioEvaluacionDesempenio.Reset();
            fer = new Usuario(3988, "fer", "1234", true);
        }

        [TestMethod]
        public void deberia_traer_una_evaluacion_con_una_pregunta()
        {
            string source = @"  |id_evaluado|Apellido |Nombre   |NroDocumento |id_evaluacion |estado_evaluacion |id_periodo |descripcion_periodo |id_nivel |descripcion_nivel |id_pregunta |orden_pregunta |Enunciado |Rpta1 |Rpta2 |Rpta3 |Rpta4 |Rpta5 |opcion_elegida |deficiente |regular|bueno |destacado|
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |19          |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       |";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioEvaluacionDesempenio repo = RepositorioEvaluacionDesempenio.NuevoRepositorioEvaluacion(conexion);
            
            var result = repo.GetAgentesEvaluablesPorRaw(fer);

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void deberia_traer_dos_evaluaciones_con_una_pregunta()
        {
            string source = @"  |id_evaluado|Apellido |Nombre   |NroDocumento |id_evaluacion |estado_evaluacion |id_periodo |descripcion_periodo |id_nivel |descripcion_nivel |id_pregunta |orden_pregunta |Enunciado |Rpta1 |Rpta2 |Rpta3 |Rpta4 |Rpta5 |opcion_elegida |deficiente |regular|bueno |destacado|
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       |
                                |1234       |Caino    |fer      |11111        |2             |0                 |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       |";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioEvaluacionDesempenio repo = RepositorioEvaluacionDesempenio.NuevoRepositorioEvaluacion(conexion);

            var result = repo.GetAgentesEvaluablesPorRaw(fer);

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void deberia_traer_una_evaluacion_con_dos_preguntas()
        {
            string source = @"  |id_evaluado|Apellido |Nombre   |NroDocumento |id_evaluacion |estado_evaluacion |id_periodo |descripcion_periodo |id_nivel |descripcion_nivel |id_pregunta |orden_pregunta |Enunciado |Rpta1 |Rpta2 |Rpta3 |Rpta4 |Rpta5 |opcion_elegida |deficiente |regular|bueno |destacado|
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       |
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |2           |2              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       |";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioEvaluacionDesempenio repo = RepositorioEvaluacionDesempenio.NuevoRepositorioEvaluacion(conexion);

            var result = repo.GetAgentesEvaluablesPorRaw(fer);
            var first = result.First();
            Type t = first.GetType();
            PropertyInfo p = t.GetProperty("detalle_preguntas");
            List<object> preguntas = (List<object>)p.GetValue(first, null);            

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2, preguntas.Count);
        }


        [TestMethod]
        public void deberia_traer_dos_evaluaciones_con_dos_preguntas()
        {
            string source = @"  |id_evaluado|Apellido |Nombre   |NroDocumento |id_evaluacion |estado_evaluacion |id_periodo |descripcion_periodo |id_nivel |descripcion_nivel |id_pregunta |orden_pregunta |Enunciado |Rpta1 |Rpta2 |Rpta3 |Rpta4 |Rpta5 |opcion_elegida |deficiente |regular|bueno |destacado|
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       |
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |2           |2              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       |
                                |1234       |Caino    |fer      |11111        |2             |0                 |     2     | p1                 |1        |niv 1             |3           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       |
                                |1234       |Caino    |fer      |11111        |2             |0                 |     2     | p1                 |1        |niv 1             |4           |2              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       |
                                |1234       |Caino    |fer      |11111        |2             |0                 |     2     | p1                 |1        |niv 1             |5           |3              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       |";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioEvaluacionDesempenio repo = RepositorioEvaluacionDesempenio.NuevoRepositorioEvaluacion(conexion);

            var result = repo.GetAgentesEvaluablesPorRaw(fer);

            var first = result.First();
            var second = result.Last();

            Type t = first.GetType();
            PropertyInfo p = t.GetProperty("detalle_preguntas");

            List<object> preguntas1 = (List<object>)p.GetValue(first, null);
            List<object> preguntas2 = (List<object>)p.GetValue(second, null);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(3, preguntas2.Count);
        }
    }
}
