using System;
using System.Collections.Generic;
namespace General.Repositorios
{
    public interface IRepositorioLicencia
    {
        SaldoLicencia CargarSaldoLicenciaGeneralDe(General.ConceptoDeLicencia concepto, General.Persona unaPersona);
        SaldoLicencia CargarSaldoLicenciaOrdinariaDe(General.ConceptoDeLicencia concepto, General.ProrrogaLicenciaOrdinaria prorroga, General.Persona unaPersona);
        IConexionBD conexion_bd { get; set; }
        bool GetLicenciasQueSePisanCon(General.Licencia unaLicencia);
        bool GetSolicitudesQueSePisanCon(General.Licencia unaLicencia);
        string Guardar(General.Licencia unaLicencia);
        //System.Collections.Generic.List<General.VacacionesPermitidas> GetVacacionesPermitidas( System.Collections.Generic.List<General.Persona> personas, System.Collections.Generic.List<General.Periodo> periodos );
        List<VacacionesPermitidas> GetVacacionesPermitidas();
        List<VacacionesPermitidas> GetVacacionPermitidaPara(Persona persona, Periodo periodo, Licencia licencia);
        List<VacacionesAprobadas> GetVacacionesAprobadasPara(Persona persona);

        List<VacacionesPermitidas> GetVacacionPermitidaPara(Persona persona, ConceptoDeLicencia concepto);
        List<VacacionesPermitidas> GetVacacionPermitidaPara(Periodo periodo, Licencia licencia);

        List<VacacionesAprobadas> GetVacacionesAprobadasPara(Persona persona, ConceptoDeLicencia concepto);
        List<VacacionesPendientesDeAprobacion> GetVacacionesPendientesPara(Persona persona, ConceptoDeLicencia concepto);

        List<VacacionesPendientesDeAprobacion> GetVacacionesPendientesPara(Persona persona);

        ProrrogaLicenciaOrdinaria CargarDatos(ProrrogaLicenciaOrdinaria unaProrroga);
    }
}
