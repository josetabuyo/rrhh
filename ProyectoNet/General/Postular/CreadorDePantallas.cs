using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CreadorDePantallas
    {

        public PatallaRecepcionDocumentacion CrearPantalla(CurriculumVitae curriculumVitae)
        {
            var pantalla = new PatallaRecepcionDocumentacion();
            var lista_docRequerida = new List<DocumentacionRequerida>();
            var documentacion = new DocumentacionRequerida();

            CompletarIdiomas(curriculumVitae, documentacion);
            CompletarPublicaciones(curriculumVitae, documentacion);
            

            lista_docRequerida.Add(documentacion);

            pantalla.DocumentacionRequerida = lista_docRequerida;

            return pantalla;
        }

        private void CompletarPublicaciones(CurriculumVitae curriculumVitae, DocumentacionRequerida documentacion)
        {
            if (curriculumVitae.CvPublicaciones.Count > 0)
            {
                List<ItemCv> lista_items = new List<ItemCv>();
                documentacion.DescripcionRequisito = "Publicaciones";
                curriculumVitae.CvPublicaciones.ForEach(publicacion => lista_items.Add(new ItemCv(publicacion.Titulo)));

                documentacion.ItemsCv = lista_items;
            }

        }

        protected void CompletarIdiomas(CurriculumVitae curriculumVitae, DocumentacionRequerida documentacion)
        {

            if (curriculumVitae.CvIdiomas.Count > 0)
            {
                List<ItemCv> lista_items = new List<ItemCv>();

                documentacion.DescripcionRequisito = "Idiomas";
                curriculumVitae.CvIdiomas.ForEach(idioma => lista_items.Add(new ItemCv(idioma.Idioma)));

                documentacion.ItemsCv = lista_items;
            }
            
        }


    }
}
