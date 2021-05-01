using System;
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
    [Route(Routes.Person)]
    public class Read : BaseAsyncEndpoint
        .WithRequest<string>
        .WithResponse<PersonResult>
    {
        private readonly IRepository<Person> _repository;

        public Read(
            IRepository<Person> repository)
        {
            _repository = repository;
        }

        [HttpGet("/person/{id}")]
        [SwaggerOperation(
            Summary = "Get Person by Id",
            Description = "Get Person by Id",
            OperationId = "Person.Read",
            Tags = new[] { "Person" })
        ]
        public override async Task<ActionResult<PersonResult>> HandleAsync(
            string id,
            CancellationToken cancellationToken = default)
        {
            var person = await _repository
                .ReadAsync(Guid.Parse(id), cancellationToken)
                .ConfigureAwait(false);

            if (person is null)
            {
                return NoContent();
            }

            var result = person.Adapt<PersonResult>();

            return Ok(result);
        }
    }
}