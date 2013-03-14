using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebRhUI
{
    public abstract class EntityToRowConverter<T>
    {
        public abstract List<object> Serialize(T entidad);
    }
}
