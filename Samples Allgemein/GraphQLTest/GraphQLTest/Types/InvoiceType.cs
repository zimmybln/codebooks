using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQLTest.Types
{
    public class InvoiceType : ObjectGraphType<Invoice>
    {
        public InvoiceType()
        {
            Field(x => x.Id);
            Field(x => x.CustomerId);
            Field(x => x.Date);
            Field(x => x.Price);
        }
    }
}
