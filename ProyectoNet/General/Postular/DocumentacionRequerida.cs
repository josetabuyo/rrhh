using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class DocumentacionRequerida
    {

        public string DescripcionRequisito { get ; set; }
        public List<ItemCv> ItemsCv { get; protected set; }

        public DocumentacionRequerida()
        {
            this.ItemsCv = new List<ItemCv>();
        }

        public ItemCv AddItemCV(string descripcion)
        {
            var item = new ItemCv(descripcion);
            this.ItemsCv.Add(item);
            return item;
        }

    }
}
