using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CurriculumVitae
    {
        protected CvDatosPersonales _datosPersonales;
        protected List<CvEstudios> _cvEstudios;
        protected List<CvEventoAcademico> _cvEventoAcademicos;
        protected List<CvExperienciaLaboral> _cvExperienciaLaboral;
        protected List<CvIdiomas> _cvIdiomas;
        protected List<CvInstitucionesAcademicas> _cvInstitucionesAcademicas;
        protected List<CvMatricula> _cvMatriculas;
        protected List<CvPublicaciones> _cvPublicaciones;
        protected List<CvDocencia> _cvDocencias;
        protected List<CvCompetenciasInformaticas> _cvCompetenciasInformaticas;
        protected List<CvCertificadoDeCapacitacion> _cvCertificadosDeCapacitacion;

        public CvDatosPersonales DatosPersonales { get { return _datosPersonales; } set { _datosPersonales = value; } }
        public List<CvEstudios> CvEstudios { get { return _cvEstudios; } set { _cvEstudios = value; } }
        public List<CvEventoAcademico> CvEventosAcademicos { get { return _cvEventoAcademicos; } set { _cvEventoAcademicos = value; } }
        public List<CvExperienciaLaboral> CvExperienciaLaboral { get { return _cvExperienciaLaboral; } set { _cvExperienciaLaboral = value; } }
        public List<CvIdiomas> CvIdiomas { get { return _cvIdiomas; } set { _cvIdiomas = value; } }
        public List<CvInstitucionesAcademicas> CvInstitucionesAcademicas { get { return _cvInstitucionesAcademicas; } set { _cvInstitucionesAcademicas = value; } }
        public List<CvMatricula> CvMatricula { get { return _cvMatriculas; } set { _cvMatriculas = value; } }
        public List<CvPublicaciones> CvPublicaciones { get { return _cvPublicaciones; } set { _cvPublicaciones = value; } }
        public List<CvDocencia> CvDocencias { get { return _cvDocencias; } set { _cvDocencias = value; } }
        public List<CvCompetenciasInformaticas> CvCompetenciasInformaticas { get { return _cvCompetenciasInformaticas; } set { _cvCompetenciasInformaticas = value; } }
        public List<CvCertificadoDeCapacitacion> CvCertificadosDeCapacitacion { get { return _cvCertificadosDeCapacitacion; } set { _cvCertificadosDeCapacitacion = value; } }


        public CurriculumVitae(CvDatosPersonales datosPersonales)
        {
            this._datosPersonales = datosPersonales;
            this._cvEstudios = new List<CvEstudios>();
            this._cvEventoAcademicos = new List<CvEventoAcademico>();
            this._cvExperienciaLaboral = new List<CvExperienciaLaboral>();
            this._cvIdiomas = new List<CvIdiomas>();
            this._cvInstitucionesAcademicas = new List<CvInstitucionesAcademicas>();
            this._cvMatriculas = new List<CvMatricula>();
            this._cvPublicaciones = new List<CvPublicaciones>();
            this._cvDocencias = new List<CvDocencia>();
            this._cvCompetenciasInformaticas = new List<CvCompetenciasInformaticas>();
            this._cvCertificadosDeCapacitacion = new List<CvCertificadoDeCapacitacion>();
        }

        public void AgregarEstudio(CvEstudios cvEstudio)
        {
            this._cvEstudios.Add(cvEstudio);
        }

        public void AgregarEventoAcademico(CvEventoAcademico cvEventoAcademico)
        {
            this._cvEventoAcademicos.Add(cvEventoAcademico);
        }

        public void AgregarExperienciaLaboral(CvExperienciaLaboral cvExperienciaLaboral)
        {
            this._cvExperienciaLaboral.Add(cvExperienciaLaboral);
        }

        public void AgregarIdioma(CvIdiomas cvIdioma)
        {
            this._cvIdiomas.Add(cvIdioma);
        }

        public void AgregarInstitucionAcademica(CvInstitucionesAcademicas cvInstitucionAcademica)
        {
            this._cvInstitucionesAcademicas.Add(cvInstitucionAcademica);
        }

        public void AgregarMatricula(CvMatricula cvMatricula)
        {
            this._cvMatriculas.Add(cvMatricula);
        }

        public void AgregarPublicacion(CvPublicaciones cvPublicacion)
        {
            this._cvPublicaciones.Add(cvPublicacion);
        }

        public void AgregarDocencia(CvDocencia cvDocencia)
        {
            this._cvDocencias.Add(cvDocencia);
        }

        public void AgregarCompetenciaInformatica(CvCompetenciasInformaticas cvCompetenciaInformatica)
        {
            this._cvCompetenciasInformaticas.Add(cvCompetenciaInformatica);
        }

        public void AgregarCertificadoDeCapacitacion(CvCertificadoDeCapacitacion cvCertificacionDeCapacitacion)
        {
            this._cvCertificadosDeCapacitacion.Add(cvCertificacionDeCapacitacion);
        }
    }
}
