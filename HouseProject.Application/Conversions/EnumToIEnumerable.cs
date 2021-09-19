using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Conversions
{
    public static class EnumToIEnumerable
    {
       public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
