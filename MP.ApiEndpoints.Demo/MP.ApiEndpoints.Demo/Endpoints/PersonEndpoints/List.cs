using System.Collections.Generic;
using System.Linq;
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
    public class List : BaseAsyncEndpoint
        .WithRequest<PersonListRequest>
        .WithResponse<IList<PersonListResult>>
    {
        private readonly IRepository<Person> repository;

        public List(
            IRepository<Person> repository)
        {
            this.repository = repository;
        }

        [HttpGet("/person")]
        [SwaggerOperation(
            Summary = "List Persons",
            Description = "List Persons",
            OperationId = "Person.List",
            Tags = new[] { "Person" })
        ]
        public override async Task<ActionResult<IList<PersonListResult>>> HandleAsync(

            [FromQuery] PersonListRequest request,
            CancellationToken cancellationToken = default)
        {
            request.PerPage = request.PerPage == 0 ? 10 : request.PerPage;
            request.Page = request.Page == 0 ? 1 : request.Page;

            var result = (await repository
                .ListAllAsync(request.PerPage, request.Page, cancellationToken)
                .ConfigureAwait(false))
                .Select(i => i.Adapt<PersonListResult>());

            return Ok(result);
        }
    }
}