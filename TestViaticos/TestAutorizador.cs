using System.Linq;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using General.Calendario;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using NMock2;

namespace TestViaticos
{

    [TestClass]
    public class TestAutorizador
    {

        [TestMethod]
        public void deberia_poder_traer_los_cursos_segun_el_area_responsable_del_usuario_logeado()
        {
            Usuario usu_cenard = TestObjects.UsuarioCENARD();
            Usuario usu_sacc = TestObjects.UsuarioSACC();
            Organigrama organigrama = TestObjects.OrganigramaConDosRamas();

            IConexionBD conexion = TestObjects.ConexionMockeada();

            Autorizador autorizador = new Autorizador();

            List<Curso> cursos = TestObjects.UnListadoDeCursoConEdificios();

            Assert.AreEqual(1, autorizador.FiltrarCursosPorUsuario(cursos, organigrama, usu_cenard).Count());
            Assert.AreEqual(3, autorizador.FiltrarCursosPorUsuario(cursos, organigrama, usu_sacc).Count());

        }

        [TestMethod]
        public void deberia_poder_traer_espacios_segun_el_area_responsable_del_usuario_logeado()
        {
            Usuario usu_cenard = TestObjects.UsuarioCENARD();
            Usuario usu_sacc = TestObjects.UsuarioSACC();
            Organigrama organigrama = TestObjects.OrganigramaConDosRamas();

            IConexionBD conexion = TestObjects.ConexionMockeada();

            Autorizador autorizador = new Autorizador();

            List<EspacioFisico> espacios_fisicos = TestObjects.EspaciosFisicos();

            Assert.AreEqual(1, autorizador.FiltrarEspaciosFisicosPorUsuario(espacios_fisicos, organigrama, usu_cenard).Count());
            Assert.AreEqual(3, autorizador.FiltrarEspaciosFisicosPorUsuario(espacios_fisicos, organigrama, usu_sacc).Count());

        }


        [TestMethod]
        public void deberia_poder_traer_alumnos_segun_el_area_responsable_del_usuario_logeado()
        {
            Usuario usu_cenard = TestObjects.UsuarioCENARD();
            Usuario usu_sacc = TestObjects.UsuarioSACC();
            Organigrama organigrama = TestObjects.OrganigramaConDosRamas();

            IConexionBD conexion = TestObjects.ConexionMockeada();

            Autorizador autorizador = new Autorizador();

            List<Alumno> alumnos = TestObjects.AlumnosNuevos();

            Assert.AreEqual(2, autorizador.FiltrarAlumnosPorUsuario(alumnos, organigrama, usu_cenard).Count());
            Assert.AreEqual(3, autorizador.FiltrarAlumnosPorUsuario(alumnos, organigrama, usu_sacc).Count());

        }

        [TestMethod]
        public void deberia_poder_determinar_si_una_persona_buscada_pertenece_al_área_de_la_persona_logueada()
        {
            Usuario usu_cenard = TestObjects.UsuarioCENARD();
            Usuario usu_sacc = TestObjects.UsuarioSACC();
            Organigrama organigrama = TestObjects.OrganigramaConDosRamas();

            IConexionBD conexion = TestObjects.ConexionMockeada();

            Autorizador autorizador = new Autorizador();

            Alumno un_alumno = TestObjects.AlumnoMinisterio();

            Assert.IsFalse(autorizador.AlumnoVisibleParaUsuario(un_alumno, organigrama, usu_cenard));
            Assert.IsTrue(autorizador.AlumnoVisibleParaUsuario(un_alumno, organigrama, usu_sacc));

        }

    }
}
