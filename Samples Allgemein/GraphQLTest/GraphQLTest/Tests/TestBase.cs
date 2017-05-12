using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation;
using GraphQL.Validation.Rules;
using GraphQLTest.Data;
using GraphQLTest.Types;

namespace GraphQLTest.Tests
{
    /// <summary>
    /// This class some methods to execute various types of queries
    /// </summary>
    public abstract class TestBase
    {
        protected static async Task<string> Query(string query, Schema schema, object userContext = null, Inputs inputs = null)
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

        protected static async Task<ExecutionResult> Validate(string query, Schema schema, Inputs inputs = null)
        {
            return await new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Query = query;
                options.Schema = schema;
                options.UserContext = new DataSource();
                options.Inputs = inputs;
                options.ValidationRules = DocumentValidator.CoreRules();
            });
        }
    }
}
