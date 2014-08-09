using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General;

namespace TestViaticos
{
    [TestClass]
    public class TestValidaciones
    {

        [TestMethod]
        public void deberia_poder_validar_por_un_id_natural()
        {
            CvDocencia una_docencia = new CvDocencia() { Id = 7 };
            var validador_docencias = new Validador();

            validador_docencias.DeberiaSer("Id", Validador.NumeroNatural);

            Assert.IsTrue(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_un_id_no_natural()
        {
            CvDocencia una_docencia = new CvDocencia() { Id = 0 };
            var validador_docencias = new Validador();

            validador_docencias.DeberiaSer("Id", Validador.NumeroNatural);

            Assert.IsFalse(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_un_id_natural_y_nivel_natural()
        {
            CvDocencia una_docencia = new CvDocencia() { Id = 7, NivelEducativo = 2 };
            var validador_docencias = new Validador();

            validador_docencias.DeberiaSer("Id", Validador.NumeroNatural)
                .DeberiaSer("NivelEducativo", Validador.NumeroNatural);

            Assert.IsTrue(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_un_id_natural_y_nivel_natural_sin_repetir_ValidaSi()
        {
            CvDocencia una_docencia = new CvDocencia() { Id = 7, NivelEducativo = 2 };
            var validador_docencias = new Validador();

            var reglas = new Dictionary<string, Validador>() { { "Id", Validador.NumeroNatural }, { "NivelEducativo", Validador.NumeroNatural } };

            validador_docencias.ValidaSi(reglas);

            Assert.IsTrue(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_un_id_natural_y_nivel_natural_sin_repetir_ValidaSi_ni_Validador()
        {
            CvDocencia una_docencia = new CvDocencia() { Id = 7, NivelEducativo = 2 };
            var validador_docencias = new Validador();

            validador_docencias.DeberianSerNaturales(new string[]{ "Id", "NivelEducativo" });

            Assert.IsTrue(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_una_asignatura_no_vacia_y_categiria_no_vacia_sin_repetir_ValidaSi_ni_Validador()
        {
            CvDocencia una_docencia = new CvDocencia() { Asignatura = "Asignatura", CategoriaDocente = "Categoria" };
            var validador_docencias = new Validador();

            validador_docencias.DeberianSerNoVacias(new string[] { "Asignatura", "CategoriaDocente" });

            Assert.IsTrue(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_un_id_natural_o_cero_y_nivel_natura_o_cero_sin_repetir_ValidaSi_ni_Validador()
        {
            CvDocencia una_docencia = new CvDocencia() { Id = 0, NivelEducativo = 0 };
            var validador_docencias = new Validador();

            validador_docencias.DeberianSerNaturalesOCero(new string[] { "Id", "NivelEducativo" });

            Assert.IsTrue(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_una_asignatura_no_nulo_y_categiria_no_nulo_sin_repetir_ValidaSi_ni_Validador()
        {
            CvDocencia una_docencia = new CvDocencia() { Asignatura = "Asignatura", CategoriaDocente = "Categoria" };
            var validador_docencias = new Validador();

            validador_docencias.DeberianSerNoNulls(new string[] { "Asignatura", "CategoriaDocente" });

            Assert.IsTrue(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_un_id_natural_y_nivel()
        {
            CvDocencia una_docencia = new CvDocencia() { Id = -7, NivelEducativo = 2 };
            var validador_docencias = new Validador();

            validador_docencias.DeberianSerNaturales(new string[] { "Id", "NivelEducativo" });

            Assert.IsFalse(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_una_asignatura_no_vacia_y_categiria()
        {
            CvDocencia una_docencia = new CvDocencia() { Asignatura = "", CategoriaDocente = "Categoria" };
            var validador_docencias = new Validador();

            validador_docencias.DeberianSerNoVacias(new string[] { "Asignatura", "CategoriaDocente" });

            Assert.IsFalse(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_un_id_natural_o_cero_y_nivel()
        {
            CvDocencia una_docencia = new CvDocencia() { Id = -1, NivelEducativo = 0 };
            var validador_docencias = new Validador();

            validador_docencias.DeberianSerNaturalesOCero(new string[] { "Id", "NivelEducativo" });

            Assert.IsFalse(validador_docencias.EsValido(una_docencia));
        }

        [TestMethod]
        public void deberia_poder_validar_por_una_asignatura_no_nulo_y_categiria()
        {
            CvDocencia una_docencia = new CvDocencia() { Asignatura = null, CategoriaDocente = "Categoria" };
            var validador_docencias = new Validador();

            validador_docencias.DeberianSerNoNulls(new string[] { "Asignatura", "CategoriaDocente" });

            Assert.IsFalse(validador_docencias.EsValido(una_docencia));
        }
    }
}
