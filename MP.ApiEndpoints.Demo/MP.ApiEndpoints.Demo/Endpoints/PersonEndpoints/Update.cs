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
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdatePersonCommand>
        .WithResponse<UpdatePersonResult>
    {
        private readonly IRepository<Person> _repository;

        public Update(
            IRepository<Person> repository)
        {
            _repository = repository;
        }

        [HttpPut("/person")]
        [SwaggerOperation(
            Summary = "Update existing Person",
            Description = "Update existing Person",
            OperationId = "Person.Update",
            Tags = new[] { "Person" })
        ]
        public override async Task<ActionResult<UpdatePersonResult>> HandleAsync(
            [FromBody] UpdatePersonCommand request,
            CancellationToken cancellationToken = default)
        {
            var person = await _repository
                .ReadAsync(request.Id, cancellationToken)
                .ConfigureAwait(false);

            request.Adapt(person);

            await _repository
                .UpdateAsync(person, cancellationToken)
                .ConfigureAwait(false);

            var result = person.Adapt<UpdatePersonResult>();

            return Ok(result);
        }
    }
}