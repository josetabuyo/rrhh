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
using General.MED;

namespace TestViaticos
{
    [TestClass]
    public class TestEvaluacionDesempenio
    {
        Persona fer;
        Usuario usr_fer;

        [TestInitialize]
        public void SetUp()
        {
            RepositorioEvaluacionDesempenio.Reset();
            fer = new Persona(1, 123, "Fer", "Caino", null);
            usr_fer = new Usuario(3988, "fer", "1234", true);
            usr_fer.Owner = fer;
        }

        [TestMethod]
        public void deberia_traer_una_evaluacion_con_una_pregunta()
        {
            string source = @"  |id_evaluado|Apellido |Nombre   |NroDocumento |id_evaluacion |estado_evaluacion |id_periodo |descripcion_periodo |id_nivel |descripcion_nivel |id_pregunta |orden_pregunta |Enunciado |Rpta1 |Rpta2 |Rpta3 |Rpta4 |Rpta5 |opcion_elegida |deficiente |regular|bueno |destacado| escalafon   | nivel | grado | agrupamiento  | puesto | id_area_evaluado | codigo_unidad_eval | Organismo    | Secretaria    | Subsecretaria | DireccionNacional | Area_Coordinacion | detalle_nivel | periodo_desde         | periodo_hasta         | nivel_estudios    | codigo_gde    | agrupamiento_evaluado | factor    | legajo
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |19          |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1a          |   1a  | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 1a        | 123";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioEvaluacionDesempenio repo = RepositorioEvaluacionDesempenio.NuevoRepositorioEvaluacion(conexion);
            
            var result = repo.GetAgentesEvaluablesPor(usr_fer).asignaciones;

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void deberia_traer_dos_evaluaciones_aunque_el_primero_no_este_evaluado()
        {
            string source = @"  |id_evaluado|Apellido |Nombre   |NroDocumento |id_evaluacion |estado_evaluacion |id_periodo |descripcion_periodo |id_nivel |descripcion_nivel |id_pregunta |orden_pregunta |Enunciado |Rpta1 |Rpta2 |Rpta3 |Rpta4 |Rpta5 |opcion_elegida |deficiente |regular|bueno |destacado| escalafon   | nivel | grado | agrupamiento  | puesto | id_area_evaluado | codigo_unidad_eval | Organismo    | Secretaria    | Subsecretaria | DireccionNacional | Area_Coordinacion | detalle_nivel | periodo_desde         | periodo_hasta         | nivel_estudios    | codigo_gde    | agrupamiento_evaluado | legajo    | factor
                                |1234       |Caino    |fer      |11111        |null          |null              |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1a          |   1a  | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | null          | a                     | 123       | 1a
                                |1235       |Perez    |juan     |21111        |2             |0                 |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1a          |   1a  | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 2b";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioEvaluacionDesempenio repo = RepositorioEvaluacionDesempenio.NuevoRepositorioEvaluacion(conexion);

            var result = repo.GetAgentesEvaluablesPor(usr_fer).asignaciones;

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void deberia_traer_dos_evaluaciones_aunque_el_ultimo_no_este_evaluado()
        {
            string source = @"  |id_evaluado|Apellido |Nombre   |NroDocumento |id_evaluacion |estado_evaluacion |id_periodo |descripcion_periodo |id_nivel |descripcion_nivel |id_pregunta |orden_pregunta |Enunciado |Rpta1 |Rpta2 |Rpta3 |Rpta4 |Rpta5 |opcion_elegida |deficiente |regular|bueno |destacado| escalafon   | nivel | grado | agrupamiento  | puesto | id_area_evaluado | codigo_unidad_eval | Organismo    | Secretaria    | Subsecretaria | DireccionNacional | Area_Coordinacion | detalle_nivel | periodo_desde         | periodo_hasta         | nivel_estudios    | codigo_gde    | agrupamiento_evaluado | legajo    | factor
                                |1235       |Perez    |juan     |21111        |2             |0                 |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1a          |   1a  | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 1a
                                |1234       |Caino    |fer      |11111        |null          |null              |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1a          |   1a  | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | null          | a                     | 123       | 1b";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioEvaluacionDesempenio repo = RepositorioEvaluacionDesempenio.NuevoRepositorioEvaluacion(conexion);

            var result = repo.GetAgentesEvaluablesPor(usr_fer).asignaciones;

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void deberia_traer_dos_evaluaciones_con_una_pregunta()
        {
            string source = @"  |id_evaluado|Apellido |Nombre   |NroDocumento |id_evaluacion |estado_evaluacion |id_periodo |descripcion_periodo |id_nivel |descripcion_nivel |id_pregunta |orden_pregunta |Enunciado |Rpta1 |Rpta2 |Rpta3 |Rpta4 |Rpta5 |opcion_elegida |deficiente |regular|bueno |destacado| escalafon   | nivel | grado | agrupamiento  | puesto | id_area_evaluado | codigo_unidad_eval | Organismo    | Secretaria    | Subsecretaria | DireccionNacional | Area_Coordinacion | detalle_nivel | periodo_desde         | periodo_hasta         | nivel_estudios    | codigo_gde    | agrupamiento_evaluado | legajo    | factor
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1a          |   1a  | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 1a
                                |1234       |Caino    |fer      |11111        |2             |0                 |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1a          |   1a  | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 1b";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioEvaluacionDesempenio repo = RepositorioEvaluacionDesempenio.NuevoRepositorioEvaluacion(conexion);

            var result = repo.GetAgentesEvaluablesPor(usr_fer).asignaciones;

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void deberia_traer_una_evaluacion_con_dos_preguntas()
        {
            string source = @"  |id_evaluado|Apellido |Nombre   |NroDocumento |id_evaluacion |estado_evaluacion |id_periodo |descripcion_periodo |id_nivel |descripcion_nivel |id_pregunta |orden_pregunta |Enunciado |Rpta1 |Rpta2 |Rpta3 |Rpta4 |Rpta5 |opcion_elegida |deficiente |regular|bueno |destacado| escalafon   | nivel | grado | agrupamiento  | puesto | id_area_evaluado | codigo_unidad_eval | Organismo    | Secretaria    | Subsecretaria | DireccionNacional | Area_Coordinacion | detalle_nivel | periodo_desde         | periodo_hasta         | nivel_estudios    | codigo_gde    | agrupamiento_evaluado | legajo    | factor
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1a          |   1a  | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 1a
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |2           |2              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1a          |   1a  | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 1a";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioEvaluacionDesempenio repo = RepositorioEvaluacionDesempenio.NuevoRepositorioEvaluacion(conexion);

            var result = repo.GetAgentesEvaluablesPor(usr_fer).asignaciones;
            var first = result.First();
            
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2, first.evaluacion.detalle_preguntas.Count);
        }


        [TestMethod]
        public void deberia_traer_dos_evaluaciones_con_dos_preguntas()
        {
            string source = @"  |id_evaluado|Apellido |Nombre   |NroDocumento |id_evaluacion |estado_evaluacion |id_periodo |descripcion_periodo |id_nivel |descripcion_nivel |id_pregunta |orden_pregunta |Enunciado |Rpta1 |Rpta2 |Rpta3 |Rpta4 |Rpta5 |opcion_elegida |deficiente |regular|bueno |destacado| escalafon   | nivel | grado | agrupamiento  | puesto | id_area_evaluado | codigo_unidad_eval | Organismo    | Secretaria    | Subsecretaria | DireccionNacional | Area_Coordinacion | detalle_nivel | periodo_desde         | periodo_hasta         | nivel_estudios    | codigo_gde    | agrupamiento_evaluado | legajo    | factor
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |1           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1a          |   1a  | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 1a
                                |1234       |Caino    |fer      |11111        |1             |0                 |     1     | p1                 |1        |niv 1             |2           |2              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1           |   2   | b     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 1a
                                |1234       |Caino    |fer      |11111        |2             |0                 |     2     | p1                 |1        |niv 1             |3           |1              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1           |   2   | c     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 1a
                                |1234       |Caino    |fer      |11111        |2             |0                 |     2     | p1                 |1        |niv 1             |4           |2              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1           |   3   | a     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 1a
                                |1234       |Caino    |fer      |11111        |2             |0                 |     2     | p1                 |1        |niv 1             |5           |3              | en1      |pr1   |pr2   |pr3   |pr4   |pr5   |1              |6          |16     |26    |36       | 1           |   3   | d     |  d            | b      | 1                | a                  | Mds          | s             | ss            | dn                | ac                | niv           | 2014-11-24 00:00:00   | 2014-11-24 00:00:00   | primaria          | gde_1         | a                     | 123       | 1a";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);// CrearResultadoSP();

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioEvaluacionDesempenio repo = RepositorioEvaluacionDesempenio.NuevoRepositorioEvaluacion(conexion);

            var result = repo.GetAgentesEvaluablesPor(usr_fer).asignaciones;

            var first = result.First();
            var second = result.Last();

            List<DetallePreguntas> preguntas1 = first.evaluacion.detalle_preguntas;
            List<DetallePreguntas> preguntas2 = second.evaluacion.detalle_preguntas;

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, preguntas1.Count);
            Assert.AreEqual(3, preguntas2.Count);
        }
    }
}
