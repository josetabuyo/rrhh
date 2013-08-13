using System.Linq;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using General.Calendario;


using NMock2;

namespace TestViaticos
{

    [TestClass]
    public class TestArticuladores
    {

        [TestMethod]
        public void deberia_poder_preguntarle_al_articulador_si_Zambri_quedo_libre_para_una_materia_del_cens_y_deberia_decirme_que_no()
        {


            string source = @"  |Id     |idAlumno     |IdCurso      |fechaAsistencia                |descripcion     |valor
                                |01     |4            |1            |2012-10-13 21:36:35.077        |Asistencia1     |1    
                                |02     |4            |1            |2012-10-13 21:36:35.077        |Asistencia2     |5    
                                |03     |1            |1            |2012-10-13 21:36:35.077        |Asistencia1     |1    ";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeAsistencias repo = new RepositorioDeAsistencias(conexion);

            
            
            
            Asistencia una_asistencia_presente = TestObjects.UnAsistenciaPresenteParaZambriEnHistoria();
            Asistencia una_asistencia_ausente = TestObjects.UnAsistenciaAusentePAraZambrienHistoria();
            var lista_de_asistencias_de_zambri_a_historia = repo.GetAsistenciasPorCursoYAlumno(TestObjects.CursoDeHistoriaDelCENS().Id, TestObjects.AlumnoZambri().Id);
            //List<Asistencia> asistencias = new List<Asistencia>();
            //asistencias.Add(una_asistencia_presente);
            //Expect.AtLeastOnce.On(TestObjects.RepoAsistenciasMockeado()).Method("GetAsistencias").WithAnyArguments().Will(Return.Value(asistencias));

           // IConexionBD conexion = TestObjects.ConexionMockeada();

           // RepositorioDeAsistencias repo = new RepositorioDeAsistencias(conexion);
            
            
            
            Articulador articulador = new Articulador();
            articulador.EvaluarCondicionPara(lista_de_asistencias_de_zambri_a_historia);
            

            Assert.AreEqual("Regular", articulador.condicion_del_alumno);
        }


    }
}
