using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class ConceptoLicenciaAnualOrdinaria : ConceptoDeLicencia
    {

        public override SaldoLicencia RealizarCalculoDeSaldo(IRepositorioLicencia repositorio_licencia, IRepositorioDePersonas repositorio_personas, Persona unaPersona, DateTime fecha_de_consulta)
        {
            SaldoLicencia saldo = new SaldoLicencia();
            saldo.Detalle = new List<SaldoLicenciaDetalle>();
            ProrrogaLicenciaOrdinaria prorroga;
            unaPersona.TipoDePlanta = repositorio_personas.GetTipoDePlantaActualDe(unaPersona);
            CalculadorDeVacaciones calculador_de_vacaciones = new CalculadorDeVacaciones();

            List<VacacionesSolicitables> vacaciones_solicitables = calculador_de_vacaciones.DiasSolicitables(this.LicenciasPermitidasPara(repositorio_licencia, unaPersona), this.LicenciasAprobadasPara(repositorio_licencia, unaPersona), this.LicenciasPendientesPara(repositorio_licencia, unaPersona), fecha_de_consulta);

            vacaciones_solicitables.ForEach(vac_solic => saldo.Detalle.Add(new SaldoLicenciaDetalle { Periodo = vac_solic.Periodo(), Disponible = vac_solic.CantidadDeDias() }));

            return saldo;

        }
        public List<VacacionesPermitidas> LicenciasPermitidasPara(IRepositorioLicencia repositorio_licencia, Persona persona)
        {
            ConceptoDeLicencia concepto = new ConceptoDeLicencia();
            concepto.Id = CodigosDeLicencias.Vacaciones;
            Licencia licencia_por_vacaciones = new Licencia();
            licencia_por_vacaciones.Concepto = concepto;
            return repositorio_licencia.GetVacacionPermitidaPara(persona, licencia_por_vacaciones);// ObtenerLicenciasPermitidasPara(persona);
        }


        public List<VacacionesAprobadas> LicenciasAprobadasPara(IRepositorioLicencia repositorio_licencia, Persona persona)
        {
            return repositorio_licencia.GetVacacionesAprobadasPara(persona);
        }

        public List<VacacionesPendientesDeAprobacion> LicenciasPendientesPara(IRepositorioLicencia repositorio_licencia, Persona persona)
        {
            return repositorio_licencia.GetVacacionesPendientesPara(persona);
        }
    }
}
