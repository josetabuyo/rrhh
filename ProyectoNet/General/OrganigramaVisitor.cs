using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public interface OrganigramaVisitor
    {
        void AcceptNodo(Nodo nodo);
        void AcceptNodoRoot(Nodo nodo);
    }
}
