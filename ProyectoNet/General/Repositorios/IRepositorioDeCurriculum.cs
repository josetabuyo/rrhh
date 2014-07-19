using System;
using General;
using System.Collections.Generic;
using General.MAU;

namespace General.Repositorios
{
    public interface IRepositorioDeCurriculum
    {
        void GuardarCVDatosPersonales(CvDatosPersonales cv, Usuario usuario);
        void ActualizarCV(CurriculumVitae cv);
        CurriculumVitae GetCV(int documento);
        List<CvEstudios> GetCvEstudios(int documento);
        List<CvCertificadoDeCapacitacion> GetCvCertificadoDeCapacitacion(int documento);
        List<CvCompetenciasInformaticas> GetCvCompetenciasInformaticas(int documento);
        CvDatosPersonales GetCvDatosPersonales(int documento);
        List<CvDomicilio> GetCvDomicilio(int documento);
        List<CvEventoAcademico> GetCvEventoAcademico(int documento);
        List<CvExperienciaLaboral> GetCvExperienciaLaboral(int documento);
        List<CvIdiomas> GetCvIdiomas(int documento);
        List<CvInstitucionesAcademicas> GetCvInstitucionesAcademicas(int documento);
        List<CvMatricula> GetCvMatricula(int documento);
        List<CvPublicaciones> GetCvPublicaciones(int documento);
    }
}
