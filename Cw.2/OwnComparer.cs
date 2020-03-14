using System;
using System.Collections.Generic;
using System.Text;

namespace Cw._2
{
     public class OwnComparer : IEqualityComparer<Student>
    {
        
        public bool Equals(Student x, Student y)
        {
            
            return StringComparer.InvariantCultureIgnoreCase
                .Equals($"{x.Imie} {x.Nazwisko} {x.Indeks}",$"{y.Imie} {y.Nazwisko} {y.Indeks}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer.CurrentCultureIgnoreCase.GetHashCode($"{obj.Imie} {obj.Nazwisko} {obj.Indeks}");
        }
    }
}
