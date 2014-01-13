using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class CalculadorDeVacaciones
    {
        protected IRepositorioLicencia _repositorio_licencia;

        public CalculadorDeVacaciones(IRepositorioLicencia repo_licencia)
        {
            this._repositorio_licencia = repo_licencia;
        }

        public List<VacacionesPermitidas> GetVacacionesPermitidas() 
        {
            return _repositorio_licencia.GetVacacionesPermitidas();
        }

        public List<VacacionesPermitidas> CalcularVacacionesPermitidasPara(Persona persona)
        {

            List<VacacionesPermitidas> vacaciones_permitidas_gral = GetVacacionesPermitidas();

            List<VacacionesPermitidas> vacaciones_permitidas_particular = vacaciones_permitidas_gral.FindAll(v => v.Persona.Equals(persona));

            return vacaciones_permitidas_particular;
 
        }

        public VacacionesPermitidas CalcularVacacionesPermitidasParaEn(Persona persona, Periodo periodo)
        {
            List<VacacionesPermitidas> vacaciones_permitidas = CalcularVacacionesPermitidasPara(persona);

            return vacaciones_permitidas.Find(v => v.Periodo.anio.Equals(periodo.anio));
        }
    }
}
