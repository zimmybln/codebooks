using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLTest.Data;

namespace GraphQLTest.Types
{
    public class CustomerMutation : ObjectGraphType
    {
        public CustomerMutation()
        {
            Field<CustomerType>("createCustomer",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> {Name = "firstName", DefaultValue = ""},
                    new QueryArgument<StringGraphType> {Name = "lastName", DefaultValue = ""},
                    new QueryArgument<StringGraphType> {Name = "city", DefaultValue = ""}
                ),
                resolve: context =>
                {
                    var data = context.UserContext as DataSource;
                    var firstName = context.GetArgument<string>("firstName");
                    var lastName = context.GetArgument<string>("lastName");
                    var city = context.GetArgument<string>("city");

                    var customer = new Customer() {
                                    FirstName = firstName,
                                    LastName = lastName,
                                    City = city,
                                    Id = data.Customers.Max(c => c.Id) + 1};

                    data.Customers.Add(customer);

                    return customer;
                });
        }
    }
}
