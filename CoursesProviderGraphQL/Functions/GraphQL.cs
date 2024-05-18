using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CoursesProviderGraphQL.Functions
{
    public class GraphQL
    {
        private readonly ILogger<GraphQL> _logger;
        private readonly IGraphQLRequestExecutor _graphQLRequestExecutor;
        public GraphQL(ILogger<GraphQL> logger, IGraphQLRequestExecutor graphQLRequestExecutor)
        {
            _logger = logger;
            _graphQLRequestExecutor = graphQLRequestExecutor;
        }

        [Function("GraphQL")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post" , Route = "graphql")] HttpRequest req)
        {
            return await _graphQLRequestExecutor.ExecuteAsync(req);
        }
    }
}
