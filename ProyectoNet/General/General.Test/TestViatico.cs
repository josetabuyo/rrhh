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
    public class TestViatico
    {
        [TestFixtureSetUp]
        public void Setup()
        {


        }

        [Test]
        public void GetMediosDeTransporte()
        {
            RepositorioMediosDeTransporte repositorio = new RepositorioMediosDeTransporte();
            List<MedioDeTransporte> transportes = repositorio.GetTodosLosMediosDeTransporte();
            Assert.IsNotEmpty(transportes);
        }


        [Test]
        public void GetMediosDePago()
        {
            RepositorioMediosDePago repositorio = new RepositorioMediosDePago();
            List<MedioDePago> Pagos = repositorio.GetTodosLosMediosDePago();
            Assert.IsNotEmpty(Pagos);
        }


        //[Test]
        //public void AltaDeViatico()
        //{

        //    ComisionDeServicio comision = new ComisionDeServicio { AdicionalParaPasajes = 589.00F, Eventuales = 730.2F, Pasajes = new List<Pasaje>(), Persona = new Persona(), Viaticos = 32.3F, Desde = DateTime.Today, Hasta = DateTime.Today, Baja = false, Motivo = "Motivo de prueba", Estado = EstadosDeComision.Pendiente };
        //    comision.Pasajes.Add(new Pasaje { Destino = new Localidad { Id = 10 }, Origen = new Localidad { Id = 10 }, Precio = 200.8F, MedioDeTransporte = new MedioDeTransporte { Id = 1 }, FechaDeViaje = new DateTime(2009, 7, 4), ComisionDeServicio = comision, EsOcovu = true });
        //    comision.Pasajes.Add(new Pasaje { Destino = new Localidad { Id = 10 }, Origen = new Localidad { Id = 10 }, Precio = 180.8F, MedioDeTransporte = new MedioDeTransporte { Id = 2 }, FechaDeViaje = new DateTime(2009, 1, 9), ComisionDeServicio = comision, EsOcovu = false });
        //    comision.Persona.NroDocumento = 29753914;

        //    ComisionDeServicio comision2 = new ComisionDeServicio { AdicionalParaPasajes = 589.00F, Eventuales = 730.2F, Pasajes = new List<Pasaje>(), Persona = new Persona(), Viaticos = 32.3F, Desde = DateTime.Today, Hasta = DateTime.Today, Baja = false, Motivo = "Motivo de prueba", Estado = EstadosDeComision.Pendiente };
        //    comision2.Pasajes.Add(new Pasaje { Destino = new Localidad { Id = 10 }, Origen = new Localidad { Id = 10 }, Precio = 200.8F, MedioDeTransporte = new MedioDeTransporte { Id = 2 }, FechaDeViaje = new DateTime(2009, 7, 4), ComisionDeServicio = comision2, EsOcovu = false });
        //    comision2.Pasajes.Add(new Pasaje { Destino = new Localidad { Id = 10 }, Origen = new Localidad { Id = 10 }, Precio = 180.8F, MedioDeTransporte = new MedioDeTransporte { Id = 2 }, FechaDeViaje = new DateTime(2009, 1, 9), ComisionDeServicio = comision2, EsOcovu = true });
        //    comision2.Persona.NroDocumento = 6278699;

        //    List<ComisionDeServicio> comisiones = new List<ComisionDeServicio>();
        //    comisiones.Add(comision);
        //    comisiones.Add(comision2);

        //    RepositorioComisionesDeServicio repositorio = new RepositorioComisionesDeServicio();
        //    repositorio.AltaDeComisionesDeServicio(comisiones);
        //}

        [Test]
        public void AltaDeViatico()
        {
            ComisionDeServicio comision1 = new ComisionDeServicio { Persona = new Persona { Documento = 29753914 }, Estado = EstadosDeComision.Pendiente, Baja = false };
            comision1.Estadias.Add(new Estadia { ComisionDeServicio = comision1, Desde = new DateTime(2009, 09, 8), Hasta = new DateTime(2009, 10, 11), Motivo = "Motivo de Prueba", Eventuales = 284.15F, CalculadoPorCategoria = 154.32F, AdicionalParaPasajes = 64.5F, Provincia = new Provincia { Id = 10 } });
            comision1.Estadias.Add(new Estadia { ComisionDeServicio = comision1, Desde = new DateTime(2009, 10, 12), Hasta = new DateTime(2009, 10, 15), Motivo = "Otro Motivo de Prueba", Eventuales = 274.85F, CalculadoPorCategoria = 256F, AdicionalParaPasajes = 12.5F, Provincia = new Provincia { Id = 14 } });
            comision1.Estadias.Add(new Estadia { ComisionDeServicio = comision1, Desde = new DateTime(2009, 10, 16), Hasta = new DateTime(2009, 10, 24), Motivo = "Tercer Motivo de Prueba", Eventuales = 224.85F, CalculadoPorCategoria = 156F, AdicionalParaPasajes = 123.5F, Provincia = new Provincia { Id = 18 } });

            comision1.Pasajes.Add(new Pasaje { ComisionDeServicio = comision1, FechaDeViaje = new DateTime(2009, 09, 8), MedioDeTransporte = new MedioDeTransporte { Id = 1 }, Origen = new Localidad { Id = 4800 }, Destino = new Localidad { Id = 5779 }, Precio = 15.32F, Baja = false, MedioDePago = new MedioDePago { Id = 1 } });
            comision1.Pasajes.Add(new Pasaje { ComisionDeServicio = comision1, FechaDeViaje = new DateTime(2009, 10, 16), MedioDeTransporte = new MedioDeTransporte { Id = 1 }, Origen = new Localidad { Id = 10204 }, Destino = new Localidad { Id = 4800 }, Precio = 15.32F, Baja = false, MedioDePago = new MedioDePago { Id = 1 } });


            ComisionDeServicio comision2 = new ComisionDeServicio { Persona = new Persona { Documento = 6278699 }, Estado = EstadosDeComision.Pendiente, Baja = false };
            comision2.Estadias.Add(new Estadia { ComisionDeServicio = comision2, Desde = new DateTime(2009, 10, 8), Hasta = new DateTime(2009, 10, 8), Motivo = "Motivo de Prueba", Eventuales = 284.15F, CalculadoPorCategoria = 154.32F, AdicionalParaPasajes = 64.5F, Provincia = new Provincia { Id = 10 } });
            comision2.Estadias.Add(new Estadia { ComisionDeServicio = comision2, Desde = new DateTime(2008, 11, 7), Hasta = new DateTime(2008, 11, 15), Motivo = "Otro Motivo de Prueba", Eventuales = 274.85F, CalculadoPorCategoria = 256F, AdicionalParaPasajes = 12.5F, Provincia = new Provincia { Id = 14 } });

            comision2.Pasajes.Add(new Pasaje { ComisionDeServicio = comision2, FechaDeViaje = new DateTime(2009, 09, 8), MedioDeTransporte = new MedioDeTransporte { Id = 1 }, Origen = new Localidad { Id = 4800 }, Destino = new Localidad { Id = 5779 }, Precio = 15.32F, Baja = false, MedioDePago = new MedioDePago { Id = 1 } });
            comision2.Pasajes.Add(new Pasaje { ComisionDeServicio = comision2, FechaDeViaje = new DateTime(2009, 10, 16), MedioDeTransporte = new MedioDeTransporte { Id = 1 }, Origen = new Localidad { Id = 10204 }, Destino = new Localidad { Id = 4800 }, Precio = 15.32F, Baja = false, MedioDePago = new MedioDePago { Id = 1 } });

            List<ComisionDeServicio> comisiones = new List<ComisionDeServicio>();
            comisiones.Add(comision1);
            comisiones.Add(comision2);

            RepositorioComisionesDeServicio repoComisiones = new RepositorioComisionesDeServicio();
            repoComisiones.AltaDeComisionesDeServicio(comisiones);

        }
    }
}
