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
        //private int IdConceptoVacaciones = 1;

        public CalculadorDeVacaciones(IRepositorioLicencia repo_licencia)
        {
            this._repositorio_licencia = repo_licencia;
        }

        public List<VacacionesPermitidas> GetVacacionesPermitidas() 
        {
            return _repositorio_licencia.GetVacacionesPermitidas();
        }

        //public List<VacacionesPermitidas> ObtenerLicenciasPermitidasPara(Persona persona)
        //{

        //    //List<VacacionesPermitidas> vacaciones_permitidas_gral = GetVacacionesPermitidas();

        //    _repositorio_licencia.GetVacacionPermitidaPara(

        //    List<VacacionesPermitidas> vacaciones_permitidas_particular = vacaciones_permitidas_gral.FindAll(v => v.Persona.Equals(persona) && v.Concepto.Equals(this.IdConceptoVacaciones));

        //    return vacaciones_permitidas_particular;
 
        //}

        public List<VacacionesPermitidas> ObtenerLicenciasPermitidasPara(Persona persona, Periodo periodo, Licencia licencia)
        {
            return _repositorio_licencia.GetVacacionPermitidaPara(persona, periodo, licencia);// ObtenerLicenciasPermitidasPara(persona);

            //return vacaciones_permitidas.Find(v => v.Periodo.anio.Equals(periodo.anio) && v.Concepto.Equals(this.IdConceptoVacaciones));
        }

        public List<VacacionesAprobadas> ObtenerLicenciasAprobadasPara(Persona persona, Periodo periodo, Licencia licencia)
        {
            return _repositorio_licencia.GetVacacionesAprobadasPara(persona, periodo, licencia);
        }

        public int CalcularTotalPermitido(List<VacacionesPermitidas> lista)
        {

            int total = 0;
            var vacaciones = lista.FindAll(licencias => licencias.Concepto.Equals(CodigosDeLicencias.Vacaciones));

            return vacaciones.Select(v => v.CantidadDeDias()).Sum();
        }

        public List<VacacionesPermitidas> ObtenerLicenciasPermitidasPara(Persona persona)
        {
            ConceptoDeLicencia concepto = new ConceptoDeLicencia();
            concepto.Id = CodigosDeLicencias.Vacaciones;
            Licencia licencia_por_vacaciones = new Licencia();
            licencia_por_vacaciones.Concepto = concepto;
            return _repositorio_licencia.GetVacacionPermitidaPara(persona, licencia_por_vacaciones);// ObtenerLicenciasPermitidasPara(persona);
        }

        public object DiasRestantes(VacacionesPermitidas permitidas_para_juan, VacacionesAprobadas aprobadas_para_juan, VacacionesPendientesDeAprobacion pendientes_de_aprobar_a_juan)
        {
            return permitidas_para_juan.CantidadDeDias() - aprobadas_para_juan.CantidadDeDias() - pendientes_de_aprobar_a_juan.CantidadDeDias();
        }
    }
}
