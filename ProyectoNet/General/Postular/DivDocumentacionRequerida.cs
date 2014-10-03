using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class DivDocumentacionRequerida
    {

        public string DescripcionRequisito { get ; set; }
        public List<ItemCv> ItemsCv { get; protected set; }

        public DivDocumentacionRequerida()
        {
            this.ItemsCv = new List<ItemCv>();
        }

        public void AddItemCv(ItemCv item_cv)
        {
            this.ItemsCv.Add(item_cv);
        }

        public bool TieneItems()
        {
            return this.ItemsCv.Count > 0;
        }
    }
}
