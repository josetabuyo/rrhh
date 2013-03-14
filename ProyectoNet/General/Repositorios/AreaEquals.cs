using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class AreaEquals : IEqualityComparer<Area>
    {
        public bool Equals(Area left, Area right)
        {
            if ((object)left == null && (object)right == null)
            {
                return true;
            }
            if ((object)left == null || (object)right == null)
            {
                return false;
            }
            return left.Id == right.Id;
        }

        public int GetHashCode(Area area)
        {
            return area.Id.GetHashCode();
        }
    }

}
