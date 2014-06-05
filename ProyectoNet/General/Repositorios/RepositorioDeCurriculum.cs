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
        protected CvEstudios _cvAntecedentesAcademicos;
        protected CvCertificadoDeCapacitacion _cvCapacitacion;
        protected CvDocencia _cvDocencia;
        protected CvEventoAcademico _cvEventoAcademico;
        protected CvPublicaciones _cvPublicacion;

        public RepositorioDeCurriculum(IConexionBD conexion) 
        {
            this.conexion_bd = conexion;
            this.lista_cv = new List<CurriculumVitae>();

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


        public void GuardarCvAntecedentesAcademicos(CvEstudios antecedentesAcademicos_nuevo, Usuario usuario)
        {
            this._cvAntecedentesAcademicos = antecedentesAcademicos_nuevo;
        }


        public List<CvEstudios> GetCvEstudios(int documento)
        {
            var estudios = new List<CvEstudios>()
                               {
                                   new CvEstudios("Contador", "UBA", "Te dije contador", new DateTime(2014, 12, 12),
                                                  new DateTime(2014, 12, 13), "CABA", "Argentina")
                               };
            //Hacer que la fecha sea shortDateTime
            //estudios.ForEach(e => e.FechaIngreso.ToShortDateString() e.FechaEgreso.ToShortDateString());
            return estudios;
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
    }
}
