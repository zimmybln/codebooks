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
using GraphQLTest.Types;

namespace GraphQLTest.Tests
{
    public abstract class TestBase
    {
        protected static async Task<string> Query(string query, Schema schema, object userContext, Inputs inputs = null)
        {
            var lstItems = new List<object>();

            var result = await new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Schema = schema;
                options.UserContext = userContext;
                options.Inputs = inputs;
                options.Query = query;
            }).ConfigureAwait(false);

            // var items = result.Data as Dictionary<string, object>;

            return new DocumentWriter(indent: true).Write(result);
        }

        protected static async Task<ExecutionResult> Validate(string query, Schema schema, Inputs inputs)
        {
            return await new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Schema = schema;
                options.Inputs = inputs;
                options.ValidationRules = DocumentValidator.CoreRules();
            });
        }
    }
}
