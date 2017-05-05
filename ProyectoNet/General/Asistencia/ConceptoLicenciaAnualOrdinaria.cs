using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class ConceptoLicenciaAnualOrdinaria : ConceptoDeLicencia
    {
        public ConceptoLicenciaAnualOrdinaria()
        {
            this.Id = 1;
        }

        public override SaldoLicencia RealizarCalculoDeSaldo(IRepositorioLicencia repositorio_licencia, IRepositorioDePersonas repositorio_personas, Persona unaPersona, DateTime fecha_de_consulta)
        {
            SaldoLicencia saldo = new SaldoLicencia();
            saldo.Detalle = new List<SaldoLicenciaDetalle>();
            //ProrrogaLicenciaOrdinaria prorroga;
            unaPersona.TipoDePlanta = repositorio_personas.GetTipoDePlantaActualDe(unaPersona);
            CalculadorDeVacaciones calculador_de_vacaciones = new CalculadorDeVacaciones(repositorio_licencia);
            List<SolicitudesDeVacaciones> solicitudes = new List<SolicitudesDeVacaciones>(this.LicenciasAprobadasPara(repositorio_licencia, unaPersona).ToArray());
            this.LicenciasPendientesPara(repositorio_licencia, unaPersona).ForEach(pendiente => solicitudes.Add(pendiente));
            var vacas_perdidas = new List<VacacionesPermitidas>();
            List<VacacionesSolicitables> vacaciones_solicitables = calculador_de_vacaciones.DiasSolicitables(this.LicenciasPermitidasPara(repositorio_licencia, unaPersona, vacas_perdidas), solicitudes, fecha_de_consulta, unaPersona, new AnalisisDeLicenciaOrdinaria(), vacas_perdidas);

            vacaciones_solicitables.ForEach(vac_solic => saldo.Detalle.Add(new SaldoLicenciaDetalle { Periodo = vac_solic.Periodo(), Disponible = vac_solic.CantidadDeDias() }));

            return saldo;
        }

        public override AnalisisDeLicenciaOrdinaria GetAnalisisCalculoVacacionesPara(IRepositorioLicencia repositorio_licencia, IRepositorioDePersonas repositorio_personas, Persona unaPersona, DateTime fecha_de_consulta)
        {
            var analisis = new AnalisisDeLicenciaOrdinaria();
            var vacas_perdidas = new List<VacacionesPermitidas>();
            var saldo = new SaldoLicencia();
            saldo.Detalle = new List<SaldoLicenciaDetalle>();

            unaPersona.TipoDePlanta = repositorio_personas.GetTipoDePlantaActualDe(unaPersona);
            var calculador_de_vacaciones = new CalculadorDeVacaciones(repositorio_licencia);

            var aprobadas = this.LicenciasAprobadasPara(repositorio_licencia, unaPersona);
            var solicitudes = new List<SolicitudesDeVacaciones>(aprobadas.ToArray());
            this.LicenciasPendientesPara(repositorio_licencia, unaPersona).ForEach(pendiente => solicitudes.Add(pendiente));
            var permitidas_descontando_perdidas = this.LicenciasPermitidasPara(repositorio_licencia, unaPersona, vacas_perdidas);
            var vacaciones_solicitables = calculador_de_vacaciones.DiasSolicitables(permitidas_descontando_perdidas, solicitudes, fecha_de_consulta, unaPersona, analisis, vacas_perdidas);
            var permitidas_calculadas = this.LicenciasCalculadasPara(repositorio_licencia, unaPersona);

            vacaciones_solicitables.ForEach(vac_solic => saldo.Detalle.Add(new SaldoLicenciaDetalle { Periodo = vac_solic.Periodo(), Disponible = vac_solic.CantidadDeDias() }));
            analisis.SetCalculoSinDescuento(permitidas_calculadas);
            analisis.Saldo = vacaciones_solicitables;
            return analisis;
        }

        public List<VacacionesPermitidas> LicenciasCalculadasPara(IRepositorioLicencia repositorio_licencia, Persona persona)
        {
            return repositorio_licencia.GetVacasPermitidasPara(persona, this);
        }

        public List<VacacionesPermitidas> LicenciasPermitidasPara(IRepositorioLicencia repositorio_licencia, Persona persona, List<VacacionesPermitidas> perdidas)
        {
            return repositorio_licencia.GetVacacionPermitidaDescontandoPerdidasPara(persona, this, perdidas);// ObtenerLicenciasPermitidasPara(persona);
        }


        public List<VacacionesAprobadas> LicenciasAprobadasPara(IRepositorioLicencia repositorio_licencia, Persona persona)
        {
            return repositorio_licencia.GetVacacionesAprobadasPara(persona, this);
        }

        public List<VacacionesPendientesDeAprobacion> LicenciasPendientesPara(IRepositorioLicencia repositorio_licencia, Persona persona)
        {
            return repositorio_licencia.GetVacacionesPendientesPara(persona, this);
        }
    }
}
