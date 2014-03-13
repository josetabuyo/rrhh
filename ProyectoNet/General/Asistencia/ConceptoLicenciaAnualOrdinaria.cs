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
            CalculadorDeVacaciones calculador_de_vacaciones = new CalculadorDeVacaciones();
            List<SolicitudesDeVacaciones> solicitudes = new List<SolicitudesDeVacaciones>(this.LicenciasAprobadasPara(repositorio_licencia, unaPersona).ToArray());
            this.LicenciasPendientesPara(repositorio_licencia, unaPersona).ForEach(pendiente => solicitudes.Add(pendiente));            
            List<VacacionesSolicitables> vacaciones_solicitables = calculador_de_vacaciones.DiasSolicitables(this.LicenciasPermitidasPara(repositorio_licencia, unaPersona), solicitudes, fecha_de_consulta, unaPersona);

            vacaciones_solicitables.ForEach(vac_solic => saldo.Detalle.Add(new SaldoLicenciaDetalle { Periodo = vac_solic.Periodo(), Disponible = vac_solic.CantidadDeDias() }));

            return saldo;

        }
        public List<VacacionesPermitidas> LicenciasPermitidasPara(IRepositorioLicencia repositorio_licencia, Persona persona)
        {
            return repositorio_licencia.GetVacacionPermitidaPara(persona, this);// ObtenerLicenciasPermitidasPara(persona);
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
