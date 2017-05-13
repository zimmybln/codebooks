using GraphQLTest.Data;
using GraphQLTest.Types;
using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace GraphQLTest.Tests
{
    [TestFixture]
    public class QueryTests : TestBase
    {

        [Test]
        public async Task QueryAll()
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

            var result = await Query(query, schema, new DataSource());
            
            Console.WriteLine(result);
        }

        [Test]
        public async Task QueryWithFragments()
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

            var result = await Query(query, schema, new DataSource());
            
            Console.WriteLine(result);
        }
        
        [Test]
        public async Task QueryWithoutWithMetadata()
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

            var result = await Query(query, schema, new DataSource());
            
            Console.WriteLine(result);
        }

        [Test]
        public async Task QueryWithParameters()
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

            var result = await Query(queryWithParameter, schema, new DataSource());
            
            Console.WriteLine(result);
        }

        [Test]
        public async Task QueryWithAliases()
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

            var result = await Query(queryWithParameter, schema, new DataSource(), inputs);
            
            Console.WriteLine(result);
        }

        [Test]
        public async Task QueryWithVariables()
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

            var result = await Query(queryWithParameter, schema, new DataSource(), inputs);
            
            Console.WriteLine(result);
        }

        [Test]
        public async Task QueryWithRelation()
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

            var result = await Query(queryWithRelation, schema, new DataSource());
            
            Console.WriteLine(result);
        }

        [Test]
        public async Task QueryWithDirectives()
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

            var result = await Query(queryWithRelation, schema, new DataSource(), inputs);
            
            Console.WriteLine(result);

        }

        [Test]
        public async Task QueryWithCustomFactory()
        {
            var datasource = new DataSource();

            // define the unity container
            var container = new UnityContainer();

            container.RegisterInstance(typeof(DataSource), datasource);
            container.RegisterType<CustomerType>();
            container.RegisterType<InvoiceType>();
            
            // callback for resolving types with parameters
            IGraphType OnResolveType(Type type)
            {
                return container.Resolve(type) as IGraphType;
            }
            
            // schema with resolving function
            var schema = new Schema
            {
                Query = new CustomerQueryWithData(datasource),
                ResolveType = OnResolveType
            };

            // query definition
            string queryWithRelation = @"
                        query {
                            customer {
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

            var result = await Query(queryWithRelation, schema);
            
            Console.WriteLine(result);
        }

    }
}
