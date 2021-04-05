using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Mapster;
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
    public class Create : BaseAsyncEndpoint
            .WithRequest<CreatePersonCommand>
            .WithResponse<CreatePersonResult>
    {
        private readonly IRepository<Person> _repository;

        public Create(
            IRepository<Person> repository)
        {
            _repository = repository;
        }

        [HttpPost("/person")]
        [SwaggerOperation(
            Summary = "Creates a new Person",
            Description = "Creates a new Person",
            OperationId = "Person.Create",
            Tags = new[] { "PersonEndpoint" })
        ]
        public override async Task<ActionResult<CreatePersonResult>> HandleAsync(
            [FromBody] CreatePersonCommand request,
            CancellationToken cancellationToken = default)
        {
            var author = request.Adapt<Person>();

            await _repository
                .CreateAsync(author, cancellationToken)
                .ConfigureAwait(false);

            var result = author.Adapt<CreatePersonResult>();
            return Ok(result);
        }
    }
}