using System.Collections.Generic;
using code.utility.matching;

namespace code.utility.filtering
{
    public class FilterExtensionPoint<TObject, TProperty> : IProvideAccessToMatchBuilders<TObject, TProperty>
    {
        private readonly IEnumerable<TObject> _items;
        private readonly IGetTheValueOfAProperty<TObject, TProperty> _propertyAccessor;

        public FilterExtensionPoint(IEnumerable<TObject> items, IGetTheValueOfAProperty<TObject, TProperty> propertyAccessor)
        { 
            _items = items;
            _propertyAccessor = propertyAccessor;
        }


        public Criteria<TObject> create(Criteria<TProperty> value_matcher)
        {
            foreach (var item in _items)
            {
                var property = _propertyAccessor(item); 

                if (value_matcher(property))
                {
                    
                }
            }
        }
    }
}