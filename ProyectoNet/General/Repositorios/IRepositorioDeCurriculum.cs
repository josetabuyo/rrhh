using System;
using General.MAU;

namespace General.Repositorios
{
    public interface IRepositorioDeCurriculum
    {
        void GuardarCVDatosPersonales(CvDatosPersonales cv, Usuario usuario);
        void ActualizarCV(CurriculumVitae cv);
        General.CurriculumVitae GetCV(int documento);
    }
}
