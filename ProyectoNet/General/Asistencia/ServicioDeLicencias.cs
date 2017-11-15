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
            //ProrrogaLicenciaOrdinaria prorroga = new ProrrogaLicenciaOrdinaria { Periodo = 2014, UsufructoDesde = 2005, UsufructoHasta = 2013 };
            //RepositorioPersonas repoPersonas = new RepositorioPersonas();

            //RepositorioLicencias repoLicencias = new RepositorioLicencias(Conexion());
            //SaldoLicencia unSaldo;
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
            var log = concepto.GetAnalisisCalculoVacacionesPara(this._repositorio_licencia, repo_personas, unaPersona, fecha_de_consulta);

            return concepto.RealizarCalculoDeSaldo(this._repositorio_licencia, repo_personas, unaPersona, fecha_de_consulta);
        }
        public int GetSegmentosUtilizados(int documento, int anio){
           return this._repositorio_licencia.GetSegmentosUtilizados(documento, anio);
        }
    }
}
