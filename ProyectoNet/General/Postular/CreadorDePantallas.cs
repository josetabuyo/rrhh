using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using General.Postular;

namespace General
{
    public class CreadorDePantallas
    {
        public PatallaRecepcionDocumentacion CrearPantalla(CurriculumVitae curriculumVitae, Puesto puesto)
        {
            var pantalla = new PatallaRecepcionDocumentacion();
            var lista_docRequerida = new List<DivDocumentacionRequerida>();

            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvEstudios, "Estudios", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvCertificadosDeCapacitacion, "Actividades de Capacitacion", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvDocencias, "Actividades Docentes", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvEventosAcademicos, "Eventos Academicos", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvPublicaciones, "Publicaciones", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvMatricula, "Matriculas", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvInstitucionesAcademicas, "Instituciones Academicas", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvExperienciaLaboral, "Experiencia Laboral", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvIdiomas, "Idiomas", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvCompetenciasInformaticas, "Compentencias Informáticas", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvCapacidadesPersonales, "Capacidades Personales", puesto);

            
            pantalla.DocumentacionRequerida = lista_docRequerida;

            AgregarACuadroPerfil(curriculumVitae.CvEstudios, puesto, pantalla);
            AgregarACuadroPerfil(curriculumVitae.CvIdiomas, puesto, pantalla);
            AgregarACuadroPerfil(curriculumVitae.CvExperienciaLaboral, puesto, pantalla);

            return pantalla;
        }

        protected void AgregarACuadroPerfil(IList items_del_cv, Puesto puesto, PatallaRecepcionDocumentacion pantalla)
        {
           
            foreach (RequisitoPerfil requisito in puesto.Requisitos())
            {
                var documentacion_requerida = new DivDocumentacionRequerida();
                foreach (ItemCv item_cv in items_del_cv)
                {
                    if (requisito.EsCumlidoPor(item_cv))
                    {
                        documentacion_requerida.DescripcionRequisito = requisito.Descripcion;
                        documentacion_requerida.AddItemCv(item_cv);
                    }
                }

                if (documentacion_requerida.TieneItems())
                {
                    pantalla.CuadroPerfil.Add(documentacion_requerida);
                }
            }
        }

        protected void CargarDocumentacionRequerida(List<DivDocumentacionRequerida> lista_doc_requerida, IList lista, string descripcion_requisito, Puesto puesto)
        {
            if (lista.Count > 0)
            {
                var documentacion = new DivDocumentacionRequerida();
                documentacion.DescripcionRequisito = descripcion_requisito;
                foreach (ItemCv item_cv in lista)
                {
                    if (!puesto.Requisitos().Any(req => req.EsCumlidoPor(item_cv)))
                    {
                        documentacion.AddItemCv(item_cv);
                    }
                }
                if (documentacion.ItemsCv.Count > 0)
                {
                    lista_doc_requerida.Add(documentacion);
                }
            }
        }
    }
}
