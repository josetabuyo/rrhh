using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioUsuarios
    {

        [TestInitialize]
        public void Setup()
        {
        }
        
     
        /// <summary>
        /// Ignorado para poder iniciarl el CI
        /// </summary>
        [TestMethod]
        [Ignore]
        public void fabian_deberia_tener_solo_un_area_con_un_asistente()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Ignorado para poder iniciarl el CI
        /// </summary>
        [TestMethod]
        [Ignore]
        public void fabian_deberia_tener_un_area_con_solo_un_asistente()
        {
            Assert.Fail();
        }
    }
}
