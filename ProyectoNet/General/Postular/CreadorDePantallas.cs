using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace General
{
    public class CreadorDePantallas
    {

        public PatallaRecepcionDocumentacion CrearPantalla(CurriculumVitae curriculumVitae)
        {
            var pantalla = new PatallaRecepcionDocumentacion();
            var lista_docRequerida = new List<DocumentacionRequerida>();
            var documentacion = new DocumentacionRequerida();


            xx(documentacion, curriculumVitae.CvIdiomas, "Idiomas");
            xx(documentacion, curriculumVitae.CvPublicaciones, "Publicaciones");

           

            lista_docRequerida.Add(documentacion);

            pantalla.DocumentacionRequerida = lista_docRequerida;

            return pantalla;
        }

        protected void xx(DocumentacionRequerida documentacion, IList lista, string descripcion_requisito) {

            List<IDescribeRequisito> descriptores_requisitos = new List<IDescribeRequisito>();
            foreach (var item in lista)
            {
                descriptores_requisitos.Add((IDescribeRequisito)item);
            }

            
            if (lista.Count > 0)
            {
                documentacion.DescripcionRequisito = descripcion_requisito;
                foreach (IDescribeRequisito item in lista)
                {
                    documentacion.AddItemCV(item.DescripcionRequisito());
                }
            }
        }

 
    }
}
