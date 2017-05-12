using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLTest.Data;
using GraphQLTest.Types;
using NUnit.Framework;

namespace GraphQLTest.Tests
{
    public class MutationTests : TestBase
    {
        [Test]
        public void CreateCustomer()
        {
            var data = new DataSource();

            var schema = new Schema { Query = new CustomerQuery() };

            string query = @"
                            query {
                                customer {
                                    id
                                    firstName
                                    lastName
                                    city
                                } 
                            }";

            string mutation = @"
                            mutation ($firstName : String!,
                                      $lastName : String!,
                                      $city : String!) {
                                createCustomer (firstName : $firstName, 
                                                lastName : $lastName,
                                                city : $city) {
                                    id
                                    firstName
                                    lastName
                                }
                            }";


            // Ausgangsdaten anzeigen
            Task<string> taskBefore = Query(query, schema, data);
            taskBefore.Wait();

            Console.WriteLine(taskBefore.Result);

            var inputs = new Inputs();
            inputs.Add("firstName", "Johanna");
            inputs.Add("lastName", "Reske");
            inputs.Add("city", "Köln");

            Task<string> taskCreate = Query(mutation, new Schema() {Mutation = new CustomerMutation()}, data, inputs);

            taskCreate.Wait();

            // Abschlussdaten anzeigen
            Task<string> taskAfter = Query(query, schema, data);
            taskAfter.Wait();

            Console.WriteLine(taskAfter.Result);

        }
    }
}
