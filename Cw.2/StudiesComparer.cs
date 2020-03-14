using Cw._2;
using System;
using System.Collections.Generic;

namespace Cw2
{
    public class StudiesComparer : IEqualityComparer<Studies>
    {

        public bool Equals(Studies x, Studies y)
        {
            return StringComparer.InvariantCultureIgnoreCase
                .Equals($"{x.Wydzial} {x.Tryb}, {y.Wydzial} {y.Tryb}");
        }

        public int GetHashCode(Studies obj)
        {
            return StringComparer
               .CurrentCultureIgnoreCase
               .GetHashCode($"{obj.Wydzial} {obj.Tryb}");
        }
    }
}