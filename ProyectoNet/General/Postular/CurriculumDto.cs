using System;
using System.Collections.Generic;

namespace General
{
    public class CurriculumDto
    {
        public int Id { get; set; }
        public CvDatosPersonales DatosPersonales { get; set; }
        public List<CvEstudios> CvEstudios  { get; set; }
        public List<CvEventoAcademico> CvEventosAcademicos { get; set; }
        public List<CvExperienciaLaboral> CvExperienciaLaboral  { get; set; }
        public List<CvIdiomas> CvIdiomas  { get; set; } //cambiado por Bel
        public List<CvInstitucionesAcademicas> CvInstitucionesAcademicas  { get; set; }
        public List<CvMatricula> CvMatricula { get; set; }
        public List<CvPublicaciones> CvPublicaciones  { get; set; }
        public List<CvDocencia> CvDocencias  { get; set; }
        public List<CvCompetenciasInformaticas> CvCompetenciasInformaticas { get; set; }
        public List<CvCertificadoDeCapacitacion> CvCertificadosDeCapacitacion  { get; set; }



        public CurriculumDto() { }
    
    }
        
    
}
