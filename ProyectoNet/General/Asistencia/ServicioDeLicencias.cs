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

            return concepto.RealizarCalculoDeSaldo(this._repositorio_licencia, repo_personas, unaPersona, fecha_de_consulta);

        }
      
    }
}
