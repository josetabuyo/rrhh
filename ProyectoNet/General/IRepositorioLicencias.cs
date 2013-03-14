using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public interface IRepositorioLicencias
    {
        string Guardar(Licencia unaLicencia);
        bool GetLicenciasQueSePisanCon(Licencia unaLicencia);
        bool GetSolicitudesQueSePisanCon(Licencia unaLicencia);
        SaldoLicencia CargarSaldoLicenciaGeneralDe(ConceptoDeLicencia concepto, Persona unaPersona);
        SaldoLicencia CargarSaldoLicenciaOrdinariaDe(ConceptoDeLicencia concepto, ProrrogaLicenciaOrdinaria prorroga, Persona unaPersona);

    }
}
