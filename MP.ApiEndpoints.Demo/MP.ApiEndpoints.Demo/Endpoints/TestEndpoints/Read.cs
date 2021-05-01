using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MP.ApiEndpoints.Demo.Endpoints.TestEndpoints
{
    [Route(Routes.Test)]
    public class Read : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<string>
    {
        public Read()
        {
        }

        [HttpGet("/test")]
        [SwaggerOperation(
            Summary = "Get Something...",
            Description = "Get Something...",
            OperationId = "Test.Read",
            Tags = new[] { "Test" })
        ]
        [Consumes("Application/json")]
        [Produces("Application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(NotFoundResult))]
        public override async Task<ActionResult<string>> HandleAsync(
            CancellationToken cancellationToken = default)
        {
            return Ok("This is as test!!!");
        }
    }
}