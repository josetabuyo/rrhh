using System;
using System.Collections.Generic;
namespace General.Repositorios
{
    public interface IRepositorioLicencia
    {
        SaldoLicencia CargarSaldoLicenciaGeneralDe(General.ConceptoDeLicencia concepto, General.Persona unaPersona);
        SaldoLicencia CargarSaldoLicenciaOrdinariaDe(General.ConceptoDeLicencia concepto, General.ProrrogaLicenciaOrdinaria prorroga, General.Persona unaPersona);
        bool GetLicenciasQueSePisanCon(General.Licencia unaLicencia);
        bool GetSolicitudesQueSePisanCon(General.Licencia unaLicencia);
        string Guardar(General.Licencia unaLicencia);
        void LoguearError(List<VacacionesPermitidas> permitidas_log, SolicitudesDeVacaciones aprobadas, Persona persona, DateTime fecha_calculo);
        //System.Collections.Generic.List<General.VacacionesPermitidas> GetVacacionesPermitidas( System.Collections.Generic.List<General.Persona> personas, System.Collections.Generic.List<General.Periodo> periodos );
        List<VacacionesPermitidas> GetVacacionesPermitidas();
        List<VacacionesPermitidas> GetVacacionPermitidaPara(Persona persona, Periodo periodo, Licencia licencia);
        List<VacacionesPermitidas> GetVacasPermitidasPara(Persona persona, ConceptoDeLicencia concepto);
        List<VacacionesAprobadas> GetVacacionesAprobadasPara(Persona persona);

        List<VacacionesPermitidas> GetVacacionPermitidaDescontandoPerdidasPara(Persona persona, ConceptoDeLicencia concepto, List<VacacionesPermitidas> perdidas);
        List<VacacionesPermitidas> GetVacacionPermitidaPara(Periodo periodo, Licencia licencia);

        List<VacacionesAprobadas> GetVacacionesAprobadasPara(Persona persona, ConceptoDeLicencia concepto);
        List<VacacionesPendientesDeAprobacion> GetVacacionesPendientesPara(Persona persona, ConceptoDeLicencia concepto);

        List<VacacionesPendientesDeAprobacion> GetVacacionesPendientesPara(Persona persona);

        ProrrogaLicenciaOrdinaria CargarDatos(ProrrogaLicenciaOrdinaria unaProrroga);

        List<VacacionesPermitidas> VacacionesPerdidasDe(int documento);
        int GetProrrogaPlantaGeneral(int anio_calculo);

        void LoguearDetalleCalculoLicencia(SolicitudesDeVacaciones aprobadas, int anio, Persona persona, DateTime fecha_calculo, bool ya_imputados, bool error);
    }
}
