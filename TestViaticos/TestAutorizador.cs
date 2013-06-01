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

    }
}
