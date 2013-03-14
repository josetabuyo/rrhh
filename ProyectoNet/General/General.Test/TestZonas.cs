using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using General;
using General.Repositorio;

namespace General.Test
{
    [TestFixture]
    public class TestZonas
    {
        [Test]
        public void TestGetZonas()
        {
            RepositorioZonas repositorio = new RepositorioZonas();
            List<Zona> zonas = new List<Zona>();
            zonas = repositorio.GetTodasLasZonas();
        }
    }
}
