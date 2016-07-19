using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using General;

namespace General
{
    public class CalculadorDeVacaciones
    {
        protected IRepositorioLicencia _repositorio_licencia;

        public CalculadorDeVacaciones(IRepositorioLicencia repo_licencia)
        {
            this._repositorio_licencia = repo_licencia;
        }

        public CalculadorDeVacaciones()
        {
            // TODO: Complete member initialization
        }

        //public List<VacacionesPermitidas> GetVacacionesPermitidas()
        //{
        //    return _repositorio_licencia.GetVacacionesPermitidas();
        //}

        public List<VacacionesPermitidas> ObtenerLicenciasPermitidasPara(Persona persona, Periodo periodo, Licencia licencia)
        {
            return _repositorio_licencia.GetVacacionPermitidaPara(persona, periodo, licencia);
        }

        //public List<VacacionesAprobadas> ObtenerLicenciasAprobadasPara(Persona persona, Periodo periodo, Licencia licencia)
        //{
        //    return _repositorio_licencia.GetVacacionesAprobadasPara(persona, periodo, licencia);
        //}

        //public List<VacacionesPermitidas> ObtenerLicenciasPermitidasPara(Persona persona)
        //{
        //    ConceptoDeLicencia concepto = new ConceptoDeLicencia();
        //    concepto.Id = CodigosDeLicencias.Vacaciones;
        //    Licencia licencia_por_vacaciones = new Licencia();
        //    licencia_por_vacaciones.Concepto = concepto;
        //    return _repositorio_licencia.GetVacacionPermitidaPara(persona, licencia_por_vacaciones);// ObtenerLicenciasPermitidasPara(persona);
        //}

        public object DiasRestantes(VacacionesPermitidas permitidas, VacacionesAprobadas aprobadas, VacacionesPendientesDeAprobacion pendientes_de_aprobar)
        {
            return permitidas.CantidadDeDias() - aprobadas.CantidadDeDias() - pendientes_de_aprobar.CantidadDeDias();
        }

        protected List<VacacionesPermitidas> Clonar(List<VacacionesPermitidas> original)
        {
            var permitidas_consumibles = new List<VacacionesPermitidas>();
            original.ForEach(permitida => permitidas_consumibles.Add(permitida.Clonar()));
            return permitidas_consumibles;
        }

        private void ImputarA(SolicitudesDeVacaciones aprobadas, List<VacacionesPermitidas> permitidas_consumibles, Persona persona, DateTime fecha_calculo)
        {

            //permitidas_consumibles.RemoveAll(consumible => aprobadas.AnioMinimoImputable() > consumible.Periodo && aprobadas.AnioMaximoImputable().Last().Periodo() <= consumible.Periodo);
            var permitidas_consumibles_log = new List<VacacionesPermitidas>(permitidas_consumibles);
            permitidas_consumibles.RemoveAll(consumible => aprobadas.AnioMinimoImputable(persona) > consumible.Periodo);
            var permitidas_consumibles2 = new List<VacacionesPermitidas>(permitidas_consumibles);
            var permitidas_log = new List<VacacionesPermitidas>(permitidas_consumibles2);
            permitidas_consumibles2.RemoveAll(consumible => aprobadas.AnioMaximoImputable().Last().Periodo() < consumible.Periodo);


            var permitidas_aplicables = permitidas_consumibles2.FindAll(consumible => consumible.CantidadDeDias() > 0);
            var primera_permitida_aplicable = new VacacionesPermitidas();
            if (permitidas_aplicables.Count() == 0)
            {
               // _repositorio_licencia.LoguearError(permitidas_log, aprobadas, persona, fecha_calculo);
                //throw new SolicitudInvalidaException(); 
                return;
            }
            primera_permitida_aplicable = permitidas_aplicables.First();
      
            if (primera_permitida_aplicable.CantidadDeDias() > aprobadas.CantidadDeDias())
            {
                primera_permitida_aplicable.RestarDias(aprobadas.CantidadDeDias());
            }
            else
            {
                aprobadas.DiasYaImputados(primera_permitida_aplicable.CantidadDeDias());
                primera_permitida_aplicable.RestarDias(primera_permitida_aplicable.CantidadDeDias());
                if (primera_permitida_aplicable.CantidadDeDias() == 0) {
                    permitidas_consumibles.Remove(primera_permitida_aplicable);
                }
                if (aprobadas.CantidadDeDias() > 0)
                {
                    ImputarA(aprobadas, permitidas_consumibles, persona, fecha_calculo);
                }
            }
        }

