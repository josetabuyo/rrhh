using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;

namespace General.Repositorios
{
    public class RepositorioDeCurriculum : General.Repositorios.IRepositorioDeCurriculum
    {
        protected IConexionBD conexion_bd;
        protected List<CurriculumVitae> lista_cv;
        protected CvDatosPersonales _cvDatosPersonales;
        protected List<CvEstudios> _cvAntecedentesAcademicos;
        protected CvCertificadoDeCapacitacion _cvCapacitacion;
        protected CvDocencia _cvDocencia;
        protected CvEventoAcademico _cvEventoAcademico;
        protected CvPublicaciones _cvPublicacion;
        protected CvMatricula _cvMatricula;


        public RepositorioDeCurriculum(IConexionBD conexion) 
        {
            this.conexion_bd = conexion;
            this.lista_cv = new List<CurriculumVitae>();
            this._cvAntecedentesAcademicos = new List<CvEstudios>();

            //FC a borrar cuando traiga los datos de la base
            string fechaIngreso = new DateTime(2014, 12, 12).ToShortDateString();

            string fechaEgreso = new DateTime(2014, 12, 13).ToShortDateString();

            var un_estudio = new CvEstudios(1, "Contador", "UBA", "Te dije contador", fechaIngreso,
                                                  fechaEgreso, "CABA", "Argentina");

            this._cvAntecedentesAcademicos.Add(un_estudio);

        }

        public CurriculumVitae GetCV(int documento)
        {

            return this.lista_cv.Find(cvs => cvs.DatosPersonales.Dni.Equals(documento));
        }

        public void GuardarCVDatosPersonales(CvDatosPersonales datosPersonales, Usuario usuario)
        {
            this._cvDatosPersonales = datosPersonales;
            //this.lista_cv.Add(cv);
        }

        public void ActualizarCV(CurriculumVitae cv)
        {
        }


        public List<CvEstudios> GuardarCvAntecedentesAcademicos(CvEstudios antecedentesAcademicos_nuevo, Usuario usuario)
        {
            this._cvAntecedentesAcademicos.Add(antecedentesAcademicos_nuevo);

            return this._cvAntecedentesAcademicos;
        }

        public CvEstudios EliminarCVAntecedentesAcademicos(CvEstudios antecedentesAcademicos_a_borrar, Usuario usuario)
        {
            this._cvAntecedentesAcademicos.Remove(antecedentesAcademicos_a_borrar);
            return antecedentesAcademicos_a_borrar;
        }

        


        public List<CvEstudios> GetCvEstudios(int documento)
        {
            
            //Hacer que la fecha sea shortDateTime
            //estudios.ForEach(e => e.FechaIngreso.ToShortDateString() e.FechaEgreso.ToShortDateString());
            return this._cvAntecedentesAcademicos;
        }

        public void GuardarCvCapacidades(CvCertificadoDeCapacitacion capacidades_nuevo, Usuario usuario)
        {
            this._cvCapacitacion = capacidades_nuevo;
        }

        public void GuardarCvDocencia(CvDocencia docencia_nuevo, Usuario usuario)
        {
            this._cvDocencia = docencia_nuevo;
        }

        public void GuardarCvEventoAcademico(CvEventoAcademico eventoAcademico_nuevo, Usuario usuario)
        {
            this._cvEventoAcademico = eventoAcademico_nuevo;
        }


        public void GuardarCvPublicaciones(CvPublicaciones publicacion_nueva, Usuario usuario)
        {
            this._cvPublicacion = publicacion_nueva;
        }


        public void GuardarCvMatriculas(CvMatricula matricula_nueva, Usuario usuario)
        {
            this._cvMatricula = matricula_nueva;
        }



    }
}
