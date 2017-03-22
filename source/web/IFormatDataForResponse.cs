using System.Collections.Generic;
using code.prep.people;

namespace code.web
{
    public delegate string IFormatDataForResponse(IEnumerable<Person> data);
}