using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using GraphQLTest.Data;
using GraphQLTest.Types;
using NUnit.Framework;

namespace GraphQLTest.Tests
{
    [TestFixture]
    public class QueryTests
    {

        [Test]
        public void QueryWithoutParameters()
        {
            var schema = new Schema { Query = new CustomerQuery() };

            string query = @"
                            query {
                                customer {
                                    id
                                    firstName
                                    lastName
                                }                                
                            }";

            Task<string> task = Query(query, schema, new DataSource());
            task.Wait();
            
            Console.WriteLine(task.Result);
        }

        [Test]
        public void QueryWithoutWithMetadata()
        {
            var schema = new Schema { Query = new CustomerQuery() };

            string query = @"
                            query {
                                customer {
                                    __typename
                                    # __Shema
                                    # __TypeKind
                                    # __field
                                    # __directive
                                    id
                                    firstName
                                    lastName
                                }                                
                            }";

            Task<string> task = Query(query, schema, new DataSource());
            task.Wait();

            Console.WriteLine(task.Result);
        }

        [Test]
        public void QueryWithParameters()
        {
            var schema = new Schema { Query = new CustomerQuery() };

            string queryWithParameter = @"
                            query {
                                customer (firstName: ""Sim"") {
                                    id
                                    firstName
                                    lastName
                                }
                            }";

            Task<string> task = Query(queryWithParameter, schema, new DataSource());
            task.Wait();

            Console.WriteLine(task.Result);
        }

        [Test]
        public void QueryWithVariables()
        {
            var schema = new Schema {Query = new CustomerQuery()};
            var inputs = new Inputs();
            inputs.Add("firstName", "Sim");

            string queryWithParameter = @"
                            query CustomerQuery ($firstName : String) {
                                customer (firstName: $firstName) {
                                    id
                                    firstName
                                    lastName
                                }
                            }";

            Task<string> task = Query(queryWithParameter, schema, new DataSource(), inputs);
            task.Wait();

            Console.WriteLine(task.Result);
        }

        [Test]
        public void QueryWithRelation()
        {
            var schema = new Schema { Query = new CustomerQuery() };

            string queryWithRelation = @"
                        query {
                            customer (id: 1) {
                                id
                                firstName
                                lastName
                                invoices
                                {
                                    id
                                    customerId
                                    date
                                    price
                                }
                            }

                        }";

            Task<string> task = Query(queryWithRelation, schema, new DataSource());
            task.Wait();

            Console.WriteLine(task.Result);
        }

        private static async Task<string> Query(string query, Schema schema, object userContext, Inputs inputs = null)
        {
            var result = await new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Schema = schema;
                options.UserContext = userContext;
                options.Inputs = inputs;
                options.Query = query;
            }).ConfigureAwait(false);

            return new DocumentWriter(indent: true).Write(result);
        }
    }
}
