﻿using System;
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
            var lista_docRequerida = new List<DocumentacionRequerida>();

            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvIdiomas, "Idiomas", puesto);
            CargarDocumentacionRequerida(lista_docRequerida ,curriculumVitae.CvPublicaciones, "Publicaciones", puesto);
            CargarDocumentacionRequerida(lista_docRequerida, curriculumVitae.CvEstudios, "Estudios", puesto);

            pantalla.DocumentacionRequerida = lista_docRequerida;

            AgregarACuadroPerfil(curriculumVitae.CvIdiomas, puesto, pantalla, "Idiomas");
            AgregarACuadroPerfil(curriculumVitae.CvEstudios, puesto, pantalla, "Estudios");

            return pantalla;
        }

        protected void AgregarACuadroPerfil(IList items, Puesto puesto, PatallaRecepcionDocumentacion pantalla, string descripcion_requisito)
        {
            List<RequisitoIdioma> requisitos_idiomas = new List<RequisitoIdioma>();
            foreach (IDescribeRequisito item in items)
            {
                requisitos_idiomas.Add(new RequisitoIdioma(item.DescripcionRequisito()));
            }

            var doc_req = new DocumentacionRequerida();
            doc_req.DescripcionRequisito = descripcion_requisito;

            requisitos_idiomas.ForEach((req) =>
            {
                if (puesto.TieneRequisito(req))
                {
                    var ItemCV = new ItemCv(req.Idioma);
                    doc_req.ItemsCv.Add(ItemCV);
                    pantalla.CuadroPerfil.Add(doc_req);
                }
            });
        }

        protected void CargarDocumentacionRequerida(List<DocumentacionRequerida> lista_doc_requerida, IList lista, string descripcion_requisito, Puesto puesto) {
            if (lista.Count > 0)
            {
                var documentacion = new DocumentacionRequerida();
                documentacion.DescripcionRequisito = descripcion_requisito;
                foreach (IDescribeRequisito item in lista)
                {
                    if (!puesto.TieneRequisito(new RequisitoIdioma(item.DescripcionRequisito())))
                    {
                        documentacion.AddItemCV(item.DescripcionRequisito());
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
