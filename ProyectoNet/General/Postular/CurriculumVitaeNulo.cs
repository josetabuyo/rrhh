using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CurriculumVitaeNulo : CurriculumVitae
    {

        public override CvDatosPersonales DatosPersonales { get { return new CvDatosPersonales(); }  }
        public override List<CvEstudios> CvEstudios { get { return new List<CvEstudios>(); } }
        public override List<CvEventoAcademico> CvEventosAcademicos { get { return new List<CvEventoAcademico>(); } }
        public override List<CvExperienciaLaboral> CvExperienciaLaboral { get { return new List<CvExperienciaLaboral>(); } }
        public override List<CvIdiomas> CvIdiomas { get { return new List<CvIdiomas>(); } }
        public override List<CvInstitucionesAcademicas> CvInstitucionesAcademicas { get { return new List<CvInstitucionesAcademicas>(); } }
        public override List<CvMatricula> CvMatricula { get { return new List<CvMatricula>(); } }
        public override List<CvPublicaciones> CvPublicaciones { get { return new List<CvPublicaciones>(); } }
        public override List<CvDocencia> CvDocencias { get { return new List<CvDocencia>(); } }
        public override List<CvCompetenciasInformaticas> CvCompetenciasInformaticas { get { return new List<CvCompetenciasInformaticas>(); } }
        public override List<CvCertificadoDeCapacitacion> CvCertificadosDeCapacitacion { get { return new List<CvCertificadoDeCapacitacion>(); } }


        public CurriculumVitaeNulo()
        {
           
        }



       
    }
}
