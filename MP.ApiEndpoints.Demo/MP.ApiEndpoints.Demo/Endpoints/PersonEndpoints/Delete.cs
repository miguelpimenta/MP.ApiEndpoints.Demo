using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using MP.ApiEndpoints.Demo.Core.Application.Contracts;
using MP.ApiEndpoints.Demo.Core.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace MP.ApiEndpoints.Demo.Endpoints.PersonEndpoints
{
    [Consumes("Application/json")]
    [Produces("Application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeletePersonRequest>
        .WithoutResponse
    {
        private readonly IRepository<Person> _repository;

        public Delete(IRepository<Person> repository)
        {
            _repository = repository;
        }

        [HttpDelete("/person/{Id}")]
        [SwaggerOperation(
            Summary = "Delete Person",
            Description = "Delete Person",
            OperationId = "Person.Delete",
            Tags = new[] { "Person" })
        ]
        public override async Task<ActionResult> HandleAsync(
            [FromRoute] DeletePersonRequest request,
            CancellationToken cancellationToken = default)
        {
            var person = await _repository
                .ReadAsync(request.Id, cancellationToken)
                .ConfigureAwait(false);

            if (person is null)
            {
                return NotFound(request.Id);
            }

            await _repository
                .DeleteAsync(person, cancellationToken)
                .ConfigureAwait(false);

            // see https://restfulapi.net/http-methods/#delete
            return NoContent();
        }
    }
}