        //private void ImputarA(SolicitudesDeVacaciones pendiente, List<VacacionesPermitidas> permitidas_consumibles, Persona persona)
        //{

        //    //permitidas_consumibles.RemoveAll(consumible => aprobadas.AnioMinimoImputable() > consumible.Periodo && aprobadas.AnioMaximoImputable().Last().Periodo() <= consumible.Periodo);
        //    permitidas_consumibles.RemoveAll(consumible => pendiente.AnioMinimoImputable(persona) > consumible.Periodo);

        //    var permitidas_aplicables = permitidas_consumibles.FindAll(consumible => consumible.CantidadDeDias() > 0);
        //    var primera_permitida_aplicable = new VacacionesPermitidas();
        //    if (permitidas_aplicables.Count() == 0) throw new SolicitudInvalidaException();
        //    primera_permitida_aplicable = permitidas_aplicables.First();

        //    if (primera_permitida_aplicable.CantidadDeDias() > (pendiente.CantidadDeDias()))
        //    {
        //        primera_permitida_aplicable.RestarDias(pendiente.CantidadDeDias());
        //    }
        //    else
        //    {
        //        pendiente.DiasYaImputados(primera_permitida_aplicable.CantidadDeDias());
        //        primera_permitida_aplicable.RestarDias(primera_permitida_aplicable.CantidadDeDias());
        //        if (primera_permitida_aplicable.CantidadDeDias() == 0)
        //        {
        //            permitidas_consumibles.Remove(primera_permitida_aplicable);
        //        }
        //        ImputarA(pendiente, permitidas_consumibles, persona);
        //    }
        //}


        protected int AnioMinimoImputable(DateTime fecha)
        {
            var offset = 2;
            if (fecha.Month == 12) offset = 1;
            return fecha.Year - offset;
        }

        public List<VacacionesSolicitables> DiasSolicitables(List<VacacionesPermitidas> permitidas, List<SolicitudesDeVacaciones> solicitudes, DateTime fecha_de_calculo, Persona persona)
        {
            var vacaciones_solicitables = new List<VacacionesSolicitables>();

         //   var pendientes_de_aprobar = pendientes.FindAll(pend => pend.Desde() >= aprobadas.Last().Desde());
            
            var permitidas_consumibles = Clonar(permitidas);
            solicitudes = this.DividirSolicitudes(solicitudes);
            if (solicitudes.Count() == 0)
            {
                var vacaciones_permitidas = permitidas_consumibles.FindAll(permitida => permitida.Periodo >= persona.TipoDePlanta.Prorroga(fecha_de_calculo).UsufructoDesde);// fecha_de_calculo.Year - 1); //El -1 representa la prórroga
               vacaciones_permitidas.ForEach(permitida => vacaciones_solicitables.Add(new VacacionesSolicitables(permitida.Periodo, permitida.CantidadDeDias())));
               return vacaciones_solicitables;
            }


            solicitudes.ForEach(solicitud => ImputarA(solicitud.Clonar(), permitidas_consumibles, persona, fecha_de_calculo));

            permitidas_consumibles.RemoveAll(consumible => consumible.Periodo < persona.TipoDePlanta.Prorroga(fecha_de_calculo).UsufructoDesde);

            //imputo las pendientes a las permitidas consumibles
            //pendientes_de_aprobar.ForEach(pendiente => ImputarA(pendiente.Clonar(), permitidas_consumibles,persona));

            permitidas_consumibles.ForEach(consumible => vacaciones_solicitables.Add(new VacacionesSolicitables(consumible.Periodo, consumible.CantidadDeDias())));

            return vacaciones_solicitables;

        }


        public List<SolicitudesDeVacaciones> DividirSolicitudes(List<SolicitudesDeVacaciones> solicitudes_original)
        {
            var result = new List<SolicitudesDeVacaciones>();
            solicitudes_original.ForEach(solicitud => result.AddRange(solicitud.Partir()));
            return result;
        }
    }
}
