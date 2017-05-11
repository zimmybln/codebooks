using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLTest.Data;

namespace GraphQLTest.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Name = "customer";

            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.City);

            Field<ListGraphType<InvoiceType>>("invoices", resolve: context =>
            {
                DataSource data = context.UserContext as DataSource;

                return data?.Invoices.Where(i => i.CustomerId == context.Source.Id);
            });
        }
    }
}
