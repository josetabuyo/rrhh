using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using General;

namespace General
{
    public class ServicioDeLicencias
    {
        protected IRepositorioLicencia _repositorio_licencia;

        public ServicioDeLicencias(IRepositorioLicencia repo_licencia)
        {
            this._repositorio_licencia = repo_licencia;
        }



        public SaldoLicencia GetSaldoLicencia(Persona unaPersona, ConceptoDeLicencia concepto, DateTime fecha_de_consulta, IRepositorioDePersonas repo_personas) 
        {
            SaldoLicencia saldo = new SaldoLicencia();
            saldo.Detalle = new List<SaldoLicenciaDetalle>();
            ProrrogaLicenciaOrdinaria prorroga;

            CalculadorDeVacaciones calculador_de_vacaciones = new CalculadorDeVacaciones();

            List<VacacionesSolicitables> vacaciones_solicitables = calculador_de_vacaciones.DiasSolicitables(this.LicenciasPermitidasPara(unaPersona), this.LicenciasAprobadasPara(unaPersona), this.LicenciasPendientesPara(unaPersona), fecha_de_consulta);

            vacaciones_solicitables.ForEach(vac_solic => saldo.Detalle.Add(new SaldoLicenciaDetalle { Periodo = vac_solic.Periodo(), Disponible = vac_solic.CantidadDeDias() }));

            //ProrrogaLicenciaOrdinaria prorroga = new ProrrogaLicenciaOrdinaria { Periodo = 2014, UsufructoDesde = 2005, UsufructoHasta = 2013 };
            
            //RepositorioPersonas repoPersonas = new RepositorioPersonas();
            unaPersona.TipoDePlanta = repo_personas.GetTipoDePlantaActualDe(unaPersona);

            //RepositorioLicencias repoLicencias = new RepositorioLicencias(Conexion());
            SaldoLicencia unSaldo;
            //ProrrogaLicenciaOrdinaria prorroga = new ProrrogaLicenciaOrdinaria();

            //if (prorroga.SeAplicaAlTipoDePlanta(unaPersona.TipoDePlanta))
            //if(unaPersona.TipoDePlanta.Id != 22)
            //{

            //    //RepositorioProrrogasDeLicenciaOrdinaria repoProrrogas = new RepositorioProrrogasDeLicenciaOrdinaria();
            //    prorroga =  this._repositorio_licencia.CargarDatos(new ProrrogaLicenciaOrdinaria());
            //}
            //else
            //{
            //    prorroga = null;
            //}

            //if (concepto.Id == 1)
            //{
            //    unSaldo = _repositorio_licencia.CargarSaldoLicenciaOrdinariaDe(concepto, prorroga, unaPersona);
            //}
            //else
            //{
            //    unSaldo = _repositorio_licencia.CargarSaldoLicenciaGeneralDe(concepto, unaPersona);
            //}
            return saldo;
        }

        public List<VacacionesPermitidas> LicenciasPermitidasPara(Persona persona)
        {
            ConceptoDeLicencia concepto = new ConceptoDeLicencia();
            concepto.Id = CodigosDeLicencias.Vacaciones;
            Licencia licencia_por_vacaciones = new Licencia();
            licencia_por_vacaciones.Concepto = concepto;
            return _repositorio_licencia.GetVacacionPermitidaPara(persona, licencia_por_vacaciones);// ObtenerLicenciasPermitidasPara(persona);
        }


        public List<VacacionesAprobadas> LicenciasAprobadasPara(Persona persona)
        {
            return _repositorio_licencia.GetVacacionesAprobadasPara(persona);
        }

        public List<VacacionesPendientesDeAprobacion> LicenciasPendientesPara(Persona persona)
        {
            return _repositorio_licencia.GetVacacionesPendientesPara(persona);
        }
    }
}
