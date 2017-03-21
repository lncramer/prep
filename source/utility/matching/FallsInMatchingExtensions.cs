using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.utility.matching
{
 
  public static class FallsInMatchingExtensions
  {
    public static Criteria<Item> falls_in<Item,Property>(this IProvideAccessToMatchBuilders<Item,Property> extension_point, Criteria<Property> compare) where Property : IComparable<Property>
    {
      return extension_point.create(compare);
    }

  }
}
