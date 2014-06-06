using System;
using General.MAU;

namespace General.Repositorios
{
    public interface IRepositorioDeCurriculum
    {
        void GuardarCVDatosPersonales(CvDatosPersonales cv, Usuario usuario);
        void ActualizarCV(CurriculumVitae cv);
        General.CurriculumVitae GetCV(int documento);
        System.Collections.Generic.List<General.CvEstudios> GetCvEstudios(int documento);
        System.Collections.Generic.List<General.CvCapacidadesPersonales> GetCvCapacidadesPersonales(int documento);
        System.Collections.Generic.List<General.CvCertificadoDeCapacitacion> GetCvCertificadoDeCapacitacion(int documento);
        System.Collections.Generic.List<General.CvCompetenciasInformaticas> GetCvCompetenciasInformaticas(int documento);
        System.Collections.Generic.List<General.CvDatosPersonales> GetCvDatosPersonales(int documento);
        System.Collections.Generic.List<General.CvDocencia> GetCvDocencia(int documento);
        System.Collections.Generic.List<General.CvDomicilio> GetCvDomicilio(int documento);
        System.Collections.Generic.List<General.CvEventoAcademico> GetCvEventoAcademico(int documento);
        System.Collections.Generic.List<General.CvExperienciaLaboral> GetCvExperienciaLaboral(int documento);
        System.Collections.Generic.List<General.CvIdiomas> GetCvIdiomas(int documento);
        System.Collections.Generic.List<General.CvInstitucionesAcademicas> GetCvInstitucionesAcademicas(int documento);
        System.Collections.Generic.List<General.CvMatricula> GetCvMatricula(int documento);
        System.Collections.Generic.List<General.CvPublicaciones> GetCvPublicaciones(int documento);
                    
            
            
            
            
            
            
            
    }
}
