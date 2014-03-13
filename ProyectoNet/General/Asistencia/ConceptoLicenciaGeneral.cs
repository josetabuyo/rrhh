using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class ConceptoLicenciaGeneral : ConceptoDeLicencia
    {
        public ConceptoLicenciaGeneral(int id)
        {
            this.Id = id;
        }
        public override SaldoLicencia RealizarCalculoDeSaldo(IRepositorioLicencia repo_licencias, IRepositorioDePersonas repositorio_personas, Persona unaPersona, DateTime fecha_de_consulta)
        {
            return repo_licencias.CargarSaldoLicenciaGeneralDe(this, unaPersona);
        }
    }
}
