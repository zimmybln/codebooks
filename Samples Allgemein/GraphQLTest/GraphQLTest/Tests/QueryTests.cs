using GraphQLTest.Data;
using GraphQLTest.Types;
using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using NUnit.Framework;

namespace GraphQLTest.Tests
{
    [TestFixture]
    public class QueryTests : TestBase
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
        public void QueryWithFragments()
        {
            var schema = new Schema { Query = new CustomerQuery() };

            string query = @"
                            query {
                                customer {
                                    id
                                    ...fullname
                                } 
                            }

                            fragment fullname on customer {
                                firstName
                                lastName
                            }
                            ";

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
        public void QueryWithAliases()
        {
            var schema = new Schema { Query = new CustomerQuery() };
            var inputs = new Inputs();
            
            string queryWithParameter = @"
                            query {
                                norddeutsche : customer (city : ""Hamburg"") {
                                    id
                                    firstName
                                    lastName
                                    city
                                }

                                süddeutsche : customer (city : ""München"") {
                                    id
                                    firstName
                                    lastName
                                    city
                                }
                            }";

            Task<string> task = Query(queryWithParameter, schema, new DataSource(), inputs);
            task.Wait();

            Console.WriteLine(task.Result);
        }

        [Test]
        public void QueryWithVariables()
        {
            var schema = new Schema {Query = new CustomerQuery()};
            var inputs = new Inputs();
            inputs.Add("firstName", "S");

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

        [Test]
        public void QueryWithDirectives()
        {
            var schema = new Schema { Query = new CustomerQuery() };
            var inputs = new Inputs();
            inputs.Add("withInvoices", "false");

            string queryWithRelation = @"
                        query DirectivesQuery ($withInvoices : Boolean!) {
                            customer {
                                id
                                firstName
                                lastName
                                invoices @skip(if: $withInvoices)
                                {
                                    id
                                    customerId
                                    date
                                    price
                                }
                            }
                        }";

            Task<string> task = Query(queryWithRelation, schema, new DataSource(), inputs);
            task.Wait();

            Console.WriteLine(task.Result);
        }


    }
}
