using System;

namespace code.utility.matching
{
  public class LessThan
  {
    public static Criteria<Value> value<Value>(Value value) where Value : IComparable<Value>
    {
      return x => x.CompareTo(value) < 0;
    }
  }

  public static class LessThanMatchingExtensions
  {
    public static Criteria<Item> less_than<Item,Property>(this IProvideAccessToMatchBuilders<Item,Property> extension_point, Property value) where Property : IComparable<Property>
    {
      return extension_point.create(LessThan.value(value));
    }

  }
}