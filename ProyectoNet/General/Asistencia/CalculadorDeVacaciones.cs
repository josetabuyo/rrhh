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

        public List<VacacionesPermitidas> GetVacacionesPermitidas()
        {
            return _repositorio_licencia.GetVacacionesPermitidas();
        }

        public List<VacacionesPermitidas> ObtenerLicenciasPermitidasPara(Persona persona, Periodo periodo, Licencia licencia)
        {
            return _repositorio_licencia.GetVacacionPermitidaPara(persona, periodo, licencia);
        }

        public List<VacacionesAprobadas> ObtenerLicenciasAprobadasPara(Persona persona, Periodo periodo, Licencia licencia)
        {
            return _repositorio_licencia.GetVacacionesAprobadasPara(persona, periodo, licencia);
        }

        public List<VacacionesPermitidas> ObtenerLicenciasPermitidasPara(Persona persona)
        {
            ConceptoDeLicencia concepto = new ConceptoDeLicencia();
            concepto.Id = CodigosDeLicencias.Vacaciones;
            Licencia licencia_por_vacaciones = new Licencia();
            licencia_por_vacaciones.Concepto = concepto;
            return _repositorio_licencia.GetVacacionPermitidaPara(persona, licencia_por_vacaciones);// ObtenerLicenciasPermitidasPara(persona);
        }

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

        private void ImputarA(VacacionesAprobadas aprobadas, List<VacacionesPermitidas> permitidas_consumibles)
        {

            //permitidas_consumibles.RemoveAll(consumible => aprobadas.AnioMinimoImputable() > consumible.Periodo && aprobadas.AnioMaximoImputable().Last().Periodo() <= consumible.Periodo);
            permitidas_consumibles.RemoveAll(consumible => aprobadas.AnioMinimoImputable() > consumible.Periodo);

            var permitidas_aplicables = permitidas_consumibles.FindAll(consumible => consumible.CantidadDeDias() > 0);
            var primera_permitida_aplicable = new VacacionesPermitidas();
            if (permitidas_aplicables.Count() == 0) throw new SolicitudInvalidaException();
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
                ImputarA(aprobadas, permitidas_consumibles);
            }
        }


        protected int AnioMinimoImputable(DateTime fecha)
        {
            var offset = 2;
            if (fecha.Month == 12) offset = 1;
            return fecha.Year - offset;
        }

        public List<VacacionesSolicitables> DiasSolicitables(List<VacacionesPermitidas> permitidas, List<VacacionesAprobadas> aprobadas, List<VacacionesPendientesDeAprobacion> pendientes_de_aprobar, DateTime fecha_de_calculo)
        {
            var vacaciones_solicitables = new List<VacacionesSolicitables>();

            var permitidas_consumibles = Clonar(permitidas);

            if (aprobadas.Count() == 0)
            {
               var vacaciones_permitidas = permitidas_consumibles.FindAll(permitida => permitida.Periodo >= fecha_de_calculo.Year - 1); //El -1 representa la prórroga
               vacaciones_permitidas.ForEach(permitida => vacaciones_solicitables.Add(new VacacionesSolicitables(permitida.Periodo, permitida.CantidadDeDias())));
               return vacaciones_solicitables;
            }
            
            aprobadas.ForEach(aprobada => ImputarA(aprobada.Clonar(), permitidas_consumibles));

            permitidas_consumibles.RemoveAll(consumible => consumible.Periodo < AnioMinimoImputable(fecha_de_calculo));

            permitidas_consumibles.ForEach(consumible => vacaciones_solicitables.Add(new VacacionesSolicitables(consumible.Periodo, consumible.CantidadDeDias())));

            return vacaciones_solicitables;

            //var vacaciones_perdidas = DiasPerdidos(permitidas, aprobadas, pendientes_de_aprobar);
            //var vacaciones_permitidas_sin_periodos_perdidos = permitidas.FindAll(vac_permit => !vacaciones_perdidas.Exists(vac_perd => vac_perd.Periodo == vac_permit.Periodo));
            //var vacaciones_solicitables_sin_perdidos = calculador().DiasSolicitables(vacaciones_permitidas_excluyendo_dias_perdidos, VacacionesAprobadas(), new List<VacacionesPendientesDeAprobacion>());


            //permitidas.ForEach(
            //    (permit) =>
            //    {

            //        var vacas_a_restar = permit.CantidadDeDias() - vacas_aprob - vacas_pend;
            //        var dias_vigentes_para_el_perido = permit.CantidadDeDias() - vacas_aprob - vacas_pend;
            //        if (vacas_a_restar < 0)
            //        {
            //            vacas_a_restar = permit.CantidadDeDias();
            //            dias_vigentes_para_el_perido = 0;
            //        }
            //        else
            //        {
            //            vacas_a_restar = vacas_aprob;
            //        };

            //        vacaciones_solicitables.Add(new VacacionesSolicitables(permit.Periodo, dias_vigentes_para_el_perido));

            //        vacas_aprob -= vacas_a_restar;
            //        if (vacas_aprob < 0) vacas_aprob = 0;
            //    }
            //    );

            //return vacaciones_solicitables;
        }

    

        public List<VacacionesPermitidas> DiasPerdidos(List<VacacionesPermitidas> vacaciones_permitidas, List<VacacionesAprobadas> vacaciones_aprobadas, List<VacacionesPendientesDeAprobacion> vacaciones_pendientes_de_aprobacion)
        {
            //SE DEVUELVE EN ESTA LISTA TODAS LAS LICENCIAS QUE PERDIÓ
            List<VacacionesPermitidas> licencias_perdidas = new List<VacacionesPermitidas>();
            //SE DEVUELVE EN ESTA LISTA TODAS LAS LICENCIAS QUE EFECTIVAMENTE YA GOZÓ
            List<VacacionesPermitidas> licencias_consumidas = new List<VacacionesPermitidas>();
            //SE DEVUELVE EN ESTA LISTA TODAS LAS LICENCIAS QUE AÚN TIENE PERMITIDAS Y QUE PUEDE TOMARSE
            List<VacacionesPermitidas> licencias_que_se_puede_tomar = new List<VacacionesPermitidas>();
            //LISTA INTERNA QUE USAREMOS PARA IR QUITANDO LAS LICENCIAS YA PROCESADAS Y DEPOSITADAS EN LAS 3 ANTERIORES LISTAS
            List<VacacionesPermitidas> lista_interna_licencias_pendientes_de_ser_tratadas = new List<VacacionesPermitidas>();

            var primer_vacacion_permitida = vacaciones_permitidas.First();

            //FUSIONAMOS LAS LICENCIAS APROBADAS CON LAS LICENCIAS QUE ESTÁN EN PROCESO DE SER APROBADAS
            var todas_las_licencias_solicitadas = ObtenerLicenciasSolicitadas(vacaciones_aprobadas, vacaciones_pendientes_de_aprobacion);
            //
            var licencias_permitidas = vacaciones_permitidas;
            //ME FALTA ORDENARLAS

            var primer_licencia_solicitada = todas_las_licencias_solicitadas.First();
            var primer_licencia_permitida = licencias_permitidas.First();

            //Si dejó pasar los años y no se tomó vacaciones, tengo que ver si la prórroga lo salva de perderse los días
            if ((primer_licencia_permitida.Periodo - primer_licencia_solicitada.Periodo()) < 0)
            {
                //obtengo el año de la prórroga de la primer licencias que se tomó
                var prorroga_del_primer_usufructo = licencias_permitidas.DefaultIfEmpty(primer_vacacion_permitida).FirstOrDefault(lic_permitida => lic_permitida.Periodo == primer_licencia_solicitada.Periodo()).Prorroga;

                //Obtengo el año más antigui que está vigente para todavía poderle descontar vacaciones
                var anio_vigente = primer_licencia_solicitada.Periodo() - prorroga_del_primer_usufructo;

                //Las perdidas son todas aquellas que son más chicas a este año
                licencias_perdidas = licencias_permitidas.FindAll(lic_permitida => lic_permitida.Periodo < anio_vigente);

            }
            else
            {
                lista_interna_licencias_pendientes_de_ser_tratadas = licencias_perdidas;

            }

            //------------------------------------------

            var cantidad_de_licencias_por_consumir = primer_licencia_solicitada.CantidadDeDias();

            foreach (var licencia_pendiente in lista_interna_licencias_pendientes_de_ser_tratadas)
            {
                if (cantidad_de_licencias_por_consumir == 0)
                {
                    break;
                }

                if (licencia_pendiente.CantidadDeDias() - cantidad_de_licencias_por_consumir < 0)
                {
                    lista_interna_licencias_pendientes_de_ser_tratadas.Find(l => l == licencia_pendiente).CantidadDeDias(0);
                    cantidad_de_licencias_por_consumir = primer_licencia_solicitada.CantidadDeDias() - licencia_pendiente.CantidadDeDias();
                }
                else
                {
                    lista_interna_licencias_pendientes_de_ser_tratadas.Find(l => l == licencia_pendiente).CantidadDeDias(licencia_pendiente.CantidadDeDias() - cantidad_de_licencias_por_consumir);
                    cantidad_de_licencias_por_consumir = 0;
                }
            }

            return licencias_perdidas;
        }

        private List<CantidadDeDiasPorPeriodo> ObtenerLicenciasSolicitadas(List<VacacionesAprobadas> vacaciones_aprobadas, List<VacacionesPendientesDeAprobacion> vacaciones_pendientes_de_aprobacion)
        {
            List<CantidadDeDiasPorPeriodo> licencias_solicitadas = new List<CantidadDeDiasPorPeriodo>();

            foreach (var aprobada in vacaciones_aprobadas)
            {
                licencias_solicitadas.AddRange(aprobada.AnioMaximoImputable());
            }

            //HARÍA EXACTAMENTE LO MISMO QUE LAS APROBADAS
            //foreach (var pendientes_de_aprobar in vacaciones_pendientes_de_aprobacion)
            //{
            //    licencias_solicitadas.AddRange(pendientes_de_aprobar.AnioMaximoImputable());
            //}

            return licencias_solicitadas;
        }
    }
}
