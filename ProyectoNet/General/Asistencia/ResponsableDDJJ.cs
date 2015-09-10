using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using General.Repositorios;
using System.Configuration;

namespace General
{
    public class ResponsableDDJJ
    {
        IRepositorioDePermisosSobreAreas repositorio;

        public ResponsableDDJJ(IRepositorioDePermisosSobreAreas un_repo)
        {
            repositorio = un_repo;
        }

        public ConexionBDSQL Conexion()
        {
            return new ConexionBDSQL(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
        }

        public List<Area> AreasConDDJJAdministradasPor(Usuario usuario)
        {
            return repositorio.AreasAdministradasPor(usuario).FindAll(area => area.PresentaDDJJ);
        }

        public List<Area> AreasSinDDJJInferioresA(Area area)
        {
            var repositorio = new RepositorioDeOrganigrama(Conexion());
            //return repositorio.GetOrganigrama().AreasInferioresInmediatasDe(area).FindAll(a => !a.PresentaDDJJ);
            return repositorio.GetAreaInferiorById(area.Id, false);
        }

        public List<DDJJ104> GetAreasDDJJ(Usuario usuario , int mes, int anio)
        {
            RepositorioPersonas repoPersonas = new RepositorioPersonas();
            DDJJ104 ddjj_dto;
            int contador_de_personas = 0;

            var areas_con_ddjj = AreasConDDJJAdministradasPor(usuario);

            List<DDJJ104> lista_ddjj = new List<DDJJ104>();
            foreach (var un_area in areas_con_ddjj)
            {
                ddjj_dto = new DDJJ104();

                //--- Cargo el areas Formal (ddjj = 1) y Obtengo las personas de esa Area
                ddjj_dto.Area = un_area;
                un_area.Personas = repoPersonas.GetPersonasDelAreaReducida(un_area,2);
                contador_de_personas += un_area.Personas.Count();

                //--- Cargo el areas inferiores (ddjj = 0) y Obtengo las personas de esas Areas
                List<Persona> personasAreaInformales = new List<Persona>();
                personasAreaInformales = repoPersonas.GetPersonasDelAreaReducida(un_area, 0);
                if (personasAreaInformales.Count != 0)
                {
                    un_area.Personas.AddRange(personasAreaInformales);
                    contador_de_personas += personasAreaInformales.Count();
                }

                ddjj_dto.CantidadPersonas = contador_de_personas;
                ddjj_dto.Mes = mes;
                ddjj_dto.Anio = anio;
                ddjj_dto.Estado = new RepositorioDDJJ104().GetEstadoDDJJ(ddjj_dto);

                lista_ddjj.Add(ddjj_dto);

                contador_de_personas = 0;
            }


            return lista_ddjj;
        }


        public bool GenerarDDJJ104(Usuario usuario, List<DDJJ104> lista)
        {
            RepositorioDDJJ104 ddjj = new RepositorioDDJJ104();
            return ddjj.GenerarDDJJ104(usuario, lista);
        }

        public List<DDJJ104> ImprimirDDJJ104(List<DDJJ104> lista)
        {
            RepositorioDDJJ104 ddjj = new RepositorioDDJJ104();
            return ddjj.ImprimirDDJJ104(lista);
        }

        public void MarcarDDJJ104Impresa(int nroDDJJ, int estado)
        {
            RepositorioDDJJ104 ddjj = new RepositorioDDJJ104();
            ddjj.MarcarDDJJ104Impresa(nroDDJJ, estado);
        }

    }
}
