using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class AliasEquals : IEqualityComparer<Alias>
    {

        public bool Equals(Alias left, Alias right)
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

        public int GetHashCode(Alias area)
        {
            return area.Id.GetHashCode();
        }









    }
}
