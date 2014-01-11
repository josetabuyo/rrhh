using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class CalculadorDeVacaciones
    {
        private IRepositorioLicencia _repositorio_licencia;

        public CalculadorDeVacaciones(IRepositorioLicencia repo_licencia)
        {
            this._repositorio_licencia = repo_licencia;
        }

        public List<VacacionesPermitidas> CalcularVacacionesPermitidasPara(List<Persona> lista_personas)
        {
            return this._repositorio_licencia.GetVacacionesPermitidas(lista_personas, new List<Periodo>());
 
        }
    }
}
